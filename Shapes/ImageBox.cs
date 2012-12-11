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
using System.Xml;
using System.IO;
using DiagramDrawer.Properties;
using System.Windows.Forms;

namespace DiagramDrawer.Shapes {
	public class ImageBox : Box {
		string _filename = String.Empty;
		public string FileName {
			set {
				_filename = value;
				if(value.Length == 0) {
					if(_image != null)
						_image.Dispose();
					_image = new Bitmap(100, 50);
					Width = 100;
					Height = 50;
					using(Graphics g = Graphics.FromImage(_image)) {
						g.DrawLine(Pens.Red, 0, 0, Width, Height);
						g.DrawLine(Pens.Red, 0, Height, Width, 0);
						g.DrawLines(Pens.Black, new[] {
						new Point(0, 0),
						new Point(Width - 1, 0),
						new Point(Width - 1, Height - 1),
						new Point(0, Height - 1),
						new Point(0, 0)
					});
					}
				}
				else
					try {
						Image temp = Image.FromFile(_filename);
						ShownImage = temp;
					}
					catch(FileNotFoundException) {
						FileName = String.Empty;
					}
			}
		}
		Image _image = new Bitmap(100, 50);
		public Image ShownImage {
			get {
				return _image;
			}
			set {
				_image = value;
				//iw/ih=w/h
				//h=ih*w/iw
				Width = 100;
				Height = value.Height * Width / value.Width;
				if(ShapeContainer != null)
					ShapeContainer.ForceRefresh();
			}
		}
		public ImageBox() {
			using(Graphics g = Graphics.FromImage(_image)) {
				g.DrawLine(Pens.Red, 0, 0, Width, Height);
				g.DrawLine(Pens.Red, 0, Height, Width, 0);
				g.DrawLines(Pens.Black, new[] {
				new Point(0, 0),
				new Point(Width - 1, 0),
				new Point(Width - 1, Height - 1),
				new Point(0, Height - 1),
				new Point(0, 0)
			});
			}
			ContextMenu.MenuItems.Add("Proprietà", PropertiesClick);
		}
		void PropertiesClick(object sender, EventArgs e) {
			new ImagePropertiesForm(this).ShowDialog();
			ShapeContainer.ForceRefresh();
		}
		public override void DrawTo(Graphics graphics) {
			Rectangle bounds = new Rectangle(Location.X, Location.Y, Width, Height);
			Rectangle src = new Rectangle(0, 0, _image.Width, _image.Height);
			graphics.DrawImage(_image, bounds, src, GraphicsUnit.Pixel);
		}
		public override string ToString() {
			return "Immagine";
		}
		public override Image Image {
			get {
				return Resources.PictureBox;
			}
		}
		public override void Load(XmlReader reader) {
			while(!reader.EOF) {
				switch(reader.Name) {
					case "name":
						ReadName(reader);
						break;
					case "location":
						ReadLocation(reader);
						break;
					case "size":
						ReadSize(reader);
						break;
					case "image":
						ReadImage(reader);
						break;
				}
				reader.ReadEndElement();
			}
		}
		private void ReadImage(XmlReader reader) {
			if(reader.MoveToAttribute("path"))
				FileName = reader.ReadString();
			else
				MessageBox.Show("Error loading imageBox: path couldn't be read");
		}
		public override void Save(XmlWriter writer) {
			SaveName(writer);
			SaveLocation(writer);
			SaveSize(writer);
			SaveImage(writer);
		}
		private void SaveImage(XmlWriter writer) {
			writer.WriteStartElement("image");
			writer.WriteAttributeString("path", _filename);
			writer.WriteEndElement();
		}
	}
}
