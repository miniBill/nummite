
using System.Windows.Forms;
using Nummite.Forms;

namespace Nummite.Forms {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.shapeContainer1 = new Nummite.Forms.ShapeContainer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comeImmagineVettorialeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectsTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.lineKindTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.hideTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.libraryTS = new System.Windows.Forms.ToolStripSplitButton();
			this.linkModeTS = new Nummite.Forms.CheckableToolStripSplitButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.fontTS = new Nummite.Forms.CheckableToolStripSplitButton();
			this.altriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fColorTS = new Nummite.Forms.CheckableToolStripSplitButton();
			this.altriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.bColorTS = new Nummite.Forms.CheckableToolStripSplitButton();
			this.altriToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.borderColorTS = new Nummite.Forms.CheckableToolStripSplitButton();
			this.altriToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.resizeTS = new System.Windows.Forms.ToolStripButton();
			this.gridTS = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.fColorDialog = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.bColorDialog = new System.Windows.Forms.ColorDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			this.borderColorDialog = new System.Windows.Forms.ColorDialog();
			this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(804, 529);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(804, 578);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.shapeContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(804, 529);
			this.panel1.TabIndex = 1;
			// 
			// shapeContainer1
			// 
			this.shapeContainer1.BackColor = System.Drawing.Color.White;
			this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.shapeContainer1.Name = "shapeContainer1";
			this.shapeContainer1.Size = new System.Drawing.Size(804, 529);
			this.shapeContainer1.TabIndex = 1;
			this.shapeContainer1.Click += new System.EventHandler<Nummite.Forms.ShapeEventArgs>(this.ShapeContainer1Click);
			this.shapeContainer1.Link += new System.EventHandler(this.ShapeContainer1Link);
			this.shapeContainer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer1MouseClick);
			this.shapeContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer1MouseDown);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.objectsTSMI,
            this.lineKindTSMI,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(804, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.newToolStripMenuItem.Text = "Nuovo...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.openToolStripMenuItem.Text = "Apri...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(191, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.saveToolStripMenuItem.Text = "Salva";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.saveAsToolStripMenuItem.Text = "Salva come...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImageToolStripMenuItem,
            this.comeImmagineVettorialeToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportToolStripMenuItem.Text = "Esporta";
			// 
			// exportImageToolStripMenuItem
			// 
			this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
			this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.exportImageToolStripMenuItem.Text = "Come immagine...";
			this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.ExportImageToolStripMenuItemClick);
			// 
			// comeImmagineVettorialeToolStripMenuItem
			// 
			this.comeImmagineVettorialeToolStripMenuItem.Name = "comeImmagineVettorialeToolStripMenuItem";
			this.comeImmagineVettorialeToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.comeImmagineVettorialeToolStripMenuItem.Text = "Come immagine vettoriale...";
			this.comeImmagineVettorialeToolStripMenuItem.Click += new System.EventHandler(this.ComeImmagineVettorialeToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.printToolStripMenuItem.Text = "&Stampa...";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.printPreviewToolStripMenuItem.Text = "Anteprima di stampa...";
			this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exitToolStripMenuItem.Text = "Esci";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Enabled = false;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Visible = false;
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Enabled = false;
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Enabled = false;
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Enabled = false;
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Enabled = false;
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Enabled = false;
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Enabled = false;
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// objectsTSMI
			// 
			this.objectsTSMI.Name = "objectsTSMI";
			this.objectsTSMI.Size = new System.Drawing.Size(59, 20);
			this.objectsTSMI.Text = "Oggetti";
			// 
			// lineKindTSMI
			// 
			this.lineKindTSMI.Name = "lineKindTSMI";
			this.lineKindTSMI.Size = new System.Drawing.Size(47, 20);
			this.lineKindTSMI.Text = "Linee";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.showTSMI,
            this.hideTSMI});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.toolsToolStripMenuItem.Text = "&Strumenti";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Enabled = false;
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			this.customizeToolStripMenuItem.Visible = false;
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.optionsToolStripMenuItem.Text = "&Opzioni";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// showTSMI
			// 
			this.showTSMI.Name = "showTSMI";
			this.showTSMI.Size = new System.Drawing.Size(186, 22);
			this.showTSMI.Text = "Mostra tutti i punti";
			this.showTSMI.Click += new System.EventHandler(this.ShowTsmiClick);
			// 
			// hideTSMI
			// 
			this.hideTSMI.Name = "hideTSMI";
			this.hideTSMI.Size = new System.Drawing.Size(186, 22);
			this.hideTSMI.Text = "Nascondi tutti i punti";
			this.hideTSMI.Click += new System.EventHandler(this.HideTsmiClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
			this.helpToolStripMenuItem.Text = "&?";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Enabled = false;
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Enabled = false;
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Enabled = false;
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.aboutToolStripMenuItem.Text = "Informazioni su...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.openToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator6,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator7,
            this.libraryTS,
            this.linkModeTS,
            this.toolStripSeparator8,
            this.fontTS,
            this.fColorTS,
            this.bColorTS,
            this.borderColorTS,
            this.toolStripSeparator9,
            this.resizeTS,
            this.gridTS,
            this.toolStripSeparator10,
            this.helpToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(3, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(360, 25);
			this.toolStrip1.TabIndex = 1;
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "Nuovo";
			this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButtonClick);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "Salva";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButtonClick);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "Apri";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButtonClick);
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton.Text = "Stampa";
			this.printToolStripButton.Click += new System.EventHandler(this.PrintToolStripButtonClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Enabled = false;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cutToolStripButton.Text = "C&ut";
			this.cutToolStripButton.Visible = false;
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Enabled = false;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.copyToolStripButton.Text = "&Copy";
			this.copyToolStripButton.Visible = false;
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Enabled = false;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.pasteToolStripButton.Text = "&Paste";
			this.pasteToolStripButton.Visible = false;
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			this.toolStripSeparator7.Visible = false;
			// 
			// libraryTS
			// 
			this.libraryTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.libraryTS.Image = global::Nummite.Properties.Resources.Book;
			this.libraryTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.libraryTS.Name = "libraryTS";
			this.libraryTS.Size = new System.Drawing.Size(32, 22);
			this.libraryTS.Text = "Libreria";
			this.libraryTS.ButtonClick += new System.EventHandler(this.LibraryTsButtonClick);
			// 
			// linkModeTS
			// 
			this.linkModeTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.linkModeTS.DoubleClickEnabled = true;
			this.linkModeTS.Image = global::Nummite.Properties.Resources.NoArrow;
			this.linkModeTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.linkModeTS.Name = "linkModeTS";
			this.linkModeTS.Size = new System.Drawing.Size(32, 22);
			this.linkModeTS.Text = "Tipo di linea";
			this.linkModeTS.ButtonClick += new System.EventHandler(this.TsButtonClick);
			this.linkModeTS.DoubleClick += new System.EventHandler(this.TsDoubleClick);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// fontTS
			// 
			this.fontTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fontTS.DoubleClickEnabled = true;
			this.fontTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altriToolStripMenuItem});
			this.fontTS.Image = ((System.Drawing.Image)(resources.GetObject("fontTS.Image")));
			this.fontTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fontTS.Name = "fontTS";
			this.fontTS.Size = new System.Drawing.Size(32, 22);
			this.fontTS.Text = "Cambia font";
			this.fontTS.ButtonClick += new System.EventHandler(this.TsButtonClick);
			this.fontTS.DoubleClick += new System.EventHandler(this.TsDoubleClick);
			// 
			// altriToolStripMenuItem
			// 
			this.altriToolStripMenuItem.Name = "altriToolStripMenuItem";
			this.altriToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.altriToolStripMenuItem.Text = "Altri...";
			this.altriToolStripMenuItem.Click += new System.EventHandler(this.AltriToolStripMenuItemClick);
			// 
			// fColorTS
			// 
			this.fColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.fColorTS.DoubleClickEnabled = true;
			this.fColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altriToolStripMenuItem1});
			this.fColorTS.Image = global::Nummite.Properties.Resources.FontColor;
			this.fColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fColorTS.Name = "fColorTS";
			this.fColorTS.Size = new System.Drawing.Size(32, 22);
			this.fColorTS.Text = "Cambia il colore del testo";
			this.fColorTS.ButtonClick += new System.EventHandler(this.TsButtonClick);
			this.fColorTS.DoubleClick += new System.EventHandler(this.TsDoubleClick);
			// 
			// altriToolStripMenuItem1
			// 
			this.altriToolStripMenuItem1.Name = "altriToolStripMenuItem1";
			this.altriToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
			this.altriToolStripMenuItem1.Text = "Altri...";
			this.altriToolStripMenuItem1.Click += new System.EventHandler(this.AltriToolStripMenuItem1Click);
			// 
			// bColorTS
			// 
			this.bColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bColorTS.DoubleClickEnabled = true;
			this.bColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altriToolStripMenuItem2});
			this.bColorTS.Image = global::Nummite.Properties.Resources.Fill;
			this.bColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bColorTS.Name = "bColorTS";
			this.bColorTS.Size = new System.Drawing.Size(32, 22);
			this.bColorTS.Text = "Cambia il colore dello sfondo";
			this.bColorTS.ButtonClick += new System.EventHandler(this.TsButtonClick);
			this.bColorTS.DoubleClick += new System.EventHandler(this.TsDoubleClick);
			// 
			// altriToolStripMenuItem2
			// 
			this.altriToolStripMenuItem2.Name = "altriToolStripMenuItem2";
			this.altriToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
			this.altriToolStripMenuItem2.Text = "Altri...";
			this.altriToolStripMenuItem2.Click += new System.EventHandler(this.AltriToolStripMenuItem2Click);
			// 
			// borderColorTS
			// 
			this.borderColorTS.AutoToolTip = false;
			this.borderColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.borderColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altriToolStripMenuItem3});
			this.borderColorTS.Image = global::Nummite.Properties.Resources.Border;
			this.borderColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.borderColorTS.Name = "borderColorTS";
			this.borderColorTS.Size = new System.Drawing.Size(32, 22);
			this.borderColorTS.Text = "Cambia il colore del bordo";
			this.borderColorTS.ButtonClick += new System.EventHandler(this.TsButtonClick);
			this.borderColorTS.DoubleClick += new System.EventHandler(this.TsDoubleClick);
			// 
			// altriToolStripMenuItem3
			// 
			this.altriToolStripMenuItem3.Name = "altriToolStripMenuItem3";
			this.altriToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
			this.altriToolStripMenuItem3.Text = "Altri...";
			this.altriToolStripMenuItem3.Click += new System.EventHandler(this.AltriToolStripMenuItem3Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// resizeTS
			// 
			this.resizeTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.resizeTS.Image = ((System.Drawing.Image)(resources.GetObject("resizeTS.Image")));
			this.resizeTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resizeTS.Name = "resizeTS";
			this.resizeTS.Size = new System.Drawing.Size(23, 22);
			this.resizeTS.Text = "Ridimensiona foglio";
			this.resizeTS.Click += new System.EventHandler(this.ResizeButtonClick);
			// 
			// gridTS
			// 
			this.gridTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.gridTS.DoubleClickEnabled = true;
			this.gridTS.Image = global::Nummite.Properties.Resources.Grid;
			this.gridTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.gridTS.Name = "gridTS";
			this.gridTS.Size = new System.Drawing.Size(23, 22);
			this.gridTS.Text = "Griglia";
			this.gridTS.Click += new System.EventHandler(this.GridTsClick);
			this.gridTS.DoubleClick += new System.EventHandler(this.GridTsDoubleClick);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			this.toolStripSeparator10.Visible = false;
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Enabled = false;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			this.helpToolStripButton.Visible = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			this.imageList1.Images.SetKeyName(0, "ellipse.bmp");
			this.imageList1.Images.SetKeyName(1, "rectangle.bmp");
			this.imageList1.Images.SetKeyName(2, "Simple.bmp");
			this.imageList1.Images.SetKeyName(3, "Point1.bmp");
			this.imageList1.Images.SetKeyName(4, "Point2.bmp");
			// 
			// fColorDialog
			// 
			this.fColorDialog.AnyColor = true;
			// 
			// fontDialog1
			// 
			this.fontDialog1.FontMustExist = true;
			// 
			// bColorDialog
			// 
			this.bColorDialog.AnyColor = true;
			this.bColorDialog.Color = System.Drawing.Color.White;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1PrintPage);
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.printDocument1;
			this.printDialog1.UseEXDialog = true;
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.printDocument1;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "File xml (*.xml)|*.xml|Tutti i files (*.*)|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xml";
			this.saveFileDialog1.FileName = "nummite";
			this.saveFileDialog1.Filter = "File xml (*.xml)|*.xml|Tutti i files (*.*)|*.*";
			this.saveFileDialog1.RestoreDirectory = true;
			// 
			// saveFileDialog2
			// 
			this.saveFileDialog2.FileName = "export";
			this.saveFileDialog2.Filter = "File png (*.png)|*.png|File jpeg (*.jpg,*.jpeg)|*.jpg,*.jpeg|File bitmap (*.bmp)|" +
    "*.bmp|File gif (*.gif)|*.gif|File tiff (*.tif,*.tiff)|*.tif,*.tiff";
			this.saveFileDialog2.RestoreDirectory = true;
			// 
			// borderColorDialog
			// 
			this.borderColorDialog.AnyColor = true;
			// 
			// saveFileDialog3
			// 
			this.saveFileDialog3.DefaultExt = "svg";
			this.saveFileDialog3.Filter = "File svg (*.svg)|*.svg|Tutti i files (*.*)|*.*";
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(804, 578);
			this.Controls.Add(this.toolStripContainer1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Nummite";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		ToolStripContainer toolStripContainer1;
		MenuStrip menuStrip1;
		ToolStripMenuItem fileToolStripMenuItem;
		ToolStripMenuItem newToolStripMenuItem;
		ToolStripMenuItem openToolStripMenuItem;
		ToolStripSeparator toolStripSeparator;
		ToolStripMenuItem saveToolStripMenuItem;
		ToolStripMenuItem saveAsToolStripMenuItem;
		ToolStripSeparator toolStripSeparator1;
		ToolStripMenuItem printToolStripMenuItem;
		ToolStripMenuItem printPreviewToolStripMenuItem;
		ToolStripSeparator toolStripSeparator2;
		ToolStripMenuItem exitToolStripMenuItem;
		ToolStripMenuItem editToolStripMenuItem;
		ToolStripMenuItem undoToolStripMenuItem;
		ToolStripMenuItem redoToolStripMenuItem;
		ToolStripSeparator toolStripSeparator3;
		ToolStripMenuItem cutToolStripMenuItem;
		ToolStripMenuItem copyToolStripMenuItem;
		ToolStripMenuItem pasteToolStripMenuItem;
		ToolStripSeparator toolStripSeparator4;
		ToolStripMenuItem selectAllToolStripMenuItem;
		ToolStripMenuItem toolsToolStripMenuItem;
		ToolStripMenuItem customizeToolStripMenuItem;
		ToolStripMenuItem optionsToolStripMenuItem;
		ToolStripMenuItem helpToolStripMenuItem;
		ToolStripMenuItem contentsToolStripMenuItem;
		ToolStripMenuItem indexToolStripMenuItem;
		ToolStripMenuItem searchToolStripMenuItem;
		ToolStripSeparator toolStripSeparator5;
		ToolStripMenuItem aboutToolStripMenuItem;
		ToolStrip toolStrip1;
		ToolStripButton newToolStripButton;
		ToolStripButton openToolStripButton;
		ToolStripButton saveToolStripButton;
		ToolStripButton printToolStripButton;
		ToolStripSeparator toolStripSeparator6;
		ToolStripButton cutToolStripButton;
		ToolStripButton copyToolStripButton;
		ToolStripButton pasteToolStripButton;
		ToolStripSeparator toolStripSeparator7;
		ToolStripButton helpToolStripButton;
		ImageList imageList1;
		ToolStripSplitButton libraryTS;
		ToolStripSeparator toolStripSeparator9;
		FontDialog fontDialog1;
		ColorDialog bColorDialog;
		PrintDialog printDialog1;
		PrintPreviewDialog printPreviewDialog1;
		ColorDialog fColorDialog;
		System.Drawing.Printing.PrintDocument printDocument1;
		OpenFileDialog openFileDialog1;
		SaveFileDialog saveFileDialog1;
		CheckableToolStripSplitButton linkModeTS;
		Panel panel1;
		ShapeContainer shapeContainer1;
		ToolStripMenuItem objectsTSMI;
		ToolStripMenuItem lineKindTSMI;
		CheckableToolStripSplitButton fontTS;
		ToolStripMenuItem altriToolStripMenuItem;
		CheckableToolStripSplitButton fColorTS;
		ToolStripMenuItem altriToolStripMenuItem1;
		CheckableToolStripSplitButton bColorTS;
		ToolStripMenuItem altriToolStripMenuItem2;
		ToolStripMenuItem showTSMI;
		ToolStripMenuItem hideTSMI;
		ToolStripButton resizeTS;
		ToolStripSeparator toolStripSeparator10;
		ToolStripMenuItem exportToolStripMenuItem;
		ToolStripMenuItem exportImageToolStripMenuItem;
		SaveFileDialog saveFileDialog2;
		ToolStripSeparator toolStripSeparator8;
		ToolStripButton gridTS;
		CheckableToolStripSplitButton borderColorTS;
		ColorDialog borderColorDialog;
		ToolStripMenuItem altriToolStripMenuItem3;
		ToolStripMenuItem comeImmagineVettorialeToolStripMenuItem;
		SaveFileDialog saveFileDialog3;
	}
}

