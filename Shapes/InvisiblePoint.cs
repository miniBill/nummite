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
using System.Collections.ObjectModel;
using System.Drawing;
using DiagramDrawer.Forms;

namespace DiagramDrawer.Shapes {
	class InvisiblePoint : IShape {
		public InvisiblePoint() {
			Text = String.Empty;
		}
		public virtual bool Contains(PointF point) {
			return false;
		}
		bool dragged;
		public bool Dragged {
			get {
				return dragged;
			}
			set {
				if(value) {
					if(DragStart != null)
						DragStart(this, EventArgs.Empty);
				}
				else
					if(dragged)
						if(DragEnd != null)
							DragEnd(this, EventArgs.Empty);
				dragged = value;
			}
		}
		public bool Depends {
			get {
				return false;
			}
		}
		public void OpenMenu(PointF point) {

		}
		void Delete() {
			ShapeContainer.RemoveShape(this);
			if(Deleted != null)
				Deleted(this, EventArgs.Empty);
		}
		public void DrawTo(Graphics graphics) {

		}

		public Point Location { get; protected set; }

		public Point Offset { get; set; }

		public int Width {
			get {
				return 0;
			}
		}
		public int Height {
			get {
				return 0;
			}
		}

		public string Text { get; set; }

		public void Move(Point point) {
			var x = point.X - Offset.X;
			if(x < 0)
				x = 0;
			if(x > ShapeContainer.Width)
				x = ShapeContainer.Width;
			var y = point.Y - Offset.Y;
			if(y < 0)
				y = 0;
			if(y > ShapeContainer.Height)
				y = ShapeContainer.Height;
			Location = new Point(x, y);
			if(Moving != null)
				Moving(this, EventArgs.Empty);
			else
				Delete();
		}
		public event EventHandler Moving;
		public event EventHandler DragStart;
		public event EventHandler DragEnd;
		public event EventHandler Deleted;
		public Point Center {
			get {
				return Location;
			}
		}
		public PointF GetIntersection(PointF other) {
			return Location;
		}

		public string Name { get; set; }

		public void BeginInitialize() {
		}
		public void EndInitialize(KeyedCollection<string, IShape> list) {
		}
		public bool NeedInitialize {
			get {
				return false;
			}
		}

		public ShapeContainer ShapeContainer { get; set; }

		public bool Linkable {
			get {
				return true;
			}
		}
		public void SetLocation(Point point) {
			Location = point;
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing) {

		}
	}
}
