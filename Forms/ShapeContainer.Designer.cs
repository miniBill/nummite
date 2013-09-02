namespace DiagramDrawer.Forms {
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
			SuspendLayout();
			// 
			// ShapeContainer
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Name = "ShapeContainer";
			MouseMove += new System.Windows.Forms.MouseEventHandler(ShapeContainer_MouseMove);
			MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ShapeContainer_MouseDoubleClick);
			MouseDown += new System.Windows.Forms.MouseEventHandler(ShapeContainer_MouseDown);
			MouseUp += new System.Windows.Forms.MouseEventHandler(ShapeContainer_MouseUp);
			ResumeLayout (false);

		}

		#endregion
	}
}
