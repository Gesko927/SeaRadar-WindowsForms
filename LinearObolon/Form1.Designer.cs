namespace LinearObolon
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.stdPoints = new System.Windows.Forms.ListBox();
            this.sortPoints = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radarOff = new System.Windows.Forms.Button();
            this.radarOn = new System.Windows.Forms.Button();
            this.paintBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(136, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 734);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.stdPoints);
            this.panel3.Controls.Add(this.sortPoints);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1085, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 734);
            this.panel3.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(51, 663);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(139, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // stdPoints
            // 
            this.stdPoints.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdPoints.FormattingEnabled = true;
            this.stdPoints.ItemHeight = 17;
            this.stdPoints.Location = new System.Drawing.Point(5, 149);
            this.stdPoints.Margin = new System.Windows.Forms.Padding(4);
            this.stdPoints.Name = "stdPoints";
            this.stdPoints.Size = new System.Drawing.Size(205, 174);
            this.stdPoints.TabIndex = 1;
            // 
            // sortPoints
            // 
            this.sortPoints.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortPoints.FormattingEnabled = true;
            this.sortPoints.ItemHeight = 18;
            this.sortPoints.Location = new System.Drawing.Point(4, 436);
            this.sortPoints.Margin = new System.Windows.Forms.Padding(4);
            this.sortPoints.Name = "sortPoints";
            this.sortPoints.Size = new System.Drawing.Size(207, 166);
            this.sortPoints.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radarOff);
            this.panel2.Controls.Add(this.radarOn);
            this.panel2.Controls.Add(this.paintBtn);
            this.panel2.Controls.Add(this.startBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(136, 734);
            this.panel2.TabIndex = 0;
            // 
            // radarOff
            // 
            this.radarOff.Location = new System.Drawing.Point(16, 128);
            this.radarOff.Margin = new System.Windows.Forms.Padding(4);
            this.radarOff.Name = "radarOff";
            this.radarOff.Size = new System.Drawing.Size(100, 55);
            this.radarOff.TabIndex = 6;
            this.radarOff.Text = "Stop Scanning";
            this.radarOff.UseVisualStyleBackColor = true;
            this.radarOff.Click += new System.EventHandler(this.radarOff_Click);
            // 
            // radarOn
            // 
            this.radarOn.Location = new System.Drawing.Point(16, 43);
            this.radarOn.Margin = new System.Windows.Forms.Padding(4);
            this.radarOn.Name = "radarOn";
            this.radarOn.Size = new System.Drawing.Size(100, 56);
            this.radarOn.TabIndex = 5;
            this.radarOn.Text = "Start Scanning";
            this.radarOn.UseVisualStyleBackColor = true;
            this.radarOn.Click += new System.EventHandler(this.radarOn_Click);
            // 
            // paintBtn
            // 
            this.paintBtn.Font = new System.Drawing.Font("BERNIER Shade", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paintBtn.Location = new System.Drawing.Point(4, 535);
            this.paintBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paintBtn.Name = "paintBtn";
            this.paintBtn.Size = new System.Drawing.Size(125, 86);
            this.paintBtn.TabIndex = 4;
            this.paintBtn.Text = "REFRESH";
            this.paintBtn.UseVisualStyleBackColor = true;
            this.paintBtn.Click += new System.EventHandler(this.paint_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("BERNIER Shade", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(7, 424);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(125, 89);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 734);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Linear MBO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private ExtendedPanel radarPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox stdPoints;
        private System.Windows.Forms.ListBox sortPoints;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button paintBtn;
        public System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button radarOff;
        private System.Windows.Forms.Button radarOn;
    }
}

