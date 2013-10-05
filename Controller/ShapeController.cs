using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProtoBuf;
using Nummite.Forms;
using Nummite.Graphs;
using Nummite.Properties;
using Nummite.Shapes.Basic;
using Nummite.Shapes.Interfaces;

namespace Nummite.Controller {
	class ShapeController {
		public ShapeController(ShapeContainer container) {
			this.Container = container;
			this.Container.MouseDoubleClick += MouseDoubleClick;
			Filename = string.Empty;
		}

		public ShapeContainer Container { get ; private set ; }

		void MouseDoubleClick(object sender, MouseEventArgs e) {
			if (Container.GetSelectedShape(e.Location, false) != null)
				return;
			if (e.Button == MouseButtons.Left) {
				using (var current = Container.ShapeType.Constructor()) {
					var location = new Point(e.Location.X - current.Width / 2, e.Location.Y - current.Height / 2);
					Container.AddCurrentShapeAtPoint(location);
				}
			}
			if (e.Button != MouseButtons.Middle || MiddleDoubleClick == null)
				return;
			MiddleDoubleClick(sender, e);
		}

		public event EventHandler MiddleDoubleClick;

		public string Filename {
			get;
			private set;
		}

		public void Open(string filename) {
			if (filename.Length == 0)
				return;
			if (!File.Exists(filename)) {
				var directoryName = Path.GetDirectoryName(Filename);
				if (directoryName == null) {
					MessageBox.Show(Resources.Error);
					return;
				}
				var nfilename = Path.Combine(directoryName, Path.GetFileName(filename));
				if (File.Exists(nfilename))
					filename = nfilename;
				else {
					MessageBox.Show(string.Format("File not found: {0}", filename), Resources.Nummite, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					MessageBox.Show(string.Format("File not found: {0}", nfilename), Resources.Nummite, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}
			}
			try {
				using (var stream = File.OpenRead(filename))
					Open(stream);

				Container.ForceRefresh();
				Filename = filename;
				if (Opened != null)
					Opened(this, EventArgs.Empty);
			}
			catch (FileNotFoundException fnfe) {
				MessageBox.Show(string.Format("File not found: {0}", fnfe.FileName), Resources.Nummite, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		void Open(Stream stream) {
			var file = Serializer.Deserialize<Nummite.Model.Document>(stream);
			Container.Width = file.Width;
			Container.Height = file.Height;
			Container.ClearShapes();
			Container.LoadShapes(file.Shapes);
		}

		public event EventHandler Opened;

		Nummite.Model.Document GetDocument() {
			return new Nummite.Model.Document(Container.ShapeList){ Height = Container.Height, Width = Container.Width };
		}

		public void Save(string filename) {
			using (var stream = File.Open(filename, FileMode.Create)) {
				Nummite.Model.Document document = GetDocument();
				Serializer.Serialize(stream, document);
			}
			Filename = filename;
			if (Saved != null)
				Saved(this, EventArgs.Empty);
		}

		public event EventHandler Saved;

		public void New() {
			Container.ClearShapes();
			Filename = string.Empty;
		}

		public void ExportImage(string filename, ImageFormat format) {
			using (Image i = new Bitmap(Container.Width, Container.Height))
			using (var g = Graphics.FromImage(i)) {
				g.Clear(Container.BackColor);
				Container.DrawTo(g, true);
				i.Save(filename, format);
			}
		}

		public void Save() {
			Save(Filename);
		}

		public void LayoutRadial() {
			using (Container.Suspend()) {
				var graph = Container.ShapeList.ToGraph();
				if (graph.IsCyclic()) {
					string cycle = graph.GetCycle();
					MessageBox.Show(Container.ParentForm, String.Format("Can't layout! Cyclic because of {0}!", cycle));
					return;
				}
				var root = GetSingleRoot(graph);
				root.Value.MoveCenter(Container.Center);
				Layout(root, 0, -90, 270);
			}
		}

		static Node<IShape> GetSingleRoot(Graph<IShape> graph) {
			var roots = graph.GetRoots();
			var rootsArray = roots as Node<IShape>[] ?? roots.ToArray();
			Node<IShape> root;
			if (rootsArray.Length == 1)
				root = rootsArray[0];
			else {
				root = new Node<IShape>(new InvisiblePoint());
				foreach (Node<IShape> node in rootsArray) {
					root.AddLink(node);
				}
			}
			return root;
		}

		void Layout(Node<IShape> root, int ring, double startAngle, double endAngle) {
			double middleAngle = (startAngle + endAngle) / 2;
			if (ring != 0) {
				startAngle = Math.Max(startAngle, middleAngle - 90);
				endAngle = Math.Min(endAngle, middleAngle + 90);
			}

			int childrenCount = root.Children.Count;
			if (childrenCount == 0)
				return;
			Point rootCenter = root.Value.Center;
			if (childrenCount == 1) {
				var child = root.Children[0];
				MoveChild(rootCenter, middleAngle, child);
				Layout(child, ring + 1, startAngle, endAngle);
				return;
			}
			double angleStep = (endAngle - startAngle) / (childrenCount + (ring == 0 ? 0 : -1));
			for (int i = 0; i < childrenCount; i++) {
				double angle = startAngle + angleStep * i;
				var child = root.Children[childrenCount - i - 1];
				MoveChild(rootCenter, angle, child);
				Layout(child, ring + 1, angle - angleStep / 2, angle + angleStep / 2);
			}
		}

		static void MoveChild(Point rootCenter, double angle, Node<IShape> node) {
			var radAngle = angle * Math.PI / 180.0;
			const int ringGap = 150;

			double cos = Math.Cos(radAngle);
			double sin = Math.Sin(radAngle);

			double dx = ringGap * cos;
			double dy = ringGap * sin;

			var shape = node.Value;
			shape.MoveCenter(new Point((int)(rootCenter.X + dx), (int)(rootCenter.Y + dy)));
		}
	}
}