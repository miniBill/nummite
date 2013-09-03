using System;
using System.Drawing;
using System.Xml;
using Nummite.Gencode;
using Nummite.Properties;

namespace Nummite.Shapes
{
	internal class BoxHelper<T> : ShapeHelper<T>, IPersistableHelper where T : Box, new()
	{
		public BoxHelper(string description, Image image)
			: base(description, image)
		{

		}

		public override void Save(T value, GEncoder encoder)
		{
			if (value == null)
				throw new ArgumentNullException ("value");
			if (encoder == null)
				throw new ArgumentNullException ("encoder");
			encoder.BeginDictionary();
			SaveType(encoder);
			SaveName(value, encoder);
			SaveLocation(value.Location, encoder);
			SaveSize(value.Size, encoder);
			SaveFont(value.Font, encoder);
			SaveColors(value, encoder);
			SaveText(value, encoder);
			SaveAuto(value, encoder);
			encoder.EndDictionary();
		}
		private static void SaveAuto(T value, GEncoder encoder)
		{
			encoder.WritePair("autoresizewidth", value.AutoResizeWidth);
			encoder.WritePair("autoresizeheight", value.AutoResizeHeight);
		}
		protected static void SaveColors(T value, GEncoder encoder)
		{
			encoder.WritePair("foregroundColor", SerializeColor(value.ForegroundColor));
			encoder.WritePair("backgroundColor", SerializeColor(value.BackgroundColor));
			encoder.WritePair("borderColor", SerializeColor(value.BorderColor));
		}

		public void SvgSave(T shape, XmlWriter writer)
		{
			throw new NotImplementedException();
		}

		public IShape Load(GDictionary shape)
		{
			var toret = new T();
			foreach (var pair in shape)
			{
				var key = pair.Key as string;
				object value = pair.Value;
				switch (key)
				{
					case "name":
						toret.Name = value as string;
						break;
					case "x":
						toret.X = (int)value;
						break;
					case "y":
						toret.Y = (int)value;
						break;
					case "height":
						toret.Height = (int)value;
						break;
					case "width":
						toret.Width = (int)value;
						break;
					case "font":
						toret.Font = ParseFont(value as GDictionary);
						break;
					case "foregroundColor":
						toret.ForegroundColor = ParseColor(value as string) ?? Color.Magenta;
						break;
					case "backgroundColor":
						toret.BackgroundColor = ParseColor(value as string) ?? Color.Magenta;
						break;
					case "borderColor":
						toret.BorderColor = ParseColor(value as string) ?? Color.Magenta;
						break;
					case "text":
						toret.Text = value as string;
						break;
					case "autoresizewidth":
						toret.AutoResizeWidth = (bool)value;
						break;
					case "autoresizeheight":
						toret.AutoResizeHeight = (bool)value;
						break;
				}
			}
			return toret;
		}

		public void SvgSave(IShape shape, XmlWriter writer)
		{
			var value = shape as T;
			if (value == null)
				throw new ArgumentException(Resources.IncorrectShapeType, "shape");
			SvgSave(value, writer);
		}

		public void Save(IShape shape, GEncoder encoder)
		{
			var value = shape as T;
			if (value == null)
				throw new ArgumentException(Resources.IncorrectShapeType, "shape");
			((ShapeHelper<T>)this).Save(value, encoder);
		}
	}
}