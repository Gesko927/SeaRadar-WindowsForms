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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.stdPoints = new System.Windows.Forms.ListBox();
            this.sortPoints = new System.Windows.Forms.ListBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radarOff = new System.Windows.Forms.Button();
            this.radarOn = new System.Windows.Forms.Button();
            this.paintBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(102, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(712, 596);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.Controls.Add(this.trackBar1);
            this.rightPanel.Controls.Add(this.stdPoints);
            this.rightPanel.Controls.Add(this.sortPoints);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(814, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(2);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(171, 596);
            this.rightPanel.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(38, 539);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // stdPoints
            // 
            this.stdPoints.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdPoints.FormattingEnabled = true;
            this.stdPoints.ItemHeight = 21;
            this.stdPoints.Location = new System.Drawing.Point(4, 121);
            this.stdPoints.Name = "stdPoints";
            this.stdPoints.Size = new System.Drawing.Size(155, 109);
            this.stdPoints.TabIndex = 1;
            // 
            // sortPoints
            // 
            this.sortPoints.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortPoints.FormattingEnabled = true;
            this.sortPoints.ItemHeight = 22;
            this.sortPoints.Location = new System.Drawing.Point(3, 354);
            this.sortPoints.Name = "sortPoints";
            this.sortPoints.Size = new System.Drawing.Size(156, 92);
            this.sortPoints.TabIndex = 2;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftPanel.Controls.Add(this.button2);
            this.leftPanel.Controls.Add(this.button1);
            this.leftPanel.Controls.Add(this.radarOff);
            this.leftPanel.Controls.Add(this.radarOn);
            this.leftPanel.Controls.Add(this.paintBtn);
            this.leftPanel.Controls.Add(this.startBtn);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(102, 596);
            this.leftPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radarOff
            // 
            this.radarOff.Location = new System.Drawing.Point(12, 104);
            this.radarOff.Name = "radarOff";
            this.radarOff.Size = new System.Drawing.Size(75, 45);
            this.radarOff.TabIndex = 6;
            this.radarOff.Text = "Stop Scanning";
            this.radarOff.UseVisualStyleBackColor = true;
            this.radarOff.Click += new System.EventHandler(this.radarOff_Click);
            // 
            // radarOn
            // 
            this.radarOn.Location = new System.Drawing.Point(12, 35);
            this.radarOn.Name = "radarOn";
            this.radarOn.Size = new System.Drawing.Size(75, 46);
            this.radarOn.TabIndex = 5;
            this.radarOn.Text = "Start Scanning";
            this.radarOn.UseVisualStyleBackColor = true;
            this.radarOn.Click += new System.EventHandler(this.radarOn_Click);
            // 
            // paintBtn
            // 
            this.paintBtn.Font = new System.Drawing.Font("BERNIER Shade", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paintBtn.Location = new System.Drawing.Point(3, 435);
            this.paintBtn.Margin = new System.Windows.Forms.Padding(2);
            this.paintBtn.Name = "paintBtn";
            this.paintBtn.Size = new System.Drawing.Size(94, 70);
            this.paintBtn.TabIndex = 4;
            this.paintBtn.Text = "REFRESH";
            this.paintBtn.UseVisualStyleBackColor = true;
            this.paintBtn.Click += new System.EventHandler(this.paint_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("BERNIER Shade", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(5, 344);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(94, 72);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.start_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 596);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Linear MBO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private ExtendedPanel radarPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.ListBox stdPoints;
        private System.Windows.Forms.ListBox sortPoints;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button paintBtn;
        public System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button radarOff;
        private System.Windows.Forms.Button radarOn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

