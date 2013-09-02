/* Copyright (C) 2009 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
 *
 * This file is part of Nummite.
 *
 * Nummite is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Nummite is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Nummite.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Nummite.Export;
using Nummite.Properties;
using Nummite.Forms;

namespace Nummite.Shapes {
	class Link : Ellipse
	{
		public Link ()
		{
			BackgroundColor = Color.LightBlue;
			Width = Height = 10;
			var mi = new MenuItem ("Vai", delegate {
				if (ShapeContainer.ParentForm != null)
					((MainForm)ShapeContainer.ParentForm).Controller.Open (Text);
			});
			ContextMenu.MenuItems.Add (0, mi);
		}

		public override void DrawTo (Graphics graphics)
		{
			DrawBackground (graphics);
		}

		public static new string Name { 
			get{
				return "Collegamento";
			}
		}

		protected override void OnTextChange ()
		{
			if (Text == "...")
				Text = string.Empty;
			base.OnTextChange ();
		}

		const int RADIUS = 10;

		protected override void OnSizeChange ()
		{
			Width = RADIUS;
			Height = RADIUS;
			base.OnSizeChange ();
		}

		public readonly static new IShapeHelper Helper = new ShapeHelper<Link> (Name, Resources.WLink);

		public override void SvgSave (XmlWriter writer)
		{
			Svg.WriteStartLink (writer, Text.Replace (".xml", ".svg"));
			Svg.WriteEllipse (writer, Center, Size, BackgroundColor, BorderPen);
			Svg.WriteEndLink (writer);
		}
	}
}