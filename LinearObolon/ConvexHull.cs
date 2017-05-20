using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ConvexHullScan
{
    internal class ConvexHull : IEnumerable
    {
        private readonly List<PointF> _incomingPoints;

        private readonly List<PointF> _linearSpanPoints;

        public ConvexHull()
        {
            _incomingPoints = new List<PointF>();
            _linearSpanPoints = new List<PointF>();
        }

        public int Count => _linearSpanPoints.Count;

        public PointF this[int i] => _linearSpanPoints[i];

        public IEnumerator GetEnumerator()
        {
            return _incomingPoints.GetEnumerator();
        }

        public void AddPoint(float x, float y)
        {
            _incomingPoints.Add(new PointF(x, y));
        }

        /// <summary>
        ///     Method which selects the lower left point.
        /// </summary>
        /// <returns>The lower left point</returns>
        private PointF StartPoint()
        {
            var min = _incomingPoints[0].Y;
            var index = 0;

            for (var i = 1; i < _incomingPoints.Count; ++i)
                if (_incomingPoints[i].Y < min)
                {
                    min = _incomingPoints[i].Y;
                    index = i;
                }
                else
                {
                    var TOLERANCE = 0.000001;
                    if (Math.Abs(_incomingPoints[i].Y - min) < TOLERANCE)
                        if (_incomingPoints[i].X < _incomingPoints[index].X)
                        {
                            index = i;
                            min = _incomingPoints[i].Y;
                        }
                }

            var buff = _incomingPoints[0];
            _incomingPoints[0] = _incomingPoints[index];
            _incomingPoints[index] = buff;

            return new PointF(_incomingPoints[0].X, _incomingPoints[0].Y);
        }

        /// <summary>
        ///     Method that determines the location of one relative to another vector
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        private static int VectorTurn(PointF p1, PointF p2, PointF p3)
        {
            var v = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
            return v > 0 ? 1 : (v < 0 ? -1 : 0);
        }

        /// <summary>
        ///     Create convex hull by Graham`s scan
        /// </summary>
        public void CreateConvexHull()
        {
            SortByAngle();

            _linearSpanPoints.Add(_incomingPoints[0]);
            _linearSpanPoints.Add(_incomingPoints[1]);

            var M = 2;

            for (var i = 2; i < _incomingPoints.Count; ++i)
            {
                while (M > 1 && VectorTurn(_linearSpanPoints[M - 2], _linearSpanPoints[M - 1], _incomingPoints[i]) < 0)
                {
                    _linearSpanPoints.Remove(_linearSpanPoints[M - 1]);
                    --M;
                }

                ++M;

                _linearSpanPoints.Add(_incomingPoints[i]);
            }

            _linearSpanPoints.Add(_incomingPoints[0]);
        }

        /// <summary>
        ///     Method which sorts incoming points by angle.
        /// </summary>
        private void SortByAngle()
        {
            var p = StartPoint();

            for (var i = 1; i < _incomingPoints.Count; ++i)
            {
                double min;

                int indexMin;

                min = MyCtg(p, _incomingPoints[i]);

                indexMin = i;

                for (var j = i + 1; j < _incomingPoints.Count; ++j)
                    if (MyCtg(p, _incomingPoints[j]) < min)
                    {
                        min = MyCtg(p, _incomingPoints[j]);
                        indexMin = j;
                    }

                var buff = _incomingPoints[i];
                _incomingPoints[i] = _incomingPoints[indexMin];
                _incomingPoints[indexMin] = buff;
            }
        }

        /// <summary>
        ///     Method which calculates the angle between the vector and the abscissaм
        /// </summary>
        /// <param name="start">Vector`s start point</param>
        /// <param name="end">Vector`s end pointa</param>
        /// <returns></returns>
        private static double MyCtg(PointF start, PointF end)
        {
            return Math.Abs(end.X - start.X) > 0.00001
                ? Math.Atan2(end.Y - start.Y, end.X - start.X) * 180 / Math.PI
                : 0;
        }

        /// <summary>
        ///     Removes points from all lists in ConvexHull object
        /// </summary>
        public void Clear()
        {
            _incomingPoints.Clear();
            _linearSpanPoints.Clear();
        }
    }
}