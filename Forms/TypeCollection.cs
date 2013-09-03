using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nummite.Forms
{
	class TypeCollection : KeyedCollection<string, Type>
	{
		protected override string GetKeyForItem(Type item)
		{
			if (item == null)
				throw new ArgumentNullException ("item");
			return item.FullName;
		}

		public void AddRange(IEnumerable<Type> types)
		{
			foreach (var t in types)
				Add(t);
		}
	}
}