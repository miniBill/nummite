using System.Windows.Forms;

namespace DiagramDrawer.Forms.OptionPanes {
	partial class Objects {
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
			tableLayoutPanel1 = new TableLayoutPanel();
			label1 = new Label();
			numericUpDown1 = new NumericUpDown();
			label2 = new Label();
			numericUpDown2 = new NumericUpDown();
			tableLayoutPanel1.SuspendLayout();
			(numericUpDown1).BeginInit();
			(numericUpDown2).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(label2, 0, 1);
			tableLayoutPanel1.Controls.Add(numericUpDown1, 1, 0);
			tableLayoutPanel1.Controls.Add(numericUpDown2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(277, 62);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(91, 13);
			label1.TabIndex = 0;
			label1.Text = "Larghezza minima";
			// 
			// numericUpDown1
			// 
			numericUpDown1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numericUpDown1.Location = new System.Drawing.Point(100, 3);
			numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(174, 20);
			numericUpDown1.TabIndex = 2;
			numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 32);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(76, 13);
			label2.TabIndex = 1;
			label2.Text = "Altezza minima";
			// 
			// numericUpDown2
			// 
			numericUpDown2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			numericUpDown2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numericUpDown2.Location = new System.Drawing.Point(100, 29);
			numericUpDown2.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(174, 20);
			numericUpDown2.TabIndex = 3;
			numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// Objects
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "Objects";
			Size = new System.Drawing.Size(277, 62);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			numericUpDown1.EndInit();
			numericUpDown2.EndInit();
			ResumeLayout (false);

		}

		#endregion

		TableLayoutPanel tableLayoutPanel1;
		Label label1;
		Label label2;
		NumericUpDown numericUpDown1;
		NumericUpDown numericUpDown2;
	}
}
