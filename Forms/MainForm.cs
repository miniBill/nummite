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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Nummite.Properties;
using Nummite.Shapes.Interfaces;
using Nummite.Shapes.Support;
using Nummite.Controller;

namespace Nummite.Forms {
	partial class MainForm : Form {
		public ShapeController Controller {
			get;
			private set;
		}

		void SetupShapeTypes() {
			EventHandler libraryHandler = LibraryItemClick;
			foreach (ShapeType<IShape> type in ShapeDictionary.ShapeTypes) {
				AddShapeType(type, libraryTS, libraryHandler);
				AddShapeType(type, objectsTSMI, libraryHandler);
			}
			EventHandler lTypeHandler = LineItemClick;
			foreach (ShapeType<Nummite.Shapes.Lines.Line> type in ShapeDictionary.LineTypes) {
				AddShapeType(type, linkModeTS, lTypeHandler);
				AddShapeType(type, lineKindTSMI, lTypeHandler);
			}
			SetDefaultObjects(ShapeDictionary.DefaultShapeType, ShapeDictionary.DefaultLineType);
		}

		public MainForm() {
			InitializeComponent();
			Controller = new ShapeController(shapeContainer1);
			Controller.MiddleDoubleClick += ShapeControllerMiddleDoubleClick;
			Controller.Opened += delegate {
				Text = String.Format(Resources.NummiteFmt, Controller.Filename);
			};
			Controller.Saved += delegate {
				Text = String.Format(Resources.NummiteFmt, Controller.Filename);
			};

			SetupShapeTypes();


			shapeContainer1.ForceRefresh();
		}

		void ShapeControllerMiddleDoubleClick(object sender, EventArgs e) {
			var i = 0;
			foreach (ToolStripItem item in linkModeTS.DropDownItems)
				if (((ToolStripMenuItem)item).Checked)
					i = linkModeTS.DropDownItems.IndexOf(item);
			LineItemClick(linkModeTS.DropDownItems[(i + 1) % linkModeTS.DropDownItems.Count], EventArgs.Empty);
			SetLock(linkModeTS, LockChange.Set);
			Controller.Container.Cursor = CrossCursor;
			linkModeTS.Owner.Refresh();
		}

		void SetDefaultObjects(ShapeType<IShape> s, ShapeType<Nummite.Shapes.Lines.Line> l) {
			libraryTS.Image = s.Image;
			libraryTS.Tag = s.GetType();
			shapeContainer1.ShapeType = s;
			linkModeTS.Image = l.Image;
			linkModeTS.Tag = l.GetType();
			shapeContainer1.LineType = l;
		}

		static void AddShapeType(IShapeType helper, ToolStripDropDownItem dropDownItem,
			EventHandler handler) {
			var i = new ToolStripMenuItem(helper.Description, helper.Image ?? Resources.Link, handler)
			{
				Tag = helper,
				ImageTransparentColor = Color.Magenta
			};
			dropDownItem.DropDownItems.Add(i);
		}

		void LineItemClick(object sender, EventArgs e) {
			var senderTsi = sender as ToolStripMenuItem;
			if (senderTsi == null)
				return;
			var maybeCreator = senderTsi.Tag as ShapeType<Nummite.Shapes.Lines.Line>?;
			if (maybeCreator == null)
				return;
			var creator = maybeCreator.Value;
			Controller.Container.LineType = creator;
			foreach (ToolStripMenuItem tsi in linkModeTS.DropDownItems)
				tsi.Checked = tsi.Tag == senderTsi.Tag;
			foreach (ToolStripMenuItem tsmi in lineKindTSMI.DropDownItems)
				tsmi.Checked = tsmi.Tag == senderTsi.Tag;
			linkModeTS.Image = creator.Image;
			SetLock(linkModeTS, LockChange.Set);
		}

		void LibraryItemClick(object sender, EventArgs e) {
			var s = sender as ToolStripMenuItem;
			if (s == null)
				return;
			var maybeCreator = s.Tag as ShapeType<IShape>?;
			if (maybeCreator == null)
				return;
			var creator = maybeCreator.Value;
			libraryTS.Image = creator.Image ?? Resources.Book;
			libraryTS.Tag = s.Tag;
			libraryTS.Text = creator.Description;
			Controller.Container.ShapeType = creator;
		}

		void LibraryTsButtonClick(object sender, EventArgs e) {
			if (libraryTS.Tag == null)
				return;
			Controller.Container.AddCurrentShapeAtPoint(Point.Empty);
		}

		Cursor CrossCursor {
			get {
				return locks.Values.All(ls => ls == LockState.Off) ? Cursors.Default : Cursors.Cross;

			}
		}

		void ShapeContainer1Click(object sender, ShapeEventArgs e) {
			if (CrossCursor == Cursors.Default)
				return;
			var styleable = e.Shape as IStyleable;
			if (styleable != null) {
				if (fontTS.Checked)
					styleable.Font = fontDialog.Font;
				if (bColorTS.Checked)
					styleable.BackgroundColor = bColorDialog.Color;
				if (fColorTS.Checked)
					styleable.ForegroundColor = fColorDialog.Color;
				if (borderColorTS.Checked)
					styleable.BorderColor = borderColorDialog.Color;
			}
			var keys = new CheckableToolStripSplitButton[locks.Count];
			locks.Keys.CopyTo(keys, 0);
			foreach (var t in keys.Where(t => t.Checked))
				SetLock(t, LockChange.Click);
			Controller.Container.ForceRefresh();
		}

		void AboutToolStripMenuItemClick(object sender, EventArgs e) {
			new AboutBox().Show(this);
		}

		void PrintDocument1PrintPage(object sender, PrintPageEventArgs e) {
			Controller.Container.PrintTo(e.Graphics, e.MarginBounds);
		}

		void PrintToolStripButtonClick(object sender, EventArgs e) {
			try {
				printDocument.Print();
			}
			catch (InvalidPrinterException) {
				MessageBox.Show(Resources.NoPrinter, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, Rtl());
			}
		}

		MessageBoxOptions Rtl() {
			return RightToLeft == RightToLeft.Yes
				? MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
				: 0;
		}

		void PrintPreviewToolStripMenuItemClick(object sender, EventArgs e) {
			printPreviewDialog.ShowDialog(this);
		}

		void PrintToolStripMenuItemClick(object sender, EventArgs e) {
			printDocument.Print();
		}

		void OpenToolStripButtonClick(object sender, EventArgs e) {
			Open();
		}

		void OpenToolStripMenuItemClick(object sender, EventArgs e) {
			Open();
		}

		void Open() {
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			Controller.Open(openFileDialog.FileName);
		}

		void SaveToolStripButtonClick(object sender, EventArgs e) {
			Save();
		}

		void SaveToolStripMenuItemClick(object sender, EventArgs e) {
			Save();
		}

		void Save() {
			if (Controller.Filename.Length == 0)
				SaveAs();
			else
				Controller.Save();
		}

		void SaveAs() {
			if (saveFileDialogXml.ShowDialog() != DialogResult.OK)
				return;
			Save(saveFileDialogXml.FileName);
		}

		void Save(string filename) {
			Controller.Save(filename);
			modified = false;
		}

		void NewToolStripMenuItemClick(object sender, EventArgs e) {
			New();
		}

		void New() {
			Controller.New();
			Text = Resources.Nummite;
		}

		void NewToolStripButtonClick(object sender, EventArgs e) {
			New();
		}

		void ShapeContainer1Link(object sender, EventArgs e) {
			if (locks[linkModeTS] == LockState.Locked)
				Controller.Container.LinkMode = true;
			else
				SetLock(linkModeTS, LockChange.Clear);
		}

		void SaveAsToolStripMenuItemClick(object sender, EventArgs e) {
			SaveAs();
		}

		enum LockChange {
			Click,
			DoubleClick,
			Clear,
			Set
		}

		void SetLock(CheckableToolStripSplitButton button, LockChange lockChange) {
			if (lockChange == LockChange.Clear) {
				if (!locks.ContainsKey(button))
					locks.Add(button, LockState.Off);
				else
					locks[button] = LockState.Off;
			}
			else if (!locks.ContainsKey(button))
				AddButton(button, lockChange);
			else
				SetButton(button, lockChange);
			button.Checked = locks[button] != LockState.Off;
			button.Owner.Refresh();
			Controller.Container.Cursor = CrossCursor;
			if (button == linkModeTS)
				Controller.Container.LinkMode = linkModeTS.Checked;
		}

		void SetButton(CheckableToolStripSplitButton button, LockChange lockChange) {
			switch (locks[button]) {
				case LockState.On:
					if (lockChange == LockChange.Click)
						locks[button] = LockState.Off;
					if (lockChange == LockChange.DoubleClick)
						locks[button] = LockState.Locked;
					break;
				case LockState.Off:
					if (button == linkModeTS)
						ClearLocks();
					else
						SetLock(linkModeTS, LockChange.Clear);
					locks[button] = lockChange == LockChange.DoubleClick
						? LockState.Locked
						: LockState.On;
					break;
				case LockState.Locked:
					if (lockChange == LockChange.DoubleClick)
						locks[button] = LockState.Off;
					break;
			}
		}

		void AddButton(CheckableToolStripSplitButton button, LockChange lockChange) {
			if (button == linkModeTS)
				ClearLocks();
			else
				SetLock(linkModeTS, LockChange.Clear);

			locks.Add(button, lockChange == LockChange.DoubleClick ? LockState.Locked : LockState.On);
		}

		void ClearLocks() {
			var l = new CheckableToolStripSplitButton[locks.Count];
			locks.Keys.CopyTo(l, 0);
			foreach (var t in l.Where(t => t != linkModeTS))
				SetLock(t, LockChange.Clear);
		}

		void ShapeContainer1MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle)
			if (locks.ContainsKey(linkModeTS) && locks[linkModeTS] == LockState.Locked)
				SetLock(linkModeTS, LockChange.Clear);
			else
				SetLock(linkModeTS, LockChange.Click);
		}

		void ExitToolStripMenuItemClick(object sender, EventArgs e) {
			Close();
		}

		void AltriToolStripMenuItemClick(object sender, EventArgs e) {
			if (fontDialog.ShowDialog() != DialogResult.OK)
				return;
			FontSelected();
		}

		void FontSelected() {
			SetLock(fontTS, LockChange.Set);
			AddCurrentFont();
			Controller.Container.Cursor = CrossCursor;
		}

		void TsiFontClick(object sender, EventArgs e) {
			fontDialog.Font = ((ToolStripItem)(sender)).Tag as Font;
			FontSelected();
		}

		void AddCurrentFont() {
			if (fontTS.DropDownItems.Count == 10)
				fontTS.DropDownItems.RemoveAt(9);
			ToolStripItem tsi = new ToolStripMenuItem(fontDialog.Font.Name + " " + fontDialog.Font.SizeInPoints + "pt")
			{
				Tag = fontDialog.Font
			};
			tsi.Click += TsiFontClick;
			fontTS.DropDownItems.Add(tsi);
		}

		void AltriToolStripMenuItem1Click(object sender, EventArgs e) {
			if (fColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while (fColorDialog.Color == Color.Magenta)
				fColorDialog.Color = Color.FromArgb(
					fColorDialog.Color.A, fColorDialog.Color.R - 1,
					fColorDialog.Color.G, fColorDialog.Color.B
				);
			ForegroundColorSelected();
		}

		void ForegroundColorSelected() {
			UpdateColorButton(fColorTS, fColorDialog);
			AddCurrentFColor();
		}

		void AddCurrentFColor() {
			ToolStripItem p = null;
			foreach (ToolStripItem item in fColorTS.DropDownItems)
				if (item.Text == fColorDialog.Color.Name)
					p = item;
			if (p != null) {
				fColorTS.DropDownItems.Remove(p);
				fColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if (fColorTS.DropDownItems.Count == 10) {
				fColorTS.DropDownItems[9].Image.Dispose();
				fColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(fColorDialog.Color.Name)
			{
				Image = new Bitmap(20, 20)
			};
			using (var g = Graphics.FromImage(tsi.Image))
			using (Brush b = new SolidBrush(fColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = fColorDialog.Color;
			tsi.Click += TsifColorClick;
			fColorTS.DropDownItems.Insert(0, tsi);
		}

		void TsifColorClick(object sender, EventArgs e) {
			fColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			ForegroundColorSelected();
		}

		void AltriToolStripMenuItem2Click(object sender, EventArgs e) {
			if (bColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while (bColorDialog.Color == Color.Magenta)
				bColorDialog.Color = Color.FromArgb(
					bColorDialog.Color.A, bColorDialog.Color.R - 1,
					bColorDialog.Color.G, bColorDialog.Color.B
				);
			BackgroundColorSelected();
		}

		void BackgroundColorSelected() {
			UpdateColorButton(bColorTS, bColorDialog);
			AddCurrentBColor();
		}

		void BorderColorSelected() {
			UpdateColorButton(borderColorTS, borderColorDialog);
			AddCurrentBorderColor();
		}

		void UpdateColorButton(CheckableToolStripSplitButton splitButton, ColorDialog dialog) {
			var current = splitButton.Image as Bitmap;
			if (current != null)
				using (var g = Graphics.FromImage(current)) {
					using (var tempPen = new Pen(dialog.Color))
						for (var y = 12; y < 16; y++)
							g.DrawLine(tempPen, 0, y, 15, y);
				}
			splitButton.Image = current;
			SetLock(splitButton, LockChange.Set);
			Controller.Container.Cursor = CrossCursor;
		}

		void AddCurrentBorderColor() {
			ToolStripItem p = null;
			foreach (ToolStripItem item in borderColorTS.DropDownItems)
				if (item.Text == borderColorDialog.Color.Name)
					p = item;
			if (p != null) {
				borderColorTS.DropDownItems.Remove(p);
				borderColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if (borderColorTS.DropDownItems.Count == 10) {
				borderColorTS.DropDownItems[9].Image.Dispose();
				borderColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(borderColorDialog.Color.Name)
			{
				Image = new Bitmap(20, 20)
			};
			using (var g = Graphics.FromImage(tsi.Image))
			using (Brush b = new SolidBrush(borderColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = borderColorDialog.Color;
			tsi.Click += TsiborderColorClick;
			borderColorTS.DropDownItems.Insert(0, tsi);
		}

		void AddCurrentBColor() {
			ToolStripItem p = null;
			foreach (ToolStripItem item in
				bColorTS.DropDownItems.Cast<ToolStripItem>().Where(item => item.Text == bColorDialog.Color.Name))
				p = item;

			if (p != null) {
				bColorTS.DropDownItems.Remove(p);
				bColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if (bColorTS.DropDownItems.Count == 10) {
				bColorTS.DropDownItems[9].Image.Dispose();
				bColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(bColorDialog.Color.Name)
			{
				Image = new Bitmap(20, 20)
			};
			using (var g = Graphics.FromImage(tsi.Image))
			using (Brush b = new SolidBrush(bColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = bColorDialog.Color;
			tsi.Click += TsibColorClick;
			bColorTS.DropDownItems.Insert(0, tsi);
		}

		void TsibColorClick(object sender, EventArgs e) {
			bColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			BackgroundColorSelected();
		}

		void TsiborderColorClick(object sender, EventArgs e) {
			borderColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			BorderColorSelected();
		}

		void ResizeButtonClick(object sender, EventArgs e) {
			new SizeForm(Controller.Container).ShowDialog(this);
			Controller.Container.ForceRefresh();
		}

		void ExportImageToolStripMenuItemClick(object sender, EventArgs e) {
			if (saveFileDialogRaster.ShowDialog() != DialogResult.OK)
				return;
			var format = ImageFormat.Png;
			switch (saveFileDialogRaster.FilterIndex) {
				case 1:
					format = ImageFormat.Png;
					break;
				case 2:
					format = ImageFormat.Jpeg;
					break;
				case 3:
					format = ImageFormat.Bmp;
					break;
				case 4:
					format = ImageFormat.Gif;
					break;
				case 5:
					format = ImageFormat.Tiff;
					break;
			}
			Controller.ExportImage(saveFileDialogRaster.FileName, format);
		}

		void OptionsToolStripMenuItemClick(object sender, EventArgs e) {
			new OptionsForm().ShowDialog();
		}

		enum LockState {
			On,
			Off,
			Locked
		}

		readonly Dictionary<CheckableToolStripSplitButton, LockState> locks = new Dictionary<CheckableToolStripSplitButton, LockState>();

		void TsDoubleClick(object sender, EventArgs e) {
			SetLock(sender as CheckableToolStripSplitButton, LockChange.DoubleClick);
		}

		void TsButtonClick(object sender, EventArgs e) {
			SetLock(sender as CheckableToolStripSplitButton, LockChange.Click);
		}

		void GridTsClick(object sender, EventArgs e) {
			Controller.Container.Grid ^= true;
			gridTS.Checked ^= true;
		}

		void GridTsDoubleClick(object sender, EventArgs e) {
			Controller.Container.AlignToGrid();
			gridTS.Checked = true;
		}

		void AltriToolStripMenuItem3Click(object sender, EventArgs e) {
			if (borderColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while (borderColorDialog.Color == Color.Magenta)
				borderColorDialog.Color = Color.FromArgb(
					borderColorDialog.Color.A, borderColorDialog.Color.R - 1,
					borderColorDialog.Color.G, borderColorDialog.Color.B
				);
			BorderColorSelected();
		}

		bool modified;

		void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (!modified || !Options.AskForSave)
				return;
			switch (
				MessageBox.Show(Resources.SaveEdits, Resources.Nummite, MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, Rtl())) {
				case DialogResult.Yes:
					Save();
					break;
				case DialogResult.Cancel:
					e.Cancel = true;
					break;
			}
		}

		void ShapeContainer1MouseDown(object sender, MouseEventArgs e) {
			modified = true;
		}

		void LayoutRadialTSB_Click(object sender, EventArgs e) {
			Controller.LayoutRadial();
		}
	}
}
