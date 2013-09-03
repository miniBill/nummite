using System;
using System.Collections.ObjectModel;

namespace Nummite.Shapes {
	class ShapeHelperCollection : KeyedCollection<string, IShapeHelper>
	{
		public void AddRange (params IShapeHelper[] shapeHelpers)
		{
			foreach (var shapeCreator in shapeHelpers)
				Add (shapeCreator);
		}

		protected override string GetKeyForItem (IShapeHelper item)
		{
			if (item == null)
				throw new ArgumentNullException ("item");
			return item.TypeName;
		}
	}
}
