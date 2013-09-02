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

using System.Drawing;
using Nummite.Gencode;

namespace Nummite.Shapes.Lines
{
	class LineHelper<T> : ShapeHelper<T>, ILineHelper where T : Line, new()
	{
		public LineHelper(string name, Image image)
			: base(name, image)
		{
		}

		public new Line Create()
		{
			return new T();
		}

		public override void Save(T value, GEncoder writer)
		{
			writer.BeginDictionary();
			SaveType(writer);
			SaveOrigin(value.Origin, writer);
			SavePointed(value.Pointed, writer);
			SaveName(value, writer);
			SaveFont(value.Font, writer);
			SaveColors(value, writer);
			SaveText(value, writer);
			writer.EndDictionary();
		}
		protected void SaveColors(T value, GEncoder writer)
		{
			writer.WritePair("foregroundColor", SerializeColor(value.ForegroundColor));
			writer.WritePair("backgroundColor", SerializeColor(value.BackgroundColor));
			writer.WritePair("borderColor", SerializeColor(value.BorderColor));
		}

		void SavePointed(IShape pointed, GEncoder writer)
		{
			writer.WritePair("pointed", pointed.Name);
		}

		void SaveOrigin(IShape origin, GEncoder writer)
		{
			writer.WritePair("origin", origin.Name);
		}
	}
}
