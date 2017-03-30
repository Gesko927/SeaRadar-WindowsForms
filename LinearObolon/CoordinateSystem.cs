using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace LinearObolon
{
    class CoordinateSystem
    {
        private int beginX;
        private int beginY;

        private float unitX;
        private float unitY;

        private Graphics g;
        private Pen p;
        private Font font;
        private MainForm mainForm;

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

        public CoordinateSystem(MainForm mainForm, Panel panel)
        {
            this.mainForm = mainForm;
            g = panel.CreateGraphics();
            font = new Font("Ariel", 15, FontStyle.Regular);
            scale = 10;
            intervalCount = 10;
        }

        public PointF ToDecartCoordinates(int x0, int y0)
        {
            int temp = scale / intervalCount;

            float x = ((x0 / UnitX)*temp - (BeginX / UnitX)*temp);
            float y = ((BeginY / UnitY)*temp - (y0 / UnitY)*temp);

            return new PointF(x, y);
        }

        public Point ToStandartCoordinates(PointF point)
        {
            int temp = scale / intervalCount;

            int x = (int)(beginX + point.X * UnitX / temp);
            int y = (int)(BeginY - point.Y * UnitY / temp);

            return new Point(x, y);
        }

        #region Coordinate System
        public void paintCoordinateSystem(Panel panel)
        {
            p = new Pen(Color.Black, 3);
            g = panel.CreateGraphics();

            //Одиничні відрізки в пікселях
            unitX = (float)(panel.ClientSize.Width / (2 * intervalCount));
            unitY = (float)(panel.ClientSize.Height / (2 * intervalCount));

            //початок системи координат
            beginX = panel.ClientSize.Width / 2;
            beginY = panel.ClientSize.Height / 2;

            //Система координат
            g.DrawLine(p, 0, beginY, panel.ClientSize.Width, beginY);
            g.DrawLine(p, beginX, panel.ClientSize.Height, beginX, 0);

            paintScaleAxes(scale);
            paintAdditionalScale(scale, panel);
        }


        private void paintScaleAxes(int scale)
        {
            p.Width = 2;
            p.EndCap = LineCap.NoAnchor;
            font = new Font("Ariel", 8, FontStyle.Regular);

            int temp = scale / intervalCount;
            /**
            * Одиничні відрізки вздовж осі Y
            */
            for (int i = 0; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходить вище нуля
                g.DrawLine(p, beginX - 10, beginY - (i * unitY), beginX + 10, beginY - (i * unitY));

                g.DrawString((i*temp).ToString(), font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX + font.Size / 2,
                                                           /*лівий верхній кут Y*/beginY - (i * unitY),
                                                           /*правий нижній кут Х*/beginX,
                                                           /*правий нижній кут Y*/beginY - (i * unitY)));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                //Вісь Y, яка знаходить нижче нуля
                g.DrawLine(p, beginX - 10, beginY + (i * unitY), beginX + 10, beginY + (i * unitY));

                g.DrawString($"-{(i * temp).ToString()}", font, Brushes.Black,
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
                //Вісь Х, що знаходить справа від нуля
                g.DrawLine(p, beginX + (i * unitX), beginY + 10, beginX + (i * unitX), beginY - 10);
                //табуляція по правій осі Х
                g.DrawString((i * temp).ToString(), font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX + (i * unitX),
                                                           /*лівий верхній кут Y*/beginY + font.Size,
                                                           /*правий нижній кут Х*/beginX + (i * unitX),
                                                           /*правий нижній кут Y*/beginY + 2 * font.Size));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                //Вісь Х, що знаходиться зліва від нуля
                g.DrawLine(p, beginX - (i * unitX), beginY + 10, beginX - (i * unitX), beginY - 10);
                //табуляція по правій осі Х
                g.DrawString($"-{(i * temp).ToString()}", font, Brushes.Black,
                                            new RectangleF(/*лівий верхній кут Х*/beginX - (i * unitX),
                                                           /*лівий верхній кут Y*/beginY + font.Size,
                                                           /*правий нижній кут Х*/beginX + (i * unitX),
                                                           /*правий нижній кут Y*/beginY - 2 * font.Size));
            }


        }
        private void paintAdditionalScale(int scale, Panel panel)
        {
            p.DashStyle = DashStyle.Dash;
            p.Width = 1;

            for (int i = 0; i < scale + 1; ++i)
            {
                g.DrawLine(p, 0, beginY + (i * unitY), panel.ClientSize.Width, beginY + (i * unitY));
                g.DrawLine(p, 0, beginY - (i * unitY), panel.ClientSize.Width, beginY - (i * unitY));
            }

            for (int i = 1; i < scale + 1; ++i)
            {
                g.DrawLine(p, beginX + (i * unitX), 0, beginX + (i * unitX), panel.ClientSize.Height);
                g.DrawLine(p, beginX - (i * unitX), 0, beginX - (i * unitX), panel.ClientSize.Height);
            }
        }

        #endregion
    }
}
