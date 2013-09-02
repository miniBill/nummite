using System;
using System.IO;

namespace Nummite.Gencode
{
	class GDecoder
	{
		readonly StreamReader reader;

		public GDecoder(StreamReader reader)
		{
			this.reader = reader;
		}
		public GDictionary ReadDictionary()
		{
			throw new NotImplementedException();
		}
	}
}