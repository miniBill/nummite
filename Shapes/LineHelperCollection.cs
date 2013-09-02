using System.Collections.ObjectModel;
using Nummite.Shapes.Lines;

namespace Nummite.Forms
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
			return item.TypeName;
		}
	}
}