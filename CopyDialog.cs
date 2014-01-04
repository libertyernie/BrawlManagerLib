﻿using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BrawlManagerLib {
	public partial class CopyDialog : Form {
		public CopyDialog(string pacNew, string pacExisting) {
			InitializeComponent();

			var dialog = this;
			dialog.lblPacNewName.Text = Path.GetFileName(pacNew);
			dialog.lblPacNewMD5.Text = ByteUtilities.MD5Sum(pacNew);
			dialog.lblPacExistingName.Text = Path.GetFileName(pacExisting);
			dialog.lblPacExistingMD5.Text = ByteUtilities.MD5Sum(pacExisting);

			if (dialog.lblPacNewMD5.Text == dialog.lblPacExistingMD5.Text) {
				dialog.lblPacExistingMD5.ForeColor = dialog.lblPacNewMD5.ForeColor = Color.Green;
			}
		}
	}
}
