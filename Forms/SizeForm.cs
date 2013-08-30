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
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
namespace DiagramDrawer.Forms {
	public interface ISizeable {
		int Height {
			get;
			set;
		}
		int Width {
			get;
			set;
		}
		void Refresh();
	}
	public interface IAutoSizeable : ISizeable {
		bool AutoResizeWidth {
			get;
			set;
		}
		bool AutoResizeHeight {
			get;
			set;
		}
	}
	public partial class SizeForm : Form {
		readonly ISizeable s;
		readonly IAutoSizeable asi;
		public SizeForm(ISizeable shape) {
			InitializeComponent();
			s = shape;
			asi = shape as IAutoSizeable;
			if(asi != null) {
				checkBox1.Checked = asi.AutoResizeHeight;
				checkBox2.Checked = asi.AutoResizeWidth;
			}
			else {
				checkBox1.Visible = false;
				checkBox2.Visible = false;
			}
			textBox1.Text = shape.Height.ToString(CultureInfo.CurrentCulture);
			textBox2.Text = shape.Width.ToString(CultureInfo.CurrentCulture);
		}
		void Button1Click(object sender, EventArgs e) {
			Ok();
		}
		private void Ok() {
			if(asi != null) {
				asi.AutoResizeHeight = checkBox1.Checked;
				asi.AutoResizeWidth = checkBox2.Checked;
			}
			if(asi == null || (!asi.AutoResizeWidth && !asi.AutoResizeHeight)) {
				s.Height = int.Parse(textBox1.Text, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.CurrentCulture);
				s.Width = int.Parse(textBox2.Text, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.CurrentCulture);
				if(s.Height < Options.MinimumHeight)
					s.Height = Options.MinimumHeight;
				if(s.Width < Options.MinimumWidth)
					s.Width = Options.MinimumWidth;
			}
			s.Refresh();
			Close();
		}
		private void TextBoxKeyUp(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter)
				Ok();
			if(e.KeyCode == Keys.Escape)
				Close();
		}
		private void TextBoxValidating(object sender, CancelEventArgs e) {
			var senderBox = sender as TextBox;
			int o;
			if(senderBox == null)
				return;
			if(!int.TryParse(senderBox.Text, NumberStyles.AllowThousands | NumberStyles.Integer, CultureInfo.CurrentCulture, out o)) {
				e.Cancel = true;
				senderBox.BackColor = Color.Red;
			}
			else
				senderBox.BackColor = SystemColors.Window;
		}
		private void Button2Click(object sender, EventArgs e) {
			Close();
		}
		private void CheckBox1CheckedChanged(object sender, EventArgs e) {
			checkBox1.Focus();
			textBox1.Enabled = !checkBox1.Checked;
			textBox2.Enabled = !checkBox2.Checked;
		}
	}
}
