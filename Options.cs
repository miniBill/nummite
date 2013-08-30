namespace DiagramDrawer {
	static class Options {
		static Options() {
			AutoCreateOnLink = true;
			AskForSave = true;
			MinimumHeight = MinimumWidth = 30;
			CheckForUpdates = true;
			UpdateUrl = "https://raw.github.com/miniBill/DiagramDrawer/master/version";
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
		public static bool CheckForUpdates {
			get;
			set;
		}
		public static string UpdateUrl {
			get;
			set;
		}
	}
}
