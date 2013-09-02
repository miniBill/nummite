/* Copyright (C) 2009 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
 *
 * This file is part of Nummite.
 *
 * Nummite is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Nummite is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Nummite.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Drawing;
using System;
using System.Xml;
using Nummite.Properties;
using Nummite.Export;

namespace Nummite.Shapes {
	class RoundedBox : Box
	{
		public override PointF GetIntersection (PointF other)
		{
			PointF c = Center;
			var ox = other.X - c.X;
			var oy = other.Y - c.Y;
			if (ox == 0)
				return new PointF (c.X, c.Y + Height / 2F * Math.Sign (oy));
			var m = oy / ox;
			var m1 = -Height / (Width - 2F * ROUNDNESS);
			var m2 = -Height / (float)Width + (2F * ROUNDNESS) / Width;
			PointF t = (m < m1 || (m >= m2 && m >= -m2 && m >= -m1))
				? VerticalIntersection (m, oy)
				: (m < m2 || m >= -m2)
					? RoundIntersection (ox, oy)
					: HorizontalIntersection (m, ox);
			return new PointF (t.X + c.X, t.Y + c.Y);
		}

		PointF HorizontalIntersection (float m, float ox)
		{
			//a=w/2 b=h/2
			//x=a*Sgn(ox)
			//y=mx
			var x = Width * Math.Sign (ox) / 2F;
			var y = m * x;
			return new PointF (x, y);
		}

		PointF RoundIntersection (float ox, float oy)
		{
			//A=w/2 B=h/2
			//y=mx+q
			//x^2+y^2=r^2
			//x^2+m^2x^2+2mxq+q^2-r^2=0
			//a=1+m*m
			//b=2*m*q
			//c=q*q-r*r
			var wh = Width / 2F;
			var hh = Height / 2F;
			const float r = ROUNDNESS;
			var x0 = (wh - ROUNDNESS) * Math.Sign (ox);
			var y0 = (hh - ROUNDNESS) * Math.Sign (oy);
			var nx = ox - x0;
			var ny = oy - y0;
			var m = oy / ox;
			var q = ny - m * nx;
			var a = m * m + 1;
			var b = 2 * m * q;
			var c = q * q - r * r;
			var d = b * b - 4 * a * c;
			var ds = (float)Math.Sqrt (d);
			var x = (-b + ds * Math.Sign (ox)) / (2F * a);
			var y = m * x + q;
			return new PointF (x + x0, y + y0);
		}

		PointF VerticalIntersection (float m, float oy)
		{
			//a=w/2 b=h/2
			//y=mx
			//y=b*Sng(oy)
			//x=y/m
			var y = Height * Math.Sign (oy) / 2F;
			var x = y / m;
			return new PointF (x, y);
		}

		const int ROUNDNESS = 10;
		PointF p1, p2, p3, p4, p5, p6, p7, p8, e, f, g, h;

		protected override void OnSizeChange ()
		{
			base.OnSizeChange ();
			SetPoints (Center);
		}

		protected override Point VCenter {
			get {
				var c = base.VCenter;
				SetPoints (c);
				return c;
			}
		}

		protected override void DrawBackground (Graphics graphics)
		{
			graphics.FillPolygon (BackBrush, new[] { p1, p2, p5, p6 });
			graphics.FillPolygon (BackBrush, new[] { p3, p4, p7, p8 });
			graphics.FillEllipse (BackBrush, e.X, e.Y, ROUNDNESS * 2, ROUNDNESS * 2);
			graphics.FillEllipse (BackBrush, f.X - ROUNDNESS * 2, f.Y, ROUNDNESS * 2, ROUNDNESS * 2);
			graphics.FillEllipse (BackBrush, g.X - ROUNDNESS * 2, g.Y - ROUNDNESS * 2, ROUNDNESS * 2, ROUNDNESS * 2);
			graphics.FillEllipse (BackBrush, h.X, h.Y - ROUNDNESS * 2, ROUNDNESS * 2, ROUNDNESS * 2);
			graphics.DrawLine (BorderPen, p1, p2);
			graphics.DrawLine (BorderPen, p3, p4);
			graphics.DrawLine (BorderPen, p5, p6);
			graphics.DrawLine (BorderPen, p7, p8);
			graphics.DrawArc (BorderPen, e.X, e.Y, ROUNDNESS * 2, ROUNDNESS * 2, 180, 90);
			graphics.DrawArc (BorderPen, f.X - ROUNDNESS * 2, f.Y, ROUNDNESS * 2, ROUNDNESS * 2, 270, 90);
			graphics.DrawArc (BorderPen, g.X - ROUNDNESS * 2, g.Y - ROUNDNESS * 2, ROUNDNESS * 2, ROUNDNESS * 2, 0, 90);
			graphics.DrawArc (BorderPen, h.X, h.Y - ROUNDNESS * 2, ROUNDNESS * 2, ROUNDNESS * 2, 90, 90);
		}

		void SetPoints (Point c)
		{
			var a = Width / 2F;
			var b = Height / 2F;
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
			p1 = new PointF (c.X - a + ROUNDNESS, c.Y - b);
			p2 = new PointF (c.X + a - ROUNDNESS, c.Y - b);
			p3 = new PointF (c.X + a, c.Y - b + ROUNDNESS);
			p4 = new PointF (c.X + a, c.Y + b - ROUNDNESS);
			p5 = new PointF (c.X + a - ROUNDNESS, c.Y + b);
			p6 = new PointF (c.X - a + ROUNDNESS, c.Y + b);
			p7 = new PointF (c.X - a, c.Y + b - ROUNDNESS);
			p8 = new PointF (c.X - a, c.Y - b + ROUNDNESS);
			e = new PointF (c.X - a, c.Y - b);
			f = new PointF (c.X + a, c.Y - b);
			g = new PointF (c.X + a, c.Y + b);
			h = new PointF (c.X - a, c.Y + b);
		}

		public static new string Description { 
			get {
				return "Rettangolo arrotondato";
			}
		}

		public readonly static new IShapeCreator Creator = new ShapeCreator<RoundedBox> (Description, Resources.RoundedBox);

		public override void SvgSave (XmlWriter writer)
		{
			Svg.WriteRoundedRectangle (writer, Location, new Size (Width, Height), BackgroundColor, BorderPen, ROUNDNESS);
			Svg.WriteText (writer, Center, ForegroundColor, Font, Text);
		}
	}
}
