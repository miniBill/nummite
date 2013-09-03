namespace Nummite.Forms {
	partial class ShapeContainer {
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
				current.Dispose();
				back.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent() {
			this.inputBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// inputBox
			// 
			this.inputBox.AcceptsReturn = true;
			this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.inputBox.Location = new System.Drawing.Point(0, 0);
			this.inputBox.Margin = new System.Windows.Forms.Padding(0);
			this.inputBox.Name = "inputBox";
			this.inputBox.Size = new System.Drawing.Size(10, 13);
			this.inputBox.TabIndex = 0;
			this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.inputBox.Visible = false;
			this.inputBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
			this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyDown);
			this.inputBox.Leave += new System.EventHandler(this.inputBox_Leave);
			// 
			// ShapeContainer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.inputBox);
			this.Name = "ShapeContainer";
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer_MouseDoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShapeContainer_MouseUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox inputBox;

	}
}
