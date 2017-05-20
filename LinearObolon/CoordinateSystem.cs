using System.Drawing;
using System.Drawing.Drawing2D;

// ReSharper disable All

namespace ConvexHullScan
{
    internal class CoordinateSystem
    {
        #region Private Fields

        private readonly int _intervalCount;
        private Font _font;

        #endregion

        #region Properties

        public int BeginX { get; private set; }

        public int BeginY { get; private set; }

        public float UnitX { get; private set; }

        public float UnitY { get; private set; }

        public int Scale { get; set; }

        #endregion

        public CoordinateSystem()
        {
            _font = new Font("Ariel", 15, FontStyle.Regular);
            Scale = 10;
            _intervalCount = 10;
        }

        /// <summary>
        ///     Convert point from standart coordinate system to decart coordinate system
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <returns>Result point</returns>
        public PointF ConvertToDecartCoordinates(Point point)
        {
            var temp = Scale / _intervalCount;

            var x = point.X / UnitX * temp - BeginX / UnitX * temp;
            var y = BeginY / UnitY * temp - point.Y / UnitY * temp;

            return new PointF(x, y);
        }

        /// <summary>
        ///     Convert point from decart coordinate system to standart coordinate system
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <returns>Result point</returns>
        public Point ConvertToStandartCoordinates(PointF point)
        {
            var temp = Scale / _intervalCount;

            var x = (int) (BeginX + point.X * UnitX / temp);
            var y = (int) (BeginY - point.Y * UnitY / temp);

            return new Point(x, y);
        }

        #region Coordinate System

        /// <summary>
        ///     Draw coordinate system on control with graphics
        /// </summary>
        /// <param name="width">Control`s width</param>
        /// <param name="height">Control`s height</param>
        /// <param name="graphics">Control`s graphics</param>
        /// <param name="pen">Pen for drawing</param>
        public void PaintCoordinateSystem(int width, int height, Graphics graphics, Pen pen)
        {
            // ReSharper disable once PossibleLossOfFraction
            UnitX = width / (2 * _intervalCount);
            UnitY = height / (2 * _intervalCount);

            BeginX = width / 2;
            BeginY = height / 2;

            graphics.DrawLine(pen, 0, BeginY, width, BeginY);
            graphics.DrawLine(pen, BeginX, height, BeginX, 0);

            PaintScaleAxes(Scale, pen, graphics);
            PaintAdditionalScale(Scale, width, height, pen, graphics);
        }

        /// <summary>
        ///     Draw scale axes for coordinate system with a given scale and graphics.
        /// </summary>
        /// <param name="scale">Scale for coordinate system</param>
        /// <param name="pen">Pen for drawing</param>
        /// <param name="graphics">Control`s graphics</param>
        private void PaintScaleAxes(int scale, Pen pen, Graphics graphics)
        {
            pen.Width = 2;
            pen.EndCap = LineCap.NoAnchor;
            _font = new Font("Ariel", 8, FontStyle.Regular);

            var temp = scale / _intervalCount;
            /**
            * Одиничні відрізки вздовж осі Y
            */
            for (var i = 0; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходиться вище нуля
                graphics.DrawLine(pen, BeginX - 10, BeginY - i * UnitY, BeginX + 10, BeginY - i * UnitY);

                graphics.DrawString((i * temp).ToString(), _font, Brushes.Black,
                    new RectangleF( /*лівий верхній кут Х*/BeginX + _font.Size / 2,
                        /*лівий верхній кут Y*/BeginY - i * UnitY,
                        /*правий нижній кут Х*/BeginX,
                        /*правий нижній кут Y*/BeginY - i * UnitY));
            }

            for (var i = 1; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходиться нижче нуля
                graphics.DrawLine(pen, BeginX - 10, BeginY + i * UnitY, BeginX + 10, BeginY + i * UnitY);

                graphics.DrawString($"-{i * temp}", _font, Brushes.Black,
                    new RectangleF( /*лівий верхній кут Х*/BeginX + _font.Size / 2,
                        /*лівий верхній кут Y*/BeginY + i * UnitY,
                        /*правий нижній кут Х*/BeginX,
                        /*правий нижній кут Y*/BeginY + i * UnitY));
            }

            /**
            * Одиничні відрізки вздовж осі X
            */
            for (var i = 1; i < scale + 1; ++i)
            {
                //Вісь Х, що знаходиться справа від нуля
                graphics.DrawLine(pen, BeginX + i * UnitX, BeginY + 10, BeginX + i * UnitX, BeginY - 10);
                //табуляція по правій осі Х
                graphics.DrawString((i * temp).ToString(), _font, Brushes.Black,
                    new RectangleF( /*лівий верхній кут Х*/BeginX + i * UnitX,
                        /*лівий верхній кут Y*/BeginY + _font.Size,
                        /*правий нижній кут Х*/BeginX + i * UnitX,
                        /*правий нижній кут Y*/BeginY + 2 * _font.Size));
            }

            for (var i = 1; i < scale + 1; ++i)
            {
                //Вісь Х, що знаходиться зліва від нуля
                graphics.DrawLine(pen, BeginX - i * UnitX, BeginY + 10, BeginX - i * UnitX, BeginY - 10);
                //табуляція по правій осі Х
                graphics.DrawString($"-{i * temp}", _font, Brushes.Black,
                    new RectangleF( /*лівий верхній кут Х*/BeginX - i * UnitX,
                        /*лівий верхній кут Y*/BeginY + _font.Size,
                        /*правий нижній кут Х*/BeginX + i * UnitX,
                        /*правий нижній кут Y*/BeginY - 2 * _font.Size));
            }
        }

        /// <summary>
        ///     Draw additional scale for coordinate system.
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pen"></param>
        /// <param name="graphics"></param>
        private void PaintAdditionalScale(int scale, int width, int height, Pen pen, Graphics graphics)
        {
            pen.DashStyle = DashStyle.Dash;
            pen.Width = 1;

            for (var i = 0; i < scale + 1; ++i)
            {
                graphics.DrawLine(pen, 0, BeginY + i * UnitY, width, BeginY + i * UnitY);
                graphics.DrawLine(pen, 0, BeginY - i * UnitY, width, BeginY - i * UnitY);
            }

            for (var i = 1; i < scale + 1; ++i)
            {
                graphics.DrawLine(pen, BeginX + i * UnitX, 0, BeginX + i * UnitX, height);
                graphics.DrawLine(pen, BeginX - i * UnitX, 0, BeginX - i * UnitX, height);
            }
        }

        #endregion
    }
}