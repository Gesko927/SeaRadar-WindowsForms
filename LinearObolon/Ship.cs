using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ConvexHullScan
{
    internal class Ship
    {
        #region Private Fields

        private Point _direction;
        private Point _enter;
        private Point _exit;
        private PointF _ort;
        private Point _position;
        private Point _scale;
        
        private List<string> _countries;
        private Random _random;

        #endregion

        #region Public Fields

        public readonly Stopwatch ShipTimer = new Stopwatch();
        public Point Position => _position;

        public string _country;
        public string _number;
        public bool _hasAllow;

        #endregion

        public Ship()
        {
            _random = new Random();
            _countries = new List<string>(){"Ukraine", "Poland", "Russia", "Spain", "Germany", "USA", "Italy"};
            _position.X = 0;
            _position.Y = 0;

            _direction.X = 0;
            _direction.Y = 0;

            _ort.X = 0;
            _ort.Y = 0;

            _enter.X = 0;
            _enter.Y = 0;

            _exit.X = 0;
            _exit.Y = 0;

            _country = _countries[_random.Next(0,7)];
            _hasAllow = (_random.Next(0, 1) == 1);
            _number = $"{_random.Next(1, 23)} - {_country} - {_random.Next(5, 76)}";
        }

        public Ship(Point enter, Point exit, int size, Point scale)
        {
            _random = new Random();
            _countries = new List<string>() { "Ukraine", "Poland", "Russia", "Spain", "Germany", "USA", "Italy" };
            _scale = scale;

            if (enter.X == 0)
            { _position.X = 0;}
            else if (enter.X > 0 && enter.X < size - 1)
            { _position.X = enter.X * scale.X;}
            else
            { _position.X = (enter.X + 1) * scale.X;}

            if (enter.Y == 0)
            { _position.Y = 0;}
            else if (enter.Y > 0 && enter.Y < size - 1)
            { _position.Y = enter.Y * scale.Y;}
            else
            { _position.Y = (enter.Y - 1) * scale.Y;}


            _enter = enter;
            _exit = exit;

            OrtDefinition();

            _direction.X = enter.X < exit.X ? 1 : (enter.X > exit.X ? -1 : 0); //1 right, -1 left
            _direction.Y = enter.Y < exit.Y ? 1 : (enter.Y > exit.Y ? -1 : 0); //1 down, -1 up

            _country = _countries[_random.Next(0, 7)];
            _hasAllow = (_random.Next(0, 1) == 1);
            _number = $"{_random.Next(1, 23)} - {_country} - {_random.Next(5, 76)}";
        }

        private void OrtDefinition()
        {
            double k = 0;

            try
            {
                k = (double) (_exit.Y - _enter.Y) / (_exit.X - _enter.X);
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            _ort.X = 1;
            _ort.Y = (float) (k * _ort.X);
        }

        public void MoveShip()
        {
            _position.X += (int) (_direction.X == 1
                ? _ort.X * _scale.X
                : (_direction.X == -1 ? -_ort.X * _scale.X : 0));

            _position.Y += (int) (_direction.Y == 1
                ? _ort.Y * _scale.Y
                : (_direction.Y == -1 ? -_ort.Y * _scale.Y : 0));
        }
    }
}