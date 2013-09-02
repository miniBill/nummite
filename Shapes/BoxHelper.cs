using System;
using System.Drawing;
using System.Xml;
using Nummite.Export;
using Nummite.Gencode;

namespace Nummite.Shapes
{
	internal class BoxHelper<T> : ShapeHelper<T>, IPersistableHelper where T : Box, new()
	{
		public BoxHelper(string description, Image image)
			: base(description, image)
		{

		}

		public override void Save(T value, GEncoder writer)
		{
			writer.BeginDictionary();
			SaveType(writer);
			SaveName(value, writer);
			SaveLocation(value.Location, writer);
			SaveSize(value.Size, writer);
			SaveFont(value.Font, writer);
			SaveColors(value, writer);
			SaveText(value, writer);
			SaveAuto(value, writer);
			writer.EndDictionary();
		}
		private void SaveAuto(T value, GEncoder writer)
		{
			writer.WritePair("autoresizewidth", value.AutoResizeWidth);
			writer.WritePair("autoresizeheight", value.AutoResizeHeight);
		}
		protected void SaveColors(T value, GEncoder writer) 
		{
			writer.WritePair("foregroundColor", SerializeColor(value.ForegroundColor));
			writer.WritePair("backgroundColor", SerializeColor(value.BackgroundColor));
			writer.WritePair("borderColor", SerializeColor(value.BorderColor));
		}

		public void SvgSave (T shape, XmlWriter writer)
		{
			throw new System.NotImplementedException ();
		}

		public IShape Load (GDecoder stream)
		{
			throw new System.NotImplementedException ();
		}

		public void SvgSave (IShape shape, XmlWriter writer)
		{
			throw new System.NotImplementedException ();
		}

		public void Save (IShape shape, GEncoder encoder)
		{
			T value = shape as T;
			if(value==null)
				throw new ArgumentException("Shape is of incorrect type","shape");
			Save (value, encoder);
		}
	}
}