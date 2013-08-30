using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using DiagramDrawer.Shapes;
using System.Drawing.Imaging;
using System.IO;
using DiagramDrawer.Export;

namespace DiagramDrawer.Forms
{
	public class ShapeController : ISizeable
	{
		readonly ShapeContainer container;
		public TypeCollection ShapeTypes { get; private set; }

		public TypeCollection ArrowTypes { get; private set; }

		public ShapeController(ShapeContainer container)
		{
			ArrowTypes = new TypeCollection();
			ShapeTypes = new TypeCollection();
			this.container = container;
			//Shapes
			ShapeTypes.AddRange(new[]{
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
			ArrowTypes.AddRange(new[]{
				typeof(Line),
				typeof(OneArrow),
				typeof(TwoArrows),
				typeof(OneArrowAngle),
				typeof(TwoArrowsAngle),
				typeof(NoArrowFragmented),
				typeof(OneArrowFragmented),
				typeof(TwoArrowsFragmented)
			});

			this.container.MouseDoubleClick += MouseDoubleClick;
			Filename = string.Empty;
		}
		public Type ShapeType
		{
			set
			{
				container.ShapeType = value;
			}
		}
		public bool LinkMode
		{
			set
			{
				container.LinkMode = value;
			}
		}
		public void AddCurrentShapeAtPoint(Point point)
		{
			LinkMode = false;
			container.AddCurrentShapeAtPoint(point);
		}
		public void ForceRefresh()
		{
			container.ForceRefresh();
		}
		void MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (container.GetSelectedShape(e.Location, false) != null)
				return;
			if (e.Button == MouseButtons.Left)
			{
				using (var current = GetIstance<IShape>(container.ShapeType))
					container.AddCurrentShapeAtPoint(new Point(e.Location.X - current.Width / 2, e.Location.Y - current.Height / 2));
			}
			if (e.Button == MouseButtons.Middle)
				if (MiddleDoubleClick != null)
					MiddleDoubleClick(sender, e);
		}
		public event EventHandler MiddleDoubleClick;
		static T GetIstance<T>(Type t) where T : class
		{
			if (t == null)
				throw new ArgumentNullException("t", "type cannot be null");
			return t.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }) as T;
		}
		public string Filename
		{
			get;
			private set;
		}
		public void Open(string filename)
		{
			if (filename.Length == 0)
				return;
			if (!File.Exists(filename))
			{
				var directoryName = Path.GetDirectoryName(Filename);
				if (directoryName == null) {
					MessageBox.Show ("Error?!?");
					return;
				}
				var nfilename = Path.Combine(directoryName, Path.GetFileName(filename));
				if (File.Exists(nfilename))
					filename = nfilename;
				else
				{
					MessageBox.Show("File non trovato:\n" + filename, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show("File non trovato:\n" + nfilename, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			var sett = new XmlReaderSettings
			{
				IgnoreWhitespace = true
			};
			try
			{
				using (var reader = XmlReader.Create(filename, sett))
				{
					reader.ReadToFollowing("size");
					Width = reader.MoveToAttribute("width")
						? Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture)
						: 1000;
					Height = reader.MoveToAttribute("height")
						? Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture)
						: 800;
					reader.MoveToElement();
					var toLoad = new ShapeCollection();
					do
					{
						reader.Read();
						Type t = null;
						switch (reader.Name)
						{
							case "shape":
								if (reader.MoveToAttribute("type"))
								{
									var type = reader.ReadContentAsString();
									//backwards-compatibility
									if (type == "DiagramDrawer.Shapes.Text")
										type = "DiagramDrawer.Shapes.LabelShape";
									t = ShapeTypes[type];
								}
								else
									t = typeof(RoundedBox);
								break;
							case "line":
								if (reader.MoveToAttribute("type"))
								{
									var type = reader.ReadContentAsString();
									//backwards-compatibility
									switch (type)
									{
										case "DiagramDrawer.Shapes.Angle":
											type = "DiagramDrawer.Shapes.OneArrowAngle";
											break;
										case "DiagramDrawer.Shapes.Fragmented":
											type = "DiagramDrawer.Shapes.NoArrowFragmented";
											break;
									}
									t = ArrowTypes[type];
								}
								else
									t = typeof(Line);
								break;
						}
						IShape s;
						if (t != null)
							s = GetIstance<IShape>(t);
						else
							break;//We're done!
						reader.MoveToElement();
						using (var r = reader.ReadSubtree())
							s.Load(r);
						toLoad.Add(s);
					} while (true);
					container.ClearShapes();
					container.LoadShapes(toLoad);
				}

				container.ForceRefresh();
				Filename = filename;
				if (Opened != null)
					Opened(this, EventArgs.Empty);
			}
			catch (FileNotFoundException fnfe)
			{
				MessageBox.Show("[WAAAAAAAAA]\nFile non trovato: " + fnfe.FileName, "Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public event EventHandler Opened;

		public void PrintTo(Graphics graphics, Rectangle rectangle)
		{
			container.PrintTo(graphics, rectangle);
		}
		public void Save(string filename)
		{
			var sett = new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "  "
			};
			using (var writer = XmlWriter.Create(filename, sett))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("shapes");

				SaveSize(writer);

				foreach (var s in container.ShapeList)
				{
					var line = s is Line;
					writer.WriteStartElement(line ? "line" : "shape");
					writer.WriteAttributeString("type", s.GetType().FullName);
					s.Save(writer);
					writer.WriteEndElement();
				}

				writer.WriteEndDocument();
			}
			Filename = filename;
			if (Saved != null)
				Saved(this, EventArgs.Empty);
		}
		public event EventHandler Saved;
		void SaveSize(XmlWriter writer)
		{
			writer.WriteStartElement("size");
			writer.WriteAttributeString("width", container.Width.ToString(CultureInfo.InvariantCulture));
			writer.WriteAttributeString("height", container.Height.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
		}
		public void New()
		{
			container.ClearShapes();
			Filename = string.Empty;
		}
		public void SetCursor(Cursor crossCursor)
		{
			container.Cursor = crossCursor;
		}
		public void ShowPoints()
		{
			container.ShowPoints();
		}
		public void HidePoints()
		{
			container.HidePoints();
		}
		public int Height
		{
			get
			{
				return container.Height;
			}
			set
			{
				container.Height = value;
				container.ForceRefresh();
			}
		}
		public int Width
		{
			get
			{
				return container.Width;
			}
			set
			{
				container.Width = value;
				container.ForceRefresh();
			}
		}
		public void Refresh()
		{
			container.ForceRefresh();
		}
		public void ExportImage(string filename, ImageFormat format)
		{
			using (Image i = new Bitmap(container.Width, container.Height))
			using (var g = Graphics.FromImage(i))
			{
				g.Clear(container.BackColor);
				container.DrawTo(g, true);
				i.Save(filename, format);
			}
		}
		public bool Grid
		{
			get
			{
				return container.Grid;
			}
			set
			{
				container.Grid = value;
			}
		}
		public void AlignToGrid()
		{
			container.AlignToGrid();
			Grid = true;
		}
		public Type LineType
		{
			set
			{
				container.LineType = value;
			}
		}
		public void Save()
		{
			Save(Filename);
		}
		public void ExportSvg(string filename)
		{
			var sett = new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "  "
			};
			using (var writer = XmlWriter.Create(filename, sett))
				Svg.Save(writer, container.ShapeList, container.Size);
		}
	}
}
