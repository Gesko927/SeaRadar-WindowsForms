using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConvexHullScan
{
    internal class SeaMap : ISeaDrawable
    {
        private readonly int _height;

        private readonly Panel _panel;
        private readonly Random _random;

        private readonly int[,] _sea;

        public SeaMap()
        {
            Width = 10;
            _height = 10;

            var amountOfShips = 10;

            _random = new Random();

            Ships = new Ship[amountOfShips];

            for (var i = 0; i < amountOfShips; ++i)
                Ships[i] = CreateShip();

            _sea = new int[Width, _height];
        }

        public SeaMap(int width, int height, int shipsAmount, Panel panel)
        {
            if (panel != null) _panel = panel;

            Width = width;
            _height = height;

            _sea = new int[width, height];

            Ships = new Ship[shipsAmount];

            _random = new Random();

            for (var i = 0; i < shipsAmount; ++i)
                Ships[i] = CreateShip();
        }

        internal Ship[] Ships { get; }

        private int Width { get; set; }

        /// <summary>
        ///     Method which draws all ships on selected control with graphics
        /// </summary>
        /// <param name="graphics">Control`s graphics</param>
        public void DrawShips(Graphics graphics)
        {
            for (var i = 0; i < Ships.Length; ++i)
            {
                if (IsOutOfSeaRange(Ships[i].Position.X, Ships[i].Position.Y))
                {
                    Ships[i] = null;
                    Ships[i] = CreateShip();
                }
                graphics.DrawImage(
                    Image.FromFile(@"C:\Users\GeskoPC\Documents\SeaRadar-WindowsForms\LinearObolon\bin\Debug\Ship.png"),
                    Ships[i].Position.X, Ships[i].Position.Y);
            }
        }

        /// <summary>
        ///     Method for creating new ship
        /// </summary>
        /// <returns>Return </returns>
        private Ship CreateShip()
        {
            var startSide = _random.Next(1, 4);
            int exitSide;

            var enterPoint = InitPoint(startSide, 0);

            while (true)
            {
                exitSide = _random.Next(1, 4);

                if (exitSide != startSide)
                    break;
            }

            var exitPoint = InitPoint(exitSide, 1);

            return new Ship(enterPoint, exitPoint, Width,
                new Point(_panel.Width / Width, _panel.Height / _height)); //Visual Ship
        }

        /// <summary>
        ///     Method for initialisation entry and exit point
        /// </summary>
        /// <param name="side">Side on matrix</param>
        /// <param name="count">0 - entry point, 1 - exit point</param>
        /// <returns>Return point on matrix</returns>
        private Point InitPoint(int side, int count)
        {
            var point = new Point();

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
                        point.Y = _random.Next(count, Width - 1);
                        point.X = 0;
                    } while (!IsCorrectEntryPoint(point.X, point.Y));
                }
                    break;
                case 2:
                {
                    do
                    {
                        point.Y = Width - 1;
                        point.X = _random.Next(count, _height - 1);
                    } while (!IsCorrectEntryPoint(point.X, point.Y));
                }
                    break;
                case 3:
                {
                    do
                    {
                        point.Y = _random.Next(count, Width - 1);
                        point.X = _height - 1;
                    } while (!IsCorrectEntryPoint(point.X, point.Y));
                }
                    break;
                case 4:
                {
                    do
                    {
                        point.Y = 0;
                        point.X = _random.Next(count, _height - 1);
                    } while (!IsCorrectEntryPoint(point.X, point.Y));
                }
                    break;
            }

            return point;
        }

        /// <summary>
        ///     Method for validation correct ship`s entry point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsCorrectEntryPoint(int x, int y)
        {
            var result = false;

            if (_sea[x, y] == 0)
                result = true;

            return result;
        }

        /// <summary>
        ///     Method for validation move beyond the sea
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsOutOfSeaRange(int x, int y)
        {
            var result = false;

            if (x < -25 || x > _panel.Width + 50 || y < -25 || y > _panel.Height + 50)
                result = true;

            return result;
        }

        /// <summary>
        ///     Method which moves all ships.
        /// </summary>
        public void MoveShips()
        {
            foreach (var ship in Ships)
                ship.MoveShip();
        }
    }
}