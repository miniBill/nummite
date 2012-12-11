using System;
using System.Drawing;

namespace DiagramDrawer.Shapes {
	static class DistanceHelper {
		//Compute the dot product AB ⋅ BC
		static float Dot(PointF a, PointF b, PointF c) {
			var ab = new PointF {X = b.X - a.X, Y = b.Y - a.Y};
			var bc = new PointF {X = c.X - b.X, Y = c.Y - b.Y};
			float dot = ab.X * bc.X + ab.Y * bc.Y;
			return dot;
		}
		//Compute the cross product AB x AC
		static float Cross(PointF a, PointF b, PointF c) {
			var ab = new PointF {X = b.X - a.X, Y = b.Y - a.Y};
			var ac = new PointF {X = c.X - a.X, Y = c.Y - a.Y};
			float cross = ab.X * ac.Y - ab.Y * ac.X;
			return cross;
		}
		//Compute the distance from A to B
		static double Distance(PointF a, PointF b) {
			float d1 = a.X - b.X;
			float d2 = a.Y - b.Y;
			return Math.Sqrt(d1 * d1 + d2 * d2);
		}
		//Compute the distance from AB to C
		//if isSegment is true, AB is a segment, not a line.
		public static double LinePointDist(PointF a, PointF b, PointF c, bool isSegment) {
			double dist = Cross(a, b, c) / Distance(a, b);
			if(isSegment) {
				float dot1 = Dot(a, b, c);
				if(dot1 > 0)
					return Distance(b, c);
				float dot2 = Dot(b, a, c);
				if(dot2 > 0)
					return Distance(a, c);
			}
			return Math.Abs(dist);
		}

	}
}
