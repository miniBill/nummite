/* Copyright (C) 2008 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
 *
 * This file is part of Diagram Drawer.
 *
 * Diagram Drawer is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Diagram Drawer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Diagram Drawer.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DiagramDrawer.Forms {
	sealed class AboutBox : Form {
		public AboutBox() {
			InitializeComponent();
			Text = String.Format(CultureInfo.CurrentCulture,"Informazioni su {0}", AssemblyTitle);
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = String.Format(CultureInfo.CurrentCulture, "Versione {0}", AssemblyVersion);
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
		}

		#region Assembly Attribute Accessors

		public static string AssemblyTitle {
			get {
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if(attributes.Length > 0) {
					var titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if(titleAttribute.Title.Length > 0)
						return titleAttribute.Title;
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static string AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		static string GetAttribute<T> (Func<T, string> extractor)
		{
			var attributes = Assembly.GetExecutingAssembly ().GetCustomAttributes (typeof(T), false);
			return attributes.Length == 0 ? String.Empty : extractor ((T)attributes [0]);
		}

		public static string AssemblyDescription {
			get {
				return GetAttribute<AssemblyDescriptionAttribute> (attr => attr.Description);
			}
		}

		public static string AssemblyProduct {
			get {
				return GetAttribute<AssemblyProductAttribute> (attr => attr.Product);
			}
		}

		public static string AssemblyCopyright {
			get {
				return GetAttribute<AssemblyCopyrightAttribute> (attr => attr.Copyright);
			}
		}

		public static string AssemblyCompany {
			get {
				return GetAttribute<AssemblyCompanyAttribute> (attr => attr.Company);
			}
		}
		#endregion

		void OkButtonClick(object sender, EventArgs e) {
			Close();
		}

		///<summary>
		///Required designer variable.
		///</summary>
		readonly IContainer components;

		///<summary>
		///Clean up any resources being used.
		///</summary>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null))
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		///<summary>
		///Required method for Designer support - do not modify
		///the contents of this method with the code editor.
		///</summary>
		void InitializeComponent() {
			var resources = new ComponentResourceManager(typeof(AboutBox));
			tableLayoutPanel = new TableLayoutPanel();
			logoPictureBox = new PictureBox();
			labelProductName = new Label();
			labelVersion = new Label();
			labelCopyright = new Label();
			labelCompanyName = new Label();
			textBoxDescription = new TextBox();
			okButton = new Button();
			tableLayoutPanel.SuspendLayout();
			((ISupportInitialize)(logoPictureBox)).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			tableLayoutPanel.ColumnCount = 2;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
			tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
			tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
			tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
			tableLayoutPanel.Controls.Add(labelCopyright, 1, 2);
			tableLayoutPanel.Controls.Add(labelCompanyName, 1, 3);
			tableLayoutPanel.Controls.Add(textBoxDescription, 1, 4);
			tableLayoutPanel.Controls.Add(okButton, 1, 5);
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 6;
			tableLayoutPanel.RowStyles.Add(new RowStyle());
			tableLayoutPanel.RowStyles.Add(new RowStyle());
			tableLayoutPanel.RowStyles.Add(new RowStyle());
			tableLayoutPanel.RowStyles.Add(new RowStyle());
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel.RowStyles.Add(new RowStyle());
			tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
			tableLayoutPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			logoPictureBox.Dock = DockStyle.Fill;
			logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			logoPictureBox.Location = new System.Drawing.Point(3, 3);
			logoPictureBox.Name = "logoPictureBox";
			tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
			logoPictureBox.Size = new System.Drawing.Size(131, 259);
			logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			logoPictureBox.TabIndex = 12;
			logoPictureBox.TabStop = false;
			// 
			// labelProductName
			// 
			labelProductName.Dock = DockStyle.Fill;
			labelProductName.Location = new System.Drawing.Point(143, 0);
			labelProductName.Margin = new Padding(6, 0, 3, 0);
			labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
			labelProductName.Name = "labelProductName";
			labelProductName.Size = new System.Drawing.Size(271, 17);
			labelProductName.TabIndex = 19;
			labelProductName.Text = "Product Name";
			labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelVersion
			// 
			labelVersion.Dock = DockStyle.Fill;
			labelVersion.Location = new System.Drawing.Point(143, 17);
			labelVersion.Margin = new Padding(6, 0, 3, 0);
			labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
			labelVersion.Name = "labelVersion";
			labelVersion.Size = new System.Drawing.Size(271, 17);
			labelVersion.TabIndex = 0;
			labelVersion.Text = "Version";
			labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCopyright
			// 
			labelCopyright.Dock = DockStyle.Fill;
			labelCopyright.Location = new System.Drawing.Point(143, 34);
			labelCopyright.Margin = new Padding(6, 0, 3, 0);
			labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
			labelCopyright.Name = "labelCopyright";
			labelCopyright.Size = new System.Drawing.Size(271, 17);
			labelCopyright.TabIndex = 21;
			labelCopyright.Text = "Copyright";
			labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompanyName
			// 
			labelCompanyName.Dock = DockStyle.Fill;
			labelCompanyName.Location = new System.Drawing.Point(143, 51);
			labelCompanyName.Margin = new Padding(6, 0, 3, 0);
			labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
			labelCompanyName.Name = "labelCompanyName";
			labelCompanyName.Size = new System.Drawing.Size(271, 17);
			labelCompanyName.TabIndex = 22;
			labelCompanyName.Text = "Company Name";
			labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			textBoxDescription.Dock = DockStyle.Fill;
			textBoxDescription.Location = new System.Drawing.Point(143, 71);
			textBoxDescription.Margin = new Padding(6, 3, 3, 3);
			textBoxDescription.Multiline = true;
			textBoxDescription.Name = "textBoxDescription";
			textBoxDescription.ReadOnly = true;
			textBoxDescription.ScrollBars = ScrollBars.Both;
			textBoxDescription.Size = new System.Drawing.Size(271, 162);
			textBoxDescription.TabIndex = 23;
			textBoxDescription.TabStop = false;
			textBoxDescription.Text = "Description";
			// 
			// okButton
			// 
			okButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			okButton.DialogResult = DialogResult.Cancel;
			okButton.Location = new System.Drawing.Point(339, 239);
			okButton.Name = "okButton";
			okButton.Size = new System.Drawing.Size(75, 23);
			okButton.TabIndex = 24;
			okButton.Text = "&OK";
			okButton.Click += new EventHandler(OkButtonClick);
			// 
			// AboutBox
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(435, 283);
			Controls.Add(tableLayoutPanel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutBox";
			Padding = new Padding(9);
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "AboutBox";
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			((ISupportInitialize)(logoPictureBox)).EndInit();
			ResumeLayout (false);

		}

		#endregion

		TableLayoutPanel tableLayoutPanel;
		PictureBox logoPictureBox;
		Label labelProductName;
		Label labelVersion;
		Label labelCopyright;
		Label labelCompanyName;
		TextBox textBoxDescription;
		Button okButton;
	}
}
