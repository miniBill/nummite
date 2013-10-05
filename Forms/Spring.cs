using System;
using System.Drawing;
using Nummite.Graphs;
using Nummite.Shapes.Interfaces;

namespace Nummite.Forms
{
	class Spring
	{
		public double? BaseLength { get; private set; }
		public Node<IShape> Left { get; private set; }
		public Node<IShape> Right { get; private set; }

		public Spring(Node<IShape> left, Node<IShape> right, double? length = null)
		{
			BaseLength = length;
			Left = left;
			Right = right;
		}

		public Tuple<double, double> GetForce()
		{
			Point leftp = Left.Value.Location;
			Point rightp = Right.Value.Location;
			var diff = new Tuple<double, double>(rightp.X - leftp.X, rightp.Y - leftp.Y);
			double length = Length (diff);
			if (Math.Abs (length) < 1)
				return Tuple.Create (0.0, 0.0);
			double ratio = 1 / length;
			if (BaseLength != null)
				ratio *= length - BaseLength.Value;
			else
				ratio /= length*length;
			return Tuple.Create(diff.Item1 * ratio, diff.Item2 * ratio);
		}

		public static double Length(Tuple<double, double> vector)
		{
			return Math.Sqrt(vector.Item1 * vector.Item1 + vector.Item2 * vector.Item2);
		}
	}
}