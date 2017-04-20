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
    class Radar
    {
        private Panel panel;
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

        public Radar(Panel panel)
        {
            this.panel = panel;

            r = Math.Max(panel.ClientSize.Width, panel.ClientSize.Height);

            xBegin = panel.ClientSize.Width / 2;
            yBegin = panel.ClientSize.Height / 2;

            fiTick = -90;
        }

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
