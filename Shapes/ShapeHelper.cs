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
using System.Globalization;
using Nummite.Gencode;

namespace Nummite.Shapes
{
	class ShapeHelper<T> : IShapeHelper where T : IShape, new()
	{
		public IShape Create()
		{
			return new T();
		}

		public string TypeName
		{
			get
			{
				return typeof(T).Name;
			}
		}

		public ShapeHelper(string description, Image image)
		{
			Description = description;
			Image = image;
		}

		public string Description
		{
			get;
			private set;
		}

		public Image Image
		{
			get;
			private set;
		}

		public virtual void Save(T value, GEncoder writer)
		{
			writer.BeginDictionary();
			SaveType(writer);
			SaveName(value, writer);
			SaveLocation(value.Location, writer);
			SaveSize(value.Size, writer);
			SaveText(value, writer);
			writer.EndDictionary();
		}

		protected void SaveType(GEncoder writer)
		{
			writer.WritePair("type", TypeName);
		}



		protected void SaveText(T value, GEncoder writer)
		{
			writer.WritePair("text", value.Text);
		}




		protected void SaveName(T value, GEncoder writer)
		{
			writer.WritePair("name", value.Name);
		}

		protected void SaveSize(Size size, GEncoder writer)
		{
			writer.WritePair("width", size.Width);
			writer.WritePair("height", size.Height);
		}

		protected void SaveLocation(Point location, GEncoder writer)
		{
			writer.WritePair("x", location.X);
			writer.WritePair("y", location.Y);
		}

		protected void SaveFont(Font font, GEncoder writer)
		{
			writer.WriteString("font");
			writer.BeginDictionary();
			writer.WritePair("name", font.FontFamily.Name);
			writer.WritePair("unit", font.Unit.ToString());
			writer.WritePair("size", font.Size.ToString(CultureInfo.InvariantCulture));
			writer.WritePair("style", font.Style.ToString());
			writer.EndDictionary();
		}

		protected static string SerializeColor(Color color)
		{
			if (color.IsNamedColor)
				return string.Format(CultureInfo.InvariantCulture, "{0}:{1}",
					ColorFormat.NamedColor, color.Name);
			return string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}:{3}:{4}",
				ColorFormat.ArgbColor,
				color.A, color.R, color.G, color.B);
		}
	}
	public enum ColorFormat
	{
		NamedColor,
		ArgbColor
	}
}
