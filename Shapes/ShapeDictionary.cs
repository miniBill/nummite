using Nummite.Shapes.Lines;

namespace Nummite.Shapes
{
	static class ShapeDictionary
	{
		static ShapeDictionary()
		{
			ArrowTypes = new LineHelperCollection();
			ShapeTypes = new ShapeHelperCollection();

			//Shapes
			ShapeTypes.AddRange(
				RoundedBox.Helper,
				Ellipse.Helper,
				Box.Helper,
				LabelShape.Helper,
				Rhombus.Helper,
				Parallelogram.Helper,
				VisiblePoint.Helper,
				ImageBox.Helper,
				Link.Helper
			);

			//Arrow Kinds
			ArrowTypes.AddRange(
				Line.Helper,
				OneArrow.Helper,
				TwoArrows.Helper,
				OneArrowAngle.Helper,
				TwoArrowsAngle.Helper,
				NoArrowFragmented.Helper,
				OneArrowFragmented.Helper,
				TwoArrowsFragmented.Helper
			);
		}

		public static ShapeHelperCollection ShapeTypes { get; set; }

		public static LineHelperCollection ArrowTypes { get; set; }

		public static IShapeHelper GetHelper(string name)
		{
			if (ShapeTypes.Contains(name))
				return ShapeTypes[name];
			if (ArrowTypes.Contains(name))
				return ArrowTypes[name];
			return null;
		}
	}
}
