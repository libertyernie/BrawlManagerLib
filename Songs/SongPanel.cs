﻿using System;
using System.Linq;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlManagerLib;
using System.Audio;
using System.ComponentModel;

namespace BrawlManagerLib {
	public partial class SongPanel : UserControl {
		/// <summary>
		/// The currently opened .brstm file's root node.
		/// </summary>
		private ResourceNode _rootNode;
		/// <summary>
		/// The full path to the currently opened .brstm file.
		/// </summary>
		private string _rootPath;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		public bool LoadNames { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		public bool LoadBrstms { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		public bool ShowPropertyGrid {
			get {
				return grid.Visible;
			}
			set {
				grid.Visible = value;
			}
		}

		public string RootPath {
			get {
				return _rootPath;
			}
		}
		public bool FileOpen {
			get {
				return _rootPath != null;
			}
		}

		public SongPanel() {
			InitializeComponent();

			LoadNames = true;
			LoadBrstms = true;

			AllowDrop = true;
			this.DragEnter += SongPanel_DragEnter;
			this.DragDrop += SongPanel_DragDrop;
		}

		public void Close() {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
			}
			_rootPath = null;

			grid.SelectedObject = null;
			app.TargetSource = null;
			app.Enabled = grid.Enabled = false;
			songNameBar.Index = -1;
		}
		public void Open(FileInfo fi) {
			if (!fi.Exists) {
				Close();
				return;
			}

			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
			}
			_rootPath = fi.FullName;
			_rootNode = NodeFactory.FromFile(null, _rootPath);
			if (LoadNames) {
				string filename = Path.GetFileNameWithoutExtension(_rootPath).ToUpper();
				int index = (from s in SongIDMap.Songs
							 where s.Filename == filename
							 select s.InfoPacIndex ?? -1)
							 .DefaultIfEmpty(-1).First();
				songNameBar.Index = index;
			} else {
				songNameBar.Index = -1;
			}
			if (LoadBrstms && _rootNode is IAudioSource) {
				grid.SelectedObject = _rootNode;
				app.TargetSource = _rootNode as IAudioSource;
				app.Enabled = grid.Enabled = true;
			} else {
				grid.SelectedObject = null;
				app.TargetSource = null;
				app.Enabled = grid.Enabled = false;
			}
		}

		public void Export() {
			using (var dialog = new SaveFileDialog()) {
				dialog.Filter = "BRSTM stream|*.brstm";
				dialog.DefaultExt = "brstm";
				dialog.AddExtension = true;
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (dialog.ShowDialog(this) == DialogResult.OK) {
					File.Copy(RootPath, dialog.FileName, true);
				}
			}
		}
		public void Rename() {
			using (NameDialog nd = new NameDialog()) {
				nd.EntryText = Path.GetFileName(RootPath);
				if (nd.ShowDialog(this) == DialogResult.OK) {
					if (!nd.EntryText.ToLower().EndsWith(".brstm")) {
						nd.EntryText += ".brstm"; // Force .brstm extension so it shows up in the list
					}
					string from = RootPath;
					Close();
					FileOperations.Rename(from, System.Environment.CurrentDirectory + "\\" + nd.EntryText);
				}
			}
		}
		public void Delete() {
			if (_rootNode != null) {
				_rootNode.Dispose();
				_rootNode = null;
				FileOperations.Delete(_rootPath);
				Close();
			}
		}

		public string findInfoFile() {
			return songNameBar.findInfoFile();
		}
		public bool IsInfoBarDirty() {
			return songNameBar.IsDirty;
		}
		public void save() {
			songNameBar.save();
		}

		public void ExportMSBin(string path) {
			songNameBar.ExportMSBin(path);
		}

		private void SongPanel_DragEnter(object sender, DragEventArgs e) {
			if (FileOpen && e.Data.GetDataPresent(DataFormats.FileDrop)) { // Must be a file
				string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (s.Length == 1) { // Can only drag and drop one file
					string filename = s[0].ToLower();
					if (filename.EndsWith(".brstm") || filename.EndsWith(".wav")) {
						e.Effect = DragDropEffects.Copy;
					}
				}
			}
		}

		private void SongPanel_DragDrop(object sender, DragEventArgs e) {
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
			string filepath = s[0].ToLower();
			if (FileOpen) {
				if (_rootNode != null) {
					_rootNode.Dispose(); // Close the file before overwriting it!
					_rootNode = null;
				}
				copyBrstm(filepath, _rootPath);
				Open(new FileInfo(_rootPath));
				//refreshDirectory();
			}
		}

		/// <summary>
		/// This method can handle WAV files, converting them to BRSTM using BrawlLib's converter.
		/// </summary>
		/// <param name="src">a BRSTM or WAV file</param>
		/// <param name="dest">the output BRSTM path</param>
		public static void copyBrstm(string src, string dest) {
			if (src.EndsWith(".brstm")) {
				FileOperations.Copy(src, dest); // Use FileOperations (calls Windows shell -> asks for confirmation to overwrite)
			} else {
				BrstmConverterDialog bcd = new BrstmConverterDialog();
				bcd.AudioSource = src;
				if (bcd.ShowDialog() == DialogResult.OK) {
					// Make a temporary node to put the data in, and export it.
					// This avoids the need to use pointers directly.
					RSTMNode tmpNode = new RSTMNode();
					tmpNode.ReplaceRaw(bcd.AudioData);
					tmpNode.Export(dest);
					tmpNode.Dispose();
				}
				bcd.Dispose();
			}
		}
	}
}