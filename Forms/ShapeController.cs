using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using DiagramDrawer.Shapes;
using System.Drawing.Imaging;
using System.IO;
using DiagramDrawer.Export;

namespace DiagramDrawer.Forms {
	public class ShapeController : ISizeable {
		readonly ShapeContainer _sc;
		public IEnumerable<Type> ShapeTypes {
			get {
				return _shapes;
			}
		}
		public IEnumerable<Type> ArrowTypes {
			get {
				return _arrowKinds;
			}
		}
		public ShapeController(ShapeContainer container) {
			_sc = container;
			//Shapes
			_shapes.AddRange(new[]{
				typeof(RoundedBox),
				typeof(Ellipse),
				typeof(Box),
				typeof(LabelShape),
				typeof(Rhombus),
				typeof(Parallelogram),
				typeof(VisiblePoint),
				typeof(ImageBox),
				typeof(Link)
			});

			//Arrow Kinds
			_arrowKinds.AddRange(new[]{
				typeof(Line),
				typeof(OneArrow),
				typeof(TwoArrows),
				typeof(OneArrowAngle),
				typeof(TwoArrowsAngle),
				typeof(NoArrowFragmented),
				typeof(OneArrowFragmented),
				typeof(TwoArrowsFragmented)
			});

			_sc.MouseDoubleClick += MouseDoubleClick;
			Filename = string.Empty;
		}
		public Type ShapeType {
			set {
				_sc.ShapeType = value;
			}
		}
		public bool LinkMode {
			set {
				_sc.LinkMode = value;
			}
		}
		public void AddCurrentShapeAtPoint(Point point) {
			LinkMode = false;
			_sc.AddCurrentShapeAtPoint(point);
		}
		public void ForceRefresh() {
			_sc.ForceRefresh();
		}
		void MouseDoubleClick(object sender, MouseEventArgs e) {
			if(_sc.GetSelectedShape(e.Location, false) != null)
				return;
			if(e.Button == MouseButtons.Left) {
				using(var current = GetIstance<IShape>(_sc.ShapeType))
					_sc.AddCurrentShapeAtPoint(new Point(e.Location.X - current.Width / 2, e.Location.Y - current.Height / 2));
			}
			if(e.Button == MouseButtons.Middle)
				if(MiddleDoubleClick != null)
					MiddleDoubleClick(sender, e);
		}
		public event EventHandler MiddleDoubleClick;
		private static T GetIstance<T>(Type t) where T : class {
			if(t == null)
				throw new ArgumentNullException("t", "type cannot be null");
			return t.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }) as T;
		}
		public string Filename {
			get;
			private set;
		}
		public void Open(string filename) {
			if(filename.Length == 0)
				return;
			if(!File.Exists(filename)) {
				string nfilename = Path.Combine(Path.GetDirectoryName(Filename), Path.GetFileName(filename));
				if(File.Exists(nfilename))
					filename = nfilename;
				else {
					MessageBox.Show("File non trovato:\n" + filename, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show("File non trovato:\n" + nfilename, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			var sett = new XmlReaderSettings() {
				IgnoreWhitespace = true
			};
			try {
				using(XmlReader reader = XmlReader.Create(filename, sett)) {
					reader.ReadToFollowing("size");
					if(reader.MoveToAttribute("width"))
						Width = Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture);
					else
						Width = 1000; //TODO: add option
					if(reader.MoveToAttribute("height"))
						Height = Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture);
					else
						Height = 800; //TODO: add option
					reader.MoveToElement();
					var toLoad = new ShapeCollection();
					do {
						reader.Read();
						Type t = null;
						switch(reader.Name) {
							case "shape":
								if(reader.MoveToAttribute("type")) {
									string type = reader.ReadContentAsString();
									//backwards-compatibility
									if(type == "DiagramDrawer.Shapes.Text")
										type = "DiagramDrawer.Shapes.LabelShape";
									t = _shapes[type];
								}
								else
									t = typeof(RoundedBox);
								break;
							case "line":
								if(reader.MoveToAttribute("type")) {
									string type = reader.ReadContentAsString();
									//backwards-compatibility
									switch(type) {
										case "DiagramDrawer.Shapes.Angle":
											type = "DiagramDrawer.Shapes.OneArrowAngle";
											break;
										case "DiagramDrawer.Shapes.Fragmented":
											type = "DiagramDrawer.Shapes.NoArrowFragmented";
											break;
									}
									t = _arrowKinds[type];
								}
								else
									t = typeof(Line);
								break;
						}
						IShape s;
						if(t != null)
							s = GetIstance<IShape>(t);
						else
							break;//We're done!
						reader.MoveToElement();
						using(XmlReader r = reader.ReadSubtree())
							s.Load(r);
						toLoad.Add(s);
					} while(true);
					_sc.ClearShapes();
					_sc.LoadShapes(toLoad);
				}

				_sc.ForceRefresh();
				Filename = filename;
				if(Opened != null)
					Opened(this, EventArgs.Empty);
			}
			catch(FileNotFoundException fnfe) {
				MessageBox.Show("[WAAAAAAAAA]\nFile non trovato: " + fnfe.FileName, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public event EventHandler Opened;
		readonly TypeCollection _shapes = new TypeCollection();
		readonly TypeCollection _arrowKinds = new TypeCollection();
		public void PrintTo(Graphics graphics, Rectangle rectangle) {
			_sc.PrintTo(graphics, rectangle);
		}
		public void Save(string filename) {
			var sett = new XmlWriterSettings() {
				Indent = true,
				IndentChars = "  "
			};
			using(XmlWriter writer = XmlWriter.Create(filename, sett)) {
				if(writer != null) {
					writer.WriteStartDocument();
					writer.WriteStartElement("shapes");

					SaveSize(writer);

					foreach(IShape s in _sc.ShapeList) {
						bool line = s is Line;
						writer.WriteStartElement(line ? "line" : "shape");
						writer.WriteAttributeString("type", s.GetType().FullName);
						s.Save(writer);
						writer.WriteEndElement();
					}

					writer.WriteEndDocument();
				}
			}
			Filename = filename;
			if(Saved != null)
				Saved(this, EventArgs.Empty);
		}
		public event EventHandler Saved;
		private void SaveSize(XmlWriter writer) {
			writer.WriteStartElement("size");
			writer.WriteAttributeString("width", _sc.Width.ToString(CultureInfo.InvariantCulture));
			writer.WriteAttributeString("height", _sc.Height.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
		}
		public void New() {
			_sc.ClearShapes();
			Filename = string.Empty;
		}
		public void SetCursor(Cursor crossCursor) {
			_sc.Cursor = crossCursor;
		}
		public void ShowPoints() {
			_sc.ShowPoints();
		}
		public void HidePoints() {
			_sc.HidePoints();
		}
		public int Height {
			get {
				return _sc.Height;
			}
			set {
				_sc.Height = value;
				_sc.ForceRefresh();
			}
		}
		public int Width {
			get {
				return _sc.Width;
			}
			set {
				_sc.Width = value;
				_sc.ForceRefresh();
			}
		}
		public void Refresh() {
			_sc.ForceRefresh();
		}
		public void ExportImage(string filename, ImageFormat format) {
			using(Image i = new Bitmap(_sc.Width, _sc.Height))
			using(Graphics g = Graphics.FromImage(i)) {
				g.Clear(_sc.BackColor);
				_sc.DrawTo(g, true);
				i.Save(filename, format);
			}
		}
		public bool Grid {
			get {
				return _sc.Grid;
			}
			set {
				_sc.Grid = value;
			}
		}
		public void AlignToGrid() {
			_sc.AlignToGrid();
			Grid = true;
		}
		public Type LineType {
			set {
				_sc.LineType = value;
			}
		}
		public void Save() {
			Save(Filename);
		}
		public void ExportSvg(string filename) {
			var sett = new XmlWriterSettings() {
				Indent = true,
				IndentChars = "  "
			};
			using(XmlWriter writer = XmlWriter.Create(filename, sett))
				Svg.Save(writer, _sc.ShapeList, _sc.Size);
		}
		public bool AutoResizeable {
			get {
				return false;
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
