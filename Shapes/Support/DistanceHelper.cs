using System;
using System.Drawing;

namespace Nummite.Shapes.Support {
	static class DistanceHelper {

		/// <summary>
		/// Computes the dot product AB ⋅ BC
		/// </summary>
		static float Dot(PointF a, PointF b, PointF c) {
			var ab = new PointF {X = b.X - a.X, Y = b.Y - a.Y};
			var bc = new PointF {X = c.X - b.X, Y = c.Y - b.Y};
			var dot = ab.X * bc.X + ab.Y * bc.Y;
			return dot;
		}

		/// <summary>
		/// Computes the cross product AB x AC
		/// </summary>
		static float Cross(PointF a, PointF b, PointF c) {
			var ab = new PointF {X = b.X - a.X, Y = b.Y - a.Y};
			var ac = new PointF {X = c.X - a.X, Y = c.Y - a.Y};
			var cross = ab.X * ac.Y - ab.Y * ac.X;
			return cross;
		}

		/// <summary>
		/// Computes the distance between two points
		/// </summary>
		static double Distance(PointF a, PointF b) {
			var d1 = a.X - b.X;
			var d2 = a.Y - b.Y;
			return Math.Sqrt(d1 * d1 + d2 * d2);
		}

		/// <summary>
		/// Computes the distance from AB to C
		/// </summary>
		/// <param name="isSegment">True if AB is a segment.</param>
		/// <returns></returns>
		public static double LinePointDist(PointF a, PointF b, PointF c, bool isSegment) {
			var dist = Cross(a, b, c) / Distance(a, b);
			if (!isSegment)
				return Math.Abs (dist);
			var dot1 = Dot(a, b, c);
			if(dot1 > 0)
				return Distance(b, c);
			var dot2 = Dot(b, a, c);
			if(dot2 > 0)
				return Distance(a, c);
			return Math.Abs(dist);
		}

	}
}
