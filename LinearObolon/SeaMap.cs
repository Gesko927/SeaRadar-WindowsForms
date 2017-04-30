using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ConvexHullScanning
{
    class SeaMap : ISeaDrawable
    {
        private Random random;

        private int width;

        private int height;

        private int[,] Sea;

        private int amountOfShips;

        private Ship[] ships;

        private Panel panel;

        internal Ship[] Ships
        {
            get
            {
                return ships;
            }
        }

        public SeaMap()
        {
            width = 10;
            height = 10;

            amountOfShips = 1;

            random = new Random();

            ships = new Ship[amountOfShips];

            for (int i = 0; i < amountOfShips; ++i)
            {
                ships[i] = CreateShip();
            }

            Sea = new int[width, height];

        }

        public SeaMap(int width, int height, int shipsAmount, Panel panel)
        {
            this.panel = panel;

            this.width = width;
            this.height = height;

            Sea = new int[width, height];

            ships = new Ship[shipsAmount];

            random = new Random();

            for (int i = 0; i < shipsAmount; ++i)
            {
                ships[i] = CreateShip();
            }
        }

        /// <summary>
        /// Method for creating new ship
        /// </summary>
        /// <returns>Return </returns>
        private Ship CreateShip()
        {
            int startSide = random.Next(1, 4);
            int exitSide = 0;

            Point enterPoint = initPoint(startSide, 0);

            while (true)
            {
                exitSide = random.Next(1, 4);

                if (exitSide != startSide)
                { break; }
            }

            Point exitPoint = initPoint(exitSide, 1);

            return (new Ship(enterPoint, exitPoint, width, new Point(panel.Width / width, panel.Height / height)));//Visual Ship
        }

        /// <summary>
        /// Method for initialisation entry and exit point
        /// </summary>
        /// <param name="side">Side on matrix</param>
        /// <param name="count">0 - entry point, 1 - exit point</param>
        /// <returns>Return point on matrix</returns>
        private Point initPoint(int side, int count)
        {
            Point point = new Point();

            /**Sides
             *       1
             *   _________
             *  |         |
             *  |         | 
             * 4|         |2
             *  |         |
             *  |_________|
             *       3
             * 
             */
            switch (side)
            {
                case 1:
                    {
                        do
                        {
                            point.Y = random.Next(count, width - 1);
                            point.X = 0;
                        } while (!IsCorrectEntryPoint(point.X, point.Y));
                    }
                    break;
                case 2:
                    {
                        do
                        {
                            point.Y = width - 1;
                            point.X = random.Next(count, height - 1);
                        } while (!IsCorrectEntryPoint(point.X, point.Y));
                    }
                    break;
                case 3:
                    {
                        do
                        {
                            point.Y = random.Next(count, width - 1);
                            point.X = height - 1;
                        } while (!IsCorrectEntryPoint(point.X, point.Y));
                    }
                    break;
                case 4:
                    {
                        do
                        {
                            point.Y = 0;
                            point.X = random.Next(count, height - 1);
                        } while (!IsCorrectEntryPoint(point.X, point.Y));
                    }
                    break;
            }

            return (point);
        }

        /// <summary>
        /// Method for validation correct ship`s entry point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsCorrectEntryPoint(int x, int y)
        {
            bool result = false;

            if(Sea[x,y] == 0)
            {
                result = true;
            }

            return result; 
        }

        /// <summary>
        /// Method for validation move beyond the sea
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsOutOfSeaRange(int x, int y)
        {
            bool result = false;

            if ((x < -25 || x > panel.Width + 50) || (y < -25 || y > panel.Height + 50))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Method which moves all ships.
        /// </summary>
        public void MoveShips()
        {
            foreach(Ship ship in ships)
            {
                ship.MoveShip();
            }
        }
        
        /// <summary>
        /// Method which draws all ships on selected control with graphics
        /// </summary>
        /// <param name="graphics">Control`s graphics</param>
        public void DrawShips(Graphics graphics)
        {
            for(int i = 0; i < ships.Length; ++i)
            {
                if (IsOutOfSeaRange((int)ships[i].Position.X, (int)ships[i].Position.Y))
                {
                    ships[i] = null;
                    ships[i] = CreateShip();
                }
                graphics.DrawImage(Image.FromFile(@"C:\Users\Gesko927\OneDrive\Visual Projects\Ball\Ball\bin\Debug\Ship.png"), ships[i].Position.X, ships[i].Position.Y);
            }
        }
    }
}
