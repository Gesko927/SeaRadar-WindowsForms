using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHullScanning
{
    public partial class MainForm : Form
    {
        private List<Point> points;
        private Dictionary<Point, Point> segments;

        private Graphics graphics;
        private Graphics doubleBuffer;
        private Bitmap bitmap;

        private int pointCount;
        private Font font;
        private ConvexHull convexHull;
        private CoordinateSystem cooSystem;
        private SeaMap sea;
        private Radar radar;

        bool isFirstInit;
        bool radarState;

        public MainForm()
        {
            isFirstInit = false;
            InitializeComponent();
            isFirstInit = true;
            pointCount = 0;
            points = new List<Point>();
            bitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
            graphics = mainPanel.CreateGraphics();
            doubleBuffer = Graphics.FromImage(bitmap);
            font = new System.Drawing.Font("Modern No 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            convexHull = new ConvexHull();
            cooSystem = new CoordinateSystem();
            segments = new Dictionary<Point, Point>();
        }

        /// <summary>
        /// Refresh all data
        /// </summary>
        private void RefreshData()
        {
            pointCount = 0;
            stdPoints.Items.Clear();
            sortPoints.Items.Clear();
            convexHull.Clear();
            segments.Clear();
            DrawConvexHullAndCoordinateSystem(doubleBuffer);
            graphics.DrawImage(bitmap, 0, 0);
        }

        /// <summary>
        /// Show selected points on control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            doubleBuffer.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);

            doubleBuffer.DrawString((++pointCount).ToString(), font, Brushes.Red, new Point(e.X - 5, e.Y + 20));

            PointF point = cooSystem.ConvertToDecartCoordinates(new Point(e.X, e.Y));

            stdPoints.Items.Add(point.X.ToString() + " " + point.Y.ToString() + " " + pointCount);

            convexHull.AddPoint(point.X, point.Y);

            graphics.DrawImage(bitmap, 0, 0);
        }

        /// <summary>
        /// Method which draws Convex Hull on control with graphics
        /// </summary>
        /// <param name="graphics">Contol`s graphics</param>
        private void DrawMBOLines(Graphics graphics)
        {
            for (int i = 0; i < convexHull.Count - 1; ++i)
            {
                Point temp = cooSystem.ConvertToStandartCoordinates(convexHull[i]);
                graphics.FillEllipse(Brushes.Red, new Rectangle(new Point(temp.X - 5, temp.Y - 5), new Size(10, 10)));
                graphics.DrawLine(new Pen(Color.Red, 2), temp, cooSystem.ConvertToStandartCoordinates(convexHull[i + 1]));
            }
        }

        /// <summary>
        /// Method which creates Convex Hull from selected points on control
        /// </summary>
        private void DrawMBO()
        {
            DrawMBOLines(doubleBuffer);

            sortPoints.Items.Clear();
            stdPoints.Items.Clear();

            for (int i = 0; i < convexHull.Count; ++i)
            {
                sortPoints.Items.Add(cooSystem.ConvertToStandartCoordinates(convexHull[i]));
                stdPoints.Items.Add(convexHull[i].X + " " + convexHull[i].Y);
            }

            for(int i = 0; i < convexHull.Count - 1; ++i)
            {
                segments.Add(cooSystem.ConvertToStandartCoordinates(convexHull[i]), cooSystem.ConvertToStandartCoordinates(convexHull[i+1]));
            }
        }

        /// <summary>
        /// Method for writing message into a file
        /// </summary>
        /// <param name="fileName">File name for writing message</param>
        /// <param name="message">Message for writing</param>
        public void PrintInfoInFile(string fileName, string message)
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
            { sw.Close(); }

        }

        /// <summary>
        /// Draws ConvexHull and Coordinate System on selected control with graphics
        /// </summary>
        /// <param name="graphics">Control`s graphics</param>
        private void DrawConvexHullAndCoordinateSystem(Graphics graphics)
        {
            graphics.Clear(Color.DodgerBlue);
            cooSystem.paintCoordinateSystem(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height, graphics, new Pen(Color.Black, 3));
            DrawMBOLines(graphics);
        }

        /// <summary>
        /// Check whether the ship crossed Convex Hull
        /// </summary>
        private void CheckShips()
        {
            bool leftIntersect = false;
            bool rightIntersect = false;

            
            for (int i = 0; i < sea.Ships.Length; ++i)
            {
                foreach (KeyValuePair<Point, Point> point in segments)
                {
                    if (VectorIntersection.RayIntersectionLeft(point.Key, point.Value ,  sea.Ships[i].Position))
                    {
                        leftIntersect = true;
                        break;
                    }
                }


                foreach (KeyValuePair<Point, Point> point in segments)
                {
                    if (VectorIntersection.RayIntersectionRight(point.Key, point.Value, sea.Ships[i].Position))
                    {
                        rightIntersect = true;
                        break;
                    }
                }

                if (leftIntersect && rightIntersect)
                {
                    if(!sea.Ships[i].shipTimer.IsRunning)
                    {
                        sea.Ships[i].shipTimer.Start();

                        PrintInfoInFile("log.txt","Ship [" + (i + 1) + "] entered at: " + DateTime.Now.ToLongTimeString() + ".\n");
                    }
                }
                else
                {
                    if (sea.Ships[i].shipTimer.IsRunning)
                    {
                        sea.Ships[i].shipTimer.Stop();

                        TimeSpan ts = sea.Ships[i].shipTimer.Elapsed;

                        PrintInfoInFile("log.txt", "Ship [" + (i + 1) + "] out at: " + DateTime.Now.ToLongTimeString() + ".\n");
                        PrintInfoInFile("log.txt", "Ship [" + (i + 1) + "] was " + ts.ToString() + ".\n");
                    }                    
                }

                leftIntersect = false;
                rightIntersect = false;
            }
           
        }

        #region Events

        private void mainTrackBar_Scroll(object sender, EventArgs e)
        {
            cooSystem.Scale = 10;

            for(int i = 0; i < (sender as TrackBar).Value; ++i)
            {
                cooSystem.Scale += 10;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (isFirstInit)
            {
                bitmap = new Bitmap(bitmap, new Size(mainPanel.Width, mainPanel.Height));

                doubleBuffer = Graphics.FromImage(bitmap);

                graphics = mainPanel.CreateGraphics();

                int arrowSize = Math.Max(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height);

                radar = new Radar(mainPanel.ClientSize.Width / 2, mainPanel.ClientSize.Height / 2, arrowSize);

                DrawConvexHullAndCoordinateSystem(doubleBuffer);

                graphics.DrawImage(bitmap, 0, 0);
            }
        }

        private void shipTimer_Tick(object sender, EventArgs e)
        {
            DrawConvexHullAndCoordinateSystem(doubleBuffer);

            sea.DrawShips(doubleBuffer);

            if (radarState)
            {
                CheckShips();

                for (int i = 0; i < 15; i++)
                {
                    radar.MoveArrow();
                    doubleBuffer.DrawLine(new Pen(Color.ForestGreen, 2), radar.XBegin, radar.YBegin, radar.XCoordinate, radar.YCoordinate);
                }
            }

            
            graphics.DrawImage(bitmap, 0 ,0);
            sea.MoveShips();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shipTimer.Stop();
        }

        private void startMoveShipsBtn_Click(object sender, EventArgs e)
        {
            sea = new SeaMap(50, 50, 2, mainPanel);
            shipTimer.Start();
        }

        private void stopMoveShipBtn_Click(object sender, EventArgs e)
        {
            shipTimer.Stop();
        }

        private void buildMBOBtn_Click(object sender, EventArgs e)
        {
            if (pointCount > 2)
            {
                sortPoints.Items.Clear();

                convexHull.CreateConvexHull();

                foreach (PointF point in convexHull)
                {
                    sortPoints.Items.Add(point.X + " " + point.Y);
                }

                DrawMBO();

                graphics.DrawImage(bitmap, 0, 0);
            }
            else
            {
                MessageBox.Show("There should be at least 3 points!");

                DrawConvexHullAndCoordinateSystem(doubleBuffer);
                graphics.DrawImage(bitmap, 0, 0);
            }
        }

        private void refreshAllInfoBtn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void turnOnRadarBtn_Click(object sender, EventArgs e)
        {
            int arrowSize = Math.Max(mainPanel.ClientSize.Width, mainPanel.ClientSize.Height);
            radar = new Radar(mainPanel.ClientSize.Width/2, mainPanel.ClientSize.Height/2, arrowSize);
            radarState = true;
        }

        private void turnOffRadarBtn_Click(object sender, EventArgs e)
        {
            radarState = false;
        }

        #endregion
    }
}
