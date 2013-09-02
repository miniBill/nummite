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

		public override void Save(ImageBox value, GEncoder writer)
		{
			writer.BeginDictionary();
			SaveName(value, writer);
			SaveLocation(value.Location, writer);
			SaveSize(value.Size, writer);
			SaveImage(value, writer);
			writer.EndDictionary();
		}

		void SaveImage(ImageBox value, GEncoder writer)
		{
			writer.WritePair("image", value.FileName);
		}
	}
}
