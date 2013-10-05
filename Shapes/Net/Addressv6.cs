using System.Drawing;
using Nummite.Properties;

namespace Nummite.Shapes.Net {
	class Addressv6 : Address {
		public static new string Description {
			get { return "IPv6"; }
		}

		protected override bool Validate() {
			return true;
		}

		protected override Image Image {
			get { return Resources.IPv6; }
		}
	}
}