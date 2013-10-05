using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Nummite.Properties;
using Nummite.Shapes.Interfaces;
using Nummite.Shapes.Support;

namespace Nummite.Shapes.Net {
	class Hostname : TaggedImage {
		public Hostname() {
			AddTransformation("To IPv4", () => Resolve4(Text));
			AddTransformation("To IPv6", () => Resolve6(Text));
			AddTransformation("To IPv*", () => Resolve4(Text).Concat(Resolve6(Text)));
		}

		private static IEnumerable<IShape> Resolve6(string host) {
			var entry = Dns.GetHostEntry(host);
			return from addr in entry.AddressList
			       where addr.AddressFamily == AddressFamily.InterNetworkV6
			       select new Addressv6 { Text = addr.ToString() };
		}

		private static IEnumerable<IShape> Resolve4(string host) {
			var entry = Dns.GetHostEntry(host);
			return from addr in entry.AddressList
			       where addr.AddressFamily == AddressFamily.InterNetwork
			       select new Addressv4 { Text = addr.ToString() };
		}

		public static new string Description {
			get { return "Hostname"; }
		}

		protected override bool Validate() {
			return !Text.EndsWith(".");
		}

		protected override Image Image {
			get { return Resources.Hostname; }
		}
	}
}