namespace DiagramDrawer.Forms {
	partial class StringInput {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		readonly System.ComponentModel.IContainer components;

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
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(textBox1, 0, 1);
			tableLayoutPanel1.Controls.Add(button1, 0, 2);
			tableLayoutPanel1.Controls.Add(button2, 1, 2);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new System.Drawing.Size(283, 91);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			tableLayoutPanel1.SetColumnSpan(label1, 2);
			label1.Location = new System.Drawing.Point(13, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(28, 13);
			label1.TabIndex = 0;
			label1.Text = "Text";
			// 
			// textBox1
			// 
			textBox1.AcceptsReturn = true;
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tableLayoutPanel1.SetColumnSpan(textBox1, 2);
			textBox1.Location = new System.Drawing.Point(13, 26);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(257, 20);
			textBox1.TabIndex = 1;
			textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(TextBox1KeyDown);
			// 
			// button1
			// 
			button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			button1.Location = new System.Drawing.Point(115, 53);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Ok";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(196, 53);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(74, 23);
			button2.TabIndex = 3;
			button2.Text = "Annulla";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2Click);
			// 
			// StringInput
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(283, 91);
			Controls.Add(tableLayoutPanel1);
			Name = "StringInput";
			Text = "StringInput";
			FormClosed += new System.Windows.Forms.FormClosedEventHandler(StringInput_FormClosed);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox textBox1;
		System.Windows.Forms.Button button1;
		System.Windows.Forms.Button button2;
	}
}
