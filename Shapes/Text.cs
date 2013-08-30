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
using DiagramDrawer.Properties;
using System.Text;

namespace DiagramDrawer.Shapes {
	class LabelShape : Box {
		public LabelShape() {
			Height = 40;
		}
		public override Image Image {
			get {
				return Resources.Text;
			}
		}
		public override PointF GetIntersection(PointF other) {
			PointF p = Center;
			p.Y += Height / 2F;
			return p;
		}
		public override void DrawTo(Graphics graphics) {
#if DEBUG
			if(Text.StartsWith("'shapes'")) {
				var sb = new StringBuilder();
				sb.Append("'shapes'" + Environment.NewLine);
				foreach(var s in ShapeContainer.ShapeList)
					if(!(s is LabelShape))
						sb.Append(s.Text + ":" + s.Location + Environment.NewLine);
				Text = sb.ToString();
			}
#endif
			base.DrawTo(graphics);
		}
		protected override void DrawBackground(Graphics graphics) {
		}
		public override string ToString() {
			return "Testo";
		}
	}
}
