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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Xml;
using DiagramDrawer.Properties;
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	public class TextLabel : Box {
		protected override void DrawBackground(Graphics graphics) {
			Rectangle bounds = new Rectangle(Location.X, Location.Y, Width, Height);
			graphics.FillRectangle(BackBrush, bounds);
		}
	}
	public class Line : Box {
		readonly TextLabel _label = new TextLabel();
		public Line() {
			Location = Point.Empty;
			Start = Point.Empty;
			End = Point.Empty;
			ForegroundColor = Color.Black;
			_label.Height = 25;
			_label.Width = 75;
			Text = String.Empty;
			BackgroundColorChange += Line_BackgroundColorChange;
			ForegroundColorChange += Line_ForegroundColorChange;
		}
		void Line_ForegroundColorChange(object sender, EventArgs e) {
			_label.ForegroundColor = ForegroundColor;
		}
		void Line_BackgroundColorChange(object sender, EventArgs e) {
			_label.BackgroundColor = BackgroundColor;
		}
		bool _textchanged;
		protected override void OnTextChange() {
			_label.Text = Text;
			_textchanged = true;
			base.OnTextChange();
		}
		private IShape _origin;
		public IShape Origin {
			get {
				return _origin;
			}
			set {
				OnOriginChange(value);
			}
		}
		protected virtual void OnOriginChange(IShape value) {
			_origin = value;
			_origin.Moving += OnMoving;
			_origin.DragStart += OnDragStart;
			_origin.DragEnd += OnDragEnd;
			_origin.Deleted += OnDeleted;
			OnMoving(this, EventArgs.Empty);
		}
		void OnDeleted(object sender, EventArgs e) {
			ShapeContainer.RemoveShape(this);
		}
		private IShape _pointed;
		public IShape Pointed {
			get {
				return _pointed;
			}
			set {
				OnPointedChange(value);
			}
		}
		protected virtual void OnPointedChange(IShape value) {
			_pointed = value;
			_pointed.Moving += OnMoving;
			_pointed.DragStart += OnDragStart;
			_pointed.DragEnd += OnDragEnd;
			_pointed.Deleted += OnDeleted;
			OnMoving(this, EventArgs.Empty);
		}
		void OnDragEnd(object sender, EventArgs e) {
			Depends = false;
		}
		void OnDragStart(object sender, EventArgs e) {
			Depends = true;
		}
		protected virtual void OnMoving(object sender, EventArgs e) {
			Moved();
		}
		private void Moved() {
			if(_origin == null || _pointed == null ||
						 _origin.Contains(_pointed.Center) || _pointed.Contains(_origin.Center)) {
				Start = End = new PointF(0, 0);
			}
			else {
				Start = _origin.GetIntersection(_pointed.Center);
				End = _pointed.GetIntersection(_origin.Center);
				_label.SetLocation(new Point((int)(Start.X + End.X - _label.Width) / 2, (int)(Start.Y + End.Y - _label.Height) / 2));
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

		public override void DrawTo(Graphics graphics) {
			if(!ShouldDraw())
				return;
			graphics.DrawLine(BorderPen, Start, End);
			if(_textchanged) {
				_textchanged = false;
				if(_label.ShapeContainer == null)
					_label.ShapeContainer = ShapeContainer;
				_label.AutoResizeHeight = _label.AutoResizeWidth = true;
				_label.SetLocation(
					new Point(
						(int)(Start.X + End.X - _label.Width) / 2,
						(int)(Start.Y + End.Y - _label.Height) / 2
					));
			}
			if(_label.Text.Length > 0)
				_label.DrawTo(graphics);
		}
		protected virtual bool ShouldDraw() {
			return (Start.X != 0 || Start.Y == 0) && (End.X != 0 || End.Y != 0) && !Pointed.Contains(Start) && !Origin.Contains(End);
		}
		protected override void OnSizeChange() {
			_label.Width = Width;
			_label.Height = Height;
			base.OnSizeChange();
		}
		protected override Point VCenter {
			get {
				return new Point((int)((Start.X + End.X) / 2F), (int)((Start.Y + End.Y) / 2F));
			}
		}
		public override bool Contains(PointF point) {
			if((Start.X == 0 && Start.Y == 0) || (End.X == 0 && End.Y == 0))
				return false;
			return DistanceHelper.LinePointDist(Start, End, point, true) < 10;
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
		public override PointF GetIntersection(PointF other) {
			throw new NotImplementedException();
		}
		public override void Load(XmlReader reader) {
			while(!reader.EOF) {
				reader.Read();
				switch(reader.Name) {
					case "origin":
						ReadEndpoints(reader);
						break;
					case "pointed":
						ReadEndpoints(reader);
						break;
					case "name":
						ReadName(reader);
						break;
					case "font":
						ReadFont(reader);
						break;
					case "foregroundColor":
						ReadColors(reader);
						break;
					case "backgroundColor":
						ReadColors(reader);
						break;
					case "borderColor":
						ReadBorderColor(reader);
						break;
					case "text":
						ReadText(reader);
						break;
				}
			}
			//backwards compatiblity
			if(BackgroundColor == ForegroundColor)
				BackgroundColor = Color.FromArgb(255 - ForegroundColor.R, 255 - ForegroundColor.G, 255 - ForegroundColor.B);
		}
		private void ReadEndpoints(XmlReader reader) {
			if(reader.Name == "origin") {
				ReadEndpointCheck(reader);
				_originName = reader.Value;
			}
			else {
				ReadEndpointCheck(reader);
				_pointedName = reader.Value;
			}
		}
		private static void ReadEndpointCheck(XmlReader reader) {
			reader.MoveToAttribute("name");
			if(!reader.ReadAttributeValue())
				throw new ArgumentException("Cannot read endpoint");
		}
		public override void Save(XmlWriter writer) {
			SaveOrigin(writer);
			SavePointed(writer);
			SaveName(writer);
			SaveFont(writer);
			SaveColors(writer);
			SaveText(writer);
		}
		private void SavePointed(XmlWriter writer) {
			writer.WriteStartElement("pointed");
			writer.WriteAttributeString("name", _pointed.Name);
			writer.WriteEndElement();
		}
		private void SaveOrigin(XmlWriter writer) {
			writer.WriteStartElement("origin");
			writer.WriteAttributeString("name", _origin.Name);
			writer.WriteEndElement();
		}
		string _originName;
		string _pointedName;
		public override void EndInitialize(KeyedCollection<string, IShape> list) {
			Origin = list[_originName];
			Pointed = list[_pointedName];
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
		public override Image Image {
			get {
				return Resources.NoArrow;
			}
		}
		public override string ToString() {
			return "Linea semplice";
		}
		public override void SvgSave(XmlWriter writer) {
			Svg.WriteLine(writer, Start, End, BorderPen);
			Svg.WriteRectangle(writer, _label.Location, new Size(_label.Width, _label.Height), BackgroundColor, BackPen);
			Svg.WriteText(writer, _label.Center, ForegroundColor, Font, _label.Text);
		}
	}
	public class OneArrow : Line {
		const float Distanza = 10F;
		const float Apertura = 5F;
		PointF _l, _r;
		public override void DrawTo(Graphics graphics) {
			if(!ShouldDraw())
				return;
			base.DrawTo(graphics);
			graphics.FillPolygon(BorderBrush, new[] { _l, End, _r, _l });
		}
		private void Recalculate() {
			float otherPointX = Start.X - End.X;
			float otherPointY = Start.Y - End.Y;
			float m = otherPointY / otherPointX;
			if(otherPointX == 0) {
				float y = (End.Y > Start.Y) ? (End.Y - Distanza) : (End.Y + Distanza);
				_l.Y = _r.Y = y;
				_l.X = End.X - Apertura;
				_r.X = End.X + Apertura;
			}
			else
				if(otherPointY == 0) {
					float x = (End.X > Start.X) ? (End.X - Distanza) : (End.X + Distanza);
					_l.X = _r.X = x;
					_l.Y = End.Y - Apertura;
					_r.Y = End.Y + Apertura;
				}
				else {
					RecalculateMath(otherPointX, m, out _l, out _r);
				}
		}
		private void RecalculateMath(float otherPointX, float m, out PointF l, out PointF r) {
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
			l = r = new PointF();
			var cross = new PointF {
				X = Distanza / (float)Math.Sqrt(1F + m * m)
			};
			if(otherPointX < 0)
				cross.X = -cross.X;
			cross.Y = cross.X * m;
			float inverseM = -1F / m;
			//y=mx+q
			//q=y-mx
			float inverseQ = cross.Y - inverseM * cross.X;
			//apertura=h
			//h^2=(mx-lx)^2+(my-ly)^2
			//h^2=mx^2-2mxlx+lx^2+2my^2-2my(imlx+iq)+(imlx+iq)^2
			//lx^2-2mxlx-2myimlx+(imlx+iq)^2-h^2+mx^2+2my^2-2myiq=0
			//lx^2+(-2mx-2myim)lx+im^2lx^2+2imlxiq+iq^2-h^2+mx^2+2my^2-2myiq=0
			//(im^2+1)lx^2+2(imiq-mx-myim)lx+iq^2-h^2+mx^2+2my^2-2myiq=0
			float a = inverseM * inverseM + 1;
			float b = 2 * (inverseM * inverseQ - cross.X - cross.Y * inverseM);
			float discriminant = inverseQ * inverseQ - Apertura * Apertura + cross.X * cross.X +
				2 * cross.Y * cross.Y - 2 * cross.Y * inverseQ;
			var discriminantRoot = (float)Math.Sqrt(discriminant);
			l.X = (-b + discriminantRoot) / (2F * a);
			l.Y = l.X * inverseM + inverseQ;
			l.X += End.X;
			l.Y += End.Y;
			r.X = (-b - discriminantRoot) / (2F * a);
			r.Y = r.X * inverseM + inverseQ;
			r.X += End.X;
			r.Y += End.Y;
		}
		public override Image Image {
			get {
				return Resources.OneArrow;
			}
		}
		public override string ToString() {
			return "Punta singola";
		}
		protected override void OnMoving(object sender, EventArgs e) {
			base.OnMoving(sender, e);
			Recalculate();
		}
		public override void SvgSave(XmlWriter writer) {
			base.SvgSave(writer);
			Svg.WritePolygon(writer, new[] { _l, End, _r, _l }, BorderColor);
		}
	}
	public class TwoArrows : OneArrow {
		public override Image Image {
			get {
				return Resources.TwoArrows;
			}
		}
		public override void DrawTo(Graphics graphics) {
			if(!ShouldDraw())
				return;
			base.DrawTo(graphics);
			Swap();
			base.DrawTo(graphics);
			Swap();
		}
		private void Swap() {
			IShape c = Pointed;
			Pointed = Origin;
			Origin = c;
		}
		public override string ToString() {
			return "Doppia freccia";
		}
		public override void SvgSave(XmlWriter writer) {
			base.SvgSave(writer);
			Swap();
			base.SvgSave(writer);
			Swap();
		}
	}
	public class NoArrowFragmented : Line {
		public override Image Image {
			get {
				return Resources.NoArrowFragmented;
			}
		}
		protected override void OnOriginChange(IShape value) {
			SubLines[0].Origin = value;
			base.OnOriginChange(value);
		}
		protected override void OnPointedChange(IShape value) {
			SubLines[2].Pointed = value;
			base.OnPointedChange(value);
		}

		protected List<InvisiblePoint> SubPoints {
			get;
			private set;
		}

		protected List<Line> SubLines {
			get;
			private set;
		}

		public NoArrowFragmented() {
			SubLines = new List<Line>();
			SubPoints = new List<InvisiblePoint>();
			for(int c = 0; c < 3; c++)
				SubLines.Add(new Line());
			for(int i = 0; i < 2; i++)
				SubPoints.Add(new InvisiblePoint());
			//origin--l1--m[0]
			//            |
			//            l2
			//            |
			//            m[1]--l3--pointed
			if(Origin != null)
				SubLines[0].Origin = Origin;
			SubLines[0].Pointed = SubPoints[0];
			SubLines[1].Origin = SubPoints[0];
			SubLines[1].Pointed = SubPoints[1];
			SubLines[2].Origin = SubPoints[1];
			if(Pointed != null)
				SubLines[2].Pointed = Pointed;
			ForegroundColorChange += Fragmented_ForegroundColorChange;
			BackgroundColorChange += Fragmented_BackgroundColorChange;
			BorderColorChange += Fragmented_BorderColorChange;
		}
		void Fragmented_BorderColorChange(object sender, EventArgs e) {
			foreach(Line l in SubLines)
				l.BorderColor = BorderColor;
		}
		void Fragmented_BackgroundColorChange(object sender, EventArgs e) {
			SubLines[1].BackgroundColor = BackgroundColor;
		}
		void Fragmented_ForegroundColorChange(object sender, EventArgs e) {
			SubLines[1].ForegroundColor = ForegroundColor;
		}
		protected override void OnMoving(object sender, EventArgs e) {
			base.OnMoving(sender, e);
			Moved();
		}
		protected override bool ShouldDraw() {
			return Origin != null && Pointed != null && ShapeContainer != null && base.ShouldDraw();
		}
		public override void DrawTo(Graphics graphics) {
			SetShapeContainer();
			if(!ShouldDraw())
				return;
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if(dx == 0 || dy == 0)
				base.DrawTo(graphics);
			else
				foreach(Line l in SubLines)
					l.DrawTo(graphics);
		}
		private void Moved() {
			if(!ShouldDraw())
				return;
			SetShapeContainer();
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if(Math.Abs(dy) > (Origin.Height / 2 + Pointed.Height / 2 + 40)) {
				SubPoints[0].Move(new Point(Origin.Center.X, Origin.Center.Y - (int)dy / 2));
				SubPoints[1].Move(new Point(Pointed.Center.X, Origin.Center.Y - (int)dy / 2));
			}
			else {
				SubPoints[0].Move(new Point(Origin.Center.X - (int)dx / 2, Origin.Center.Y));
				SubPoints[1].Move(new Point(Origin.Center.X - (int)dx / 2, Pointed.Center.Y));
			}
			if(Origin.Contains(SubPoints[0].Location) || Pointed.Contains(SubPoints[1].Location)) {
				PointF m1Int = Origin.GetIntersection(Pointed.Center);
				SubPoints[0].Move(new Point(Origin.Center.X - (int)(dx / 2), (int)m1Int.Y));
				PointF m2Int = Pointed.GetIntersection(Origin.Center);
				SubPoints[1].Move(new Point(Origin.Center.X - (int)(dx / 2), (int)m2Int.Y));
			}
		}
		protected void SetShapeContainer() {
			if(SubPoints[0].ShapeContainer == null) {
				foreach(Line l in SubLines)
					l.ShapeContainer = ShapeContainer;
				foreach(InvisiblePoint m in SubPoints)
					m.ShapeContainer = ShapeContainer;
			}
		}
		public override bool Contains(PointF point) {
			return SubLines.Any(l => l.Contains(point));
		}

		protected override void OnTextChange() {
			if(SubLines.Count > 1)
				SubLines[1].Text = Text;
			base.OnTextChange();
		}
		public override string ToString() {
			return "Spezzata";
		}
		public override void SvgSave(XmlWriter writer) {
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if(dx == 0 || dy == 0)
				base.SvgSave(writer);
			else
				foreach(Line l in SubLines)
					l.SvgSave(writer);
		}
	}
	public class OneArrowFragmented : NoArrowFragmented {
		public override void DrawTo(Graphics graphics) {
			SetShapeContainer();
			if(!ShouldDraw())
				return;
			int c = SubLines.Count - 1;
			if(!(SubLines[c] is OneArrow)) {
				SubLines[c] = new OneArrow {
					Origin = SubPoints[1]
				};
				if(Pointed != null)
					SubLines[c].Pointed = Pointed;
			}
			base.DrawTo(graphics);
		}
		public override string ToString() {
			return "Spezzata con freccia";
		}
		public override Image Image {
			get {
				return Resources.OneArrowFragmented;
			}
		}
	}
	public class TwoArrowsFragmented : OneArrowFragmented {
		public override void DrawTo(Graphics graphics) {
			SetShapeContainer();
			if(!ShouldDraw())
				return;
			if(!(SubLines[0] is OneArrow)) {
				SubLines[0] = new OneArrow {
					Origin = SubPoints[0]
				};
				if(Origin != null)
					SubLines[0].Pointed = Origin;
			}
			base.DrawTo(graphics);
		}
		public override string ToString() {
			return "Spezzata con doppia freccia";
		}
		public override Image Image {
			get {
				return Resources.TwoArrowsFragmented;
			}
		}
	}
	public class OneArrowAngle : OneArrow {
		public override Image Image {
			get {
				return Resources.OneArrowAngle;
			}
		}
		protected override void OnOriginChange(IShape value) {
			SubLines[0].Origin = value;
			base.OnOriginChange(value);
		}
		protected override void OnPointedChange(IShape value) {
			SubLines[1].Pointed = value;
			base.OnPointedChange(value);
		}

		private List<InvisiblePoint> SubPoints {
			get;
			set;
		}

		protected List<Line> SubLines {
			get;
			private set;
		}

		bool _reverse;
		public OneArrowAngle() {
			SubLines = new List<Line>();
			SubPoints = new List<InvisiblePoint>();
			SubLines.Add(new Line());
			SubLines.Add(new OneArrow());
			SubPoints.Add(new InvisiblePoint());
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
			if(Origin != null)
				SubLines[0].Origin = Origin;
			SubLines[0].Pointed = SubPoints[0];
			SubLines[1].Origin = SubPoints[0];
			if(Pointed != null)
				SubLines[1].Pointed = Pointed;
			ForegroundColorChange += Fragmented_ForegroundColorChange;
			BackgroundColorChange += Fragmented_BackgroundColorChange;
			BorderColorChange += Fragmented_BorderColorChange;
			ContextMenu.MenuItems.Add("Inverti", delegate {
				_reverse ^= true;
				ShapeContainer.ForceRefresh();
			});
		}
		void Fragmented_BorderColorChange(object sender, EventArgs e) {
			foreach(Line l in SubLines)
				l.BorderColor = BorderColor;
		}
		void Fragmented_BackgroundColorChange(object sender, EventArgs e) {
			foreach(Line l in SubLines)
				l.BackgroundColor = BackgroundColor;
		}
		void Fragmented_ForegroundColorChange(object sender, EventArgs e) {
			foreach(Line l in SubLines)
				l.ForegroundColor = ForegroundColor;
		}
		protected override void OnMoving(object sender, EventArgs e) {
			base.OnMoving(sender, e);
			Moved();
		}
		public override void DrawTo(Graphics graphics) {
			CheckShapeContainer();
			if(!ShouldDraw())
				return;
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if(dx == 0 || dy == 0)
				base.DrawTo(graphics);
			else
				foreach(Line l in SubLines)
					l.DrawTo(graphics);
		}
		private void Moved() {
			if(Origin == null || Pointed == null || ShapeContainer == null)
				return;
			CheckShapeContainer();
			/*float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;*/
			SubPoints[0].Move(_reverse
								? new Point(Pointed.Center.X, Origin.Center.Y)
								: new Point(Origin.Center.X, Pointed.Center.Y));
			if(Origin.Contains(SubPoints[0].Location)) {
				PointF m1Int = Origin.GetIntersection(Pointed.Center);
				SubPoints[0].Move(new Point((int)m1Int.X, Pointed.Center.Y));
			}
			else
				if(Pointed.Contains(SubPoints[0].Location)) {
					PointF m1Int = Origin.GetIntersection(Pointed.Center);
					SubPoints[0].Move(new Point(Pointed.Center.X, (int)m1Int.Y));
				}
		}
		private void CheckShapeContainer() {
			if(SubPoints[0].ShapeContainer == null) {
				foreach(Line l in SubLines)
					l.ShapeContainer = ShapeContainer;
				foreach(InvisiblePoint m in SubPoints)
					m.ShapeContainer = ShapeContainer;
			}
		}
		protected override void OnTextChange() {
			if(SubLines.Count > 1)
				SubLines[_reverse ? 0 : 1].Text = Text;
		}
		public override bool Contains(PointF point) {
			return SubLines.Any(l => l.Contains(point));
		}

		public override string ToString() {
			return "Ad angolo";
		}
		public override void SvgSave(XmlWriter writer) {
			float dx = Origin.Center.X - Pointed.Center.X;
			float dy = Origin.Center.Y - Pointed.Center.Y;
			if(dx == 0 || dy == 0)
				base.SvgSave(writer);
			else
				foreach(Line l in SubLines)
					l.SvgSave(writer);
		}
	}
	public class TwoArrowsAngle : OneArrowAngle {
		public override void DrawTo(Graphics graphics) {
			if(!(SubLines[0] is OneArrow)) {
				Line l = SubLines[0];
				SubLines[0] = new OneArrow {
					Origin = l.Pointed,
					Pointed = l.Origin
				};
			}
			base.DrawTo(graphics);
		}
		public override Image Image {
			get {
				return Resources.TwoArrowsAngle;
			}
		}
		public override string ToString() {
			return "Ad angolo con doppia freccia";
		}
	}
}
