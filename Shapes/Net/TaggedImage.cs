using System;
using System.Drawing;
using Nummite.Shapes.Basic;

namespace Nummite.Shapes.Net {
	abstract class TaggedImage : Box
	{
		private const int PADDING = 5;

		protected TaggedImage ()
		{
			TextChanged += delegate {
				ForegroundColor = Validate () ? Color.Black : Color.Red;
			};
		}

		protected abstract bool Validate ();

		public override StringAlignment LineAlignment {
			get { return StringAlignment.Near; }
		}

		public override Point TextPosition {
			get { return new Point (Center.X, Location.Y + Image.Height + PADDING); }
		}

		protected override void DrawBackground (Graphics graphics)
		{
			graphics.DrawImage (Image, Center.X - Image.Width / 2, Location.Y, Image.Width, Image.Height);
		}

		protected override void DoAutoResize ()
		{
			if (ShapeContainer == null)
				return;
			Size newSize;
			using (var g = ShapeContainer.CreateGraphics ())
				newSize = GetSize (g, Text, Font);
			newSize.Width = AutoResizeWidth ? Math.Max (newSize.Width, Image.Width) : Width;
			newSize.Height += Image.Height + PADDING;
			Size = newSize;
			ShapeContainer.ForceRefresh ();
		}

		protected abstract Image Image { get; }
	}
}