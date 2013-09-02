using System;

namespace Nummite.Gencode
{
	static class GObjectHelper
	{
		public static T? As<T>(this GObject value) where T : struct
		{
			if (value == null)
				return null;
			throw new NotImplementedException();
		}

		public static T GetObject<T>(this GDictionary value, string key) where T : class
		{
			if (value == null)
				return null;
			return value[key] as T;
		}

		public static T? GetValue<T>(this GDictionary value, string key) where T : struct
		{
			if (value == null)
				return null;
			return value[key] as T?;
		}
	}
}