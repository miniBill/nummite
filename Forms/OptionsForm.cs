using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiagramDrawer.Forms.OptionPanes;

namespace DiagramDrawer.Forms {
	public partial class OptionsForm : Form {
		readonly List<IOptionPane> panes = new List<IOptionPane>();
		public OptionsForm() {
			InitializeComponent();
			LoadPanes();
			LoadTree();
			tableLayoutPanel1.SetColumnSpan(panel, 2);
		}
		void LoadPanes() {
			IOptionPane general = new General();
			panes.Add(general);
			IOptionPane objects = new Objects();
			panes.Add(objects);
		}
		void LoadTree() {
			foreach(var pane in panes) {
				var t = treeView1.Nodes.Add(pane.Name);
				t.Tag = pane;
				pane.Load();
				foreach(var child in pane.Children)
					AddChildren(child, t);
			}
		}
		static void AddChildren(IOptionPane child, TreeNode treeNode) {
			var t = treeNode.Nodes.Add(child.Name);
			t.Tag = child;
			child.Load();
			foreach(var cchild in child.Children)
				AddChildren(cchild, t);
		}
		void Button1Click(object sender, EventArgs e) {
			Close();
		}
		void Button2Click(object sender, EventArgs e) {
			foreach(var child in panes)
				Save(child);
			Close();
		}
		static void Save(IOptionPane child) {
			child.Save();
			foreach(var cchild in child.Children)
				Save(cchild);
		}

		void TreeView1AfterSelect (object sender, TreeViewEventArgs e)
		{
			var c = e.Node.Tag as Control;
			if (c == null)
				return;
			panel.SuspendLayout ();
			panel.Controls.Clear ();
			panel.Controls.Add (c);
			c.Dock = DockStyle.Fill;
			panel.ResumeLayout (true);
		}
	}
}
