namespace DiagramDrawer.Forms {
	partial class SizeForm {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		readonly System.ComponentModel.IContainer components;

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
		void InitializeComponent() {
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.AcceptsReturn = true;
			textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			textBox1.Location = new System.Drawing.Point(75, 13);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(225, 20);
			textBox1.TabIndex = 0;
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(TextBoxKeyUp);
			textBox1.Validating += new System.ComponentModel.CancelEventHandler(TextBoxValidating);
			// 
			// textBox2
			// 
			textBox2.AcceptsReturn = true;
			textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			textBox2.Location = new System.Drawing.Point(75, 39);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(225, 20);
			textBox2.TabIndex = 1;
			textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(TextBoxKeyUp);
			textBox2.Validating += new System.ComponentModel.CancelEventHandler(TextBoxValidating);
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(button1, 1, 2);
			tableLayoutPanel1.Controls.Add(button2, 2, 2);
			tableLayoutPanel1.Controls.Add(label2, 0, 1);
			tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
			tableLayoutPanel1.Controls.Add(checkBox2, 2, 1);
			tableLayoutPanel1.Controls.Add(checkBox1, 2, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new System.Drawing.Size(379, 103);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// button1
			// 
			button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			button1.Location = new System.Drawing.Point(240, 66);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(60, 23);
			button1.TabIndex = 3;
			button1.Text = "Ok";
			button1.Click += new System.EventHandler(Button1Click);
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(306, 66);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(60, 23);
			button2.TabIndex = 6;
			button2.Text = "Annulla";
			button2.Click += new System.EventHandler(Button2Click);
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 42);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 13);
			label2.TabIndex = 5;
			label2.Text = "Larghezza";
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 13);
			label1.TabIndex = 4;
			label1.Text = "Altezza";
			// 
			// checkBox1
			// 
			checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(318, 14);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(48, 17);
			checkBox1.TabIndex = 7;
			checkBox1.Text = "Auto";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(CheckBox1CheckedChanged);
			// 
			// checkBox2
			// 
			checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(318, 40);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(48, 17);
			checkBox2.TabIndex = 8;
			checkBox2.Text = "Auto";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox2.CheckedChanged += new System.EventHandler(CheckBox1CheckedChanged);
			// 
			// SizeForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(379, 103);
			Controls.Add(tableLayoutPanel1);
			Name = "SizeForm";
			Text = "SizeForm";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout (false);

		}
		System.Windows.Forms.Label label2;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.Button button1;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.TextBox textBox2;
		System.Windows.Forms.TextBox textBox1;
		System.Windows.Forms.Button button2;
		System.Windows.Forms.CheckBox checkBox1;
		System.Windows.Forms.CheckBox checkBox2;
	}
}
