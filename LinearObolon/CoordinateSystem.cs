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
    class CoordinateSystem
    {
        private int beginX;
        private int beginY;

        private float unitX;
        private float unitY;

        private Font font;

        //масштаб
        private int scale;

        //кількість одиничних відрізків
        private int intervalCount;

        public int BeginX
        {
            get
            {
                return beginX;
            }
        }

        public int BeginY
        {
            get
            {
                return beginY;
            }
        }

        public float UnitX
        {
            get
            {
                return unitX;
            }
        }

        public float UnitY
        {
            get
            {
                return unitY;
            }
        }

        public int Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public CoordinateSystem()
        {
            font = new Font("Ariel", 15, FontStyle.Regular);
            scale = 10;
            intervalCount = 10;
        }

        /// <summary>
        /// Convert point from standart coordinate system to decart coordinate system
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <returns>Result point</returns>
        public PointF ConvertToDecartCoordinates(Point point)
        {
            int temp = scale / intervalCount;

            float x = ((point.X / UnitX)*temp - (BeginX / UnitX)*temp);
            float y = ((BeginY / UnitY)*temp - (point.Y / UnitY)*temp);

            return new PointF(x, y);
        }

        /// <summary>
        /// Convert point from decart coordinate system to standart coordinate system
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <returns>Result point</returns>
        public Point ConvertToStandartCoordinates(PointF point)
        {
            int temp = scale / intervalCount;

            int x = (int)(beginX + point.X * UnitX / temp);
            int y = (int)(BeginY - point.Y * UnitY / temp);

            return new Point(x, y);
        }

        #region Coordinate System

        /// <summary>
        /// Draw coordinate system on control with graphics
        /// </summary>
        /// <param name="width">Control`s width</param>
        /// <param name="height">Control`s height</param>
        /// <param name="graphics">Control`s graphics</param>
        /// <param name="pen">Pen for drawing</param>
        public void paintCoordinateSystem(int width, int height, Graphics graphics, Pen pen)
        {
            unitX = (float)(width / (2 * intervalCount));
            unitY = (float)(height / (2 * intervalCount));

            beginX = width / 2;
            beginY = height / 2;

            graphics.DrawLine(pen, 0, beginY, width, beginY);
            graphics.DrawLine(pen, beginX, height, beginX, 0);

            paintScaleAxes(scale, pen, graphics);
            paintAdditionalScale(scale, width, height, pen, graphics);
        }

        /// <summary>
        /// Draw scale axes for coordinate system with a given scale and graphics.
        /// </summary>
        /// <param name="scale">Scale for coordinate system</param>
        /// <param name="pen">Pen for drawing</param>
        /// <param name="graphics">Control`s graphics</param>
        private void paintScaleAxes(int scale, Pen pen, Graphics graphics)
        {
            pen.Width = 2;
            pen.EndCap = LineCap.NoAnchor;
            font = new Font("Ariel", 8, FontStyle.Regular);

            int temp = scale / intervalCount;
            /**
            * Одиничні відрізки вздовж осі Y
            */
            for (int i = 0; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходиться вище нуля
                graphics.DrawLine(pen, beginX - 10, beginY - (i * unitY), beginX + 10, beginY - (i * unitY));

                graphics.DrawString((i*temp).ToString(), font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX + font.Size / 2,
                                                           /*лівий верхній кут Y*/beginY - (i * unitY),
                                                           /*правий нижній кут Х*/beginX,
                                                           /*правий нижній кут Y*/beginY - (i * unitY)));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходиться нижче нуля
                graphics.DrawLine(pen, beginX - 10, beginY + (i * unitY), beginX + 10, beginY + (i * unitY));

                graphics.DrawString($"-{(i * temp).ToString()}", font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX + font.Size / 2,
                                                           /*лівий верхній кут Y*/beginY + (i * unitY),
                                                           /*правий нижній кут Х*/beginX,
                                                           /*правий нижній кут Y*/beginY + (i * unitY)));
            }

            /**
            * Одиничні відрізки вздовж осі X
            */
            for (int i = 1; i < scale + 1; ++i)
            {
                //Вісь Х, що знаходиться справа від нуля
                graphics.DrawLine(pen, beginX + (i * unitX), beginY + 10, beginX + (i * unitX), beginY - 10);
                //табуляція по правій осі Х
                graphics.DrawString((i * temp).ToString(), font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX + (i * unitX),
                                                           /*лівий верхній кут Y*/beginY + font.Size,
                                                           /*правий нижній кут Х*/beginX + (i * unitX),
                                                           /*правий нижній кут Y*/beginY + 2 * font.Size));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                //Вісь Х, що знаходиться зліва від нуля
                graphics.DrawLine(pen, beginX - (i * unitX), beginY + 10, beginX - (i * unitX), beginY - 10);
                //табуляція по правій осі Х
                graphics.DrawString($"-{(i * temp).ToString()}", font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX - (i * unitX),
                                                           /*лівий верхній кут Y*/beginY + font.Size,
                                                           /*правий нижній кут Х*/beginX + (i * unitX),
                                                           /*правий нижній кут Y*/beginY - 2 * font.Size));
            }


        }

        /// <summary>
        /// Draw additional scale for coordinate system.
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pen"></param>
        /// <param name="graphics"></param>
        private void paintAdditionalScale(int scale, int width, int height, Pen pen, Graphics graphics)
        {
            pen.DashStyle = DashStyle.Dash;
            pen.Width = 1;

            for (int i = 0; i < scale + 1; ++i)
            {
                graphics.DrawLine(pen, 0, beginY + (i * unitY), width, beginY + (i * unitY));
                graphics.DrawLine(pen, 0, beginY - (i * unitY), width, beginY - (i * unitY));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                graphics.DrawLine(pen, beginX + (i * unitX), 0, beginX + (i * unitX), height);
                graphics.DrawLine(pen, beginX - (i * unitX), 0, beginX - (i * unitX), height);
            }
        }

        #endregion
    }
}
