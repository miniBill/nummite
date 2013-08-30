namespace DiagramDrawer.Forms {
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
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			panel1 = new System.Windows.Forms.Panel();
			shapeContainer1 = new ShapeContainer();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			comeImmagineVettorialeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			objectsTSMI = new System.Windows.Forms.ToolStripMenuItem();
			lineKindTSMI = new System.Windows.Forms.ToolStripMenuItem();
			toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			showTSMI = new System.Windows.Forms.ToolStripMenuItem();
			hideTSMI = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			newToolStripButton = new System.Windows.Forms.ToolStripButton();
			saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			openToolStripButton = new System.Windows.Forms.ToolStripButton();
			printToolStripButton = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			libraryTS = new System.Windows.Forms.ToolStripSplitButton();
			linkModeTS = new CheckableToolStripSplitButton();
			toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			fontTS = new CheckableToolStripSplitButton();
			altriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			fColorTS = new CheckableToolStripSplitButton();
			altriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			bColorTS = new CheckableToolStripSplitButton();
			altriToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			borderColorTS = new CheckableToolStripSplitButton();
			altriToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			resizeTS = new System.Windows.Forms.ToolStripButton();
			gridTS = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			imageList1 = new System.Windows.Forms.ImageList(components);
			fColorDialog = new System.Windows.Forms.ColorDialog();
			fontDialog1 = new System.Windows.Forms.FontDialog();
			bColorDialog = new System.Windows.Forms.ColorDialog();
			printDocument1 = new System.Drawing.Printing.PrintDocument();
			printDialog1 = new System.Windows.Forms.PrintDialog();
			printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
			borderColorDialog = new System.Windows.Forms.ColorDialog();
			saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
			toolStripContainer1.ContentPanel.SuspendLayout();
			toolStripContainer1.TopToolStripPanel.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			panel1.SuspendLayout();
			menuStrip1.SuspendLayout();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			toolStripContainer1.ContentPanel.Controls.Add(panel1);
			toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(804, 529);
			toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			toolStripContainer1.Name = "toolStripContainer1";
			toolStripContainer1.Size = new System.Drawing.Size(804, 578);
			toolStripContainer1.TabIndex = 1;
			toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
			toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.AutoSize = true;
			panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			panel1.Controls.Add(shapeContainer1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(804, 529);
			panel1.TabIndex = 1;
			// 
			// shapeContainer1
			// 
			shapeContainer1.BackColor = System.Drawing.Color.White;
			shapeContainer1.Location = new System.Drawing.Point(0, 0);
			shapeContainer1.Name = "shapeContainer1";
			shapeContainer1.Size = new System.Drawing.Size(804, 529);
			shapeContainer1.TabIndex = 1;
			shapeContainer1.Link += new System.EventHandler(ShapeContainer1Link);
			shapeContainer1.Click += new System.EventHandler<ShapeEventArgs>(ShapeContainer1Click);
			shapeContainer1.MouseClick += new System.Windows.Forms.MouseEventHandler(ShapeContainer1MouseClick);
			shapeContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(ShapeContainer1MouseDown);
			// 
			// menuStrip1
			// 
			menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            editToolStripMenuItem,
            objectsTSMI,
            lineKindTSMI,
            toolsToolStripMenuItem,
            helpToolStripMenuItem});
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(804, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newToolStripMenuItem,
            openToolStripMenuItem,
            toolStripSeparator,
            saveToolStripMenuItem,
            saveAsToolStripMenuItem,
            exportToolStripMenuItem,
            toolStripSeparator1,
            printToolStripMenuItem,
            printPreviewToolStripMenuItem,
            toolStripSeparator2,
            exitToolStripMenuItem});
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			newToolStripMenuItem.Name = "newToolStripMenuItem";
			newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			newToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			newToolStripMenuItem.Text = "Nuovo...";
			newToolStripMenuItem.Click += new System.EventHandler(NewToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			openToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			openToolStripMenuItem.Text = "Apri...";
			openToolStripMenuItem.Click += new System.EventHandler(OpenToolStripMenuItemClick);
			// 
			// toolStripSeparator
			// 
			toolStripSeparator.Name = "toolStripSeparator";
			toolStripSeparator.Size = new System.Drawing.Size(191, 6);
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			saveToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			saveToolStripMenuItem.Text = "Salva";
			saveToolStripMenuItem.Click += new System.EventHandler(SaveToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			saveAsToolStripMenuItem.Text = "Salva come...";
			saveAsToolStripMenuItem.Click += new System.EventHandler(SaveAsToolStripMenuItemClick);
			// 
			// exportToolStripMenuItem
			// 
			exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            exportImageToolStripMenuItem,
            comeImmagineVettorialeToolStripMenuItem});
			exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			exportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			exportToolStripMenuItem.Text = "Esporta";
			// 
			// exportImageToolStripMenuItem
			// 
			exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
			exportImageToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			exportImageToolStripMenuItem.Text = "Come immagine...";
			exportImageToolStripMenuItem.Click += new System.EventHandler(ExportImageToolStripMenuItemClick);
			// 
			// comeImmagineVettorialeToolStripMenuItem
			// 
			comeImmagineVettorialeToolStripMenuItem.Name = "comeImmagineVettorialeToolStripMenuItem";
			comeImmagineVettorialeToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			comeImmagineVettorialeToolStripMenuItem.Text = "Come immagine vettoriale...";
			comeImmagineVettorialeToolStripMenuItem.Click += new System.EventHandler(ComeImmagineVettorialeToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// printToolStripMenuItem
			// 
			printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			printToolStripMenuItem.Name = "printToolStripMenuItem";
			printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			printToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			printToolStripMenuItem.Text = "&Stampa...";
			printToolStripMenuItem.Click += new System.EventHandler(PrintToolStripMenuItemClick);
			// 
			// printPreviewToolStripMenuItem
			// 
			printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			printPreviewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			printPreviewToolStripMenuItem.Text = "Anteprima di stampa...";
			printPreviewToolStripMenuItem.Click += new System.EventHandler(PrintPreviewToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			exitToolStripMenuItem.Text = "Esci";
			exitToolStripMenuItem.Click += new System.EventHandler(ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            undoToolStripMenuItem,
            redoToolStripMenuItem,
            toolStripSeparator3,
            cutToolStripMenuItem,
            copyToolStripMenuItem,
            pasteToolStripMenuItem,
            toolStripSeparator4,
            selectAllToolStripMenuItem});
			editToolStripMenuItem.Enabled = false;
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			editToolStripMenuItem.Text = "&Edit";
			editToolStripMenuItem.Visible = false;
			// 
			// undoToolStripMenuItem
			// 
			undoToolStripMenuItem.Enabled = false;
			undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			redoToolStripMenuItem.Enabled = false;
			redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
			// 
			// cutToolStripMenuItem
			// 
			cutToolStripMenuItem.Enabled = false;
			cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.Enabled = false;
			copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			pasteToolStripMenuItem.Enabled = false;
			pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			selectAllToolStripMenuItem.Enabled = false;
			selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// objectsTSMI
			// 
			objectsTSMI.Name = "objectsTSMI";
			objectsTSMI.Size = new System.Drawing.Size(59, 20);
			objectsTSMI.Text = "Oggetti";
			// 
			// lineKindTSMI
			// 
			lineKindTSMI.Name = "lineKindTSMI";
			lineKindTSMI.Size = new System.Drawing.Size(47, 20);
			lineKindTSMI.Text = "Linee";
			// 
			// toolsToolStripMenuItem
			// 
			toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            customizeToolStripMenuItem,
            optionsToolStripMenuItem,
            showTSMI,
            hideTSMI});
			toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			toolsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			toolsToolStripMenuItem.Text = "&Strumenti";
			// 
			// customizeToolStripMenuItem
			// 
			customizeToolStripMenuItem.Enabled = false;
			customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			customizeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			customizeToolStripMenuItem.Text = "&Customize";
			customizeToolStripMenuItem.Visible = false;
			// 
			// optionsToolStripMenuItem
			// 
			optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			optionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			optionsToolStripMenuItem.Text = "&Opzioni";
			optionsToolStripMenuItem.Click += new System.EventHandler(OptionsToolStripMenuItemClick);
			// 
			// showTSMI
			// 
			showTSMI.Name = "showTSMI";
			showTSMI.Size = new System.Drawing.Size(186, 22);
			showTSMI.Text = "Mostra tutti i punti";
			showTSMI.Click += new System.EventHandler(ShowTsmiClick);
			// 
			// hideTSMI
			// 
			hideTSMI.Name = "hideTSMI";
			hideTSMI.Size = new System.Drawing.Size(186, 22);
			hideTSMI.Text = "Nascondi tutti i punti";
			hideTSMI.Click += new System.EventHandler(HideTsmiClick);
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            contentsToolStripMenuItem,
            indexToolStripMenuItem,
            searchToolStripMenuItem,
            toolStripSeparator5,
            aboutToolStripMenuItem});
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
			helpToolStripMenuItem.Text = "&?";
			// 
			// contentsToolStripMenuItem
			// 
			contentsToolStripMenuItem.Enabled = false;
			contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			contentsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			indexToolStripMenuItem.Enabled = false;
			indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			indexToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			searchToolStripMenuItem.Enabled = false;
			searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			searchToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			aboutToolStripMenuItem.Text = "Informazioni su...";
			aboutToolStripMenuItem.Click += new System.EventHandler(AboutToolStripMenuItemClick);
			// 
			// toolStrip1
			// 
			toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newToolStripButton,
            saveToolStripButton,
            openToolStripButton,
            printToolStripButton,
            toolStripSeparator6,
            cutToolStripButton,
            copyToolStripButton,
            pasteToolStripButton,
            toolStripSeparator7,
            libraryTS,
            linkModeTS,
            toolStripSeparator8,
            fontTS,
            fColorTS,
            bColorTS,
            borderColorTS,
            toolStripSeparator9,
            resizeTS,
            gridTS,
            toolStripSeparator10,
            helpToolStripButton});
			toolStrip1.Location = new System.Drawing.Point(3, 24);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(360, 25);
			toolStrip1.TabIndex = 1;
			// 
			// newToolStripButton
			// 
			newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			newToolStripButton.Name = "newToolStripButton";
			newToolStripButton.Size = new System.Drawing.Size(23, 22);
			newToolStripButton.Text = "Nuovo";
			newToolStripButton.Click += new System.EventHandler(NewToolStripButtonClick);
			// 
			// saveToolStripButton
			// 
			saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			saveToolStripButton.Name = "saveToolStripButton";
			saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			saveToolStripButton.Text = "Salva";
			saveToolStripButton.Click += new System.EventHandler(SaveToolStripButtonClick);
			// 
			// openToolStripButton
			// 
			openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			openToolStripButton.Name = "openToolStripButton";
			openToolStripButton.Size = new System.Drawing.Size(23, 22);
			openToolStripButton.Text = "Apri";
			openToolStripButton.Click += new System.EventHandler(OpenToolStripButtonClick);
			// 
			// printToolStripButton
			// 
			printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			printToolStripButton.Name = "printToolStripButton";
			printToolStripButton.Size = new System.Drawing.Size(23, 22);
			printToolStripButton.Text = "Stampa";
			printToolStripButton.Click += new System.EventHandler(PrintToolStripButtonClick);
			// 
			// toolStripSeparator6
			// 
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// cutToolStripButton
			// 
			cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			cutToolStripButton.Enabled = false;
			cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			cutToolStripButton.Name = "cutToolStripButton";
			cutToolStripButton.Size = new System.Drawing.Size(23, 22);
			cutToolStripButton.Text = "C&ut";
			cutToolStripButton.Visible = false;
			// 
			// copyToolStripButton
			// 
			copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			copyToolStripButton.Enabled = false;
			copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			copyToolStripButton.Name = "copyToolStripButton";
			copyToolStripButton.Size = new System.Drawing.Size(23, 22);
			copyToolStripButton.Text = "&Copy";
			copyToolStripButton.Visible = false;
			// 
			// pasteToolStripButton
			// 
			pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			pasteToolStripButton.Enabled = false;
			pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			pasteToolStripButton.Name = "pasteToolStripButton";
			pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
			pasteToolStripButton.Text = "&Paste";
			pasteToolStripButton.Visible = false;
			// 
			// toolStripSeparator7
			// 
			toolStripSeparator7.Name = "toolStripSeparator7";
			toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			toolStripSeparator7.Visible = false;
			// 
			// libraryTS
			// 
			libraryTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			libraryTS.Image = global::DiagramDrawer.Properties.Resources.Book;
			libraryTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			libraryTS.Name = "libraryTS";
			libraryTS.Size = new System.Drawing.Size(32, 22);
			libraryTS.Text = "Libreria";
			libraryTS.ButtonClick += new System.EventHandler(LibraryTsButtonClick);
			// 
			// linkModeTS
			// 
			linkModeTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			linkModeTS.DoubleClickEnabled = true;
			linkModeTS.Image = global::DiagramDrawer.Properties.Resources.NoArrow;
			linkModeTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			linkModeTS.Name = "linkModeTS";
			linkModeTS.Size = new System.Drawing.Size(32, 22);
			linkModeTS.Text = "Tipo di linea";
			linkModeTS.DoubleClick += new System.EventHandler(TsDoubleClick);
			linkModeTS.ButtonClick += new System.EventHandler(TsButtonClick);
			// 
			// toolStripSeparator8
			// 
			toolStripSeparator8.Name = "toolStripSeparator8";
			toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// fontTS
			// 
			fontTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			fontTS.DoubleClickEnabled = true;
			fontTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            altriToolStripMenuItem});
			fontTS.Image = ((System.Drawing.Image)(resources.GetObject("fontTS.Image")));
			fontTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			fontTS.Name = "fontTS";
			fontTS.Size = new System.Drawing.Size(32, 22);
			fontTS.Text = "Cambia font";
			fontTS.DoubleClick += new System.EventHandler(TsDoubleClick);
			fontTS.ButtonClick += new System.EventHandler(TsButtonClick);
			// 
			// altriToolStripMenuItem
			// 
			altriToolStripMenuItem.Name = "altriToolStripMenuItem";
			altriToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			altriToolStripMenuItem.Text = "Altri...";
			altriToolStripMenuItem.Click += new System.EventHandler(AltriToolStripMenuItemClick);
			// 
			// fColorTS
			// 
			fColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			fColorTS.DoubleClickEnabled = true;
			fColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            altriToolStripMenuItem1});
			fColorTS.Image = global::DiagramDrawer.Properties.Resources.FontColor;
			fColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			fColorTS.Name = "fColorTS";
			fColorTS.Size = new System.Drawing.Size(32, 22);
			fColorTS.Text = "Cambia il colore del testo";
			fColorTS.DoubleClick += new System.EventHandler(TsDoubleClick);
			fColorTS.ButtonClick += new System.EventHandler(TsButtonClick);
			// 
			// altriToolStripMenuItem1
			// 
			altriToolStripMenuItem1.Name = "altriToolStripMenuItem1";
			altriToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
			altriToolStripMenuItem1.Text = "Altri...";
			altriToolStripMenuItem1.Click += new System.EventHandler(AltriToolStripMenuItem1Click);
			// 
			// bColorTS
			// 
			bColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			bColorTS.DoubleClickEnabled = true;
			bColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            altriToolStripMenuItem2});
			bColorTS.Image = global::DiagramDrawer.Properties.Resources.Fill;
			bColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			bColorTS.Name = "bColorTS";
			bColorTS.Size = new System.Drawing.Size(32, 22);
			bColorTS.Text = "Cambia il colore dello sfondo";
			bColorTS.DoubleClick += new System.EventHandler(TsDoubleClick);
			bColorTS.ButtonClick += new System.EventHandler(TsButtonClick);
			// 
			// altriToolStripMenuItem2
			// 
			altriToolStripMenuItem2.Name = "altriToolStripMenuItem2";
			altriToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
			altriToolStripMenuItem2.Text = "Altri...";
			altriToolStripMenuItem2.Click += new System.EventHandler(AltriToolStripMenuItem2Click);
			// 
			// borderColorTS
			// 
			borderColorTS.AutoToolTip = false;
			borderColorTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			borderColorTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            altriToolStripMenuItem3});
			borderColorTS.Image = global::DiagramDrawer.Properties.Resources.Border;
			borderColorTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			borderColorTS.Name = "borderColorTS";
			borderColorTS.Size = new System.Drawing.Size(32, 22);
			borderColorTS.Text = "Cambia il colore del bordo";
			borderColorTS.DoubleClick += new System.EventHandler(TsDoubleClick);
			borderColorTS.ButtonClick += new System.EventHandler(TsButtonClick);
			// 
			// altriToolStripMenuItem3
			// 
			altriToolStripMenuItem3.Name = "altriToolStripMenuItem3";
			altriToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
			altriToolStripMenuItem3.Text = "Altri...";
			altriToolStripMenuItem3.Click += new System.EventHandler(AltriToolStripMenuItem3Click);
			// 
			// toolStripSeparator9
			// 
			toolStripSeparator9.Name = "toolStripSeparator9";
			toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// resizeTS
			// 
			resizeTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resizeTS.Image = ((System.Drawing.Image)(resources.GetObject("resizeTS.Image")));
			resizeTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			resizeTS.Name = "resizeTS";
			resizeTS.Size = new System.Drawing.Size(23, 22);
			resizeTS.Text = "Ridimensiona foglio";
			resizeTS.Click += new System.EventHandler(ResizeButtonClick);
			// 
			// gridTS
			// 
			gridTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			gridTS.DoubleClickEnabled = true;
			gridTS.Image = global::DiagramDrawer.Properties.Resources.Grid;
			gridTS.ImageTransparentColor = System.Drawing.Color.Magenta;
			gridTS.Name = "gridTS";
			gridTS.Size = new System.Drawing.Size(23, 22);
			gridTS.Text = "Griglia";
			gridTS.DoubleClick += new System.EventHandler(GridTsDoubleClick);
			gridTS.Click += new System.EventHandler(GridTsClick);
			// 
			// toolStripSeparator10
			// 
			toolStripSeparator10.Name = "toolStripSeparator10";
			toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			toolStripSeparator10.Visible = false;
			// 
			// helpToolStripButton
			// 
			helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			helpToolStripButton.Enabled = false;
			helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			helpToolStripButton.Name = "helpToolStripButton";
			helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			helpToolStripButton.Text = "He&lp";
			helpToolStripButton.Visible = false;
			// 
			// imageList1
			// 
			imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			imageList1.TransparentColor = System.Drawing.Color.Magenta;
			imageList1.Images.SetKeyName(0, "ellipse.bmp");
			imageList1.Images.SetKeyName(1, "rectangle.bmp");
			imageList1.Images.SetKeyName(2, "Simple.bmp");
			imageList1.Images.SetKeyName(3, "Point1.bmp");
			imageList1.Images.SetKeyName(4, "Point2.bmp");
			// 
			// fColorDialog
			// 
			fColorDialog.AnyColor = true;
			// 
			// fontDialog1
			// 
			fontDialog1.FontMustExist = true;
			// 
			// bColorDialog
			// 
			bColorDialog.AnyColor = true;
			bColorDialog.Color = System.Drawing.Color.White;
			// 
			// printDocument1
			// 
			printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDocument1PrintPage);
			// 
			// printDialog1
			// 
			printDialog1.Document = printDocument1;
			printDialog1.UseEXDialog = true;
			// 
			// printPreviewDialog1
			// 
			printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.Enabled = true;
			printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			printPreviewDialog1.Name = "printPreviewDialog1";
			printPreviewDialog1.Visible = false;
			// 
			// openFileDialog1
			// 
			openFileDialog1.DefaultExt = "xml";
			openFileDialog1.FileName = "openFileDialog1";
			openFileDialog1.Filter = "File xml (*.xml)|*.xml|Tutti i files (*.*)|*.*";
			// 
			// saveFileDialog1
			// 
			saveFileDialog1.DefaultExt = "xml";
			saveFileDialog1.FileName = "diagram";
			saveFileDialog1.Filter = "File xml (*.xml)|*.xml|Tutti i files (*.*)|*.*";
			saveFileDialog1.RestoreDirectory = true;
			// 
			// saveFileDialog2
			// 
			saveFileDialog2.FileName = "export";
			saveFileDialog2.Filter = "File png (*.png)|*.png|File jpeg (*.jpg,*.jpeg)|*.jpg,*.jpeg|File bitmap (*.bmp)|" +
				"*.bmp|File gif (*.gif)|*.gif|File tiff (*.tif,*.tiff)|*.tif,*.tiff";
			saveFileDialog2.RestoreDirectory = true;
			// 
			// borderColorDialog
			// 
			borderColorDialog.AnyColor = true;
			// 
			// saveFileDialog3
			// 
			saveFileDialog3.DefaultExt = "svg";
			saveFileDialog3.Filter = "File svg (*.svg)|*.svg|Tutti i files (*.*)|*.*";
			// 
			// MainForm
			// 
			ClientSize = new System.Drawing.Size(804, 578);
			Controls.Add(toolStripContainer1);
			MainMenuStrip = menuStrip1;
			Name = "MainForm";
			Text = "Diagram Drawer";
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainForm_FormClosing);
			toolStripContainer1.ContentPanel.ResumeLayout(false);
			toolStripContainer1.ContentPanel.PerformLayout();
			toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			toolStripContainer1.TopToolStripPanel.PerformLayout();
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
			panel1.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.ToolStripContainer toolStripContainer1;
		System.Windows.Forms.MenuStrip menuStrip1;
		System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		System.Windows.Forms.ToolStrip toolStrip1;
		System.Windows.Forms.ToolStripButton newToolStripButton;
		System.Windows.Forms.ToolStripButton openToolStripButton;
		System.Windows.Forms.ToolStripButton saveToolStripButton;
		System.Windows.Forms.ToolStripButton printToolStripButton;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		System.Windows.Forms.ToolStripButton cutToolStripButton;
		System.Windows.Forms.ToolStripButton copyToolStripButton;
		System.Windows.Forms.ToolStripButton pasteToolStripButton;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		System.Windows.Forms.ToolStripButton helpToolStripButton;
		System.Windows.Forms.ImageList imageList1;
		System.Windows.Forms.ToolStripSplitButton libraryTS;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		System.Windows.Forms.FontDialog fontDialog1;
		System.Windows.Forms.ColorDialog bColorDialog;
		System.Windows.Forms.PrintDialog printDialog1;
		System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		System.Windows.Forms.ColorDialog fColorDialog;
		System.Drawing.Printing.PrintDocument printDocument1;
		System.Windows.Forms.OpenFileDialog openFileDialog1;
		System.Windows.Forms.SaveFileDialog saveFileDialog1;
		CheckableToolStripSplitButton linkModeTS;
		System.Windows.Forms.Panel panel1;
		ShapeContainer shapeContainer1;
		System.Windows.Forms.ToolStripMenuItem objectsTSMI;
		System.Windows.Forms.ToolStripMenuItem lineKindTSMI;
		CheckableToolStripSplitButton fontTS;
		System.Windows.Forms.ToolStripMenuItem altriToolStripMenuItem;
		CheckableToolStripSplitButton fColorTS;
		System.Windows.Forms.ToolStripMenuItem altriToolStripMenuItem1;
		CheckableToolStripSplitButton bColorTS;
		System.Windows.Forms.ToolStripMenuItem altriToolStripMenuItem2;
		System.Windows.Forms.ToolStripMenuItem showTSMI;
		System.Windows.Forms.ToolStripMenuItem hideTSMI;
		System.Windows.Forms.ToolStripButton resizeTS;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
		System.Windows.Forms.SaveFileDialog saveFileDialog2;
		System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		System.Windows.Forms.ToolStripButton gridTS;
		CheckableToolStripSplitButton borderColorTS;
		System.Windows.Forms.ColorDialog borderColorDialog;
		System.Windows.Forms.ToolStripMenuItem altriToolStripMenuItem3;
		System.Windows.Forms.ToolStripMenuItem comeImmagineVettorialeToolStripMenuItem;
		System.Windows.Forms.SaveFileDialog saveFileDialog3;
	}
}

