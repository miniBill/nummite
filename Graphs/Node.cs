using System.Collections.Generic;

namespace Nummite.Graphs {
	class Node<T>
	{
		readonly List<Node<T>> children;
		readonly List<Node<T>> parents;

		public T Value { get; private set; }

		public IReadOnlyList<Node<T>> Children {
			get { return children; }
		}

		public IReadOnlyList<Node<T>> Parents {
			get { return parents; }
		}

		public Node (T value)
		{
			children = new List<Node<T>> ();
			parents = new List<Node<T>> ();
			Value = value;
		}

		public void AddLink (Node<T> node)
		{
			children.Add (node);
			node.parents.Add (this);
		}
	}
}