using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ConvexHullScan
{
    public partial class MainForm : Form
    {
        #region Private Fields
        private readonly ConvexHull _convexHull;
        private readonly CoordinateSystem _cooSystem;
        
        private readonly Font _font;

        private Bitmap _bitmap;
        private Graphics _doubleBuffer;
        private Graphics _contolGraphics;

        private readonly bool _isFirstInit;

        private readonly Dictionary<Point, Point> _pointSegments;
        private int _pointAmount;

        private Radar _radar;
        private bool _radarState;
        private SeaMap _sea;
        #endregion

        public MainForm()
        {
            _isFirstInit = false;
            InitializeComponent();
            _isFirstInit = true;
            _pointAmount = 0;
            _bitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
            _contolGraphics = mainPanel.CreateGraphics();
            _doubleBuffer = Graphics.FromImage(_bitmap);
            _font = new Font("Modern No 20", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _convexHull = new ConvexHull();
            _cooSystem = new CoordinateSystem();
            _pointSegments = new Dictionary<Point, Point>();
        }

        /// <summary>
        ///     Refresh all data
        /// </summary>
        private void RefreshData()
        {
            _pointAmount = 0;
            stdPoints.Items.Clear();
            sortPoints.Items.Clear();
            _convexHull.Clear();
            _pointSegments.Clear();
            DrawConvexHullAndCoordinateSystem(_doubleBuffer);
            _contolGraphics.DrawImage(_bitmap, 0, 0);
        }

        /// <summary>
        ///     Show selected points on control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            _doubleBuffer.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);

            _doubleBuffer.DrawString((++_pointAmount).ToString(), _font, Brushes.Red, new Point(e.X - 5, e.Y + 20));

            var point = _cooSystem.ConvertToDecartCoordinates(new Point(e.X, e.Y));

            stdPoints.Items.Add(point.X + " " + point.Y + " " + _pointAmount);

            _convexHull.AddPoint(point.X, point.Y);

            _contolGraphics.DrawImage(_bitmap, 0, 0);
        }

        /// <summary>
        ///     Method which draws Convex Hull on control with graphics
        /// </summary>
        /// <param name="graphics">Contol`s graphics</param>
        private void DrawHullLines(Graphics graphics)
        {
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));

            for (var i = 0; i < _convexHull.Count - 1; ++i)
            {
                var temp = _cooSystem.ConvertToStandartCoordinates(_convexHull[i]);
                graphics.FillEllipse(Brushes.Red, new Rectangle(new Point(temp.X - 5, temp.Y - 5), new Size(10, 10)));
                graphics.DrawLine(new Pen(Color.Red, 2), temp,
                    _cooSystem.ConvertToStandartCoordinates(_convexHull[i + 1]));
            }
        }

        /// <summary>
        ///     Method which creates Convex Hull from selected points on control
        /// </summary>
        private void DrawHull()
        {
            DrawHullLines(_doubleBuffer);

            sortPoints.Items.Clear();
            stdPoints.Items.Clear();

            for (var i = 0; i < _convexHull.Count; ++i)
            {
                sortPoints.Items.Add(_cooSystem.ConvertToStandartCoordinates(_convexHull[i]));
                stdPoints.Items.Add(_convexHull[i].X + " " + _convexHull[i].Y);
            }

            for (var i = 0; i < _convexHull.Count - 1; ++i)
                _pointSegments.Add(_cooSystem.ConvertToStandartCoordinates(_convexHull[i]),
                    _cooSystem.ConvertToStandartCoordinates(_convexHull[i + 1]));
        }

        /// <summary>
        ///     Method for writing message into a file
        /// </summary>
        /// <param name="fileName">File name for writing message</param>
        /// <param name="message">Message for writing</param>
        private static void PrintInfoInFile(string fileName, string message)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fileName, true);

                sw.WriteLine(message);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw?.Close();
            }
        }

        /// <summary>
        ///     Draws ConvexHull and Coordinate System on selected control with graphics
        /// </summary>
        /// <param name="graphics">Control`s graphics</param>
        private void DrawConvexHullAndCoordinateSystem(Graphics graphics)
        {
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));

            graphics.Clear(Color.DodgerBlue);
            _cooSystem.PaintCoordinateSystem(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height, graphics,
                new Pen(Color.Black, 3));
            DrawHullLines(graphics);
        }

        /// <summary>
        ///     Check whether the ship crossed Convex Hull
        /// </summary>
        private void CheckShips()
        {
            var leftIntersect = false;
            var rightIntersect = false;


            for (var i = 0; i < _sea.Ships.Length; ++i)
            {
                if (_pointSegments.Any(point => VectorIntersection.RayIntersectionLeft(point.Key, point.Value, _sea.Ships[i].Position)))
                {
                    leftIntersect = true;
                }


                if (_pointSegments.Any(point => VectorIntersection.RayIntersectionRight(point.Key, point.Value, _sea.Ships[i].Position)))
                {
                    rightIntersect = true;
                }

                if (leftIntersect && rightIntersect)
                {
                    if (!_sea.Ships[i].ShipTimer.IsRunning)
                    {
                        _sea.Ships[i].ShipTimer.Start();

                        PrintInfoInFile("log.txt",
                            "Ship [" + (i + 1) + "] entered at: " + DateTime.Now.ToLongTimeString() + ".\n");
                    }
                }
                else
                {
                    if (_sea.Ships[i].ShipTimer.IsRunning)
                    {
                        _sea.Ships[i].ShipTimer.Stop();

                        var ts = _sea.Ships[i].ShipTimer.Elapsed;

                        PrintInfoInFile("log.txt",
                            "Ship [" + (i + 1) + "] out at: " + DateTime.Now.ToLongTimeString() + ".\n");
                        PrintInfoInFile("log.txt", "Ship [" + (i + 1) + "] was " + ts + ".\n");
                    }
                }

                leftIntersect = false;
                rightIntersect = false;
            }
        }

        #region Events

        private void mainTrackBar_Scroll(object sender, EventArgs e)
        {
            _cooSystem.Scale = 10;

            for (var i = 0; i < ((TrackBar)sender).Value; ++i)
                _cooSystem.Scale += 10;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (_isFirstInit)
            {
                _bitmap = new Bitmap(_bitmap, new Size(mainPanel.Width, mainPanel.Height));

                _doubleBuffer = Graphics.FromImage(_bitmap);

                _contolGraphics = mainPanel.CreateGraphics();

                var arrowSize = Math.Max(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height);

                _radar = new Radar(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2, arrowSize);

                DrawConvexHullAndCoordinateSystem(_doubleBuffer);

                _contolGraphics.DrawImage(_bitmap, 0, 0);
            }
        }

        private void shipTimer_Tick(object sender, EventArgs e)
        {
            DrawConvexHullAndCoordinateSystem(_doubleBuffer);

            _sea.DrawShips(_doubleBuffer);

            if (_radarState)
            {
                CheckShips();

                for (var i = 0; i < 15; i++)
                {
                    _radar.MoveArrow();
                    _doubleBuffer.DrawLine(new Pen(Color.ForestGreen, 2), _radar.XBegin, _radar.YBegin, _radar.XCoordinate,
                        _radar.YCoordinate);
                }
            }


            _contolGraphics.DrawImage(_bitmap, 0, 0);
            _sea.MoveShips();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shipTimer.Stop();
        }

        private void startMoveShipsBtn_Click(object sender, EventArgs e)
        {
            _sea = new SeaMap(50, 50, 2, mainPanel);
            shipTimer.Start();
        }

        private void stopMoveShipBtn_Click(object sender, EventArgs e)
        {
            shipTimer.Stop();
        }

        private void buildMBOBtn_Click(object sender, EventArgs e)
        {
            if (_pointAmount > 2)
            {
                sortPoints.Items.Clear();

                _convexHull.CreateConvexHull();

                foreach (PointF point in _convexHull)
                    sortPoints.Items.Add(point.X + " " + point.Y);

                DrawHull();

                _contolGraphics.DrawImage(_bitmap, 0, 0);
            }
            else
            {
                MessageBox.Show(@"There should be at least 3 points!");

                DrawConvexHullAndCoordinateSystem(_doubleBuffer);
                _contolGraphics.DrawImage(_bitmap, 0, 0);
            }
        }

        private void refreshAllInfoBtn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void turnOnRadarBtn_Click(object sender, EventArgs e)
        {
            var arrowSize = Math.Max(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height);
            _radar = new Radar(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2, arrowSize);
            _radarState = true;
        }

        private void turnOffRadarBtn_Click(object sender, EventArgs e)
        {
            _radarState = false;
        }

        #endregion
    }
}