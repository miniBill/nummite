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
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Nummite.Shapes;
using System.ComponentModel;
using Nummite.Shapes.Lines;

namespace Nummite.Forms {
	partial class ShapeContainer : UserControl, ISizeable
	{
		public ShapeCollection ShapeList {
			get;
			private set;
		}

		Bitmap back;
		Bitmap current;
		bool linkMode;

		[DefaultValue (false)]
		public bool LinkMode {
			get {
				return linkMode;
			}
			set {
				linkMode = value;
				linking &= linkMode;
			}
		}

		public ShapeContainer ()
		{
			ShapeType = RoundedBox.Helper;
			LineType = Line.Helper;
			ShapeList = new ShapeCollection ();
			back = new Bitmap (Width, Height);
			current = new Bitmap (Width, Height);
			InitializeComponent ();
		}

		protected override void OnResize (EventArgs e)
		{
			base.OnResize (e);
			if (Width * Height < 1)
				return;
			ClearAndDrawShapesToBack ();
			RegenImage ();
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			RegenImage ();
		}

		/// <summary>
		/// Copy back to front
		/// Draw moving shapes on front
		/// Draw front
		/// </summary>
		void RegenImage ()
		{
			current.Dispose ();
			current = (Bitmap)back.Clone ();
			DrawMovingShapes ();
			using (var g = CreateGraphics())
				g.DrawImageUnscaled (current, Point.Empty);
		}

		void DrawMovingShapes ()
		{
			using (var f = Graphics.FromImage(current))
				foreach (IShape s in ShapeList.Where(s => s.Dragged || s.Depends))
					s.DrawTo (f);
		}

		public ILineHelper LineType {
			get;
			set;
		}

		void ShapeContainer_MouseDown (object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			if (!LinkMode)
				OnLeftNonLinkClick (e.Location);
			else
				OnLeftLinkClick (e.Location);
		}

		bool linking;
		/// <summary>
		/// This is the invisible point which is the tip of the line during the link phase
		/// </summary>
		InvisiblePoint linkingPoint;
		/// <summary>
		/// This is the line used during the link phase
		/// </summary>
		Line linkingPointer;

		void OnLeftLinkClick (Point p)
		{
			var s = GetSelectedShape (p, true);
			if (s == null)
				return;
			linking = true;
			ClearAndDrawShapesToBack ();
			AddLinkingShapes (p, s);
			RegenImage ();
		}

		void ClearAndDrawShapesToBack ()
		{
			using (var b = Graphics.FromImage(back)) {
				b.Clear (BackColor);
				foreach (var nD in ShapeList)
					nD.DrawTo (b);
			}
		}

		void AddLinkingShapes (Point p, IShape s)
		{
			//Point
			var point = new InvisiblePoint ();
			point.SetLocation (p);
			point.Dragged = true;
			point.Offset = Point.Empty;
			linkingPoint = point;
			AddShape (point);
			//Pointer
			var pointer = LineType.Create ();
			pointer.Origin = s;
			pointer.Pointed = point;
			pointer.Depends = true;
			linkingPointer = pointer;
			AddShape (pointer);
			point.Move (p);
		}

		public IShape GetSelectedShape (Point point, bool needsLinkable)
		{
			var selected = new List<IShape> ();
			foreach (var s in ShapeList) {
				if (s.Contains (point) && (!needsLinkable || s.Linkable))
					selected.Add (s);
				s.Dragged = false;
			}
			var i = selected.Select (ShapeList.IndexOf).Concat (new[] { -1 }).Max ();
			return i < 0 ? null : ShapeList [i];
		}

		void OnRightNonLinkClick (Point p)
		{
			var s = GetSelectedShape (p, false);
			if (s != null)
				s.OpenMenu (p);
		}

		void OnLeftNonLinkClick (Point p)
		{
			using (var b = Graphics.FromImage(back)) {
				b.Clear (BackColor);

				var selectedShape = GetSelectedShape (p, true);
				if (selectedShape != null) {
					selectedShape.Dragged = true;
					selectedShape.Offset = new Point (
						p.X - selectedShape.Location.X,
						p.Y - selectedShape.Location.Y
					);
					selectedShape.Move (p);
				}

				foreach (IShape nD in ShapeList.Where(nD => !nD.Dragged && !nD.Depends))
					nD.DrawTo (b);

			}
			RegenImage ();
		}

		void ShapeContainer_MouseMove (object sender, MouseEventArgs e)
		{
			var drag = false;
			var parent = Parent as ScrollableControl;
			foreach (var s in ShapeList)
				if (s.Dragged) {
					drag = true;
					s.Move (e.Location);
					if (parent == null)
						continue;
					var x = -parent.AutoScrollPosition.X;
					if (x > s.Location.X)
						x = s.Location.X - 5;
					if (s.Location.X + s.Width > x + parent.Width)
						x = s.Location.X + 5 + s.Width - parent.Width;
					var y = -parent.AutoScrollPosition.Y;
					if (y > s.Location.Y)
						y = s.Location.Y - 5;
					if (s.Location.Y + s.Height > y + parent.Height)
						y = s.Location.Y + 5 + s.Height - parent.Height;
					parent.AutoScrollPosition = new Point (x, y);
				}
			if (drag)
				RegenImage ();
		}

		public new event EventHandler<ShapeEventArgs> Click;

		void ShapeContainer_MouseUp (object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && !LinkMode) {
				OnRightNonLinkClick (e.Location);
				return;
			}
			if (linking)
				TryLink (e.Location);
			using (var g = Graphics.FromImage(back)) {
				g.Clear (BackColor);
				foreach (var s in ShapeList) {
					if (s.Dragged)
						s.Dragged = false;
					s.DrawTo (g);
				}
			}
			RegenImage ();
			var selected = GetSelectedShape (e.Location, false);
			if ((Click != null) && (selected != null))
				Click.Invoke (this, new ShapeEventArgs (selected));
		}

		void TryLink (Point location)
		{
			linking = false;
			linkingPoint.Dragged = false;
			linkingPointer.Depends = false;
			RemoveShape (linkingPoint);
			var selectedShape = GetSelectedShape (location, true);
			if (selectedShape == null || selectedShape == linkingPointer.Origin) {
				if (Options.AutoCreateOnLink) {
					using (var shapeSize = ShapeType.Create ())
						selectedShape = AddCurrentShapeAtPoint (new Point (location.X - shapeSize.Width / 2, location.Y - shapeSize.Height / 2));
				} else {
					RemoveShape (linkingPointer);
					return;
				}
			}
			linkingPointer.Pointed = selectedShape;
			selectedShape.Offset = Point.Empty;
			selectedShape.Move (selectedShape.Location);
			LinkMode = false;
			if (Link != null)
				Link (this, EventArgs.Empty);

		}

		public IShapeHelper ShapeType {
			get;
			set;
		}

		public IShape AddCurrentShapeAtPoint (Point location)
		{
			var toret = ShapeType.Create ();
			AddShapeAtPoint (toret, location);
			return toret;
		}

		public event EventHandler Link;

		public void RemoveShape (IShape shape)
		{
			ShapeList.Remove (shape);
			shape.Deleted += delegate {
				shape.Dispose ();
			};
			ForceRefresh ();
		}

		void AddShapeAtPoint (IShape shape, Point point)
		{
			shape.Name = GetNextName (0);
			if (shape.Text.Length == 0 && !(shape is Line))
				shape.Text = "...";
			shape.SetLocation (Grid ? CutToGrid (point) : point);
			DoAddShape (shape);
		}

		bool suspended;

		void DoAddShape (IShape shape)
		{
			ShapeList.Add (shape);
			shape.ShapeContainer = this;
			if (suspended)
				return;
			using (var b = Graphics.FromImage(back))
				shape.DrawTo (b);
			RegenImage ();
		}

		void AddShape (IShape shape)
		{
			var parent = Parent as ScrollableControl;
			if (parent == null)
				return;
			var p = new Point (-parent.AutoScrollPosition.X, -parent.AutoScrollPosition.Y);
			AddShapeAtPoint (shape, p);
		}

		string GetNextName (int p)
		{
			while (true) {
				if (ShapeList.Contains ("Shape" + p.ToString (CultureInfo.CurrentCulture)))
					p++;
				else
					return "Shape" + p.ToString (CultureInfo.CurrentCulture);
			}
		}

		public void LoadShapes (IEnumerable<IShape> shapes)
		{
			Suspend ();
			var enumerable = shapes as IList<IShape> ?? shapes.ToList ();
			var initialized = enumerable.Where (b => b.NeedInitialize).ToList ();
			foreach (var b in initialized)
				b.BeginInitialize ();
			foreach (var s in enumerable)
				DoAddShape (s);
			foreach (var e in initialized)
				e.EndInitialize (ShapeList);
			ForceRefresh ();
		}

		void ShapeContainer_MouseDoubleClick (object sender, MouseEventArgs e)
		{
			var selectedShape = GetSelectedShape (e.Location, false);
			if (selectedShape == null || selectedShape is ImageBox)
				return;
			if (StringInput.Show ("Inserisci il testo", "Nummite", selectedShape.Text.Replace (Environment.NewLine, @"\n")) != DialogResult.OK)
				return;
			selectedShape.Text = StringInput.LastResult.Replace (@"\n", Environment.NewLine);
			Refresh ();
		}

		public void DrawTo (Graphics graphics, bool hidePoints)
		{
			foreach (var s in ShapeList)
				if (!hidePoints || !(s is VisiblePoint))
					s.DrawTo (graphics);
		}

		public void PrintTo (Graphics graphics, Rectangle rectangle)
		{
			using (Image i = new Bitmap(Width, Height))
			using (var g = Graphics.FromImage(i)) {
				DrawTo (g, true);
				graphics.DrawImage (i, rectangle);
			}
		}

		public void ClearShapes ()
		{
			ShapeList.Clear ();
			using (var g = Graphics.FromImage(back))
				g.Clear (BackColor);
			RegenImage ();
			Refresh ();
		}

		void Suspend ()
		{
			suspended = true;
		}

		public void ForceRefresh ()
		{
			suspended = false;
			back.Dispose ();
			back = new Bitmap (Width, Height);
			using (var g = Graphics.FromImage(back)) {
				g.Clear (BackColor);
				foreach (var s in ShapeList)
					s.DrawTo (g);
			}
			current.Dispose ();
			current = (Bitmap)back.Clone ();
			using (var g = CreateGraphics())
				g.DrawImageUnscaled (current, Point.Empty);
		}

		public void ShowPoints ()
		{
			TogglePoints (true);
		}

		void TogglePoints (bool show)
		{
			foreach (var s in ShapeList) {
				var p = s as VisiblePoint;
				if (p != null)
					p.Open = show;
			}
		}

		public void HidePoints ()
		{
			TogglePoints (false);
		}

		const int GRID_SIZE = 10;

		public void AlignToGrid ()
		{
			foreach (var s in ShapeList) {
				s.Offset = Point.Empty;
				s.Move (CutToGrid (s.Location));
			}
			ForceRefresh ();
		}

		public static Point CutToGrid (Point point)
		{
			return new Point (point.X - (point.X % GRID_SIZE), point.Y - (point.Y % GRID_SIZE));
		}

		[DefaultValue (false)]
		public bool Grid {
			get;
			set;
		}

		public void BringForeground (IShape shape)
		{
			ShapeList.Remove (shape);
			ShapeList.Add (shape);
			ForceRefresh ();
		}
	}
}
