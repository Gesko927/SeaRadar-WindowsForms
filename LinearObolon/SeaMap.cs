using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LinearObolon
{
    class SeaMap
    {
        private Random random;

        private int width;

        private int height;

        private int[,] Sea;

        private int amountOfShips;

        private Ship[] ships;

        public SeaMap()
        {
            width = 10;
            height = 10;

            amountOfShips = 1;

            random = new Random();

            ships = new Ship[amountOfShips];

            for(int i = 0; i < amountOfShips; ++i)
            {
                ships[i] = new Ship();
            }

            Sea = new int[width, height];

        }

        public SeaMap(int width, int height, int shipsAmount)
        {
            this.width = width;
            this.height = height;

            ships = new Ship[shipsAmount];

            random = new Random();

            for (int i = 0; i < shipsAmount; ++i)
            {
                ships[i] = new Ship();
            }

            Sea = new int[width, height];
        }
        
        private Ship CreateShip()
        {
            int startSide = random.Next(1,4);
            int exitSide = 0;

            Point enterPoint = new Point();
            Point exitPoint = new Point();

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
            switch (startSide)
            {
                case 1:
                    {
                        enterPoint.Y = 0;
                        enterPoint.X = random.Next(0, width - 1);
                    } break;
                case 2:
                    {
                        enterPoint.Y = random.Next(0, height - 1);
                        enterPoint.X = width - 1;
                    } break;
                case 3:
                    {
                        enterPoint.Y = height - 1;
                        enterPoint.X = random.Next(0, width - 1);
                    } break;
                case 4:
                    {
                        enterPoint.Y = random.Next(0, height - 1);
                        enterPoint.X = 0;
                    } break;
            }
            
            while(true)
            {
                exitSide = random.Next(1, 4);

                if(exitSide != startSide)
                { break; }
            }

            switch (exitSide)
            {
                case 1:
                    {
                        exitPoint.Y = 0;
                        exitPoint.X = random.Next(1, width - 1);
                    }
                    break;
                case 2:
                    {
                        exitPoint.Y = random.Next(1, height - 1);
                        exitPoint.X = width - 1;
                    } break;
                case 3:
                    {
                        exitPoint.Y = height - 1;
                        exitPoint.X = random.Next(1, width - 1);
                    } break;
                case 4:
                    {
                        exitPoint.Y = random.Next(0, height - 1);
                        exitPoint.X = 0;
                    } break;
            }

            return (new Ship(enterPoint, exitPoint));

        }
    }
}
