using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearObolon
{
    public partial class MainForm : Form
    {
        private List<Point> points = new List<Point>();
        private Dictionary<Point, Point> segments;

        private Graphics graphics;

        private int pointCount;
        private Font font;
        private LinObolonka lin;
        private CoordinateSystem cooSystem;

        private RadarForm radarForm;

        bool isFirstInit;
        bool radarState;

        public MainForm()
        {
            isFirstInit = true;
            InitializeComponent();
            isFirstInit = false;
            graphics = panel1.CreateGraphics();
            pointCount = 0;
            font = new System.Drawing.Font("Modern No 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lin = new LinObolonka();
            cooSystem = new CoordinateSystem(this, panel1);
        }

        /**Обновляємо дані
         * 
         * Викликається, коли:
         * натискається клавіша "Refresh"
         * змінюються розміри форми
         * 
         */ 
        private void refreshData()
        {
            pointCount = 0;
            graphics = panel1.CreateGraphics();
            stdPoints.Items.Clear();
            sortPoints.Items.Clear();
            lin.Clear();
            ClearPanel();
            cooSystem.paintCoordinateSystem(panel1);
            
        }

        /**Очистка всієї панелі
         * 
         */ 
        private void ClearPanel()
        {
            graphics.Clear(Color.DodgerBlue);
        }

        /**Вибір точок
         * 
         * Малюємо точки на панелі
         * Переводимо в декартову систему
         * Добавляємо в лісти
         * 
         */
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            graphics.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);

            graphics.DrawString((++pointCount).ToString(), font, Brushes.Red, new Point(e.X - 5, e.Y + 20));

            PointF point = cooSystem.ToDecartCoordinates(e.X, e.Y);

            stdPoints.Items.Add(point.X.ToString() + " " + point.Y.ToString() + " " + pointCount);

            lin.AddPoint(point.X, point.Y);
        }

        /**Оболонка
         * Малюємо саму оболонку на панелі
         * 
         */ 
        private void DrawMBO()
        {
            segments = new Dictionary<Point, Point>();
            cooSystem.paintCoordinateSystem(panel1);

            for (int i = 0; i < lin.Count - 1; ++i)
            {
                graphics.DrawLine(new Pen(Color.Red, 2), cooSystem.ToStandartCoordinates(lin[i]), cooSystem.ToStandartCoordinates(lin[i + 1]));
            }

            sortPoints.Items.Clear();
            stdPoints.Items.Clear();

            for (int i = 0; i < lin.Count; ++i)
            {
                sortPoints.Items.Add(cooSystem.ToStandartCoordinates(lin[i]));
                stdPoints.Items.Add(lin[i].X + " " + lin[i].Y);
            }

            for(int i = 0; i < lin.Count - 1; ++i)
            {
                segments.Add(cooSystem.ToStandartCoordinates(lin[i]), cooSystem.ToStandartCoordinates(lin[i+1]));
            }
        }

        private void RadarInitialize()
        {
            radarForm = new RadarForm(panel1, this);
            radarForm.Show();
        }

        #region Events
        private void start_Click(object sender, EventArgs e)
        {
            if (pointCount > 2)
            {
                sortPoints.Items.Clear();

                lin.CreateLinObolonka();

                foreach (PointF point in lin)
                {
                    sortPoints.Items.Add(point.X + " " + point.Y);
                }

                DrawMBO();
            }
            else
            {
                MessageBox.Show("There should be at least 3 points!");
                refreshData();
            }
        }
        private void paint_Click(object sender, EventArgs e)
        {
            refreshData();
            ClearPanel();
            cooSystem.paintCoordinateSystem(panel1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cooSystem.Scale = 10;

            for(int i = 0; i < (sender as TrackBar).Value; ++i)
            {
                cooSystem.Scale += 10;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (!isFirstInit)
            {
                refreshData(); 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void radarOn_Click(object sender, EventArgs e)
        {
            RadarInitialize();
            radarState = true;
            radarForm.StartTimer();
        }

        private void radarOff_Click(object sender, EventArgs e)
        {
            radarForm.Close();
            radarForm.StopTimer();
            radarState = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (radarForm != null && radarState)
            {
                //MessageBox.Show("You can`t relocate form while scaning");
                radarForm.Relocate();
                radarForm.BringToFront();
            }
        }

        #endregion


    }
}
