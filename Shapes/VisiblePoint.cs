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

using System.Drawing;
using System.Windows.Forms;
using System;
using DiagramDrawer.Properties;

namespace DiagramDrawer.Shapes {
	public class VisiblePoint : Box {
		public VisiblePoint() {
			Width = Height = 20;
			Text = String.Empty;
			ContextMenu.MenuItems.Add("Mostra", ShowClick);
			ContextMenu.MenuItems.Add("Nascondi", HideClick);
		}
		public override bool NeedInitialize {
			get {
				return true;
			}
		}
		public override void BeginInitialize() {
			
		}
		public override void EndInitialize(System.Collections.ObjectModel.KeyedCollection<string, IShape> list) {
			Open = false;
		}
		private void ShowClick(object sender, EventArgs e) {
			Open = true;
		}
		private void HideClick(object sender, EventArgs e) {
			Open = false;
		}
		public override string ToString() {
			return "Punto";
		}
		bool _open = true;
		public bool Open {
			private get {
				return _open;
			}
			set {
				_open = value;
				ShapeContainer.ForceRefresh();
			}
		}
		public override void DrawTo(Graphics graphics) {
			if(!Open)
				return;
			graphics.DrawEllipse(BorderPen, Location.X, Location.Y, Width, Height);
			graphics.FillEllipse(ForeBrush,
				Location.X + Width / 3F, Location.Y + Height / 3F,
				Width / 3F, Height / 3F);
		}
		public override Image Image {
			get {
				return Resources.Point;
			}
		}
		public override PointF GetIntersection(PointF other) {
			return Center;
		}
		public override void SvgSave(System.Xml.XmlWriter writer) {
			return;
		}
	}
}
