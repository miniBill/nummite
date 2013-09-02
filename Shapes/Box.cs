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
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using Nummite.Forms;
using Nummite.Properties;
using Nummite.Export;

namespace Nummite.Shapes {
	class Box : IPersistableShape, IAutoSizeable, IStyleable
	{
		public Font Font {
			protected get;
			set;
		}

		string text;

		public string Text {
			get {
				return text;
			}
			set {
				text = value;
				OnTextChange ();
			}
		}

		protected virtual void OnTextChange ()
		{
			if (AutoResizeWidth || AutoResizeHeight)
				DoAutoResize ();
		}

		protected Brush BackBrush {
			get;
			private set;
		}

		protected Pen BackPen {
			get;
			private set;
		}

		Color backgroundColor;

		public Color BackgroundColor {
			protected get {
				return backgroundColor;
			}
			set {
				backgroundColor = value;
				OnBackgroundColorChange ();
			}
		}

		public event EventHandler BackgroundColorChange;

		void OnBackgroundColorChange ()
		{
			if (BackBrush != null)
				BackBrush.Dispose ();
			if (BackPen != null)
				BackPen.Dispose ();
			BackBrush = new SolidBrush (backgroundColor);
			BackPen = new Pen (backgroundColor);
			if (BackgroundColorChange != null)
				BackgroundColorChange (this, EventArgs.Empty);
		}

		protected Brush ForeBrush {
			get;
			private set;
		}

		protected Pen ForePen {
			get;
			private set;
		}

		Color foregroundColor;

		public Color ForegroundColor {
			get {
				return foregroundColor;
			}
			set {
				foregroundColor = value;
				if (ForeBrush != null)
					ForeBrush.Dispose ();
				if (ForePen != null)
					ForePen.Dispose ();
				ForeBrush = new SolidBrush (foregroundColor);
				ForePen = new Pen (foregroundColor);
				if (ForegroundColorChange != null)
					ForegroundColorChange (this, EventArgs.Empty);
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

		Color borderColor;

		public Color BorderColor {
			get {
				return borderColor;
			}
			set {
				if (ForeBrush != null)
					ForeBrush.Dispose ();
				if (ForePen != null)
					ForePen.Dispose ();
				ForeBrush = new SolidBrush (foregroundColor);
				ForePen = new Pen (foregroundColor);
				if (ForegroundColorChange != null)
					ForegroundColorChange (this, EventArgs.Empty);


				borderColor = value;
				if (BorderBrush != null)
					BorderBrush.Dispose ();
				if (BorderPen != null)
					BorderPen.Dispose ();
				BorderBrush = new SolidBrush (borderColor);
				BorderPen = new Pen (borderColor);
				if (BorderColorChange != null)
					BorderColorChange (this, EventArgs.Empty);
			}
		}

		public Box ()
		{
			ContextMenu = new ContextMenu ();
			Center = new Point ();
			height = 50;
			width = 100;
			BackgroundColor = Color.White;
			ForegroundColor = Color.Black;
			BorderColor = Color.Black;
			text = String.Empty;
			Font = SystemFonts.DefaultFont;
			ContextMenu.MenuItems.Add ("Elimina", DelClick);
			ContextMenu.MenuItems.Add ("Dimensione", SizeClick);
			ContextMenu.MenuItems.Add ("Porta in primo piano", ForeBring);
		}

		void ForeBring (object sender, EventArgs e)
		{
			ShapeContainer.BringForeground (this);
		}

		void DelClick (object sender, EventArgs e)
		{
			new MethodInvoker (Delete).BeginInvoke (null, null);
		}

		void SizeClick (object sender, EventArgs e)
		{
			new SizeForm (this).Show ();
		}

		public virtual bool Contains (PointF point)
		{
			return point.X > Location.X && point.X < Location.X + Width && point.Y > Location.Y && point.Y < Location.Y + Height;
		}

		public virtual void DrawTo (Graphics graphics)
		{
			DrawBackground (graphics);
			DrawText (graphics);
		}

		protected virtual void DrawBackground (Graphics graphics)
		{
			var bounds = new Rectangle (Location.X, Location.Y, Width, Height);
			graphics.FillRectangle (BackBrush, bounds);
			graphics.DrawRectangle (BorderPen, bounds);
		}

		void DrawText (Graphics graphics)
		{
			var sf = new StringFormat {
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			graphics.DrawString (Text, Font, ForeBrush, Center, sf);
		}

		public Point Center {
			get;
			private set;
		}

		public virtual PointF GetIntersection (PointF other)
		{
			float r = Height;
			r /= Width;
			var l = -r;
			PointF c = Center;
			var ox = other.X - c.X;
			var oy = other.Y - c.Y;
			if (Math.Abs(ox) < Options.TOLERANCE)
				return new PointF (c.X, c.Y + Height / 2F * Math.Sign (oy));
			var m = oy / ox;
			float x, y;
			if (l < m && m < r) {
				x = Width / 2F * Math.Sign (ox);
				y = m * x;
			} else {
				y = Height / 2F * Math.Sign (oy);
				x = y / m;
			}
			return new PointF (x + c.X, y + c.Y);
		}

		protected ContextMenu ContextMenu { get; private set; }

		public virtual void OpenMenu (PointF point)
		{
			ContextMenu.Show (ShapeContainer, new Point ((int)point.X, (int)point.Y));
		}

		protected void Delete ()
		{
			ShapeContainer.RemoveShape (this);
			if (Deleted != null)
				Deleted (this, EventArgs.Empty);
		}

		public void Move (Point point)
		{
			var x = point.X - Offset.X;
			if (x < 0)
				x = 0;
			if (x + Width > ShapeContainer.Width)
				x = ShapeContainer.Width - Width;
			var y = point.Y - Offset.Y;
			if (y < 0)
				y = 0;
			if (y + Height > ShapeContainer.Height)
				y = ShapeContainer.Height - Height;
			Location = new Point (x, y);
			if (ShapeContainer.Grid)
				Location = ShapeContainer.CutToGrid (Location);
			if (Moving != null)
				Moving (this, EventArgs.Empty);
		}

		public static string Description { 
			get {
				return "Rettangolo";
			}
		}

		bool dragged;

		public bool Dragged {
			get {
				return dragged;
			}
			set {
				if (value) {
					if (DragStart != null)
						DragStart (this, EventArgs.Empty);
				} else if (dragged)
				if (DragEnd != null)
					DragEnd (this, EventArgs.Empty);
				dragged = value;
			}
		}

		Point location;

		public Point Location {
			get {
				return location;
			}
			protected set {
				location = value;
				Center = VCenter;
			}
		}

		/// <summary>
		/// For optimization issues, this is the "true" center proprierty, whereas Center is just a "buffer"
		/// </summary>
		protected virtual Point VCenter {
			get {
				return new Point (Location.X + Width / 2, Location.Y + Height / 2);
			}
		}

		public Point Offset {
			get;
			set;
		}

		int width;

		public int Width {
			get {
				return width;
			}
			set {
				if (width == value)
					return;
				width = value;
				OnSizeChange ();
			}
		}

		protected virtual void OnSizeChange ()
		{
			Center = VCenter;
		}

		int height;

		public int Height {
			get {
				return height;
			}
			set {
				if (height == value)
					return;
				height = value;
				OnSizeChange ();
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

		public virtual void BeginInitialize ()
		{
		}

		public virtual void EndInitialize (KeyedCollection<string, IShape> list)
		{
		}

		public virtual bool NeedInitialize {
			get {
				return false;
			}
		}

		public virtual void Load (XmlReader reader)
		{
			while (!reader.EOF) {
				reader.Read ();
				switch (reader.Name) {
					case "name":
						ReadName (reader);
						break;
					case "location":
						ReadLocation (reader);
						break;
					case "size":
						ReadSize (reader);
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
					case "autoresizewidth":
						ReadAutoResize (reader);
						break;
					case "autoresizeheight":
						ReadAutoResize (reader);
						break;
				}
			}
		}

		void ReadAutoResize (XmlReader reader)
		{
			switch (reader.Name) {
				case "autoresizeheight":
					var s = reader.ReadString ();
					if (s.Length == 0)
						return;
					AutoResizeHeight = bool.Parse (s);
					break;
				case "autoresizewidth":
					var s2 = reader.ReadString ();
					if (s2.Length == 0)
						return;
					AutoResizeWidth = bool.Parse (s2);
					break;
			}
		}

		protected void ReadName (XmlReader reader)
		{
			Name = reader.ReadString ();
		}

		protected void ReadBorderColor (XmlReader reader)
		{
			BorderColor = DeserializeColor (reader.ReadString ());
		}

		protected void ReadText (XmlReader reader)
		{
			Text = reader.ReadString ().Replace (@"\n", Environment.NewLine);
		}

		protected void ReadColors (XmlReader reader)
		{
			switch (reader.Name) {
				case "foregroundColor":
					ForegroundColor = DeserializeColor (reader.ReadString ());
					break;
				case "backgroundColor":
					BackgroundColor = DeserializeColor (reader.ReadString ());
					break;
				case "borderColo":
					BorderColor = DeserializeColor (reader.ReadString ());
					break;
			}
		}

		protected void ReadFont (XmlReader reader)
		{
			reader.ReadStartElement ("font");
			reader.ReadStartElement ("name");
			var fontName = reader.ReadString ();
			reader.ReadEndElement ();
			reader.ReadStartElement ("unit");
			var fontUnit = (GraphicsUnit)Enum.Parse (typeof(GraphicsUnit), reader.ReadString ());
			reader.ReadEndElement ();
			reader.ReadStartElement ("size");
			var val = reader.ReadString ();
			val = val.Replace (',', '.');//HACK: find a way to understand numbers culture-invariantly
			var fontSize = float.Parse (val, CultureInfo.InvariantCulture);
			reader.ReadEndElement ();
			reader.ReadStartElement ("style");
			var fontStyle = (FontStyle)Enum.Parse (typeof(FontStyle), reader.ReadString ());
			Font = new Font (fontName, fontSize, fontStyle, fontUnit);
			reader.ReadEndElement ();
		}

		protected void ReadSize (XmlReader reader)
		{
			reader.ReadToFollowing ("width");
			Width = reader.ReadElementContentAsInt ();
			Height = reader.ReadElementContentAsInt ();
		}

		protected void ReadLocation (XmlReader reader)
		{
			reader.ReadToFollowing ("x");
			var x = reader.ReadElementContentAsInt ();
			var y = reader.ReadElementContentAsInt ();
			Location = new Point (x, y);
		}

		public virtual void Save (XmlWriter writer)
		{
			SaveName (writer);
			SaveLocation (writer);
			SaveSize (writer);
			SaveFont (writer);
			SaveColors (writer);
			SaveText (writer);
			SaveAuto (writer);
		}

		void SaveAuto (XmlWriter writer)
		{
			writer.WriteElementString ("autoresizewidth", AutoResizeWidth.ToString ());
			writer.WriteElementString ("autoresizeheight", AutoResizeHeight.ToString ());
		}

		protected void SaveText (XmlWriter writer)
		{
			writer.WriteElementString ("text", Text.Replace (Environment.NewLine, "\\n"));
		}

		protected void SaveColors (XmlWriter writer)
		{
			writer.WriteElementString ("foregroundColor", SerializeColor (ForegroundColor));
			writer.WriteElementString ("backgroundColor", SerializeColor (BackgroundColor));
			writer.WriteElementString ("borderColor", SerializeColor (BorderColor));
		}

		protected void SaveName (XmlWriter writer)
		{
			writer.WriteElementString ("name", Name);
		}

		protected void SaveSize (XmlWriter writer)
		{
			writer.WriteStartElement ("size");
			writer.WriteElementString ("width", Width.ToString (CultureInfo.InvariantCulture));
			writer.WriteElementString ("height", Height.ToString (CultureInfo.InvariantCulture));
			writer.WriteEndElement ();
		}

		protected void SaveLocation (XmlWriter writer)
		{
			writer.WriteStartElement ("location");
			writer.WriteElementString ("x", Location.X.ToString (CultureInfo.InvariantCulture));
			writer.WriteElementString ("y", Location.Y.ToString (CultureInfo.InvariantCulture));
			writer.WriteEndElement ();
		}

		protected void SaveFont (XmlWriter writer)
		{
			writer.WriteStartElement ("font");
			writer.WriteElementString ("name", Font.FontFamily.Name);
			writer.WriteElementString ("unit", Font.Unit.ToString ());
			writer.WriteElementString ("size", Font.Size.ToString (CultureInfo.InvariantCulture));
			writer.WriteElementString ("style", Font.Style.ToString ());
			writer.WriteEndElement ();
		}

		enum ColorFormat
		{
			NamedColor,
			ArgbColor
		}

		static string SerializeColor (Color color)
		{
			if (color.IsNamedColor)
				return string.Format (CultureInfo.InvariantCulture, "{0}:{1}",
				                      ColorFormat.NamedColor, color.Name);
			return string.Format (CultureInfo.InvariantCulture, "{0}:{1}:{2}:{3}:{4}",
			                      ColorFormat.ArgbColor,
			                      color.A, color.R, color.G, color.B);
		}

		static Color DeserializeColor (string color)
		{
			var pieces = color.Split (new[] { ':' });

			var colorType = (ColorFormat)
				Enum.Parse (typeof(ColorFormat), pieces [0], true);

			switch (colorType) {
				case ColorFormat.NamedColor:
					return Color.FromName (pieces [1]);

				case ColorFormat.ArgbColor:
					var a = byte.Parse (pieces [1], CultureInfo.InvariantCulture);
					var r = byte.Parse (pieces [2], CultureInfo.InvariantCulture);
					var g = byte.Parse (pieces [3], CultureInfo.InvariantCulture);
					var b = byte.Parse (pieces [4], CultureInfo.InvariantCulture);

					return Color.FromArgb (a, r, g, b);
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

		public readonly static IShapeCreator Creator = new ShapeCreator<Box> (Description, Resources.Rectangle);

		public void Refresh ()
		{
			ShapeContainer.ForceRefresh ();
		}

		public void SetLocation (Point point)
		{
			Location = point;
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (!disposing)
				return;
			BackBrush.Dispose ();
			ForeBrush.Dispose ();
			BorderBrush.Dispose ();
			BackPen.Dispose ();
			ForePen.Dispose ();
			BorderPen.Dispose ();
			Font.Dispose ();
			ContextMenu.Dispose ();
		}

		protected void DoAutoResize ()
		{
			if (!(AutoResizeHeight || AutoResizeWidth) || ShapeContainer == null)
				return;
			using (var g = ShapeContainer.CreateGraphics()) {
				var size = g.MeasureString (Text, Font);
				if (AutoResizeWidth) {
					var w = (int)size.Width + 10;
					Width = Math.Max (w, Options.MinimumWidth);
				}
				if (AutoResizeHeight) {
					var h = (int)size.Height + 5;
					Height = Math.Max (h, Options.MinimumHeight);
				}
				ShapeContainer.ForceRefresh ();
			}
		}

		public virtual void SvgSave (XmlWriter writer)
		{
			Svg.WriteRectangle (writer, Location, new Size (Width, Height), BackgroundColor, BorderPen);
			Svg.WriteText (writer, Center, ForegroundColor, Font, Text);
		}

		bool autoresizewidth;

		public bool AutoResizeWidth {
			get {
				return autoresizewidth;
			}
			set {
				autoresizewidth = value;
				if (value)
					DoAutoResize ();
			}
		}

		bool autoresizeheight;

		public bool AutoResizeHeight {
			get {
				return autoresizeheight;
			}
			set {
				autoresizeheight = value;
				if (value)
					DoAutoResize ();
			}
		}
	}
}
