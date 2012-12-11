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
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	public class Ellipse : Box {
		public override bool Contains(PointF point) {
			Point c = Center;
			float ox = point.X - c.X;
			float oy = point.Y - c.Y;
			float a = Width / 2F;
			float b = Height / 2F;
			return ox * ox / (a * a) + oy * oy / (b * b) <= 1;
		}
		public override PointF GetIntersection(PointF other) {
			PointF c = Center;
			float ox = other.X - c.X;
			float oy = other.Y - c.Y;
			if(ox == 0)
				return new PointF(c.X, c.Y + Height / 2F * Math.Sign(oy));
			float a = Width / 2F;
			float b = Height / 2F;
			float m = oy / ox;
			float x = 1F / (1F / (a * a) + m * m / (b * b));
			x = (float)Math.Sqrt(x);
			if(ox < 0)
				x = -x;
			float y = m * x;
			return new PointF(x + c.X, y + c.Y);
		}
		protected override void DrawBackground(Graphics graphics) {
			Rectangle bounds = new Rectangle(Location.X, Location.Y, Width, Height);
			graphics.FillEllipse(BackBrush, bounds);
			graphics.DrawEllipse(BorderPen, bounds);
		}
		public override string ToString() {
			return "Ellisse";
		}
		public override Image Image {
			get {
				return Resources.Ellipse;
			}
		}
		public override void SvgSave(System.Xml.XmlWriter writer) {
			Svg.WriteEllipse(writer, Center, new Size(Width, Height), BackgroundColor, BorderPen);
			Svg.WriteText(writer, Center, ForegroundColor, Font, Text);
		}
	}
}
