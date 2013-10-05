namespace Nummite {
	static class Options
	{
		public const float TOLERANCE = 1e-10f;

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
