using System;
using Nummite.Gencode;
using Nummite.Properties;

namespace Nummite.Shapes
{
	class ImageBoxHelper : ShapeHelper<ImageBox>
	{
		public ImageBoxHelper()
			: base("Immagine", Resources.PictureBox)
		{
		}

		public override void Save(ImageBox value, GEncoder encoder)
		{
			if (value == null)
				throw new ArgumentNullException ("value");
			if (encoder == null)
				throw new ArgumentNullException ("encoder");
			encoder.BeginDictionary();
			SaveName(value, encoder);
			SaveLocation(value.Location, encoder);
			SaveSize(value.Size, encoder);
			SaveImage(value, encoder);
			encoder.EndDictionary();
		}

		static void SaveImage(ImageBox value, GEncoder writer)
		{
			writer.WritePair("image", value.FileName);
		}

		public virtual IShape Load(GDictionary shape)
		{
			var toret = new ImageBox();
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
					case "image":
						toret.FileName = value as string;
						break;
				}
			}
			return toret;
		}
	}
}
