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
		readonly ImageBox _val;
		int _w, _h;
		public ImagePropertiesForm(ImageBox shape) {
			InitializeComponent();
			_val = shape;
			pictureBox1.BackgroundImage = _val.ShownImage;
			_w = _val.Width;
			_h = _val.Height;
			UpdateSize();
		}
		private void TrackBar1Scroll(object sender, EventArgs e) {
			UpdateSize();
		}

		private void UpdateSize() {
			pictureBox1.Width = _w * trackBar1.Value / 10;
			pictureBox1.Height = _h * trackBar2.Value / 10;
		}
		private void Button2Click(object sender, EventArgs e) {
			Close();
		}
		private void Button1Click(object sender, EventArgs e) {
			if(!_loaded)
				_val.ShownImage = pictureBox1.BackgroundImage;
			else
				_val.FileName = openFileDialog1.FileName;
			_val.Width = pictureBox1.Width;
			_val.Height = pictureBox1.Height;
			Close();
		}
		bool _loaded;
		private void Button3Click(object sender, EventArgs e) {
			if(openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			Image temp = Image.FromFile(openFileDialog1.FileName);
			pictureBox1.BackgroundImage = temp;
			_w = 100;
			_h = temp.Height * _w / temp.Width;
			UpdateSize();
			_loaded = true;
		}
	}
}
