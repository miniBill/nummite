using System.Collections.ObjectModel;
using Nummite.Shapes;

namespace Nummite.Forms {
	class ShapeHelperCollection : KeyedCollection<string, IShapeHelper>
	{
		public void AddRange (params IShapeHelper[] shapeHelpers)
		{
			foreach (var shapeCreator in shapeHelpers)
				Add (shapeCreator);
		}

		protected override string GetKeyForItem (IShapeHelper item)
		{
			return item.TypeName;
		}
	}
}
