using System;

namespace ConvexHullScan
{
    internal class Radar
    {
        #region Private Fields
        private readonly int _arrowLength;

        private int _fiTick; 
        #endregion

        #region Public Properties

        public int XBegin { get; }

        public int YBegin { get; }

        public float XCoordinate { get; private set; }

        public float YCoordinate { get; private set; }

        #endregion

        /// <summary>
        ///     Creates a radar centered with X and Y coordinates
        /// </summary>
        /// <param name="xCenter">Center X coordinate</param>
        /// <param name="yCenter">Center Y coordinate</param>
        /// <param name="arrowSize">Size of radar`s arrow in px</param>
        public Radar(int xCenter, int yCenter, int arrowSize)
        {
            _arrowLength = arrowSize;

            XBegin = xCenter;
            YBegin = yCenter;

            _fiTick = -90;
        }

        /// <summary>
        ///     Method which moves radar`s arrows
        /// </summary>
        public void MoveArrow()
        {
            _fiTick += 1;

            XCoordinate = XBegin + _arrowLength * CosFi(_fiTick);
            YCoordinate = YBegin + _arrowLength * SinFi(_fiTick);
        }

        private static float CosFi(int fi)
        {
            return (float) Math.Cos(Math.PI * fi / 180);
        }

        private static float SinFi(int fi)
        {
            return (float) Math.Sin(Math.PI * fi / 180);
        }
    }
}