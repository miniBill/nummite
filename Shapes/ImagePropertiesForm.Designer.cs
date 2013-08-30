using System.Windows.Forms;

namespace DiagramDrawer.Shapes {
	partial class ImagePropertiesForm {
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
			pictureBox1 = new PictureBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			label1 = new Label();
			label2 = new Label();
			trackBar1 = new TrackBar();
			trackBar2 = new TrackBar();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			flowLayoutPanel1 = new FlowLayoutPanel();
			button2 = new Button();
			button1 = new Button();
			button3 = new Button();
			openFileDialog1 = new OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
			tableLayoutPanel1.SuspendLayout();
			(trackBar1).BeginInit();
			(trackBar2).BeginInit();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Anchor = AnchorStyles.None;
			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
			tableLayoutPanel1.SetColumnSpan(pictureBox1, 3);
			pictureBox1.Location = new System.Drawing.Point(252, 256);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(100, 50);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 6;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
			tableLayoutPanel1.Controls.Add(pictureBox1, 2, 6);
			tableLayoutPanel1.Controls.Add(label1, 1, 2);
			tableLayoutPanel1.Controls.Add(label2, 1, 3);
			tableLayoutPanel1.Controls.Add(trackBar1, 2, 2);
			tableLayoutPanel1.Controls.Add(trackBar2, 2, 3);
			tableLayoutPanel1.Controls.Add(label3, 1, 6);
			tableLayoutPanel1.Controls.Add(label4, 2, 4);
			tableLayoutPanel1.Controls.Add(label5, 3, 4);
			tableLayoutPanel1.Controls.Add(label6, 4, 4);
			tableLayoutPanel1.Controls.Add(label7, 1, 1);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 7);
			tableLayoutPanel1.Controls.Add(button3, 4, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 9;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new System.Drawing.Size(527, 432);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(23, 63);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 13);
			label1.TabIndex = 1;
			label1.Text = "Larghezza";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(23, 103);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 13);
			label2.TabIndex = 2;
			label2.Text = "Altezza";
			// 
			// trackBar1
			// 
			trackBar1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(trackBar1, 3);
			trackBar1.LargeChange = 1;
			trackBar1.Location = new System.Drawing.Point(103, 53);
			trackBar1.Maximum = 19;
			trackBar1.Minimum = 1;
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new System.Drawing.Size(399, 34);
			trackBar1.TabIndex = 3;
			trackBar1.Value = 10;
			trackBar1.Scroll += new System.EventHandler(TrackBar1Scroll);
			// 
			// trackBar2
			// 
			trackBar2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.SetColumnSpan(trackBar2, 3);
			trackBar2.LargeChange = 1;
			trackBar2.Location = new System.Drawing.Point(103, 93);
			trackBar2.Maximum = 19;
			trackBar2.Minimum = 1;
			trackBar2.Name = "trackBar2";
			trackBar2.Size = new System.Drawing.Size(399, 34);
			trackBar2.TabIndex = 4;
			trackBar2.Value = 10;
			trackBar2.Scroll += new System.EventHandler(TrackBar1Scroll);
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(23, 274);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(54, 13);
			label3.TabIndex = 5;
			label3.Text = "Anteprima";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(103, 138);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(27, 13);
			label4.TabIndex = 6;
			label4.Text = "10%";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.None;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(286, 138);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(33, 13);
			label5.TabIndex = 7;
			label5.Text = "100%";
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Right;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(469, 138);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(33, 13);
			label6.TabIndex = 8;
			label6.Text = "190%";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(23, 28);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(23, 13);
			label7.TabIndex = 9;
			label7.Text = "File";
			// 
			// flowLayoutPanel1
			// 
			tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 3);
			flowLayoutPanel1.Controls.Add(button2);
			flowLayoutPanel1.Controls.Add(button1);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
			flowLayoutPanel1.Location = new System.Drawing.Point(100, 382);
			flowLayoutPanel1.Margin = new Padding(0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new System.Drawing.Size(405, 30);
			flowLayoutPanel1.TabIndex = 10;
			// 
			// button2
			// 
			button2.Location = new System.Drawing.Point(327, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 1;
			button2.Text = "Annulla";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2Click);
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(246, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.Right;
			button3.Location = new System.Drawing.Point(427, 23);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 23);
			button3.TabIndex = 11;
			button3.Text = "Sfoglia...";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3Click);
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// ImagePropertiesForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(527, 432);
			Controls.Add(tableLayoutPanel1);
			Name = "ImagePropertiesForm";
			Text = "ImageSizeForm";
			((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			(trackBar1).EndInit();
			(trackBar2).EndInit();
			flowLayoutPanel1.ResumeLayout(false);
			ResumeLayout (false);

		}

		#endregion

		PictureBox pictureBox1;
		TableLayoutPanel tableLayoutPanel1;
		Label label1;
		Label label2;
		TrackBar trackBar1;
		TrackBar trackBar2;
		Label label3;
		Label label4;
		Label label5;
		Label label6;
		Label label7;
		FlowLayoutPanel flowLayoutPanel1;
		Button button1;
		Button button2;
		Button button3;
		OpenFileDialog openFileDialog1;
	}
}
