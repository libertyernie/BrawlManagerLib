namespace BrawlManagerLib {
	partial class SongPanel {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.grid = new System.Windows.Forms.PropertyGrid();
			this.app = new System.Windows.Forms.AudioPlaybackPanel();
			this.songNameBar = new SongNameBar();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.HelpVisible = false;
			this.grid.Location = new System.Drawing.Point(0, 20);
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(300, 169);
			this.grid.TabIndex = 0;
			// 
			// app
			// 
			this.app.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.app.Location = new System.Drawing.Point(0, 189);
			this.app.Name = "app";
			this.app.Size = new System.Drawing.Size(300, 111);
			this.app.TabIndex = 1;
			this.app.TargetStreams = null;
			// 
			// songNameBar
			// 
			this.songNameBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.songNameBar.Index = 0;
			this.songNameBar.Location = new System.Drawing.Point(0, 0);
			this.songNameBar.Name = "songNameBar";
			this.songNameBar.Size = new System.Drawing.Size(300, 20);
			this.songNameBar.TabIndex = 2;
			// 
			// SongPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grid);
			this.Controls.Add(this.songNameBar);
			this.Controls.Add(this.app);
			this.Name = "SongPanel";
			this.Size = new System.Drawing.Size(300, 300);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid grid;
		private System.Windows.Forms.AudioPlaybackPanel app;
		private SongNameBar songNameBar;
	}
}
