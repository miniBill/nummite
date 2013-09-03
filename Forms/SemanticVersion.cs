using System;

namespace Nummite.Forms
{
	class SemanticVersion : IComparable<SemanticVersion>
	{
		public int Major { get; private set; }
		public int Minor { get; private set; }
		public int Patch { get; private set; }
		public string Prerelease { get; private set; }
		public string Metadata { get; private set; }

		public static SemanticVersion Parse(string input)
		{
			string[] split = input.Split('.');
			int major = Int32.Parse(split[0]);
			int minor = Int32.Parse(split[1]);
			int hypenidx = split[2].IndexOf('-');
			int patch = Int32.Parse(hypenidx < 0 ? split[2] : split[2].Substring(0, hypenidx));
			string prerelease = null;
			string metadata = null;
			if (hypenidx >= 0)
			{
				int plusidx = split[2].IndexOf('+');
				prerelease = plusidx < 0
					? split[2].Substring(hypenidx + 1)
					: split[2].Substring(hypenidx + 1, plusidx - hypenidx);
				if (plusidx >= 0)
					metadata = split[2].Substring(plusidx + 1);
			}
			return new SemanticVersion(major, minor, patch, prerelease, metadata);
		}

		public int CompareTo(SemanticVersion other)
		{
			if (other == null)
				return 1;
			if (Major != other.Major)
				return Major.CompareTo(other.Major);
			if (Minor != other.Minor)
				return Minor.CompareTo(other.Minor);
			if (Patch != other.Patch)
				return Patch.CompareTo(other.Patch);
			if (Prerelease == null)
			{
				if (other.Prerelease == null)
					return 0;
				if (other.Prerelease != null)
					return 1;
			}
			if (Prerelease != null)
			{
				if (other.Prerelease == null)
					return -1;
				if (other.Prerelease != null)
					return String.Compare(Prerelease, other.Prerelease, StringComparison.Ordinal);
			}
			return 0;
		}

		public SemanticVersion(int major, int minor, int patch, string prerelease, string metadata)
		{
			Major = major;
			Minor = minor;
			Patch = patch;
			Prerelease = prerelease;
			Metadata = metadata;
		}
	}
}