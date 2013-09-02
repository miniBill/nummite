namespace DiagramDrawer.Forms {
	partial class HelpForm {
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
			treeView1 = new System.Windows.Forms.TreeView();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView1.Location = new System.Drawing.Point(13, 13);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(114, 391);
			treeView1.TabIndex = 0;
			// 
			// richTextBox1
			// 
			richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			richTextBox1.Location = new System.Drawing.Point(133, 13);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.ShortcutsEnabled = false;
			richTextBox1.Size = new System.Drawing.Size(432, 391);
			richTextBox1.TabIndex = 1;
			richTextBox1.Text = "";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(treeView1);
			tableLayoutPanel1.Controls.Add(richTextBox1, 1, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(578, 417);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// HelpForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(578, 417);
			Controls.Add(tableLayoutPanel1);
			Name = "HelpForm";
			Text = "HelpForm";
			tableLayoutPanel1.ResumeLayout(false);
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.TreeView treeView1;
		System.Windows.Forms.RichTextBox richTextBox1;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}