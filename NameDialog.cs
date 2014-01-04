﻿using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlManagerLib
{
    public class NameDialog : Form
    {
		public string EntryText {
			get {
				return txtName.Text;
			}
			set {
				txtName.Text = value;
			}
		}
		public string LabelText {
			get {
				return label1.Text;
			}
			set {
				label1.Text = value;
			}
		}

        public NameDialog() { InitializeComponent(); }

        public DialogResult ShowDialog(IWin32Window owner, string text)
        {
			Text = text;
			return ShowDialog(owner);
		}
        private void btnOkay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Close();
		}


        #region Designer

        private TextBox txtName;
        private Button btnCancel;
		private Label label1;
        private Button btnOkay;

        private void InitializeComponent()
        {
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOkay = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.HideSelection = false;
			this.txtName.Location = new System.Drawing.Point(12, 25);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(260, 20);
			this.txtName.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(197, 51);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOkay
			// 
			this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkay.Location = new System.Drawing.Point(116, 51);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size(75, 23);
			this.btnOkay.TabIndex = 1;
			this.btnOkay.Text = "&Okay";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "    ";
			// 
			// NameDialog
			// 
			this.AcceptButton = this.btnOkay;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 86);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOkay);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "NameDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enter Name";
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


    }
}
