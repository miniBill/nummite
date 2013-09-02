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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml;
using Nummite.Shapes;
using System.Text;

namespace Nummite.Export {
	static class Svg {
		internal static void Save(XmlWriter writer, IEnumerable<IShape> shapes, Size size) {
			if (writer == null)
				throw new ArgumentNullException ("writer");
			writer.WriteStartDocument (false);
			writer.WriteDocType ("svg", "-//W3C//Dtd SVG 1.1//EN",
			                    "http://www.w3.org/Graphics/SVG/1.1/Dtd/svg11.dtd", null);
			writer.WriteStartElement ("svg", "http://www.w3.org/2000/svg");
			writer.WriteAttributeString ("width", SafeString (size.Width));
			writer.WriteAttributeString ("height", SafeString (size.Height));
			writer.WriteAttributeString ("version", "1.1");
			writer.WriteAttributeString ("preserveAspectratio", "xMidYMid");
			if (shapes != null)
				foreach (var s in shapes) {
					var pers = s as IPersistableShape;
					if (pers != null)
						pers.SvgSave (writer);
				}
			writer.WriteEndElement ();
		}
		internal static void WriteRectangle(XmlWriter writer, Point location, Size size, Color fill, Pen forePen) {
			writer.WriteStartElement("rect");

			writer.WriteAttributeString("x", SafeString(location.X));
			writer.WriteAttributeString("y", SafeString(location.Y));
			writer.WriteAttributeString("width", SafeString(size.Width));
			writer.WriteAttributeString("height", SafeString(size.Height));
			writer.WriteAttributeString("style",
				"fill:" + ColorString(fill) +
				";stroke:" + ColorString(forePen.Color) +
				";stroke-width:" + SafeString(forePen.Width)
			);

			writer.WriteEndElement();
		}
		internal static void WriteText(XmlWriter writer, Point location, Color fill, Font font, string text) {
			var lines = text.Split (new[] { Environment.NewLine }, StringSplitOptions.None);
			for (var c = 0; c < lines.Length; c++) {
				writer.WriteStartElement ("text");
				writer.WriteAttributeString ("x", SafeString (location.X));
				writer.WriteAttributeString ("y",
				                            SafeString (location.Y + font.Size * c * 4 / 3));
				writer.WriteAttributeString ("style",
				                            "fill:" + ColorString (fill) +
					/*";font-family:" + font.FontFamily.Name.ToLowerInvariant() +*/
				                            ";font-size:" + SafeString (Math.Round (font.Size * 1.40F)) + "px" +
				                            ";text-anchor:middle"
				);
				writer.WriteValue (lines [c]);
				writer.WriteEndElement ();
			}
		}

		static string ColorString(Color c) {
			return c.IsNamedColor
				? c.Name.ToLowerInvariant () 
				: "#" + c.Name.ToLowerInvariant ().Substring (2);
		}

		internal static void WriteLine(XmlWriter writer, PointF from, PointF to, Pen pen) {
			writer.WriteStartElement ("line");

			writer.WriteAttributeString ("x1", SafeString (from.X));
			writer.WriteAttributeString ("y1", SafeString (from.Y));
			writer.WriteAttributeString ("x2", SafeString (to.X));
			writer.WriteAttributeString ("y2", SafeString (to.Y));
			writer.WriteAttributeString ("style",
			                            "stroke:" + ColorString (pen.Color) +
			                            ";stroke-width:" + SafeString (pen.Width)
			);
			writer.WriteEndElement ();
		}
		internal static void WriteStartLink(XmlWriter writer, string text) {
			writer.WriteStartElement ("a");
			writer.WriteAttributeString ("href", "http://www.w3.org/1999/xlink", text);
		}
		internal static void WriteEndLink(XmlWriter writer) {
			writer.WriteEndElement();
		}
		internal static void WriteEllipse(XmlWriter writer, Point center, Size size, Color fill, Pen forePen) {
			writer.WriteStartElement ("ellipse");

			writer.WriteAttributeString ("cx", SafeString (center.X));
			writer.WriteAttributeString ("cy", SafeString (center.Y));
			writer.WriteAttributeString ("rx", SafeString (size.Width / 2F));
			writer.WriteAttributeString ("ry", SafeString (size.Height / 2F));
			writer.WriteAttributeString ("style",
			                            "fill:" + ColorString (fill) +
			                            ";stroke:" + ColorString (forePen.Color) +
			                            ";stroke-width:" + SafeString (forePen.Width)
			);

			writer.WriteEndElement ();
		}

		internal static void WritePolygon(XmlWriter writer, PointF[] points, Color fill) {
			writer.WriteStartElement ("polygon");
			var sb = new StringBuilder ();
			for (var i = 0; i < points.Length; i++) {
				sb.Append (
					SafeString (points [i].X) + "," + SafeString (points [i].Y));
				if (i != (points.Length - 1))
					sb.Append (",");
			}
			writer.WriteAttributeString ("points", sb.ToString ());
			writer.WriteAttributeString ("style", "fill:" + ColorString (fill));
			writer.WriteEndElement ();
		}

		static string SafeString(double f) {
			return f.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
		}

		internal static void WriteRoundedRectangle(XmlWriter writer, Point location, Size size, Color fill, Pen pen, int radius) {
			writer.WriteStartElement ("rect");

			writer.WriteAttributeString ("x", SafeString (location.X));
			writer.WriteAttributeString ("y", SafeString (location.Y));
			writer.WriteAttributeString ("width", SafeString (size.Width));
			writer.WriteAttributeString ("height", SafeString (size.Height));
			writer.WriteAttributeString ("style",
			                            "fill:" + ColorString (fill) +
			                            ";stroke:" + ColorString (pen.Color) +
			                            ";stroke-width:" + SafeString (pen.Width)
			);
			writer.WriteAttributeString ("rx", SafeString (radius));
			writer.WriteAttributeString ("ry", SafeString (radius));

			writer.WriteEndElement ();
		}
	}
}
