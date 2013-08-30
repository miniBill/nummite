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
using System.Drawing;
using System.Windows.Forms;

namespace DiagramDrawer.Shapes {
	public partial class ImagePropertiesForm : Form {
		readonly ImageBox val;
		int w, h;
		public ImagePropertiesForm(ImageBox shape) {
			InitializeComponent();
			val = shape;
			pictureBox1.BackgroundImage = val.ShownImage;
			w = val.Width;
			h = val.Height;
			UpdateSize();
		}
		void TrackBar1Scroll(object sender, EventArgs e) {
			UpdateSize();
		}

		void UpdateSize() {
			pictureBox1.Width = w * trackBar1.Value / 10;
			pictureBox1.Height = h * trackBar2.Value / 10;
		}
		void Button2Click(object sender, EventArgs e) {
			Close();
		}
		void Button1Click(object sender, EventArgs e) {
			if(!loaded)
				val.ShownImage = pictureBox1.BackgroundImage;
			else
				val.FileName = openFileDialog1.FileName;
			val.Width = pictureBox1.Width;
			val.Height = pictureBox1.Height;
			Close();
		}
		bool loaded;
		void Button3Click(object sender, EventArgs e) {
			if(openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			var temp = Image.FromFile(openFileDialog1.FileName);
			pictureBox1.BackgroundImage = temp;
			w = 100;
			h = temp.Height * w / temp.Width;
			UpdateSize();
			loaded = true;
		}
	}
}
