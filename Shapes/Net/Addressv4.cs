using System.Drawing;
using Nummite.Properties;

namespace Nummite.Shapes.Net {
	class Addressv4 : Address {
		public static new string Description {
			get { return "IPv4"; }
		}

		protected override bool Validate() {
			return true;
		}

		protected override Image Image {
			get { return Resources.IPv4; }
		}
	}
}