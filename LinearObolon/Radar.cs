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

            r = 500;

            xBegin = panel.ClientSize.Width / 2;
            yBegin = panel.ClientSize.Height / 2;

            fiTick = -90;
        }

        public void moveArrow()
        {
            fiTick += 6;

            xCoordinate = xBegin + r * cosFi(fiTick);
            yCoordinate = yBegin + r * sinFi(fiTick);
        }

        private float cosFi(int fi)
        {
            return (float)Math.Cos((Math.PI * fi) / 180);
        }

        private float sinFi(int fi)
        {
            return (float)Math.Sin((Math.PI * fi) / 180);
        }
    }
}
