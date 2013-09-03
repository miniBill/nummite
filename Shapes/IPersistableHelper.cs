using System.Xml;
using Nummite.Gencode;

namespace Nummite.Shapes
{
	interface IPersistableHelper : IShapeHelper
	{
		IShape Load(GDictionary shape);
		void SvgSave(IShape shape, XmlWriter writer);
		void Save(IShape shape, GEncoder encoder);
	}
}