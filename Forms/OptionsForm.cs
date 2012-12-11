using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiagramDrawer.Forms.OptionPanes;

namespace DiagramDrawer.Forms {
	public partial class OptionsForm : Form {
		readonly List<IOptionPane> _panes = new List<IOptionPane>();
		public OptionsForm() {
			InitializeComponent();
			LoadPanes();
			LoadTree();
			tableLayoutPanel1.SetColumnSpan(panel, 2);
		}
		private void LoadPanes() {
			IOptionPane general = new General();
			_panes.Add(general);
			IOptionPane objects = new Objects();
			_panes.Add(objects);
		}
		private void LoadTree() {
			foreach(var pane in _panes) {
				var t = treeView1.Nodes.Add(pane.Name);
				t.Tag = pane;
				pane.Load();
				foreach(var child in pane.Children)
					AddChildren(child, t);
			}
		}
		private static void AddChildren(IOptionPane child, TreeNode treeNode) {
			var t = treeNode.Nodes.Add(child.Name);
			t.Tag = child;
			child.Load();
			foreach(var cchild in child.Children)
				AddChildren(cchild, t);
		}
		private void Button1Click(object sender, EventArgs e) {
			Close();
		}
		private void Button2Click(object sender, EventArgs e) {
			foreach(var child in _panes)
				Save(child);
			Close();
		}
		private static void Save(IOptionPane child) {
			child.Save();
			foreach(var cchild in child.Children)
				Save(cchild);
		}
		private void TreeView1AfterSelect(object sender, TreeViewEventArgs e) {
			var c = e.Node.Tag as Control;
			panel.SuspendLayout();
			panel.Controls.Clear();
			panel.Controls.Add(c);
			if(c != null)
				c.Dock = DockStyle.Fill;
			panel.ResumeLayout(true);
		}
	}
}
