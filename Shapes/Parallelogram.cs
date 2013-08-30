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

namespace DiagramDrawer.Shapes {
	class Parallelogram : Box {
		protected override void DrawBackground(Graphics graphics) {
			var i = Width / 10F;
			var a = Width / 2F;
			var b = Height / 2F;
			PointF c = Center;
			var points = new[] { 
				new PointF(c.X - a + i, c.Y - b),
				new PointF(c.X - a, c.Y + b),
				new PointF(c.X + a - i, c.Y + b),
				new PointF(c.X + a, c.Y - b),
				new PointF(c.X - a + i, c.Y - b)
			};
			graphics.FillPolygon(BackBrush, points);
			graphics.DrawPolygon(BorderPen, points);
		}
		public override bool Contains(PointF point) {
			if(point.Y > Location.Y + Height || point.Y < Location.Y)
				return false;
			if(point.X < Center.X) {
				float m = -Height * 10;
				m /= Width;
				var q = Center.Y - m * (Location.X + Width / 20F);
				if(point.Y > (m * point.X + q))
					return true;
			}
			else {
				float m = -Height * 10;
				m /= Width;
				var q = Center.Y - m * (Location.X + Width - Width / 20F);
				if(point.Y < (m * point.X + q))
					return true;
			}
			return false;
		}
		public override PointF GetIntersection(PointF other) {
			float r = -Height;
			r /= Width;
			var l = 5F * Height;
			l /= 4F * Width;
			PointF c = Center;
			var ox = other.X - c.X;
			var oy = other.Y - c.Y;
			if(ox == 0)
				return new PointF(c.X, c.Y + Height / 2F * Math.Sign(oy));
			var om = oy / ox;
			var oq = oy - om * ox;
			float x, y;
			if(r < om && om < l) {
				float m = -Height * 10;
				m /= Width;
				//q=y-mx
				//q=0-10H/W*(-W/2+W/20)
				//q=-5H*(-10/10+1/10)
				//q=-H*(-9/2)
				//q=9H/2
				var q = 4.5F * Height;
				if(other.X < Center.X)
					q = -q;
				//y=mx+q
				//y=omx
				//mx+q=omx
				//(m-om)x=-q
				//x=q/(om-m)
				x = q / (om - m);
				y = om * x;
			}
			else {
				y = Height / 2F * Math.Sign(oy);
				x = (y - oq) / om;
			}
			return new PointF(x + c.X, y + c.Y);
		}
		public override Image Image {
			get {
				return Resources.Parallelogram;
			}
		}
		public override string ToString() {
			return "Parallelogramma";
		}
	}
}
