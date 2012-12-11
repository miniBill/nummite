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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramDrawer.Forms {
	public class CheckableToolStripSplitButton : ToolStripSplitButton {
		static readonly Brush Bb = new LinearGradientBrush(new Point(0, 0), new Point(0, 22), Color.FromArgb(255, 220, 150), Color.FromArgb(255, 170, 80));
		static readonly Brush Rb = new LinearGradientBrush(new Point(0, 0), new Point(0, 22), Color.FromArgb(255, 170, 80), Color.FromArgb(255, 220, 150));
		Rectangle ButtonBound {
			get {
				return new Rectangle(ButtonBounds.X, ButtonBounds.Y, ButtonBounds.Width, ButtonBounds.Height - 1);
			}
		}
		Rectangle DropBound {
			get {
				return new Rectangle(DropDownButtonBounds.X - 1, DropDownButtonBounds.Y, DropDownButtonBounds.Width, DropDownButtonBounds.Height - 1);
			}
		}
		bool _over;
		protected override void OnMouseEnter(EventArgs e) {
			_over = true;
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e) {
			_over = false;
			base.OnMouseLeave(e);
		}
		protected override void OnPaint(PaintEventArgs e) {
			Rectangle clip = e.ClipRectangle;
			clip = new Rectangle(0, 0, Width, Height - 1);//HACK: needs os specific code
			Rectangle btb = ButtonBound;
			btb = new Rectangle(0, 0, 20, Height - 1);//HACK: needs os specific code
			Rectangle ddb = DropBound;
			ddb = new Rectangle(20, 0, Width - 20 - 1, Height - 1);//HACK: needs os specific code
			if(Checked) {
				e.Graphics.FillRectangle(_over ? Rb : Bb, clip);
				e.Graphics.DrawRectangles(Pens.Black, new[] { btb, ddb });
			}
			base.OnPaint(e);
		}
		bool _ck;

		[Category("Appearance")]
		[Description("Controls wheter the CheckableButton will appear checked")]
		[DefaultValue(false)]
		public bool Checked {
			get {
				return _ck;
			}
			set {
				_ck = value;
				if(Parent != null)
					Parent.Refresh();
			}
		}
	}
}
