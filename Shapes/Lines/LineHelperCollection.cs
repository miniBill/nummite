using System;
using System.Collections.ObjectModel;

namespace Nummite.Shapes.Lines
{
	class LineHelperCollection : KeyedCollection<string, ILineHelper>
	{
		public void AddRange(params ILineHelper[] shapeHelpers)
		{
			foreach (var shapeCreator in shapeHelpers)
				Add(shapeCreator);
		}

		protected override string GetKeyForItem(ILineHelper item)
		{
			if (item == null)
				throw new ArgumentNullException ("item");
			return item.TypeName;
		}
	}
}