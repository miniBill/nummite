namespace DiagramDrawer.Forms {
	partial class ErrorForm {
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
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
			tableLayoutPanel1.Controls.Add(button1, 0, 1);
			tableLayoutPanel1.Controls.Add(button2, 1, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(292, 266);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// textBox1
			// 
			tableLayoutPanel1.SetColumnSpan(textBox1, 2);
			textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox1.Location = new System.Drawing.Point(13, 13);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(266, 211);
			textBox1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			button1.AutoSize = true;
			button1.Location = new System.Drawing.Point(24, 230);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(107, 23);
			button1.TabIndex = 1;
			button1.Text = "Copia negli appunti";
			button1.Click += new System.EventHandler(Button1Click);
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			button2.AutoSize = true;
			button2.Location = new System.Drawing.Point(176, 230);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 2;
			button2.Text = "Chiudi";
			button2.Click += new System.EventHandler(Button2Click);
			// 
			// ErrorForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(292, 266);
			Controls.Add(tableLayoutPanel1);
			Name = "ErrorForm";
			Text = "ErrorForm";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.TextBox textBox1;
		System.Windows.Forms.Button button1;
		System.Windows.Forms.Button button2;
	}
}