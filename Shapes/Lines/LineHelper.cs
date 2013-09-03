/* Copyright (C) 2008 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
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
using System.Drawing;
using System.Xml;
using Nummite.Gencode;
using Nummite.Properties;

namespace Nummite.Shapes.Lines
{
	class LineHelper<T> : ShapeHelper<T>, ILineHelper, IPersistableHelper where T : Line, new()
	{
		public LineHelper(string name, Image image)
			: base(name, image)
		{
		}

		public new Line Create()
		{
			return new T();
		}

		public override void Save(T value, GEncoder encoder)
		{
			if (value == null)
				throw new ArgumentNullException ("value");
			if (encoder == null)
				throw new ArgumentNullException ("encoder");
			encoder.BeginDictionary();
			SaveType(encoder);
			SaveOrigin(value.Origin, encoder);
			SavePointed(value.Pointed, encoder);
			SaveName(value, encoder);
			SaveFont(value.Font, encoder);
			SaveColors(value, encoder);
			SaveText(value, encoder);
			encoder.EndDictionary();
		}
		protected static void SaveColors(T value, GEncoder writer)
		{
			writer.WritePair("foregroundColor", SerializeColor(value.ForegroundColor));
			writer.WritePair("backgroundColor", SerializeColor(value.BackgroundColor));
			writer.WritePair("borderColor", SerializeColor(value.BorderColor));
		}

		static void SavePointed(IShape pointed, GEncoder writer)
		{
			writer.WritePair("pointed", pointed.Name);
		}

		static void SaveOrigin(IShape origin, GEncoder writer)
		{
			writer.WritePair("origin", origin.Name);
		}

		public IShape Load(GDictionary shape)
		{
			var toret = new T();
			foreach (var pair in shape)
			{
				var key = pair.Key as string;
				object value = pair.Value;
				LoadPair (toret, key, value);
			}
			return toret;
		}

		private static void LoadPair (T toret, string key, object value)
		{
			switch (key) {
				case "origin":
					toret.OriginName = value as string;
					break;
				case "pointed":
					toret.PointedName = value as string;
					break;
				case "name":
					toret.Name = value as string;
					break;
				case "x":
					toret.X = (int) value;
					break;
				case "y":
					toret.Y = (int) value;
					break;
				case "height":
					toret.Height = (int) value;
					break;
				case "width":
					toret.Width = (int) value;
					break;
				case "font":
					toret.Font = ParseFont (value as GDictionary);
					break;
				case "foregroundColor":
					toret.ForegroundColor = ParseColor (value as string) ?? Color.Magenta;
					break;
				case "backgroundColor":
					toret.BackgroundColor = ParseColor (value as string) ?? Color.Magenta;
					break;
				case "borderColor":
					toret.BorderColor = ParseColor (value as string) ?? Color.Magenta;
					break;
				case "text":
					toret.Text = (string) value;
					break;
			}
		}

		public void SvgSave(IShape shape, XmlWriter writer)
		{
			var value = shape as T;
			if (value == null)
				throw new ArgumentException(Resources.IncorrectShapeType, "shape");
			SvgSave(value, writer);
		}
		public void SvgSave(T shape, XmlWriter writer)
		{
			throw new NotImplementedException();
		}
		public void Save(IShape shape, GEncoder encoder)
		{
			var value = shape as T;
			if (value == null)
				throw new ArgumentException(Resources.IncorrectShapeType, "shape");
			((ShapeHelper<T>)this).Save(value, encoder);
		}
	}
}
