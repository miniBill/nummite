/* Copyright (C) 2009 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
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

using System.Drawing;
using System.Windows.Forms;
using DiagramDrawer.Forms;
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	public class Link : Ellipse {
		public Link() {
			BackgroundColor = Color.LightBlue;
			Width = Height = 10;
			MenuItem mi = new MenuItem("Vai", delegate {
													if(ShapeContainer.ParentForm != null)
														((MainForm)ShapeContainer.ParentForm).Controller.Open(Text);
												});
			ContextMenu.MenuItems.Add(0, mi);
		}
		public override void DrawTo(Graphics graphics) {
			base.DrawBackground(graphics);
		}
		public override string ToString() {
			return "Collegamento";
		}
		protected override void OnTextChange() {
			if(Text == "...")
				Text = string.Empty;
			base.OnTextChange();
		}
		const int Radius = 10;
		protected override void OnSizeChange() {
			if(Width != Radius)
				Width = Radius;
			if(Height != Radius)
				Height = Radius;
			base.OnSizeChange();
		}
		public override Image Image {
			get {
				return Properties.Resources.WLink;
			}
		}
		public override void SvgSave(System.Xml.XmlWriter writer) {
			Svg.WriteStartLink(writer, Text.Replace(".xml", ".svg"));
			Svg.WriteEllipse(writer, Center, new Size(Width, Height), BackgroundColor, BorderPen);
			Svg.WriteEndLink(writer);
		}
	}
}