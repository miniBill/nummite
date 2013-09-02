namespace Nummite.Forms.OptionPanes {
	partial class General {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent() {
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(3, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(292, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Crea automaticamente gli oggetti durante il collegamento";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(3, 26);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(282, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Chiedi conferma prima di chiudere i diagrammi modificati";
			// 
			// General
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Name = "General";
			this.Size = new System.Drawing.Size(326, 79);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		System.Windows.Forms.CheckBox checkBox1;
		System.Windows.Forms.CheckBox checkBox2;
	}
}
