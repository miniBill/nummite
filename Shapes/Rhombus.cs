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
using System;
using DiagramDrawer.Properties;

namespace DiagramDrawer.Shapes {
	public class Rhombus : Box {
		public override bool Contains(PointF point) {
			Point c = Center;
			float ox = point.X - c.X;
			float oy = point.Y - c.Y;
			if(ox == 0)
				return Math.Abs(oy) <= (Height / 2F);
			if(oy == 0)
				return Math.Abs(ox) <= (Width / 2F);
			float m = oy / ox;
			if(m > 0) {
				float qa = Height / 2F * Math.Sign(ox);
				float ma = -Height;
				ma /= Width;
				if(oy >= 0)
					return oy < (ox * ma + qa);
				return oy > (ox * ma + qa);
			}
			float qb = -Height / 2F * Math.Sign(ox);
			float mb = Height;
			mb /= Width;
			if(oy >= 0)
				return oy < (ox * mb + qb);
			return oy > (ox * mb + qb);
		}
		public override PointF GetIntersection(PointF other) {
			PointF c = Center;
			float ox = other.X - c.X;
			float oy = other.Y - c.Y;
			if(ox == 0)
				return new PointF(c.X, c.Y + Height / 2 * Math.Sign(oy));
			if(oy == 0)
				return new PointF(c.X + Width / 2 * Math.Sign(ox), c.Y);
			float m = oy / ox;
			float qa = Height / 2F * Math.Sign(oy);
			float ma = -Height * Math.Sign(m);
			ma /= Width;
			float x = qa / (m - ma);
			float y = m * x;
			return new PointF(x + c.X, y + c.Y);
		}
		protected override void DrawBackground(Graphics graphics) {
			float a = Width / 2F;
			float b = Height / 2F;
			PointF c = Center;
			var points = new[]{
				new PointF(c.X - a, c.Y),
				new PointF(c.X, c.Y + b),
				new PointF(c.X + a, c.Y),
				new PointF(c.X, c.Y - b),
				new PointF(c.X - a, c.Y)
			};
			graphics.FillPolygon(BackBrush, points);
			graphics.DrawPolygon(BorderPen, points);
		}
		public override string ToString() {
			return "Rombo";
		}
		public override Image Image {
			get {
				return Resources.Rhombus;
			}
		}
	}
}
