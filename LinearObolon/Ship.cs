
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LinearObolon
{
    class Ship
    {
        private PointF position;
        private Point direction;

        private PointF ort;

        private Point enter;
        private Point exit;

        private Point scale;

        public PointF Position
        {
            get
            {
                return position;
            }
        }

        public Ship()
        {
            position.X = 0;
            position.Y = 0;

            direction.X = 0;
            direction.Y = 0;

            ort.X = 0;
            ort.Y = 0;

            enter.X = 0;
            enter.Y = 0;

            exit.X = 0;
            exit.Y = 0;
        }

        public Ship(Point enter, Point exit, int size, Point scale)
        {
            this.scale = scale;

            if(enter.X == 0)
            {
                this.position.X = 0;
            }
            else if(enter.X > 0 && enter.X < size - 1)
            {
                this.position.X = (enter.X) * scale.X;
            }
            else
            {
                this.position.X = (enter.X+1) * scale.X;
            }

            if (enter.Y == 0)
            {
                this.position.Y = 0;
            }
            else if (enter.Y > 0 && enter.Y < size - 1)
            {
                this.position.Y = (enter.Y) * scale.Y;
            }
            else
            {
                this.position.Y = (enter.Y - 1) * scale.Y;
            }


            this.enter = enter;
            this.exit = exit;

            ortDefinition(size);

            direction.X = (enter.X < exit.X) ? 1 : ((enter.X > exit.X) ? -1 : 0);//1 right, -1 left
            direction.Y = (enter.Y < exit.Y) ? 1 : ((enter.Y > exit.Y) ? -1 : 0);//1 down, -1 up
        }

        private void ortDefinition(int size)
        {
            double k = 0;

            try
            {
               k  = (double)(exit.Y - enter.Y) / (exit.X - enter.X);
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            ort.X = 1;
            ort.Y = (float)(k * ort.X);
        }

        public void MoveShip()
        {
            position.X += (direction.X == 1) ? ort.X * scale.X : ((direction.X == -1) ? - ort.X * scale.X : 0);
            position.Y += (direction.Y == 1) ? ort.Y * scale.Y : ((direction.Y == -1) ? - ort.Y * scale.Y : 0);
        }

    }
}