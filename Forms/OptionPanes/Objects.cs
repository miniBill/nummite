/* Copyright (C) 2009 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
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

using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagramDrawer.Forms.OptionPanes {
	public partial class Objects : UserControl, IOptionPane {
		public Objects() {
			Children = new List<IOptionPane>();
			InitializeComponent();
		}

		public IEnumerable<IOptionPane> Children {
			get;
			private set;
		}

		public new void Load() {
			numericUpDown1.Value = Options.MinimumWidth;
			numericUpDown2.Value = Options.MinimumHeight;
		}
		public void Save() {
			Options.MinimumWidth = (int)numericUpDown1.Value;
			Options.MinimumHeight = (int)numericUpDown2.Value;
		}
	}
}
