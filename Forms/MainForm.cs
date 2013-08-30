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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using DiagramDrawer.Properties;
using DiagramDrawer.Shapes;
using System.Text;
using System.Net;
using System.Threading;

namespace DiagramDrawer.Forms {
	public partial class MainForm : Form {
		public ShapeController Controller {
			get;
			private set;
		}

		public MainForm() {
			InitializeComponent();
			Controller = new ShapeController(shapeContainer1);
			Controller.MiddleDoubleClick += ShapeControllerMiddleDoubleClick;
			Controller.Opened += delegate {
				Text = "Diagram Drawer: " + Controller.Filename;
			};
			Controller.Saved += delegate {
				Text = "Diagram Drawer: " + Controller.Filename;
			};

			EventHandler libraryHandler = LibraryItemClick;
			foreach(var t in Controller.ShapeTypes) {
				AddShapeType(t, libraryTS, libraryHandler);
				AddShapeType(t, objectsTSMI, libraryHandler);
			}

			EventHandler lTypeHandler = LineItemClick;
			foreach(var t in Controller.ArrowTypes) {
				AddShapeType(t, linkModeTS, lTypeHandler);
				AddShapeType(t, lineKindTSMI, lTypeHandler);
			}
			SetDefaultObject(new RoundedBox());
			if(Options.CheckForUpdates)
				new Thread(CheckForUpdates).Start();

			//the following code recreates the shapeContainer back image
			Controller.Width = shapeContainer1.Width;
		}
		void CheckForUpdates() {
			try {
				var client = new WebClient();
				var buff = client.DownloadData(Options.UpdateUrl);
				var gnu = Encoding.UTF8.GetString(buff);
				gnu = gnu.Substring(0, gnu.Length - 1);
				var old = Encoding.UTF8.GetString(Resources.Version);
				old = old.Substring(0, old.Length - 1);
				if(gnu != old)
					MessageBox.Show("E' disponibile una nuova versione! [" + gnu + "]" +
					Environment.NewLine + "(corrente: " + old + ")",
					"Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception e) {
				MessageBox.Show("Errore nel tentativo di controllare nuove versioni:" +
					Environment.NewLine + e.Message + "[" + e.GetType() + "].",
					"Diagram Drawer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		void ShapeControllerMiddleDoubleClick(object sender, EventArgs e) {
			var i = 0;
			foreach(ToolStripItem item in linkModeTS.DropDownItems)
				if(((ToolStripMenuItem)item).Checked)
					i = linkModeTS.DropDownItems.IndexOf(item);
			LineItemClick(linkModeTS.DropDownItems[(i + 1) % linkModeTS.DropDownItems.Count], EventArgs.Empty);
			SetLock(linkModeTS, LockChange.Set);
			Controller.SetCursor(CrossCursor);
			linkModeTS.Owner.Refresh();
		}
		void SetDefaultObject(IShape e) {
			libraryTS.Image = e.Image;
			libraryTS.Tag = e.GetType();
			libraryTS.Text = e.ToString();
		}
		static void AddShapeType(Type t, ToolStripDropDownItem dropDownItem,
			EventHandler handler) {
			var istance = GetIstance<IShape>(t);
			if(istance == null)
				return;
			var i = new ToolStripMenuItem(istance.ToString(),
				istance.Image ?? Resources.Link, handler
			) {
				Tag = t,
				ImageTransparentColor = Color.Magenta
			};
			dropDownItem.DropDownItems.Add(i);
		}
		void LineItemClick(object sender, EventArgs e) {
			var senderTsi = sender as ToolStripMenuItem;
			if(senderTsi == null)
				return;
			var t = senderTsi.Tag as Type;
			Controller.LineType = t;
			foreach(ToolStripMenuItem tsi in linkModeTS.DropDownItems)
				tsi.Checked = tsi.Tag == senderTsi.Tag;
			foreach(ToolStripMenuItem tsmi in lineKindTSMI.DropDownItems)
				tsmi.Checked = tsmi.Tag == senderTsi.Tag;
			var istance = GetIstance<Line>(t);
			linkModeTS.Image = istance.Image;
			SetLock(linkModeTS, LockChange.Set);
		}
		void LibraryItemClick(object sender, EventArgs e) {
			var s = sender as ToolStripMenuItem;
			var t = s.Tag as Type;
			var istance = GetIstance<IShape>(t);
			libraryTS.Image = istance.Image ?? Resources.Book;
			libraryTS.Tag = s.Tag;
			libraryTS.Text = istance.ToString();
			Controller.ShapeType = t;
		}
		static T GetIstance<T>(Type t) where T : class {
			if(t == null)
				throw new ArgumentNullException("t", "type cannot be null");
			return t.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }) as T;
		}
		void LibraryTsButtonClick(object sender, EventArgs e) {
			if(libraryTS.Tag == null)
				return;
			Controller.AddCurrentShapeAtPoint(Point.Empty);
		}
		Cursor CrossCursor {
			get {
				return locks.Values.All (ls => ls == LockState.Off) ? Cursors.Default : Cursors.Cross;

			}
		}
		void ShapeContainer1Click(object sender, ShapeEventArgs e) {
			if(CrossCursor == Cursors.Default)
				return;
			if(fontTS.Checked)
				e.Shape.Font = fontDialog1.Font;
			if(bColorTS.Checked)
				e.Shape.BackgroundColor = bColorDialog.Color;
			if(fColorTS.Checked)
				e.Shape.ForegroundColor = fColorDialog.Color;
			if(borderColorTS.Checked)
				e.Shape.BorderColor = borderColorDialog.Color;
			var keys = new CheckableToolStripSplitButton[locks.Count];
			locks.Keys.CopyTo(keys, 0);
			foreach(var t in keys.Where(t => t.Checked))
				SetLock(t, LockChange.Click);
			Controller.ForceRefresh();
		}
		void AboutToolStripMenuItemClick(object sender, EventArgs e) {
			new AboutBox().Show(this);
		}
		void PrintDocument1PrintPage(object sender, PrintPageEventArgs e) {
			Controller.PrintTo(e.Graphics, e.MarginBounds);
		}
		void PrintToolStripButtonClick(object sender, EventArgs e) {
			try {
				printDocument1.Print();
			}
			catch(InvalidPrinterException) {
				MessageBox.Show("Nessuna stampante!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, Rtl());
			}
		}
		MessageBoxOptions Rtl() {
			return RightToLeft == RightToLeft.Yes
				? MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
				: 0;
		}
		void PrintPreviewToolStripMenuItemClick(object sender, EventArgs e) {
			printPreviewDialog1.ShowDialog(this);
		}
		void PrintToolStripMenuItemClick(object sender, EventArgs e) {
			printDocument1.Print();
		}
		void OpenToolStripButtonClick(object sender, EventArgs e) {
			Open();
		}
		void OpenToolStripMenuItemClick(object sender, EventArgs e) {
			Open();
		}
		void Open() {
			if(openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			Controller.Open(openFileDialog1.FileName);
		}
		void SaveToolStripButtonClick(object sender, EventArgs e) {
			Save();
		}
		void SaveToolStripMenuItemClick(object sender, EventArgs e) {
			Save();
		}
		void Save() {
			if(Controller.Filename.Length == 0)
				SaveAs();
			else
				Controller.Save();
		}
		void SaveAs() {
			if(saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			Save(saveFileDialog1.FileName);
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
			Text = "Diagram Drawer";
		}
		void NewToolStripButtonClick(object sender, EventArgs e) {
			New();
		}
		void ShapeContainer1Link(object sender, EventArgs e) {
			if(locks[linkModeTS] == LockState.Locked)
				Controller.LinkMode = true;
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
			if(lockChange == LockChange.Clear) {
				if(!locks.ContainsKey(button))
					locks.Add(button, LockState.Off);
				else
					locks[button] = LockState.Off;
			}
			else
				if(!locks.ContainsKey(button))
					AddButton(button, lockChange);
				else
					SetButton(button, lockChange);
			button.Checked = locks[button] != LockState.Off;
			button.Owner.Refresh();
			Controller.SetCursor(CrossCursor);
			if(button == linkModeTS)
				Controller.LinkMode = linkModeTS.Checked;
		}
		void SetButton(CheckableToolStripSplitButton button, LockChange lockChange) {
			switch(locks[button]) {
				case LockState.On:
					if(lockChange == LockChange.Click)
						locks[button] = LockState.Off;
					if(lockChange == LockChange.DoubleClick)
						locks[button] = LockState.Locked;
					break;
				case LockState.Off:
					if(button == linkModeTS)
						ClearLocks();
					else
						SetLock(linkModeTS, LockChange.Clear);
					locks [button] = lockChange == LockChange.DoubleClick
						? LockState.Locked
						: LockState.On;
					break;
				case LockState.Locked:
					if(lockChange == LockChange.DoubleClick)
						locks[button] = LockState.Off;
					break;
			}
		}
		void AddButton(CheckableToolStripSplitButton button, LockChange lockChange) {
			if(button == linkModeTS)
				ClearLocks();
			else
				SetLock(linkModeTS, LockChange.Clear);

			locks.Add(button, lockChange == LockChange.DoubleClick ? LockState.Locked : LockState.On);
		}

		void ClearLocks() {
			var l = new CheckableToolStripSplitButton[locks.Count];
			locks.Keys.CopyTo(l, 0);
			foreach(var t in l.Where(t => t != linkModeTS))
				SetLock(t, LockChange.Clear);
		}
		void ShapeContainer1MouseClick(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Middle)
				if(locks.ContainsKey(linkModeTS) && locks[linkModeTS] == LockState.Locked)
					SetLock(linkModeTS, LockChange.Clear);
				else
					SetLock(linkModeTS, LockChange.Click);
		}
		void ExitToolStripMenuItemClick(object sender, EventArgs e) {
			Close();
		}
		void AltriToolStripMenuItemClick(object sender, EventArgs e) {
			if(fontDialog1.ShowDialog() != DialogResult.OK)
				return;
			FontSelected();
		}
		void FontSelected() {
			SetLock(fontTS, LockChange.Set);
			AddCurrentFont();
			Controller.SetCursor(CrossCursor);
		}
		void TsiFontClick(object sender, EventArgs e) {
			fontDialog1.Font = ((ToolStripItem)(sender)).Tag as Font;
			FontSelected();
		}
		void AddCurrentFont() {
			if(fontTS.DropDownItems.Count == 10)
				fontTS.DropDownItems.RemoveAt(9);
			ToolStripItem tsi = new ToolStripMenuItem(fontDialog1.Font.Name + " " + fontDialog1.Font.SizeInPoints + "pt") {
				Tag = fontDialog1.Font
			};
			tsi.Click += TsiFontClick;
			fontTS.DropDownItems.Add(tsi);
		}
		void ShowTsmiClick(object sender, EventArgs e) {
			Controller.ShowPoints();
		}
		void HideTsmiClick(object sender, EventArgs e) {
			Controller.HidePoints();
		}
		void AltriToolStripMenuItem1Click(object sender, EventArgs e) {
			if(fColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while(fColorDialog.Color == Color.Magenta)
				fColorDialog.Color = Color.FromArgb(
					fColorDialog.Color.A, fColorDialog.Color.R - 1,
					fColorDialog.Color.G, fColorDialog.Color.B
					);
			FColorSelected();
		}
		void FColorSelected() {
			var current = fColorTS.Image as Bitmap;
			if(current != null)
				using(var g = Graphics.FromImage(current))
				using(var tempPen = new Pen(fColorDialog.Color))
					for(var y = 12; y < 16; y++)
						g.DrawLine(tempPen, 0, y, 15, y);
			fColorTS.Image = current;
			SetLock(fColorTS, LockChange.Set);
			AddCurrentFColor();
			Controller.SetCursor(CrossCursor);
		}
		void AddCurrentFColor() {
			ToolStripItem p = null;
			foreach(ToolStripItem item in fColorTS.DropDownItems)
				if(item.Text == fColorDialog.Color.Name)
					p = item;
			if(p != null) {
				fColorTS.DropDownItems.Remove(p);
				fColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if(fColorTS.DropDownItems.Count == 10) {
				fColorTS.DropDownItems[9].Image.Dispose();
				fColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(fColorDialog.Color.Name) {
				Image = new Bitmap(20, 20)
			};
			using(var g = Graphics.FromImage(tsi.Image))
			using(Brush b = new SolidBrush(fColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = fColorDialog.Color;
			tsi.Click += TsifColorClick;
			fColorTS.DropDownItems.Insert(0, tsi);
		}
		void TsifColorClick(object sender, EventArgs e) {
			fColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			FColorSelected();
		}
		void AltriToolStripMenuItem2Click(object sender, EventArgs e) {
			if(bColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while(bColorDialog.Color == Color.Magenta)
				bColorDialog.Color = Color.FromArgb(
					bColorDialog.Color.A, bColorDialog.Color.R - 1,
					bColorDialog.Color.G, bColorDialog.Color.B
					);
			BColorSelected();
		}
		void BColorSelected() {
			var current = bColorTS.Image as Bitmap;
			if(current != null)
				using(var g = Graphics.FromImage(current))
				using(var tempPen = new Pen(bColorDialog.Color))
					for(var y = 12; y < 16; y++)
						g.DrawLine(tempPen, 0, y, 15, y);
			bColorTS.Image = current;
			SetLock(bColorTS, LockChange.Set);
			AddCurrentBColor();
			Controller.SetCursor(CrossCursor);
		}
		void BorderColorSelected() {
			var current = borderColorTS.Image as Bitmap;
			if(current != null)
				using(var g = Graphics.FromImage(current))
				using(var tempPen = new Pen(borderColorDialog.Color))
					for(var y = 12; y < 16; y++)
						g.DrawLine(tempPen, 0, y, 15, y);
			borderColorTS.Image = current;
			SetLock(borderColorTS, LockChange.Set);
			AddCurrentBorderColor();
			Controller.SetCursor(CrossCursor);
		}
		void AddCurrentBorderColor() {
			ToolStripItem p = null;
			foreach(ToolStripItem item in borderColorTS.DropDownItems)
				if(item.Text == borderColorDialog.Color.Name)
					p = item;
			if(p != null) {
				borderColorTS.DropDownItems.Remove(p);
				borderColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if(borderColorTS.DropDownItems.Count == 10) {
				borderColorTS.DropDownItems[9].Image.Dispose();
				borderColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(borderColorDialog.Color.Name) {
				Image = new Bitmap(20, 20)
			};
			using(var g = Graphics.FromImage(tsi.Image))
			using(Brush b = new SolidBrush(borderColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = borderColorDialog.Color;
			tsi.Click += TsiborderColorClick;
			borderColorTS.DropDownItems.Insert(0, tsi);
		}
		void AddCurrentBColor() {
			ToolStripItem p = null;
			foreach(ToolStripItem item in
				bColorTS.DropDownItems.Cast<ToolStripItem>().Where(item => item.Text == bColorDialog.Color.Name))
				p = item;

			if(p != null) {
				bColorTS.DropDownItems.Remove(p);
				bColorTS.DropDownItems.Insert(0, p);
				return;
			}
			if(bColorTS.DropDownItems.Count == 10) {
				bColorTS.DropDownItems[9].Image.Dispose();
				bColorTS.DropDownItems.RemoveAt(9);
			}
			ToolStripItem tsi = new ToolStripMenuItem(bColorDialog.Color.Name) {
				Image = new Bitmap(20, 20)
			};
			using(var g = Graphics.FromImage(tsi.Image))
			using(Brush b = new SolidBrush(bColorDialog.Color)) {
				g.FillRectangle(b, 0, 5, 20, 10);
				g.DrawRectangle(Pens.Black, 0, 5, 19, 10);
			}
			tsi.Tag = bColorDialog.Color;
			tsi.Click += TsibColorClick;
			bColorTS.DropDownItems.Insert(0, tsi);
		}
		void TsibColorClick(object sender, EventArgs e) {
			bColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			BColorSelected();
		}
		void TsiborderColorClick(object sender, EventArgs e) {
			borderColorDialog.Color = (Color)((ToolStripItem)sender).Tag;
			BorderColorSelected();
		}
		void ResizeButtonClick(object sender, EventArgs e) {
			new SizeForm(Controller).ShowDialog(this);
			Controller.ForceRefresh();
		}
		void ExportImageToolStripMenuItemClick(object sender, EventArgs e) {
			if(saveFileDialog2.ShowDialog() != DialogResult.OK)
				return;
			var format = ImageFormat.Png;
			switch(saveFileDialog2.FilterIndex) {
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
			Controller.ExportImage(saveFileDialog2.FileName, format);
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
			Controller.Grid ^= true;
			gridTS.Checked ^= true;
		}
		void GridTsDoubleClick(object sender, EventArgs e) {
			Controller.AlignToGrid();
			gridTS.Checked = true;
		}
		void AltriToolStripMenuItem3Click(object sender, EventArgs e) {
			if(borderColorDialog.ShowDialog() != DialogResult.OK)
				return;
			while(borderColorDialog.Color == Color.Magenta)
				borderColorDialog.Color = Color.FromArgb(
					borderColorDialog.Color.A, borderColorDialog.Color.R - 1,
					borderColorDialog.Color.G, borderColorDialog.Color.B
					);
			BorderColorSelected();
		}
		bool modified;
		void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(!modified || !Options.AskForSave)
				return;
			switch(
				MessageBox.Show("Salvare le modifiche?", "Diagram Drawer", MessageBoxButtons.YesNoCancel,
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
		void ComeImmagineVettorialeToolStripMenuItemClick(object sender, EventArgs e) {
			if(saveFileDialog3.ShowDialog() != DialogResult.OK)
				return;
			Controller.ExportSvg(saveFileDialog3.FileName);
		}
	}
	public class TypeCollection : KeyedCollection<string, Type> {
		protected override string GetKeyForItem(Type item) {
			return item.FullName;
		}
		public void AddRange(IEnumerable<Type> types) {
			foreach(var t in types)
				Add(t);
		}
	}
}
