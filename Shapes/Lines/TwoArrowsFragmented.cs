/* Copyright (C) 2008 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
 *
 * This file is part of Diagram Drawer.
 *
 * Diagram Drawer is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Diagram Drawer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Diagram Drawer.  If not, see <http://www.gnu.org/licenses/>.
 */

using DiagramDrawer.Properties;
using System.Drawing;

namespace DiagramDrawer.Shapes {
	class TwoArrowsFragmented : OneArrowFragmented
	{
		public override void DrawTo (Graphics graphics)
		{
			SetShapeContainer ();
			if (!ShouldDraw ())
				return;
			if (!(SubLines [0] is OneArrow)) {
				SubLines [0] = new OneArrow {
					Origin = SubPoints [0]
				};
				if (Origin != null)
					SubLines [0].Pointed = Origin;
			}
			base.DrawTo (graphics);
		}

		public override string ToString ()
		{
			return "Spezzata con doppia freccia";
		}

		public override Image Image {
			get {
				return Resources.TwoArrowsFragmented;
			}
		}
	}
}
