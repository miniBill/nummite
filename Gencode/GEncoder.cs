using System.Globalization;
using System.IO;

namespace Nummite.Gencode
{
	class GEncoder
	{
		readonly StreamWriter stream;

		public GEncoder (StreamWriter stream)
		{
			this.stream = stream;
		}
		public void BeginDictionary ()
		{
			stream.Write ('d');
		}

		public void EndDictionary ()
		{
			stream.Write ('e');
		}

		public void WritePair (string key, bool value)
		{
			WriteString (key);
			WriteBool (value);
		}
		public void WritePair(string key, string value)
		{
			WriteString(key);
			WriteString(value);
		}

		private void WriteBool (bool value)
		{
			stream.Write (value ? 'T' : 'F');
		}

		public void WriteString (string key)
		{
			stream.Write (key.Length.ToString(CultureInfo.InvariantCulture));
			stream.Write (':');
			stream.Write (key);
		}

		public void WritePair (string key, int value)
		{
			WriteString(key);
			WriteInt(value);
		}

		private void WriteInt (int value)
		{
			stream.Write ('i');
			stream.Write (value.ToString (CultureInfo.InvariantCulture));
			stream.Write ('e');
		}

		public void BeginList ()
		{
			stream.Write ('l');
		}

		public void EndList()
		{
			stream.Write('e');
		}
	}
}