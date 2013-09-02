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

namespace Nummite.Shapes {
	class ShapeCreator<T> : IShapeCreator where T: IPersistableShape, new()
	{
		public IPersistableShape Create ()
		{
			return new T ();
		}

		public string TypeName { 
			get { 
				return typeof(T).Name;
			}
		}

		public ShapeCreator (string description, Image image)
		{
			Description = description;
			Image = image;
		}

		public string Description { 
			get; 
			private set; 
		}

		public Image Image {
			get;
			private set;
		}
	}
}
