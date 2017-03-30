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

        private Graphics graphics;

        private int pointCount;
        private Font font;
        private LinObolonka lin;
        private CoordinateSystem cooSystem;

        //private Radar radar;
        //private Graphics graphicsRadar;

        //Цілковита прозорість панелі (MUST TO DO)

        public MainForm()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            pointCount = 0;
            font = new System.Drawing.Font("Modern No 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lin = new LinObolonka();
            cooSystem = new CoordinateSystem(this, panel1);

            //radar = new Radar(radarPanel);
            //graphicsRadar = radarPanel.CreateGraphics();
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
            lin.clear();
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
         * 
         * Малюємо саму оболонку на панелі
         * 
         */ 
        private void DrawMBO()
        {
            //ClearPanel();
            cooSystem.paintCoordinateSystem(panel1);

            for (int i = 0; i < lin.Count - 1; ++i)
            {
                graphics.DrawLine(new Pen(Color.Red, 2), cooSystem.ToStandartCoordinates(lin[i]), cooSystem.ToStandartCoordinates(lin[i + 1]));
            }

            sortPoints.Items.Clear();
            stdPoints.Items.Clear();

            for (int i = 0; i < lin.Count-1; ++i)
            {
                sortPoints.Items.Add(cooSystem.ToStandartCoordinates(lin[i]));
                stdPoints.Items.Add(lin[i].X + " " + lin[i].Y);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            sortPoints.Items.Clear();

            lin.createLinObolonka();

            foreach (PointF point in lin)
            {
                sortPoints.Items.Add(point.X + " " + point.Y);
            }

            DrawMBO();

            timer1.Start();

            //radarPanel.Visible = true;
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
            refreshData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //graphicsRadar.DrawLine(new Pen(Color.ForestGreen, 1), radar.XBegin, radar.YBegin, radar.XCoordinate, radar.YCoordinate);

            //radar.moveArrow();
        }
    }
}
