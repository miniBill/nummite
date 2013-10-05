using Nummite.Properties;
using Nummite.Shapes.Lines;
using Nummite.Shapes.Net;
using Nummite.Shapes.Interfaces;

namespace Nummite.Shapes.Support {
	static class ShapeDictionary {
		static ShapeDictionary() {
			ShapeTypes = new ShapeTypeCollection<IShape>();
			DefaultShapeType = ShapeTypes.Add<Domain>("Domain name", Resources.Domain);
			ShapeTypes.Add<Hostname>("Hostname", Resources.Hostname);
			ShapeTypes.Add<Addressv4>("IPv4 address", Resources.IPv4Icon);
			ShapeTypes.Add<Addressv6>("IPv6 address", Resources.IPv6Icon);

			LineTypes = new ShapeTypeCollection<Line>();
			DefaultLineType = LineTypes.Add<OneArrow>("Line", Resources.OneArrow);
		}

		public static ShapeTypeCollection<IShape> ShapeTypes { get; set; }

		public static ShapeTypeCollection<Line> LineTypes { get; set; }

		public static ShapeType<IShape> DefaultShapeType { get; private set; }

		public static ShapeType<Line> DefaultLineType { get; private set; }
	}
}
