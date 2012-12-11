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
using System.Xml;
using DiagramDrawer.Forms;

namespace DiagramDrawer.Shapes {
	public class InvisiblePoint : IShape {
		public InvisiblePoint() {
			Text = String.Empty;
		}
		public virtual bool Contains(PointF point) {
			return false;
		}
		bool _dragged;
		public bool Dragged {
			get {
				return _dragged;
			}
			set {
				if(value) {
					if(DragStart != null)
						DragStart(this, EventArgs.Empty);
				}
				else
					if(_dragged)
						if(DragEnd != null)
							DragEnd(this, EventArgs.Empty);
				_dragged = value;
			}
		}
		public bool Depends {
			get {
				return false;
			}
			set {
			}
		}
		public void OpenMenu(PointF point) {

		}
		private void Delete() {
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
			set {
				throw new NotImplementedException();
			}
		}
		public int Height {
			get {
				return 0;
			}
			set {
				throw new NotImplementedException();
			}
		}

		public string Text { get; set; }

		public void Move(Point point) {
			int x = point.X - Offset.X;
			if(x < 0)
				x = 0;
			if(x > ShapeContainer.Width)
				x = ShapeContainer.Width;
			int y = point.Y - Offset.Y;
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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
		public Image Image {
			get {
				throw new NotImplementedException();
			}
		}
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
		public Font Font {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
		public Color BackgroundColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
		public Color ForegroundColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		public void Load(XmlReader reader) {
			throw new NotImplementedException();
		}
		public void Save(XmlWriter writer) {
			throw new NotImplementedException();
		}
		public void Refresh() {
			throw new NotImplementedException();
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
		public Color BorderColor {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		public void SvgSave(XmlWriter writer) {
			throw new NotImplementedException();
		}
		public bool AutoResizeable {
			get {
				throw new NotImplementedException();
			}
		}
		public bool AutoResizeWidth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		public bool AutoResizeHeight {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
	}
}
