/* Copyright (C) 2008 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
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

using System;
using System.Drawing;
using System.Xml;
using Nummite.Export;
using Nummite.Properties;

namespace Nummite.Shapes.Lines {
	class OneArrow : Line
	{
		const float DISTANZA = 10F;
		const float APERTURA = 5F;
		PointF l, r;

		public override void DrawTo (Graphics graphics)
		{
			if (!ShouldDraw ())
				return;
			base.DrawTo (graphics);
			graphics.FillPolygon (BorderBrush, new[] { l, End, r, l });
		}

		void Recalculate ()
		{
			var otherPointX = Start.X - End.X;
			var otherPointY = Start.Y - End.Y;
			var m = otherPointY / otherPointX;
			if (otherPointX == 0) {
				var y = (End.Y > Start.Y) ? (End.Y - DISTANZA) : (End.Y + DISTANZA);
				l.Y = r.Y = y;
				l.X = End.X - APERTURA;
				r.X = End.X + APERTURA;
			} else if (otherPointY == 0) {
				var x = (End.X > Start.X) ? (End.X - DISTANZA) : (End.X + DISTANZA);
				l.X = r.X = x;
				l.Y = End.Y - APERTURA;
				r.Y = End.Y + APERTURA;
			} else {
				RecalculateMath (otherPointX, m, out l, out r, End);
			}
		}

		static void RecalculateMath (float otherPointX, float m, out PointF l, out PointF r, PointF end)
		{
			//       c
			//      /|\
			//     / | \
			//    /  O  \
			//   /   |   \
			//  /    |    \
			// L--H--M--H--R
			//       |
			//       |
			//       |
			//       D
			//M=Cross
			//LR=inverse
			//CD="Straight"
			//distanza=o
			//my=m*mx
			//o^2=mx^2+my^2
			//o^2=mx^2+m^2mx^2
			//o^2=(1+m^2)mx^2
			//mx=o/sqrt(1+m^2)
			l = r = new PointF ();
			var cross = new PointF {
				X = DISTANZA / (float)Math.Sqrt (1F + m * m)
			};
			if (otherPointX < 0)
				cross.X = -cross.X;
			cross.Y = cross.X * m;
			var inverseM = -1F / m;
			//y=mx+q
			//q=y-mx
			var inverseQ = cross.Y - inverseM * cross.X;
			//apertura=h
			//h^2=(mx-lx)^2+(my-ly)^2
			//h^2=mx^2-2mxlx+lx^2+2my^2-2my(imlx+iq)+(imlx+iq)^2
			//lx^2-2mxlx-2myimlx+(imlx+iq)^2-h^2+mx^2+2my^2-2myiq=0
			//lx^2+(-2mx-2myim)lx+im^2lx^2+2imlxiq+iq^2-h^2+mx^2+2my^2-2myiq=0
			//(im^2+1)lx^2+2(imiq-mx-myim)lx+iq^2-h^2+mx^2+2my^2-2myiq=0
			var a = inverseM * inverseM + 1;
			var b = 2 * (inverseM * inverseQ - cross.X - cross.Y * inverseM);
			var discriminant = inverseQ * inverseQ - APERTURA * APERTURA + cross.X * cross.X +
			                   2 * cross.Y * cross.Y - 2 * cross.Y * inverseQ;
			var discriminantRoot = (float)Math.Sqrt (discriminant);
			l.X = (-b + discriminantRoot) / (2F * a);
			l.Y = l.X * inverseM + inverseQ;
			l.X += end.X;
			l.Y += end.Y;
			r.X = (-b - discriminantRoot) / (2F * a);
			r.Y = r.X * inverseM + inverseQ;
			r.X += end.X;
			r.Y += end.Y;
		}

		public readonly static new ILineCreator Creator = new LineCreator<OneArrow> (Description, Resources.OneArrow);

		public static new string Description { 
			get {
				return "Punta singola";
			}
		}

		protected override void OnMoving (object sender, EventArgs e)
		{
			base.OnMoving (sender, e);
			Recalculate ();
		}

		public override void SvgSave (XmlWriter writer)
		{
			base.SvgSave (writer);
			Svg.WritePolygon (writer, new[] { l, End, r, l }, BorderColor);
		}
	}
}
