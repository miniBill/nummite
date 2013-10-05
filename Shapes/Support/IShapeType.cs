using System.Drawing;

namespace Nummite.Shapes.Support {
	interface IShapeType {
		string Description { get; }

		Image Image { get; }
	}
}
