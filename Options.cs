namespace Nummite {
	static class Options
	{
		public const string UPDATE_URL = "http://raw.github.com/miniBill/nummite/master/version";

		static Options ()
		{
			AutoCreateOnLink = true;
			AskForSave = true;
			MinimumHeight = MinimumWidth = 30;
		}

		public static int MinimumWidth {
			get;
			set;
		}

		public static int MinimumHeight {
			get;
			set;
		}

		public static bool AutoCreateOnLink {
			get;
			set;
		}

		public static bool AskForSave {
			get;
			set;
		}
	}
}
