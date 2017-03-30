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
            //this.radarPanel = new LinearObolon.ExtendedPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.stdPoints = new System.Windows.Forms.ListBox();
            this.sortPoints = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.paintBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            //this.panel1.Controls.Add(this.radarPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(100, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 596);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // radarPanel
            // 
            //this.radarPanel.BackColor = System.Drawing.Color.Transparent;
            //this.radarPanel.Location = new System.Drawing.Point(67, 52);
            //this.radarPanel.Name = "radarPanel";
            //this.radarPanel.Opacity = 25;
            //this.radarPanel.Size = new System.Drawing.Size(714, 596);
            //this.radarPanel.TabIndex = 0;
            //this.radarPanel.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.stdPoints);
            this.panel3.Controls.Add(this.sortPoints);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(814, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(171, 596);
            this.panel3.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(38, 539);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // stdPoints
            // 
            this.stdPoints.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdPoints.FormattingEnabled = true;
            this.stdPoints.ItemHeight = 17;
            this.stdPoints.Location = new System.Drawing.Point(4, 121);
            this.stdPoints.Name = "stdPoints";
            this.stdPoints.Size = new System.Drawing.Size(155, 157);
            this.stdPoints.TabIndex = 1;
            // 
            // sortPoints
            // 
            this.sortPoints.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortPoints.FormattingEnabled = true;
            this.sortPoints.ItemHeight = 18;
            this.sortPoints.Location = new System.Drawing.Point(3, 354);
            this.sortPoints.Name = "sortPoints";
            this.sortPoints.Size = new System.Drawing.Size(156, 148);
            this.sortPoints.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.paintBtn);
            this.panel2.Controls.Add(this.startBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 596);
            this.panel2.TabIndex = 0;
            // 
            // paintBtn
            // 
            this.paintBtn.Font = new System.Drawing.Font("BERNIER Shade", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paintBtn.Location = new System.Drawing.Point(3, 323);
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
            this.startBtn.Location = new System.Drawing.Point(3, 206);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(94, 72);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "Linear MBO";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
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
    }
}

