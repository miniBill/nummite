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
using System.Collections.ObjectModel;
using System.Drawing;
using Nummite.Forms;

namespace Nummite.Shapes.Interfaces {
	interface IShape : IDisposable, IDimension {
		bool Contains(PointF point);

		bool Dragged { get; set; }

		bool Depends { get; }

		void OpenMenu(PointF point);

		void DrawTo(Graphics graphics);

		bool Linkable { get; }

		ShapeContainer ShapeContainer { set; }

		Point Location { get; }

		Point Offset { set; }

		string Text { get; set; }

		void Move(Point point);

		event EventHandler Moving;
		event EventHandler DragStart;
		event EventHandler DragEnd;
		event EventHandler Deleted;

		Point Center { get; }

		PointF GetIntersection(PointF other);

		void SetLocation(Point point);

		void MoveCenter(Point center);
	}
}
