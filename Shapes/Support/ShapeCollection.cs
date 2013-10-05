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

using System.Linq;
using Nummite.Graphs;
using Nummite.Shapes.Interfaces;
using Nummite.Shapes.Lines;
using System.Collections.Generic;

namespace Nummite.Shapes.Support {
	class ShapeCollection : List<IShape> {
		public Graph<IShape> ToGraph() {
			var nodes = from shape in this
			            where !(shape is Line)
			            select new Node<IShape>(shape);
			var nodesDictionary = nodes.ToDictionary(node => node.Value);
			foreach (var line in this.OfType<Line> ())
				if (line.Origin != line.Pointed)
					nodesDictionary[line.Origin].AddLink(nodesDictionary[line.Pointed]);

			return new Graph<IShape>(nodesDictionary.Values);
		}
	}
}
