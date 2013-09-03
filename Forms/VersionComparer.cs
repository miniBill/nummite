namespace Nummite.Forms
{
	static class VersionComparer
	{
		public static int Compare(string s1, string s2)
		{
			var v1 = SemanticVersion.Parse(s1);
			var v2 = SemanticVersion.Parse(s2);
			return v1.CompareTo(v2);
		}
	}
}