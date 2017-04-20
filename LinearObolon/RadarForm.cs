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
    public partial class RadarForm : Form
    {
        private Form form;
        private Radar radar;
        private Graphics graphics;
        private Panel panel;

        public RadarForm()
        {
            InitializeComponent();
        }

        public RadarForm(Panel panel, Form mainForm)
        {
            form = mainForm;
            this.panel = panel;
            InitializeComponent();

            this.ClientSize = panel.ClientSize;
            this.Location = new Point(panel.Location.X + mainForm.Location.X + 8, panel.Location.Y + mainForm.Location.Y + 30);
            this.TransparencyKey = this.BackColor;

            panel1.Location = panel.Location;
            panel1.Size = panel.ClientSize;


            radar = new Radar(panel1);

            graphics = panel.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

            for (int i = 0; i < 15; ++i)
            {
                radar.MoveArrow();
                graphics.DrawLine(new Pen(Color.ForestGreen, 2), radar.XBegin, radar.YBegin, radar.XCoordinate, radar.YCoordinate);
            }

        }

        public void StartTimer()
        {
            timer1.Start();
        }

        public void StopTimer()
        {
            timer1.Stop();
        }

        public void Relocate()
        {
            this.Location = new Point(panel.Location.X + form.Location.X + 8, panel.Location.Y + form.Location.Y + 30);
            this.BringToFront();
        }
    }
}
