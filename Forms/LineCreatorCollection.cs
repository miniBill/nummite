using System.Collections.ObjectModel;
using DiagramDrawer.Shapes.Lines;

namespace DiagramDrawer.Forms
{
	class LineCreatorCollection : KeyedCollection<string, ILineCreator>
	{
		public void AddRange(params ILineCreator[] shapeCreators)
		{
			foreach (var shapeCreator in shapeCreators)
				Add(shapeCreator);
		}

		protected override string GetKeyForItem(ILineCreator item)
		{
			return item.TypeName;
		}
	}
}