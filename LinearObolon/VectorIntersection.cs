using System;
using System.Drawing;

namespace ConvexHullScan
{
    internal class VectorIntersection
    {
        /// <summary>
        ///     Method which checks whether there is intersection of two segments
        /// </summary>
        /// <param name="p1Begin">Vector1`s begin point</param>
        /// <param name="p1End">Vector1`s end point</param>
        /// <param name="p2Begin">Vector2`s begin point</param>
        /// <param name="p2End">Vector2`s end point</param>
        /// <returns></returns>
        private static bool SegmentsIntersect(Point p1Begin, Point p1End, Point p2Begin, Point p2End)
        {
            var dir1 = Direction(p2Begin, p2End, p1Begin);
            var dir2 = Direction(p2Begin, p2End, p1End);
            var dir3 = Direction(p1Begin, p1End, p2Begin);
            var dir4 = Direction(p1Begin, p1End, p2End);

            if ((dir1 > 0 && dir2 < 0 || dir1 < 0 && dir2 > 0)
                &&
                (dir3 > 0 && dir4 < 0 || dir3 < 0 && dir4 > 0))
                return true;
            if (dir1 == 0 && IsPointOnSegment(p2Begin, p2End, p1Begin))
                return true;
            if (dir2 == 0 && IsPointOnSegment(p2Begin, p2End, p1End))
                return true;
            if (dir3 == 0 && IsPointOnSegment(p1Begin, p1End, p2Begin))
                return true;
            if (dir4 == 0 && IsPointOnSegment(p1Begin, p1End, p2End))
                return true;
            return false;
        }

        /// <summary>
        ///     Method which checks whether point belongs to segment
        /// </summary>
        /// <param name="vectorBeginPoint">Vector`s begin point</param>
        /// <param name="vectorEndPoint">Vector`s end point</param>
        /// <param name="point">Point for checking</param>
        /// <returns></returns>
        private static bool IsPointOnSegment(Point vectorBeginPoint, Point vectorEndPoint, Point point)
        {
            var result = (point.X - vectorBeginPoint.X) * (vectorEndPoint.Y - vectorBeginPoint.Y) -
                         (vectorEndPoint.X - vectorBeginPoint.X) * (point.Y - vectorBeginPoint.Y);
            if (result == 0)
                return true;
            return false;
        }

        /// <summary>
        ///     The relative location of segments
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int Direction(Point a, Point b, Point c)
        {
            return CartesianProduct(new Point(c.X - a.X, c.Y - a.Y), new Point(b.X - a.X, b.Y - a.Y));
        }

        /// <summary>
        ///     Cartesian product for two points
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private static int CartesianProduct(Point point1, Point point2)
        {
            return point1.X * point2.Y - point2.X * point1.Y;
        }

        /// <summary>
        ///     Method which checks whether ray intersects segment right of it
        /// </summary>
        /// <param name="vectorBeginPoint">Vector`s begin point</param>
        /// <param name="vectorEndPoint">Vector`s end point</param>
        /// <param name="rayPoint">Ray`s begin point</param>
        /// <returns></returns>
        protected internal static bool RayIntersectionRight(Point vectorBeginPoint, Point vectorEndPoint,
            Point rayPoint)
        {
            if (Math.Max(vectorBeginPoint.X, vectorEndPoint.X) < rayPoint.X)
                return false;

            if (vectorBeginPoint.X <= vectorEndPoint.X)
                return SegmentsIntersect(vectorBeginPoint, vectorEndPoint, rayPoint,
                    new Point(vectorEndPoint.X, rayPoint.Y));

            return SegmentsIntersect(vectorBeginPoint, vectorEndPoint, rayPoint,
                new Point(vectorBeginPoint.X, rayPoint.Y));
        }

        /// <summary>
        ///     Method which checks whether ray intersects segment left of it
        /// </summary>
        /// <param name="vectorBeginPoint">Vector`s begin point</param>
        /// <param name="vectorEndPoint">Vector`s end point</param>
        /// <param name="rayPoint">Ray`s begin point</param>
        /// <returns></returns>
        protected internal static bool RayIntersectionLeft(Point vectorBeginPoint, Point vectorEndPoint, Point rayPoint)
        {
            if (Math.Min(vectorBeginPoint.X, vectorEndPoint.X) > rayPoint.X)
                return false;
            if (vectorBeginPoint.X < vectorEndPoint.X)
                return SegmentsIntersect(vectorBeginPoint, vectorEndPoint, rayPoint,
                    new Point(vectorBeginPoint.X, rayPoint.Y));
            return SegmentsIntersect(vectorBeginPoint, vectorEndPoint, rayPoint,
                new Point(vectorEndPoint.X, rayPoint.Y));
        }
    }
}