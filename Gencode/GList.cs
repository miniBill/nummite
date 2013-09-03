using System.Collections;
using System.Collections.Generic;

namespace Nummite.Gencode
{
	class GList : GObject, IEnumerable
	{
		readonly List<object> list = new List<object>();

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public void Add(object value)
		{
			list.Add(value);
		}
	}
}