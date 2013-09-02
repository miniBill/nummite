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
using DiagramDrawer.Properties;
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	class Ellipse : Box
	{
		public override bool Contains (PointF point)
		{
			var c = Center;
			var ox = point.X - c.X;
			var oy = point.Y - c.Y;
			var a = Width / 2F;
			var b = Height / 2F;
			return ox * ox / (a * a) + oy * oy / (b * b) <= 1;
		}

		public override PointF GetIntersection (PointF other)
		{
			PointF c = Center;
			var ox = other.X - c.X;
			var oy = other.Y - c.Y;
			if (ox == 0)
				return new PointF (c.X, c.Y + Height / 2F * Math.Sign (oy));
			var a = Width / 2F;
			var b = Height / 2F;
			var m = oy / ox;
			var x = 1F / (1F / (a * a) + m * m / (b * b));
			x = (float)Math.Sqrt (x);
			if (ox < 0)
				x = -x;
			var y = m * x;
			return new PointF (x + c.X, y + c.Y);
		}

		protected override void DrawBackground (Graphics graphics)
		{
			var bounds = new Rectangle (Location.X, Location.Y, Width, Height);
			graphics.FillEllipse (BackBrush, bounds);
			graphics.DrawEllipse (BorderPen, bounds);
		}

		public new static string Name {
			get {
				return "Ellisse"; 
			}
		}

		public readonly static new IShapeCreator Creator = new ShapeCreator<Ellipse> (Name, Resources.Ellipse);

		public override void SvgSave (XmlWriter writer)
		{
			Svg.WriteEllipse (writer, Center, new Size (Width, Height), BackgroundColor, BorderPen);
			Svg.WriteText (writer, Center, ForegroundColor, Font, Text);
		}
	}
}
