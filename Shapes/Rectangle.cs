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
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using DiagramDrawer.Forms;
using DiagramDrawer.Properties;
using DiagramDrawer.Export;

namespace DiagramDrawer.Shapes {
	public class Box : IShape {
		public Font Font {
			protected get;
			set;
		}

		string _text;
		public string Text {
			get {
				return _text;
			}
			set {
				_text = value;
				OnTextChange();
			}
		}
		protected virtual void OnTextChange() {
			if(AutoResizeWidth || AutoResizeHeight)
				DoAutoResize();
		}

		protected Brush BackBrush {
			get;
			private set;
		}

		protected Pen BackPen {
			get;
			private set;
		}
		Color _backgroundColor;
		public Color BackgroundColor {
			protected get {
				return _backgroundColor;
			}
			set {
				_backgroundColor = value;
				OnBackgroundColorChange();
			}
		}
		public event EventHandler BackgroundColorChange;

		private void OnBackgroundColorChange() {
			if(BackBrush != null)
				BackBrush.Dispose();
			if(BackPen != null)
				BackPen.Dispose();
			BackBrush = new SolidBrush(_backgroundColor);
			BackPen = new Pen(_backgroundColor);
			if(BackgroundColorChange != null)
				BackgroundColorChange(this, EventArgs.Empty);
		}


		protected Brush ForeBrush {
			get;
			private set;
		}

		protected Pen ForePen {
			get;
			private set;
		}

		Color _foregroundColor;
		public Color ForegroundColor {
			get {
				return _foregroundColor;
			}
			set {
				_foregroundColor = value;
				if(ForeBrush != null)
					ForeBrush.Dispose();
				if(ForePen != null)
					ForePen.Dispose();
				ForeBrush = new SolidBrush(_foregroundColor);
				ForePen = new Pen(_foregroundColor);
				if(ForegroundColorChange != null)
					ForegroundColorChange(this, EventArgs.Empty);
			}
		}
		public event EventHandler ForegroundColorChange;

		public event EventHandler BorderColorChange;
		protected Pen BorderPen {
			get;
			private set;
		}

		protected Brush BorderBrush {
			get;
			private set;
		}

		Color _borderColor;

		public Color BorderColor {
			get {
				return _borderColor;
			}
			set {
				if(ForeBrush != null)
					ForeBrush.Dispose();
				if(ForePen != null)
					ForePen.Dispose();
				ForeBrush = new SolidBrush(_foregroundColor);
				ForePen = new Pen(_foregroundColor);
				if(ForegroundColorChange != null)
					ForegroundColorChange(this, EventArgs.Empty);


				_borderColor = value;
				if(BorderBrush != null)
					BorderBrush.Dispose();
				if(BorderPen != null)
					BorderPen.Dispose();
				BorderBrush = new SolidBrush(_borderColor);
				BorderPen = new Pen(_borderColor);
				if(BorderColorChange != null)
					BorderColorChange(this, EventArgs.Empty);
			}
		}

		public Box() {
			Center = new Point();
			_height = 50;
			_width = 100;
			BackgroundColor = Color.White;
			ForegroundColor = Color.Black;
			BorderColor = Color.Black;
			_text = String.Empty;
			Font = SystemFonts.DefaultFont;
			cm.MenuItems.Add("Elimina", DelClick);
			cm.MenuItems.Add("Dimensione", SizeClick);
			cm.MenuItems.Add("Porta in primo piano", ForeBring);
		}
		void ForeBring(object sender, EventArgs e) {
			ShapeContainer.BringForeground(this);
		}
		void DelClick(object sender, EventArgs e) {
			new MethodInvoker(Delete).BeginInvoke(null, null);
		}
		void SizeClick(object sender, EventArgs e) {
			new SizeForm(this).Show();
		}
		public virtual bool Contains(PointF point) {
			return point.X > Location.X && point.X < Location.X + Width && point.Y > Location.Y && point.Y < Location.Y + Height;
		}
		public virtual void DrawTo(Graphics graphics) {
			DrawBackground(graphics);
			DrawText(graphics);
		}
		protected virtual void DrawBackground(Graphics graphics) {
			var bounds = new Rectangle(Location.X, Location.Y, Width, Height);
			graphics.FillRectangle(BackBrush, bounds);
			graphics.DrawRectangle(BorderPen, bounds);
		}

		private void DrawText(Graphics graphics) {
			var sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			graphics.DrawString(Text, Font, ForeBrush, Center, sf);
		}

		public Point Center {
			get;
			private set;
		}

		public virtual PointF GetIntersection(PointF other) {
			float r = Height;
			r /= Width;
			float l = -r;
			PointF c = Center;
			float ox = other.X - c.X;
			float oy = other.Y - c.Y;
			if(ox == 0)
				return new PointF(c.X, c.Y + Height / 2F * Math.Sign(oy));
			float m = oy / ox;
			float x, y;
			if(l < m && m < r) {
				x = Width / 2F * Math.Sign(ox);
				y = m * x;
			}
			else {
				y = Height / 2F * Math.Sign(oy);
				x = y / m;
			}
			return new PointF(x + c.X, y + c.Y);
		}
		ContextMenu cm = new ContextMenu();
		protected ContextMenu ContextMenu {
			get {
				return cm;
			}
		}
		public virtual void OpenMenu(PointF point) {
			cm.Show(ShapeContainer, new Point((int)point.X, (int)point.Y));
		}
		protected void Delete() {
			ShapeContainer.RemoveShape(this);
			if(Deleted != null)
				Deleted(this, EventArgs.Empty);
		}
		public void Move(Point point) {
			int x = point.X - Offset.X;
			if(x < 0)
				x = 0;
			if(x + Width > ShapeContainer.Width)
				x = ShapeContainer.Width - Width;
			int y = point.Y - Offset.Y;
			if(y < 0)
				y = 0;
			if(y + Height > ShapeContainer.Height)
				y = ShapeContainer.Height - Height;
			Location = new Point(x, y);
			if(ShapeContainer.Grid)
				Location = ShapeContainer.CutToGrid(Location);
			if(Moving != null)
				Moving(this, EventArgs.Empty);
		}
		public override string ToString() {
			return "Rettangolo";
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
		Point _location;
		public Point Location {
			get {
				return _location;
			}
			protected set {
				_location = value;
				Center = VCenter;
			}
		}
		/// <summary>
		/// For optimization issues, this is the "true" center proprierty, whereas Center is just a "buffer"
		/// </summary>
		protected virtual Point VCenter {
			get {
				return new Point(Location.X + Width / 2, Location.Y + Height / 2);
			}
		}

		public Point Offset {
			get;
			set;
		}

		int _width;
		public int Width {
			get {
				return _width;
			}
			set {
				_width = value;
				OnSizeChange();
			}
		}
		protected virtual void OnSizeChange() {
			Center = VCenter;
		}
		int _height;
		public int Height {
			get {
				return _height;
			}
			set {
				_height = value;
				OnSizeChange();
			}
		}
		public event EventHandler Moving;
		public bool Depends {
			get;
			set;
		}

		public event EventHandler DragStart;
		public event EventHandler DragEnd;
		public event EventHandler Deleted;
		public string Name {
			get;
			set;
		}

		public virtual void BeginInitialize() {
		}
		public virtual void EndInitialize(KeyedCollection<string, IShape> list) {
		}
		public virtual bool NeedInitialize {
			get {
				return false;
			}
		}
		public virtual void Load(XmlReader reader) {
			while(!reader.EOF) {
				reader.Read();
				switch(reader.Name) {
					case "name":
						ReadName(reader);
						break;
					case "location":
						ReadLocation(reader);
						break;
					case "size":
						ReadSize(reader);
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
					case "autoresizewidth":
						ReadAutoResize(reader);
						break;
					case "autoresizeheight":
						ReadAutoResize(reader);
						break;
				}
			}
		}
		private void ReadAutoResize(XmlReader reader) {
			switch(reader.Name) {
				case "autoresizeheight":
					string s = reader.ReadString();
					if(s.Length == 0)
						return;
					AutoResizeHeight = bool.Parse(s);
					break;
				case "autoresizewidth":
					string s2 = reader.ReadString();
					if(s2.Length == 0)
						return;
					AutoResizeWidth = bool.Parse(s2);
					break;
			}
		}
		protected void ReadName(XmlReader reader) {
			Name = reader.ReadString();
		}
		protected void ReadBorderColor(XmlReader reader) {
			BorderColor = DeserializeColor(reader.ReadString());
		}
		protected void ReadText(XmlReader reader) {
			Text = reader.ReadString().Replace(@"\n", Environment.NewLine);
		}
		protected void ReadColors(XmlReader reader) {
			switch(reader.Name) {
				case "foregroundColor":
					ForegroundColor = DeserializeColor(reader.ReadString());
					break;
				case "backgroundColor":
					BackgroundColor = DeserializeColor(reader.ReadString());
					break;
				case "borderColo":
					BorderColor = DeserializeColor(reader.ReadString());
					break;
			}
		}
		protected void ReadFont(XmlReader reader) {
			reader.ReadStartElement("font");
			reader.ReadStartElement("name");
			string fontName = reader.ReadString();
			reader.ReadEndElement();
			reader.ReadStartElement("unit");
			GraphicsUnit fontUnit = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), reader.ReadString());
			reader.ReadEndElement();
			reader.ReadStartElement("size");
			string val = reader.ReadString();
			val = val.Replace(',', '.');//HACK: find a way to understand numbers culture-invariantly
			float fontSize = float.Parse(val, CultureInfo.InvariantCulture);
			reader.ReadEndElement();
			reader.ReadStartElement("style");
			FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), reader.ReadString());
			Font = new Font(fontName, fontSize, fontStyle, fontUnit);
			reader.ReadEndElement();
		}
		protected void ReadSize(XmlReader reader) {
			reader.ReadToFollowing("width");
			Width = reader.ReadElementContentAsInt();
			Height = reader.ReadElementContentAsInt();
		}
		protected void ReadLocation(XmlReader reader) {
			reader.ReadToFollowing("x");
			int x = reader.ReadElementContentAsInt();
			int y = reader.ReadElementContentAsInt();
			Location = new Point(x, y);
		}
		public virtual void Save(XmlWriter writer) {
			SaveName(writer);
			SaveLocation(writer);
			SaveSize(writer);
			SaveFont(writer);
			SaveColors(writer);
			SaveText(writer);
			SaveAuto(writer);
		}
		private void SaveAuto(XmlWriter writer) {
			writer.WriteElementString("autoresizewidth", AutoResizeWidth.ToString());
			writer.WriteElementString("autoresizeheight", AutoResizeHeight.ToString());
		}
		protected void SaveText(XmlWriter writer) {
			writer.WriteElementString("text", Text.Replace(Environment.NewLine, "\\n"));
		}
		protected void SaveColors(XmlWriter writer) {
			writer.WriteElementString("foregroundColor", SerializeColor(ForegroundColor));
			writer.WriteElementString("backgroundColor", SerializeColor(BackgroundColor));
			writer.WriteElementString("borderColor", SerializeColor(BorderColor));
		}
		protected void SaveName(XmlWriter writer) {
			writer.WriteElementString("name", Name);
		}
		protected void SaveSize(XmlWriter writer) {
			writer.WriteStartElement("size");
			writer.WriteElementString("width", Width.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("height", Height.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
		}
		protected void SaveLocation(XmlWriter writer) {
			writer.WriteStartElement("location");
			writer.WriteElementString("x", Location.X.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("y", Location.Y.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
		}
		protected void SaveFont(XmlWriter writer) {
			writer.WriteStartElement("font");
			writer.WriteElementString("name", Font.FontFamily.Name);
			writer.WriteElementString("unit", Font.Unit.ToString());
			writer.WriteElementString("size", Font.Size.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("style", Font.Style.ToString());
			writer.WriteEndElement();
		}
		enum ColorFormat {
			NamedColor,
			ArgbColor
		}

		private static string SerializeColor(Color color) {
			if(color.IsNamedColor)
				return string.Format(CultureInfo.InvariantCulture, "{0}:{1}",
					ColorFormat.NamedColor, color.Name);
			return string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}:{3}:{4}",
								 ColorFormat.ArgbColor,
								 color.A, color.R, color.G, color.B);
		}

		private static Color DeserializeColor(string color) {
			string[] pieces = color.Split(new[] { ':' });

			var colorType = (ColorFormat)
				Enum.Parse(typeof(ColorFormat), pieces[0], true);

			switch(colorType) {
				case ColorFormat.NamedColor:
					return Color.FromName(pieces[1]);

				case ColorFormat.ArgbColor:
					byte a = byte.Parse(pieces[1], CultureInfo.InvariantCulture);
					byte r = byte.Parse(pieces[2], CultureInfo.InvariantCulture);
					byte g = byte.Parse(pieces[3], CultureInfo.InvariantCulture);
					byte b = byte.Parse(pieces[4], CultureInfo.InvariantCulture);

					return Color.FromArgb(a, r, g, b);
			}
			return Color.Empty;
		}

		public ShapeContainer ShapeContainer {
			get;
			set;
		}

		public virtual bool Linkable {
			get {
				return true;
			}
		}
		public virtual Image Image {
			get {
				return Resources.Rectangle;
			}
		}
		public void Refresh() {
			ShapeContainer.ForceRefresh();
		}
		public void SetLocation(Point point) {
			Location = point;
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing) {
			if(!disposing)
				return;
			BackBrush.Dispose();
			ForeBrush.Dispose();
			BorderBrush.Dispose();
			BackPen.Dispose();
			ForePen.Dispose();
			BorderPen.Dispose();
			Font.Dispose();
			cm.Dispose();
		}
		protected void DoAutoResize() {
			if(!(AutoResizeHeight || AutoResizeWidth) || ShapeContainer == null)
				return;
			using(Graphics g = ShapeContainer.CreateGraphics()) {
				SizeF size = g.MeasureString(Text, Font);
				if(AutoResizeWidth) {
					int w = (int)size.Width + 10;
					if(w < Options.MinimumWidth)
						Width = Options.MinimumWidth;
					else
						Width = w;
				}
				if(AutoResizeHeight) {
					int h = (int)size.Height + 5;
					if(h < Options.MinimumHeight)
						Height = Options.MinimumHeight;
					else
						Height = h;
				}
				ShapeContainer.ForceRefresh();
			}
		}
		public virtual void SvgSave(XmlWriter writer) {
			Svg.WriteRectangle(writer, Location, new Size(Width, Height), BackgroundColor, BorderPen);
			Svg.WriteText(writer, Center, ForegroundColor, Font, Text);
		}
		public bool AutoResizeable {
			get {
				return true;
			}
		}
		bool _autoresizewidth;
		public bool AutoResizeWidth {
			get {
				return _autoresizewidth;
			}
			set {
				_autoresizewidth = value;
				if(value)
					DoAutoResize();
			}
		}
		bool _autoresizeheight;
		public bool AutoResizeHeight {
			get {
				return _autoresizeheight;
			}
			set {
				_autoresizeheight = value;
				if(value)
					DoAutoResize();
			}
		}
	}
}
