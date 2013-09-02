using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using Nummite.Gencode;
using Nummite.Properties;
using Nummite.Shapes;
using System.Drawing.Imaging;
using System.IO;
using Nummite.Shapes.Lines;
using Nummite.Export;

namespace Nummite.Forms
{
	class ShapeController : ISizeable
	{
		readonly ShapeContainer container;

		public ShapeController(ShapeContainer container)
		{
			this.container = container;
			this.container.MouseDoubleClick += MouseDoubleClick;
			Filename = string.Empty;
		}

		public IShapeHelper ShapeType
		{
			get
			{
				return container.ShapeType;
			}
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
				using (var current = ShapeType.Create())
					container.AddCurrentShapeAtPoint(new Point(e.Location.X - current.Width / 2, e.Location.Y - current.Height / 2));
			}
			if (e.Button == MouseButtons.Middle)
				if (MiddleDoubleClick != null)
					MiddleDoubleClick(sender, e);
		}

		public event EventHandler MiddleDoubleClick;

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
				if (directoryName == null)
				{
					MessageBox.Show(Resources.Error);
					return;
				}
				var nfilename = Path.Combine(directoryName, Path.GetFileName(filename));
				if (File.Exists(nfilename))
					filename = nfilename;
				else
				{
					MessageBox.Show(string.Format("File non trovato: {0}", filename), Resources.Nummite, MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show(string.Format("File non trovato: {0}", nfilename), Resources.Nummite, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			try
			{
				using (var reader = File.OpenText(filename))
				{
					Open(reader);
				}

				container.ForceRefresh();
				Filename = filename;
				if (Opened != null)
					Opened(this, EventArgs.Empty);
			}
			catch (FileNotFoundException fnfe)
			{
				MessageBox.Show(string.Format("File non trovato: {0}", fnfe.FileName), Resources.Nummite, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Open(StreamReader reader)
		{
			var decoder = new GDecoder(reader);
			GDictionary file = decoder.ReadDictionary();
			var attributes = file.GetObject<GDictionary>("attributes");
			Width = attributes.GetValue<int>("width") ?? 1000;
			Height = attributes.GetValue<int>("height") ?? 800;
			var toLoad = new ShapeCollection();
			var shapes = file.GetObject<GList>("shapes");
			foreach (GDictionary shape in shapes)
			{
				var type = shape.GetObject<string>("type");
				var helper = ShapeDictionary.GetHelper(type) as IPersistableHelper;
				if (helper == null)
					throw new ArgumentException(String.Format("Found a non-persistable type {0} in file", type));
				IShape s = helper.Load(decoder);
				toLoad.Add(s);
			}
			container.ClearShapes();
			container.LoadShapes(toLoad);
		}

		public event EventHandler Opened;

		public void PrintTo(Graphics graphics, Rectangle rectangle)
		{
			container.PrintTo(graphics, rectangle);
		}

		public void Save(string filename)
		{
			using (var stream = File.OpenWrite(filename))
			using (var writer = new StreamWriter(stream))
			{
				var encoder = new GEncoder(writer);
				encoder.BeginDictionary();
				encoder.WriteString("attributes");
				{
					encoder.BeginDictionary();
					encoder.WritePair("width", container.Width);
					encoder.WritePair("height", container.Height);
					encoder.EndDictionary();
				}

				encoder.WriteString("shapes");
				foreach (var s in container.ShapeList)
				{
					IShapeHelper helper = ShapeDictionary.GetHelper(s.GetType().Name);
					var persistable = helper as IPersistableHelper;
					if (persistable == null)
						continue;
					persistable.Save(s, encoder);
				}

				encoder.EndDictionary();
			}
			Filename = filename;
			if (Saved != null)
				Saved(this, EventArgs.Empty);
		}

		public event EventHandler Saved;

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

		public Size Size
		{
			get
			{
				return container.Size;
			}
			set
			{
				container.Size = value;
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

		public ILineHelper LineType
		{
			set
			{
				container.LineType = value;
			}
		}

		public int Width { get { return Size.Width; } set { Size = new Size(value,Height); } }
		public int Height { get { return Size.Height; } set { Size = new Size(Width, value); } }

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
