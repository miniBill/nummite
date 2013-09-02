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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using Nummite.Properties;

namespace Nummite.Shapes.Lines {
	class NoArrowFragmented : Line
	{
		public readonly static new ILineCreator Creator = new LineCreator<NoArrowFragmented>(Description, Resources.NoArrowFragmented);

		protected override void OnOriginChange (IShape value)
		{
			SubLines [0].Origin = value;
			base.OnOriginChange (value);
		}

		protected override void OnPointedChange (IShape value)
		{
			SubLines [2].Pointed = value;
			base.OnPointedChange (value);
		}

		protected List<InvisiblePoint> SubPoints {
			get;
			private set;
		}

		protected List<Line> SubLines {
			get;
			private set;
		}

		public NoArrowFragmented ()
		{
			SubLines = new List<Line> ();
			SubPoints = new List<InvisiblePoint> ();
			for (var c = 0; c < 3; c++)
				SubLines.Add (new Line ());
			for (var i = 0; i < 2; i++)
				SubPoints.Add (new InvisiblePoint ());
			//origin--l1--m[0]
			//            |
			//            l2
			//            |
			//            m[1]--l3--pointed
			if (Origin != null)
				SubLines [0].Origin = Origin;
			SubLines [0].Pointed = SubPoints [0];
			SubLines [1].Origin = SubPoints [0];
			SubLines [1].Pointed = SubPoints [1];
			SubLines [2].Origin = SubPoints [1];
			if (Pointed != null)
				SubLines [2].Pointed = Pointed;
			ForegroundColorChange += Fragmented_ForegroundColorChange;
			BackgroundColorChange += Fragmented_BackgroundColorChange;
			BorderColorChange += Fragmented_BorderColorChange;
		}

		void Fragmented_BorderColorChange (object sender, EventArgs e)
		{
			foreach (var l in SubLines)
				l.BorderColor = BorderColor;
		}

		void Fragmented_BackgroundColorChange (object sender, EventArgs e)
		{
			SubLines [1].BackgroundColor = BackgroundColor;
		}

		void Fragmented_ForegroundColorChange (object sender, EventArgs e)
		{
			SubLines [1].ForegroundColor = ForegroundColor;
		}

		protected override void OnMoving (object sender, EventArgs e)
		{
			base.OnMoving (sender, e);
			Moved ();
		}

		protected override bool ShouldDraw ()
		{
			return Origin != null && Pointed != null && ShapeContainer != null && base.ShouldDraw ();
		}

		public override void DrawTo (Graphics graphics)
		{
			SetShapeContainer ();
			if (!ShouldDraw ())
				return;
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if (Math.Abs(dx) < Options.TOLERANCE || Math.Abs(dy) < Options.TOLERANCE)
				base.DrawTo (graphics);
			else
				foreach (var l in SubLines)
					l.DrawTo (graphics);
		}

		void Moved ()
		{
			if (!ShouldDraw ())
				return;
			SetShapeContainer ();
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if (Math.Abs (dy) > (Origin.Height / 2 + Pointed.Height / 2 + 40)) {
				SubPoints [0].Move (new Point (Origin.Center.X, Origin.Center.Y - (int)dy / 2));
				SubPoints [1].Move (new Point (Pointed.Center.X, Origin.Center.Y - (int)dy / 2));
			} else {
				SubPoints [0].Move (new Point (Origin.Center.X - (int)dx / 2, Origin.Center.Y));
				SubPoints [1].Move (new Point (Origin.Center.X - (int)dx / 2, Pointed.Center.Y));
			}
			if (Origin.Contains (SubPoints [0].Location) || Pointed.Contains (SubPoints [1].Location)) {
				var m1Int = Origin.GetIntersection (Pointed.Center);
				SubPoints [0].Move (new Point (Origin.Center.X - (int)(dx / 2), (int)m1Int.Y));
				var m2Int = Pointed.GetIntersection (Origin.Center);
				SubPoints [1].Move (new Point (Origin.Center.X - (int)(dx / 2), (int)m2Int.Y));
			}
		}

		protected void SetShapeContainer ()
		{
			if (SubPoints [0].ShapeContainer == null) {
				foreach (var l in SubLines)
					l.ShapeContainer = ShapeContainer;
				foreach (var m in SubPoints)
					m.ShapeContainer = ShapeContainer;
			}
		}

		public override bool Contains (PointF point)
		{
			return SubLines.Any (l => l.Contains (point));
		}

		protected override void OnTextChange ()
		{
			if (SubLines.Count > 1)
				SubLines [1].Text = Text;
			base.OnTextChange ();
		}

		public static new string Description { 
			get {
				return "Spezzata";
			}
		}

		public override void SvgSave (XmlWriter writer)
		{
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if (Math.Abs(dx) < Options.TOLERANCE || Math.Abs(dy) < Options.TOLERANCE)
				base.SvgSave (writer);
			else
				foreach (var l in SubLines)
					l.SvgSave (writer);
		}
	}
}
