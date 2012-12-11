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
using System;
using DiagramDrawer.Properties;
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	public class RoundedBox : Box {
		public override PointF GetIntersection(PointF other) {
			PointF c = Center;
			float ox = other.X - c.X;
			float oy = other.Y - c.Y;
			if(ox == 0)
				return new PointF(c.X, c.Y + Height / 2F * Math.Sign(oy));
			float m = oy / ox;
			float m1 = -Height / (Width - 2F * Roundness);
			float m2 = -Height / (float)Width + (2F * Roundness) / Width;
			PointF t;
			if(m < m1)
				t = VerticalIntersection(m, oy);
			else {
				if(m < m2)
					t = RoundIntersection(ox, oy);
				else {
					if(m < -m2)
						t = HorizontalIntersection(m, ox);
					else {
						t = m < -m1 ? RoundIntersection(ox, oy) : VerticalIntersection(m, oy);
					}
				}
			}
			return new PointF(t.X + c.X, t.Y + c.Y);
		}
		private PointF HorizontalIntersection(float m, float ox) {
			//a=w/2 b=h/2
			//x=a*Sgn(ox)
			//y=mx
			float x = Width * Math.Sign(ox) / 2F;
			float y = m * x;
			return new PointF(x, y);
		}
		private PointF RoundIntersection(float ox, float oy) {
			//A=w/2 B=h/2
			//y=mx+q
			//x^2+y^2=r^2
			//x^2+m^2x^2+2mxq+q^2-r^2=0
			//a=1+m*m
			//b=2*m*q
			//c=q*q-r*r
			float wh = Width / 2F;
			float hh = Height / 2F;
			const float r = Roundness;
			float x0 = (wh - Roundness) * Math.Sign(ox);
			float y0 = (hh - Roundness) * Math.Sign(oy);
			float nx = ox - x0;
			float ny = oy - y0;
			float m = oy / ox;
			float q = ny - m * nx;
			float a = m * m + 1;
			float b = 2 * m * q;
			float c = q * q - r * r;
			float d = b * b - 4 * a * c;
			float ds = (float)Math.Sqrt(d);
			float x = (-b + ds * Math.Sign(ox)) / (2F * a);
			float y = m * x + q;
			return new PointF(x + x0, y + y0);
		}
		private PointF VerticalIntersection(float m, float oy) {
			//a=w/2 b=h/2
			//y=mx
			//y=b*Sng(oy)
			//x=y/m
			float y = Height * Math.Sign(oy) / 2F;
			float x = y / m;
			return new PointF(x, y);
		}
		const int Roundness = 10;
		PointF _p1, _p2, _p3, _p4, _p5, _p6, _p7, _p8, _e, _f, _g, _h;
		protected override void OnSizeChange() {
			base.OnSizeChange();
			SetPoints(Center);
		}
		protected override Point VCenter {
			get {
				Point c = base.VCenter;
				SetPoints(c);
				return c;
			}
		}
		protected override void DrawBackground(Graphics graphics) {
			graphics.FillPolygon(BackBrush, new[] { _p1, _p2, _p5, _p6 });
			graphics.FillPolygon(BackBrush, new[] { _p3, _p4, _p7, _p8 });
			graphics.FillEllipse(BackBrush, _e.X, _e.Y, Roundness * 2, Roundness * 2);
			graphics.FillEllipse(BackBrush, _f.X - Roundness * 2, _f.Y, Roundness * 2, Roundness * 2);
			graphics.FillEllipse(BackBrush, _g.X - Roundness * 2, _g.Y - Roundness * 2, Roundness * 2, Roundness * 2);
			graphics.FillEllipse(BackBrush, _h.X, _h.Y - Roundness * 2, Roundness * 2, Roundness * 2);
			graphics.DrawLine(BorderPen, _p1, _p2);
			graphics.DrawLine(BorderPen, _p3, _p4);
			graphics.DrawLine(BorderPen, _p5, _p6);
			graphics.DrawLine(BorderPen, _p7, _p8);
			graphics.DrawArc(BorderPen, _e.X, _e.Y, Roundness * 2, Roundness * 2, 180, 90);
			graphics.DrawArc(BorderPen, _f.X - Roundness * 2, _f.Y, Roundness * 2, Roundness * 2, 270, 90);
			graphics.DrawArc(BorderPen, _g.X - Roundness * 2, _g.Y - Roundness * 2, Roundness * 2, Roundness * 2, 0, 90);
			graphics.DrawArc(BorderPen, _h.X, _h.Y - Roundness * 2, Roundness * 2, Roundness * 2, 90, 90);
		}
		private void SetPoints(Point c) {
			float a = Width / 2F;
			float b = Height / 2F;
			//e  1---2  f
			// **     ** 
			// *       * 
			//8         3
			//|         |
			//|         |
			//7         4
			// *       * 
			// **     ** 
			//h  6---5  g
			_p1 = new PointF(c.X - a + Roundness, c.Y - b);
			_p2 = new PointF(c.X + a - Roundness, c.Y - b);
			_p3 = new PointF(c.X + a, c.Y - b + Roundness);
			_p4 = new PointF(c.X + a, c.Y + b - Roundness);
			_p5 = new PointF(c.X + a - Roundness, c.Y + b);
			_p6 = new PointF(c.X - a + Roundness, c.Y + b);
			_p7 = new PointF(c.X - a, c.Y + b - Roundness);
			_p8 = new PointF(c.X - a, c.Y - b + Roundness);
			_e = new PointF(c.X - a, c.Y - b);
			_f = new PointF(c.X + a, c.Y - b);
			_g = new PointF(c.X + a, c.Y + b);
			_h = new PointF(c.X - a, c.Y + b);
		}
		public override string ToString() {
			return "Rettangolo arrotondato";
		}
		public override Image Image {
			get {
				return Resources.RoundedBox;
			}
		}
		public override void SvgSave(System.Xml.XmlWriter writer) {
			Svg.WriteRoundedRectangle(writer, Location, new Size(Width, Height), BackgroundColor, BorderPen, Roundness);
			Svg.WriteText(writer, Center, ForegroundColor, Font, Text);
		}
	}
}
