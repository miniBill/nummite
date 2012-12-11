namespace DiagramDrawer.Forms {
	partial class SizeForm {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(75, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(225, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
			this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
			// 
			// textBox2
			// 
			this.textBox2.AcceptsReturn = true;
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(75, 39);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(225, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyUp);
			this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.button1, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.button2, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.checkBox2, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.checkBox1, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 103);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button1.Location = new System.Drawing.Point(240, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Ok";
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button2.Location = new System.Drawing.Point(306, 66);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(60, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Annulla";
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Larghezza";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Altezza";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(318, 14);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(48, 17);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Auto";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(318, 40);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(48, 17);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Auto";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// SizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 103);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SizeForm";
			this.Text = "SizeForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}
