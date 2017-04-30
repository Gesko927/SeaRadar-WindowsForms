using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace ConvexHullScanning
{
    class Radar
    {
        private int r;

        private int fiTick;

        private int xBegin;
        private int yBegin;

        private float xCoordinate;
        private float yCoordinate;

        public int XBegin
        {
            get
            {
                return xBegin;
            }
        }

        public int YBegin
        {
            get
            {
                return yBegin;
            }
        }

        public float XCoordinate
        {
            get
            {
                return xCoordinate;
            }
        }

        public float YCoordinate
        {
            get
            {
                return yCoordinate;
            }
        }

        /// <summary>
        /// Creates a radar centered with X and Y coordinates
        /// </summary>
        /// <param name="xCenter">Center X coordinate</param>
        /// <param name="yCenter">Center Y coordinate</param>
        /// <param name="arrowSize">Size of radar`s arrow in px</param>
        public Radar(int xCenter, int yCenter, int arrowSize)
        {

            r = arrowSize;

            xBegin = xCenter;
            yBegin = yCenter;

            fiTick = -90;
        }

        /// <summary>
        /// Method which moves radar`s arrows
        /// </summary>
        public void MoveArrow()
        {
            fiTick += 1;

            xCoordinate = xBegin + r * CosFi(fiTick);
            yCoordinate = yBegin + r * SinFi(fiTick);
        }

        private float CosFi(int fi)
        {
            return (float)Math.Cos((Math.PI * fi) / 180);
        }

        private float SinFi(int fi)
        {
            return (float)Math.Sin((Math.PI * fi) / 180);
        }
    }
}
