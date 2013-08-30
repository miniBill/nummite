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

using System.Linq;
using DiagramDrawer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace DiagramDrawer.Shapes {
	class OneArrowAngle : OneArrow
	{
		public override Image Image {
			get {
				return Resources.OneArrowAngle;
			}
		}

		protected override void OnOriginChange (IShape value)
		{
			SubLines [0].Origin = value;
			base.OnOriginChange (value);
		}

		protected override void OnPointedChange (IShape value)
		{
			SubLines [1].Pointed = value;
			base.OnPointedChange (value);
		}

		List<InvisiblePoint> SubPoints {
			get;
			set;
		}

		protected List<Line> SubLines {
			get;
			private set;
		}

		bool reverse;

		public OneArrowAngle ()
		{
			SubLines = new List<Line> ();
			SubPoints = new List<InvisiblePoint> ();
			SubLines.Add (new Line ());
			SubLines.Add (new OneArrow ());
			SubPoints.Add (new InvisiblePoint ());
			//"normal"
			//origin
			//|
			//l1
			//|
			//m[0]--l2--pointed
			//
			//reverse
			//origin--l1--m[0]
			//            |
			//            l2
			//            |
			//            pointed
			if (Origin != null)
				SubLines [0].Origin = Origin;
			SubLines [0].Pointed = SubPoints [0];
			SubLines [1].Origin = SubPoints [0];
			if (Pointed != null)
				SubLines [1].Pointed = Pointed;
			ForegroundColorChange += Fragmented_ForegroundColorChange;
			BackgroundColorChange += Fragmented_BackgroundColorChange;
			BorderColorChange += Fragmented_BorderColorChange;
			ContextMenu.MenuItems.Add ("Inverti", delegate {
				reverse = !reverse;
				ShapeContainer.ForceRefresh ();
			});
		}

		void Fragmented_BorderColorChange (object sender, EventArgs e)
		{
			foreach (var l in SubLines)
				l.BorderColor = BorderColor;
		}

		void Fragmented_BackgroundColorChange (object sender, EventArgs e)
		{
			foreach (var l in SubLines)
				l.BackgroundColor = BackgroundColor;
		}

		void Fragmented_ForegroundColorChange (object sender, EventArgs e)
		{
			foreach (var l in SubLines)
				l.ForegroundColor = ForegroundColor;
		}

		protected override void OnMoving (object sender, EventArgs e)
		{
			base.OnMoving (sender, e);
			Moved ();
		}

		public override void DrawTo (Graphics graphics)
		{
			CheckShapeContainer ();
			if (!ShouldDraw ())
				return;
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if (dx == 0 || dy == 0)
				base.DrawTo (graphics);
			else
				foreach (var l in SubLines)
					l.DrawTo (graphics);
		}

		void Moved ()
		{
			if (Origin == null || Pointed == null || ShapeContainer == null)
				return;
			CheckShapeContainer ();
			/*float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;*/
			SubPoints [0].Move (reverse
								? new Point (Pointed.Center.X, Origin.Center.Y)
								: new Point (Origin.Center.X, Pointed.Center.Y));
			if (Origin.Contains (SubPoints [0].Location)) {
				var m1Int = Origin.GetIntersection (Pointed.Center);
				SubPoints [0].Move (new Point ((int)m1Int.X, Pointed.Center.Y));
			} else if (Pointed.Contains (SubPoints [0].Location)) {
				var m1Int = Origin.GetIntersection (Pointed.Center);
				SubPoints [0].Move (new Point (Pointed.Center.X, (int)m1Int.Y));
			}
		}

		void CheckShapeContainer ()
		{
			if (SubPoints [0].ShapeContainer == null) {
				foreach (var l in SubLines)
					l.ShapeContainer = ShapeContainer;
				foreach (var m in SubPoints)
					m.ShapeContainer = ShapeContainer;
			}
		}

		protected override void OnTextChange ()
		{
			if (SubLines.Count > 1)
				SubLines [reverse ? 0 : 1].Text = Text;
		}

		public override bool Contains (PointF point)
		{
			return SubLines.Any (l => l.Contains (point));
		}

		public override string ToString ()
		{
			return "Ad angolo";
		}

		public override void SvgSave (XmlWriter writer)
		{
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if (dx == 0 || dy == 0)
				base.SvgSave (writer);
			else
				foreach (var l in SubLines)
					l.SvgSave (writer);
		}
	}
}
