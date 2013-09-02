namespace Nummite.Forms {
	partial class OptionsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
#pragma warning disable 649
		readonly System.ComponentModel.IContainer components;
#pragma warning restore 649

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
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			treeView1 = new System.Windows.Forms.TreeView();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			panel = new System.Windows.Forms.Panel();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(treeView1, 0, 0);
			tableLayoutPanel1.Controls.Add(button1, 2, 1);
			tableLayoutPanel1.Controls.Add(button2, 1, 1);
			tableLayoutPanel1.Controls.Add(panel, 1, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new System.Drawing.Size(428, 266);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// treeView1
			// 
			treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView1.Location = new System.Drawing.Point(13, 13);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(84, 211);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TreeView1AfterSelect);
			// 
			// button1
			// 
			button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			button1.Location = new System.Drawing.Point(340, 230);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Annulla";
			button1.Click += new System.EventHandler(Button1Click);
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(259, 230);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 3;
			button2.Text = "Ok";
			button2.Click += new System.EventHandler(Button2Click);
			// 
			// panel
			// 
			panel.Dock = System.Windows.Forms.DockStyle.Fill;
			panel.Location = new System.Drawing.Point(103, 13);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(231, 211);
			panel.TabIndex = 4;
			// 
			// OptionsForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(428, 266);
			Controls.Add(tableLayoutPanel1);
			Name = "OptionsForm";
			Text = "OptionsForm";
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.TreeView treeView1;
		System.Windows.Forms.Button button1;
		System.Windows.Forms.Button button2;
		System.Windows.Forms.Panel panel;
	}
}