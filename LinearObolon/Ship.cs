
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
        private Point position;
        private Point direction;

        private Point ort;

        private Point enter;
        private Point exit;

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

        public Ship(Point enter, Point exit)
        {
            this.position = enter;
            this.enter = enter;
            this.exit = exit;

            ortDefinition();

            direction.X = (enter.X < exit.X) ? 1 : ((enter.X > exit.X) ? -1 : 0);//1 right, -1 left
            direction.Y = (enter.Y < exit.Y) ? 1 : ((enter.Y > exit.Y) ? -1 : 0);//1 down, -1 up
        }

        private void ortDefinition()
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
            ort.Y = Convert.ToInt32(Math.Round(k * ort.X, 0, MidpointRounding.AwayFromZero));
        }

    }
}