using System.Drawing;
using Nummite.Properties;
using Nummite.Shapes.Interfaces;
using Nummite.Shapes.Support;

namespace Nummite.Shapes.Net {
	class Domain : TaggedImage {
		public Domain() {
			AddTransformation("To hostname", () => new Hostname { Text = Text.Trim('.') });
		}

		public static new string Description {
			get { return "Domain"; }
		}

		protected override bool Validate() {
			return Text.EndsWith(".");
		}

		protected override Image Image {
			get { return Resources.Domain; }
		}

		public override string ToString() {
			return string.Format("[Domain {{ Text = {0}}}]", Text);
		}
	}
}
