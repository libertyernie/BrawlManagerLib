﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlManagerLib;

namespace BrawlManagerLib {
	public partial class SongNameBar : UserControl {
		private int _index;

		private ResourceNode info_pac, info_training_pac;
		private MSBinNode info, info_training;
		private string _currentFile, _currentTrainingFile;

		private bool updateTextColor;
		private string TextBoxText {
			set {
				updateTextColor = false;
				textBox1.Text = value;
				updateTextColor = true;
			}
		}

		/// <summary>
		/// A set of numbers that keeps track of which song titles have been changed by the user, but not yet saved to the file.
		/// This does not include song titles which are different in info and info_training; these will remain different unless the user clicks Restore or otherwise changes them.
		/// </summary>
		private HashSet<int> modifiedStringIndices;
		private List<string> fileStrings;

		public int Index {
			get {
				return _index;
			}
			set {
				_index = value;
				if (_index < 0 || info == null) {
					textBox1.Enabled = button1.Enabled = button2.Enabled = false;
					textBox1.BackColor = SystemColors.Control;
					TextBoxText = "";
				} else {
					refreshColor();
					TextBoxText = info._strings[_index];
					if (info_training != null && info_training._strings[_index] != textBox1.Text) {
						textBox1.BackColor = Color.LightPink;
					}
					textBox1.Enabled = button1.Enabled = button2.Enabled = true;
				}
			}
		}

		public bool IsDirty {
			get {
				return modifiedStringIndices.Count > 0;
			}
		}

		public SongNameBar() {
			InitializeComponent();
			modifiedStringIndices = new HashSet<int>();

			fileStrings = new List<string>(265);

			updateTextColor = true;
		}

		/// <summary>
		/// This function finds the new info.pac. It should be called whenever you change the working directory.
		/// It also clears the list of edited ("dirty") strings, and records the current names (for the "restore" button).
		/// </summary>
		public String findInfoFile() {
			_index = -1;

			info = info_training = null;
			_currentFile = _currentTrainingFile = null;

			string tempfile = Path.GetTempFileName();
			if (new FileInfo("MiscData[140].msbin").Exists) {
				_currentFile = "MiscData[140].msbin";
				File.Copy("MiscData[140].msbin", tempfile, true);
				info = NodeFactory.FromFile(null, tempfile) as MSBinNode;
				return "Loaded .\\MiscData[140].msbin";
			} else if (new FileInfo("\\MiscData[140].msbin").Exists) {
				_currentFile = "\\MiscData[140].msbin";
				File.Copy("\\MiscData[140].msbin", tempfile, true);
				info = NodeFactory.FromFile(null, tempfile) as MSBinNode;
				return "Loaded \\MiscData[140].msbin";
			} else {
				string[] infopaths = { "..\\..\\info2\\info.pac", "..\\..\\info2\\info_en.pac", "..\\info.pac" };

				foreach (string relativepath in infopaths) {
					if (info == null) {
						string s = Path.GetFullPath(relativepath);
						if (new FileInfo(s).Exists) {
							_currentFile = s;
							File.Copy(s, tempfile, true);
							info_pac = NodeFactory.FromFile(null, tempfile);
							info = (MSBinNode)info_pac.FindChild("MiscData[140]", true);
						}
					}
				}

				if (info == null) {
					return "No song list loaded";
				} else {
					modifiedStringIndices.Clear();
					copyIntoFileStrings();

					// info found; try info_training in same directory
					string trainingpath = _currentFile.Replace("info.pac", "info_training.pac").Replace("info_en.pac", "info_training_en.pac");
					if (trainingpath != _currentFile && new FileInfo(trainingpath).Exists) {
						_currentTrainingFile = trainingpath;
						string tempfile_training = Path.GetTempFileName();
						File.Copy(trainingpath, tempfile_training, true);
						info_training_pac = NodeFactory.FromFile(null, tempfile_training);
						info_training = (MSBinNode)info_training_pac.FindChild("MiscData[140]", true);
						return "Loaded info.pac and info_training.pac";
					} else {
						return "Loaded info.pac";
					}
				}
			}
		}

		/// <summary>
		/// Updates strings in the info.pac in memory. If an info_training file was found earlier, it will edit that too.
		/// This function will not edit the actual files - use save() for that.
		/// </summary>
		private void updateNodeString() {
			if (_index >= 0) {
				info._strings[_index] = textBox1.Text;
				info.SignalPropertyChange();
				if (info_training != null) {
					info_training._strings[_index] = textBox1.Text;
					info_training.SignalPropertyChange();
				}
				textBox1.BackColor = SystemColors.Window;
			}
		}

		private void copyIntoFileStrings() {
			fileStrings.Clear();
			info._strings.ForEach(i => fileStrings.Add(i));
		}

		private void refreshColor() {
			if (modifiedStringIndices.Contains(_index)) {
				textBox1.BackColor = Color.Wheat;
			} else {
				textBox1.BackColor = SystemColors.Window;
			}
		}

		/// <summary>
		/// Saves the info.pac file. If an info_training file was found earlier, it will save that too.
		/// </summary>
		public void save() {
			if (IsDirty) {
				updateNodeString();
				info.Rebuild();
				(info_pac ?? info).Merge();
				(info_pac ?? info).Export(_currentFile);
				if (info_training != null) {
					info_training.Rebuild();
					info_training_pac.Merge();
					info_training_pac.Export(_currentTrainingFile);
				}
				modifiedStringIndices.Clear();
				copyIntoFileStrings();
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			if (updateTextColor) {
				updateNodeString();
				modifiedStringIndices.Add(_index);
				refreshColor();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Enter) {
				DialogResult res = MessageBox.Show("Overwrite info.pac" + (info_training == null ? "" : " and info_training.pac") + "?", "Saving", MessageBoxButtons.YesNo);
				if (res == DialogResult.Yes) save();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			TextBoxText = fileStrings[_index];
			updateNodeString();
			modifiedStringIndices.Add(_index);
			refreshColor();
		}

		private void button2_Click(object sender, EventArgs e) {
			TextBoxText = (from s in SongIDMap.Songs
						   where s.InfoPacIndex == _index
						   select s.DefaultName).First();
			updateNodeString();
			modifiedStringIndices.Add(_index);
			refreshColor();
		}

		public void ExportMSBin(string path) {
			updateNodeString();
			info.Rebuild();
			info.Export(path);
		}

		private class MyTextBox : TextBox {
			protected override void OnKeyPress(KeyPressEventArgs e) {
				if (e.KeyChar == (char)Keys.Enter) {
					e.Handled = true;
				}
				base.OnKeyPress(e);
			}
		}
	}
}
