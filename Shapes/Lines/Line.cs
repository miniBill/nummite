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
using System.Xml;
using Nummite.Export;
using Nummite.Properties;

namespace Nummite.Shapes.Lines {
	class Line : Box
	{
		readonly TextLabel label = new TextLabel ();

		public Line ()
		{
			Location = Point.Empty;
			Start = Point.Empty;
			End = Point.Empty;
			ForegroundColor = Color.Black;
			label.Height = 25;
			label.Width = 75;
			Text = String.Empty;
			BackgroundColorChange += Line_BackgroundColorChange;
			ForegroundColorChange += Line_ForegroundColorChange;
		}

		void Line_ForegroundColorChange (object sender, EventArgs e)
		{
			label.ForegroundColor = ForegroundColor;
		}

		void Line_BackgroundColorChange (object sender, EventArgs e)
		{
			label.BackgroundColor = BackgroundColor;
		}

		bool textchanged;

		protected override void OnTextChange ()
		{
			label.Text = Text;
			textchanged = true;
			base.OnTextChange ();
		}

		IShape origin;

		public IShape Origin {
			get {
				return origin;
			}
			set {
				OnOriginChange (value);
			}
		}

		protected virtual void OnOriginChange (IShape value)
		{
			origin = value;
			origin.Moving += OnMoving;
			origin.DragStart += OnDragStart;
			origin.DragEnd += OnDragEnd;
			origin.Deleted += OnDeleted;
			OnMoving (this, EventArgs.Empty);
		}

		void OnDeleted (object sender, EventArgs e)
		{
			ShapeContainer.RemoveShape (this);
		}

		IShape pointed;

		public IShape Pointed {
			get {
				return pointed;
			}
			set {
				OnPointedChange (value);
			}
		}

		protected virtual void OnPointedChange (IShape value)
		{
			pointed = value;
			pointed.Moving += OnMoving;
			pointed.DragStart += OnDragStart;
			pointed.DragEnd += OnDragEnd;
			pointed.Deleted += OnDeleted;
			OnMoving (this, EventArgs.Empty);
		}

		void OnDragEnd (object sender, EventArgs e)
		{
			Depends = false;
		}

		void OnDragStart (object sender, EventArgs e)
		{
			Depends = true;
		}

		protected virtual void OnMoving (object sender, EventArgs e)
		{
			Moved ();
		}

		void Moved ()
		{
			if (origin == null || pointed == null ||
			    origin.Contains (pointed.Center) || pointed.Contains (origin.Center)) {
				Start = End = new PointF (0, 0);
			} else {
				Start = origin.GetIntersection (pointed.Center);
				End = pointed.GetIntersection (origin.Center);
				label.SetLocation (new Point ((int)(Start.X + End.X - label.Width) / 2, (int)(Start.Y + End.Y - label.Height) / 2));
			}
		}

		protected PointF Start {
			get;
			private set;
		}

		protected PointF End {
			get;
			private set;
		}

		public override void DrawTo (Graphics graphics)
		{
			if (!ShouldDraw ())
				return;
			graphics.DrawLine (BorderPen, Start, End);
			if (textchanged) {
				textchanged = false;
				if (label.ShapeContainer == null)
					label.ShapeContainer = ShapeContainer;
				label.AutoResizeHeight = label.AutoResizeWidth = true;
				label.SetLocation (
					new Point (
						(int)(Start.X + End.X - label.Width) / 2,
						(int)(Start.Y + End.Y - label.Height) / 2
					));
			}
			if (label.Text.Length > 0)
				label.DrawTo (graphics);
		}

		protected virtual bool ShouldDraw ()
		{
			return (Math.Abs(Start.X) > Options.TOLERANCE || Math.Abs(Start.Y) < Options.TOLERANCE)
				&& (Math.Abs(End.X) > Options.TOLERANCE || Math.Abs(End.Y) > Options.TOLERANCE)
				&& !Pointed.Contains(Start) && !Origin.Contains(End);
		}

		protected override void OnSizeChange ()
		{
			label.Width = Width;
			label.Height = Height;
			base.OnSizeChange ();
		}

		protected override Point VCenter {
			get {
				return new Point ((int)((Start.X + End.X) / 2F), (int)((Start.Y + End.Y) / 2F));
			}
		}

		public override bool Contains (PointF point)
		{
			return (Math.Abs(Start.X) > Options.TOLERANCE || Math.Abs(Start.Y) > Options.TOLERANCE)
				&& (Math.Abs(End.X) > Options.TOLERANCE || Math.Abs(End.Y) > Options.TOLERANCE)
				&& DistanceHelper.LinePointDist(Start, End, point, true) < 10;
			/*
			//caso ay=by
			//y=k
			//0x+1y-k=0
			float la = 0, lb = 1, lc = -a.Y;
			//else
			if(a.Y != b.Y) {
				if(a.X == b.X) {
					//x=k
					//1x+0y-k=0
					la = 1;
					lb = 0;
					lc = -a.X;
				}
				else {
					//ax+y+c=0
					//a(xa)+ya+c=0
					//a(xb)+yb+c=0
					//a(xa-xb)+ya-yb=0
					//a(xa-xb)=yb-ya
					//a=(yb-ya)/(xa-xb)
					//c=-ya-a(xa)
					la = (b.Y - a.Y) / (a.X - b.X);
					lb = 1;
					lc = -a.Y - la * a.X;
				}
			}
			float d = Math.Abs(la * point.X + lb * point.Y + lc) / (float)Math.Sqrt(la * la + lb * lb);
			return d < 10;
			 * */
		}

		public override PointF GetIntersection (PointF other)
		{
			throw new NotImplementedException ();
		}

		public override void Load (XmlReader reader)
		{
			while (!reader.EOF) {
				reader.Read ();
				switch (reader.Name) {
					case "origin":
						ReadEndpoints (reader);
						break;
					case "pointed":
						ReadEndpoints (reader);
						break;
					case "name":
						ReadName (reader);
						break;
					case "font":
						ReadFont (reader);
						break;
					case "foregroundColor":
						ReadColors (reader);
						break;
					case "backgroundColor":
						ReadColors (reader);
						break;
					case "borderColor":
						ReadBorderColor (reader);
						break;
					case "text":
						ReadText (reader);
						break;
				}
			}
			//backwards compatiblity
			if (BackgroundColor == ForegroundColor)
				BackgroundColor = Color.FromArgb (255 - ForegroundColor.R, 255 - ForegroundColor.G, 255 - ForegroundColor.B);
		}

		void ReadEndpoints (XmlReader reader)
		{
			if (reader.Name == "origin") {
				ReadEndpointCheck (reader);
				originName = reader.Value;
			} else {
				ReadEndpointCheck (reader);
				pointedName = reader.Value;
			}
		}

		static void ReadEndpointCheck (XmlReader reader)
		{
			reader.MoveToAttribute ("name");
			if (!reader.ReadAttributeValue ())
				throw new ArgumentException ("Cannot read endpoint");
		}

		public override void Save (XmlWriter writer)
		{
			SaveOrigin (writer);
			SavePointed (writer);
			SaveName (writer);
			SaveFont (writer);
			SaveColors (writer);
			SaveText (writer);
		}

		void SavePointed (XmlWriter writer)
		{
			writer.WriteStartElement ("pointed");
			writer.WriteAttributeString ("name", pointed.Name);
			writer.WriteEndElement ();
		}

		void SaveOrigin (XmlWriter writer)
		{
			writer.WriteStartElement ("origin");
			writer.WriteAttributeString ("name", origin.Name);
			writer.WriteEndElement ();
		}

		string originName;
		string pointedName;

		public override void EndInitialize (KeyedCollection<string, IShape> list)
		{
			Origin = list [originName];
			Pointed = list [pointedName];
		}

		public override bool NeedInitialize {
			get {
				return true;
			}
		}

		public override bool Linkable {
			get {
				return false;
			}
		}

		public readonly static new ILineCreator Creator = new LineCreator<Line> (Description, Resources.NoArrow);

		public static new string Description {
			get {
				return "Linea semplice";
			} 
		}

		public override void SvgSave (XmlWriter writer)
		{
			Svg.WriteLine (writer, Start, End, BorderPen);
			Svg.WriteRectangle (writer, label.Location, new Size (label.Width, label.Height), BackgroundColor, BackPen);
			Svg.WriteText (writer, label.Center, ForegroundColor, Font, label.Text);
		}
	}
}
