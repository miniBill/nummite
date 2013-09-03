using System.Collections;
using System.Collections.Generic;

namespace Nummite.Gencode
{
	class GDictionary : GObject, IEnumerable<KeyValuePair<object, object>>
	{
		readonly Dictionary<object, object> dictionary = new Dictionary<object, object>();
		public object this[object key]
		{
			get { return dictionary.ContainsKey(key) ? dictionary[key] : null; }
		}

		public void Add(object key, object value)
		{
			dictionary.Add(key, value);
		}

		public IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			return dictionary.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
	}
}