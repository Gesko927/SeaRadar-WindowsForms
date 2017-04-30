using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConvexHullScanning
{
    class ConvexHull: IEnumerable
    {
        private List<PointF> incomingPoints;

        //Список точок, які входять в лінійну оболонку
        private List<PointF> linearSpanPoints;

        public int Count
        {
            get { return linearSpanPoints.Count; }
        }

        public ConvexHull(List<PointF> list)
        {
            incomingPoints = new List<PointF>(list);
            linearSpanPoints = new List<PointF>();
        }

        public ConvexHull()
        {
            incomingPoints = new List<PointF>();
            linearSpanPoints = new List<PointF>();
        }

        public void AddPoint(float x, float y)
        {
            incomingPoints.Add(new PointF(x, y));
        }

        /// <summary>
        /// Method which selects the lower left point.
        /// </summary>
        /// <returns>The lower left point</returns>
        private PointF StartPoint()
        {
            float min = incomingPoints[0].Y;
            int index = 0;

            for(int i = 1; i < incomingPoints.Count; ++i)
            {
                if(incomingPoints[i].Y < min)
                {
                    min = incomingPoints[i].Y;
                    index = i;
                }
                else
                {
                    if(incomingPoints[i].Y == min)
                    {
                        if(incomingPoints[i].X < incomingPoints[index].X)
                        {
                            index = i;
                            min = incomingPoints[i].Y;
                        }
                    }
                }
            }
            
            PointF buff = incomingPoints[0];
            incomingPoints[0] = incomingPoints[index];
            incomingPoints[index] = buff;

            return new PointF(incomingPoints[0].X, incomingPoints[0].Y);
        }

        /// <summary>
        /// Method that determines the location of one relative to another vector
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        private int VectorTurn(PointF p1, PointF p2, PointF p3)
        {
            float v = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
            return v > 0 ? 1 : ( v < 0 ? -1 : 0 );
        }

        /// <summary>
        /// Create convex hull by Graham`s scan
        /// </summary>
        public void CreateConvexHull()
        {
            SortByAngle();

            linearSpanPoints.Add(incomingPoints[0]);
            linearSpanPoints.Add(incomingPoints[1]);

            int M = 2;

            for(int i = 2; i < incomingPoints.Count;++i)
            {
                while(M > 1 && (VectorTurn(linearSpanPoints[M-2], linearSpanPoints[M-1], incomingPoints[i]) < 0))
                {
                    linearSpanPoints.Remove(linearSpanPoints[M-1]);
                    --M;
                }

                ++M;

                linearSpanPoints.Add(incomingPoints[i]);
            }

            linearSpanPoints.Add(incomingPoints[0]);
        }

        /// <summary>
        /// Method which sorts incoming points by angle.
        /// </summary>
        public void SortByAngle()
        {
            PointF p = StartPoint();

            for (int i = 1; i < incomingPoints.Count; ++i)
            {
                double min;

                int indexMin;

                min = MyCtg(p, incomingPoints[i]);

                indexMin = i;

                for(int j = i + 1; j < incomingPoints.Count; ++j)
                {
                    if(MyCtg(p, incomingPoints[j]) < min)
                    {
                        min = MyCtg(p, incomingPoints[j]);
                        indexMin = j;
                    }
                }

                PointF buff = incomingPoints[i];
                incomingPoints[i] = incomingPoints[indexMin];
                incomingPoints[indexMin] = buff;
            }
        }

        /// <summary>
        /// Method which calculates the angle between the vector and the abscissaм
        /// </summary>
        /// <param name="start">Vector`s start point</param>
        /// <param name="end">Vector`s end pointa</param>
        /// <returns></returns>
        public double MyCtg(PointF start, PointF end)
        {
            return ((end.X - start.X) != 0.0 ? (Math.Atan2((end.Y - start.Y),(end.X - start.X))*180/Math.PI) : 0);
        }

        /// <summary>
        /// Removes points from all lists in ConvexHull object
        /// </summary>
        public void Clear()
        {
            incomingPoints.Clear();
            linearSpanPoints.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return incomingPoints.GetEnumerator();
        }

        public PointF this[int i]
        {
            get { return linearSpanPoints[i]; }
        }

        
    }
}
