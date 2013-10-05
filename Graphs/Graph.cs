using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nummite.Graphs {
	class Graph<T> : IEnumerable<Node<T>>
	{
		readonly IList<Node<T>> nodes;

		public Graph (IEnumerable<Node<T>> nodes)
		{
			this.nodes = new List<Node<T>> (nodes);
		}

		public bool IsCyclic ()
		{
			var visit = new Dictionary<Node<T>, VisitState> ();
			return nodes.Any (node => !visit.ContainsKey (node) && IsCyclic (visit, node));
		}

		private static bool IsCyclic (IDictionary<Node<T>, VisitState> visit, Node<T> node)
		{
			if (!visit.ContainsKey (node))
				visit.Add (node, VisitState.White);
			switch (visit [node]) {
				case VisitState.Black:
					return false;
				case VisitState.Grey:
					return true;
				case VisitState.White:
					visit [node] = VisitState.Grey;
					if (node.Children.Any (child => IsCyclic (visit, child))) {
						return true;
					}
					visit [node] = VisitState.Black;
					return false;
			}
			return false;
		}

		public IEnumerable<Node<T>> GetRoots ()
		{
			return nodes.Where (node => !node.Parents.Any ());
		}

		public IEnumerator<Node<T>> GetEnumerator ()
		{
			return nodes.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		public string GetCycle ()
		{
			var visit = new Dictionary<Node<T>, VisitState> ();
			return (from node in nodes
			        where !visit.ContainsKey (node)
			        let cycle = GetCycle (visit, node)
			        where cycle != null
			        select cycle).FirstOrDefault ();
		}

		private static string GetCycle (IDictionary<Node<T>, VisitState> visit, Node<T> node)
		{
			if (!visit.ContainsKey (node))
				visit.Add (node, VisitState.White);
			switch (visit [node]) {
				case VisitState.Black:
					return null;
				case VisitState.Grey:
					return node.Value.ToString ();
				case VisitState.White:
					visit [node] = VisitState.Grey;
					string cy = (from child in node.Children
					             let cycle = GetCycle (visit, child)
					             where cycle != null
					             select node.Value + " -> " + cycle).FirstOrDefault ();
					if (cy != null)
						return cy;
					visit [node] = VisitState.Black;
					return null;
			}
			return null;
		}
	}

	enum VisitState
	{
		White,
		Grey,
		Black
	}
}