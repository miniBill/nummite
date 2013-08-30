namespace DiagramDrawer.Forms.OptionPanes {
	partial class General {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent() {
			checkBox1 = new System.Windows.Forms.CheckBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			checkBox2 = new System.Windows.Forms.CheckBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(3, 3);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(292, 17);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "Crea automaticamente gli oggetti durante il collegamento";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
			tableLayoutPanel1.Controls.Add(checkBox2, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(303, 60);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(3, 26);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(282, 17);
			checkBox2.TabIndex = 1;
			checkBox2.Text = "Chiedi conferma prima di chiudere diagrammi modificati";
			// 
			// General
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "General";
			Size = new System.Drawing.Size(303, 60);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout (false);

		}

		#endregion

		System.Windows.Forms.CheckBox checkBox1;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.CheckBox checkBox2;
	}
}
