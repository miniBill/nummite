using System;
using System.Diagnostics;
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
		public object ReadRoot()
		{
			return ReadNext();
		}

		private object ReadNext()
		{
			switch (reader.Peek())
			{
				case 'd':
					return ReadGDictionary();
				case 'l':
					return ReadGList();
				case 'i':
					return ReadGInt();
				case 'T':
					AssertRead('T');
					return true;
				case 'F':
					AssertRead ('F');
					return false;
				case 'e':
					AssertRead('e');
					return GEnd.Instance;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					return ReadGString();
				default:
					throw new ParseException(string.Format("Unrecognized marker: {0}", (char)reader.Peek()));
			}
		}

		private string ReadGString()
		{
			int len = ReadInt();
			AssertRead(':');
			var buffer = new char[len];
			reader.Read(buffer, 0, len);
			return new String(buffer);
		}

		private int ReadInt()
		{
			int toret = 0;
			while (IsDigit(reader.Peek()))
			{
				toret *= 10;
				toret += reader.Read() - '0';
			}
			return toret;
		}

		private static bool IsDigit(int peek)
		{
			return peek >= '0' && peek <= '9';
		}

		private int ReadGInt()
		{
			AssertRead('i');
			int toret = ReadInt();
			AssertRead('e');
			return toret;
		}

		private void AssertRead(char test)
		{
			int read = reader.Read();
			Debug.Assert(read == test);
		}

		private GList ReadGList()
		{
			AssertRead ('l');
			var toret = new GList ();
			object value;
			while ((value = ReadNext ()) != GEnd.Instance) {
				toret.Add (value);
			}
			return toret;
		}

		private GDictionary ReadGDictionary()
		{
			AssertRead('d');
			var toret = new GDictionary();
			object key;
			while ((key = ReadNext()) != GEnd.Instance) {
				if (!(key is string))
					throw new ParseException ("Key must be a string");
				object value = ReadNext ();
				if (value == GEnd.Instance)
					throw new ParseException ("Early end of dictionary");
				toret.Add (key, value);
			}
			return toret;
		}
	}

	internal class GEnd : GObject
	{
		public static GEnd Instance = new GEnd();
		private GEnd() { }
	}

	[Serializable]
	public class ParseException : Exception
	{
		public ParseException(string message)
			: base(message)
		{
		}
	}
}