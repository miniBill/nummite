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
using System.Windows.Forms;

namespace DiagramDrawer.Forms {
	public partial class StringInput : Form {
		public static string LastResult {
			get;
			private set;
		}

		public static DialogResult Show(string text, string caption, string defaultText) {
			var si = new StringInput {
				textBox1 = {
					Text = LastResult = defaultText
				},
				Text = caption,
				label1 = {
					Text = text
				}
			};
			si.ShowDialog();
			return si.DialogResult;
		}
		StringInput() {
			InitializeComponent();
		}
		bool isok;
		void Button2Click(object sender, EventArgs e) {
			Close();
		}
		void Button1Click(object sender, EventArgs e) {
			isok = true;
			Close();
		}
		void StringInput_FormClosed(object sender, FormClosedEventArgs e) {
			LastResult = textBox1.Text;
			DialogResult = isok ? DialogResult.OK : DialogResult.Cancel;
		}

		void TextBox1KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode != Keys.Enter && e.KeyCode != Keys.Escape)
				return;
			e.Handled = true;
			if(e.KeyCode == Keys.Enter)
				Button1Click(sender, e);
			else
				Button2Click(sender, e);
		}
	}
}
