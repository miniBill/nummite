using System;
using System.Drawing;

namespace Nummite.Shapes.Support {
	struct ShapeType<T> : IShapeType {
		public Func<T> Constructor{ get; set; }

		public string Description{ get; set; }

		public Image Image{ get; set; }
	}
}
