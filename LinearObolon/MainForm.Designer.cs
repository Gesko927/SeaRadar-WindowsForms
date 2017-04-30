namespace ConvexHullScanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTrackBar = new System.Windows.Forms.TrackBar();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.refreshAllInfoBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.buildMBOBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.stopMoveShipBtn = new Bunifu.Framework.UI.BunifuTileButton();
            this.startMoveShipsBtn = new Bunifu.Framework.UI.BunifuTileButton();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.turnOffRadarBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.turnOnRadarBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.stdPoints = new System.Windows.Forms.ListBox();
            this.sortPoints = new System.Windows.Forms.ListBox();
            this.shipTimer = new System.Windows.Forms.Timer(this.components);
            this.metroScrollBar1 = new MetroFramework.Controls.MetroScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.mainTrackBar)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshAllInfoBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildMBOBtn)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnOffRadarBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnOnRadarBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.mainPanel.Location = new System.Drawing.Point(191, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(871, 734);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseClick);
            // 
            // mainTrackBar
            // 
            this.mainTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTrackBar.Location = new System.Drawing.Point(57, 566);
            this.mainTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.mainTrackBar.Maximum = 9;
            this.mainTrackBar.Name = "mainTrackBar";
            this.mainTrackBar.Size = new System.Drawing.Size(139, 45);
            this.mainTrackBar.TabIndex = 3;
            this.mainTrackBar.Value = 1;
            this.mainTrackBar.Scroll += new System.EventHandler(this.mainTrackBar_Scroll);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftPanel.Controls.Add(this.refreshAllInfoBtn);
            this.leftPanel.Controls.Add(this.buildMBOBtn);
            this.leftPanel.Controls.Add(this.stopMoveShipBtn);
            this.leftPanel.Controls.Add(this.startMoveShipsBtn);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(191, 734);
            this.leftPanel.TabIndex = 0;
            // 
            // refreshAllInfoBtn
            // 
            this.refreshAllInfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshAllInfoBtn.BackColor = System.Drawing.Color.Transparent;
            this.refreshAllInfoBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshAllInfoBtn.Image")));
            this.refreshAllInfoBtn.ImageActive = null;
            this.refreshAllInfoBtn.Location = new System.Drawing.Point(46, 593);
            this.refreshAllInfoBtn.Name = "refreshAllInfoBtn";
            this.refreshAllInfoBtn.Size = new System.Drawing.Size(95, 90);
            this.refreshAllInfoBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.refreshAllInfoBtn.TabIndex = 10;
            this.refreshAllInfoBtn.TabStop = false;
            this.refreshAllInfoBtn.Zoom = 10;
            this.refreshAllInfoBtn.Click += new System.EventHandler(this.refreshAllInfoBtn_Click);
            // 
            // buildMBOBtn
            // 
            this.buildMBOBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buildMBOBtn.BackColor = System.Drawing.Color.Transparent;
            this.buildMBOBtn.Image = ((System.Drawing.Image)(resources.GetObject("buildMBOBtn.Image")));
            this.buildMBOBtn.ImageActive = null;
            this.buildMBOBtn.Location = new System.Drawing.Point(46, 465);
            this.buildMBOBtn.Name = "buildMBOBtn";
            this.buildMBOBtn.Size = new System.Drawing.Size(95, 90);
            this.buildMBOBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buildMBOBtn.TabIndex = 9;
            this.buildMBOBtn.TabStop = false;
            this.buildMBOBtn.Zoom = 10;
            this.buildMBOBtn.Click += new System.EventHandler(this.buildMBOBtn_Click);
            // 
            // stopMoveShipBtn
            // 
            this.stopMoveShipBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.stopMoveShipBtn.color = System.Drawing.Color.DodgerBlue;
            this.stopMoveShipBtn.colorActive = System.Drawing.Color.MediumBlue;
            this.stopMoveShipBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopMoveShipBtn.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.stopMoveShipBtn.ForeColor = System.Drawing.Color.White;
            this.stopMoveShipBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopMoveShipBtn.Image")));
            this.stopMoveShipBtn.ImagePosition = 20;
            this.stopMoveShipBtn.ImageZoom = 50;
            this.stopMoveShipBtn.LabelPosition = 41;
            this.stopMoveShipBtn.LabelText = "Stop";
            this.stopMoveShipBtn.Location = new System.Drawing.Point(12, 216);
            this.stopMoveShipBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.stopMoveShipBtn.Name = "stopMoveShipBtn";
            this.stopMoveShipBtn.Size = new System.Drawing.Size(159, 144);
            this.stopMoveShipBtn.TabIndex = 8;
            this.stopMoveShipBtn.Click += new System.EventHandler(this.stopMoveShipBtn_Click);
            // 
            // startMoveShipsBtn
            // 
            this.startMoveShipsBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.startMoveShipsBtn.color = System.Drawing.Color.DodgerBlue;
            this.startMoveShipsBtn.colorActive = System.Drawing.Color.MediumBlue;
            this.startMoveShipsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startMoveShipsBtn.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.startMoveShipsBtn.ForeColor = System.Drawing.Color.White;
            this.startMoveShipsBtn.Image = ((System.Drawing.Image)(resources.GetObject("startMoveShipsBtn.Image")));
            this.startMoveShipsBtn.ImagePosition = 20;
            this.startMoveShipsBtn.ImageZoom = 50;
            this.startMoveShipsBtn.LabelPosition = 41;
            this.startMoveShipsBtn.LabelText = "Start";
            this.startMoveShipsBtn.Location = new System.Drawing.Point(12, 16);
            this.startMoveShipsBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.startMoveShipsBtn.Name = "startMoveShipsBtn";
            this.startMoveShipsBtn.Size = new System.Drawing.Size(159, 151);
            this.startMoveShipsBtn.TabIndex = 7;
            this.startMoveShipsBtn.Click += new System.EventHandler(this.startMoveShipsBtn_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.Controls.Add(this.mainTrackBar);
            this.rightPanel.Controls.Add(this.turnOffRadarBtn);
            this.rightPanel.Controls.Add(this.turnOnRadarBtn);
            this.rightPanel.Controls.Add(this.stdPoints);
            this.rightPanel.Controls.Add(this.sortPoints);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(1057, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(256, 734);
            this.rightPanel.TabIndex = 3;
            // 
            // turnOffRadarBtn
            // 
            this.turnOffRadarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.turnOffRadarBtn.BackColor = System.Drawing.Color.Transparent;
            this.turnOffRadarBtn.Image = ((System.Drawing.Image)(resources.GetObject("turnOffRadarBtn.Image")));
            this.turnOffRadarBtn.ImageActive = null;
            this.turnOffRadarBtn.Location = new System.Drawing.Point(93, 628);
            this.turnOffRadarBtn.Name = "turnOffRadarBtn";
            this.turnOffRadarBtn.Size = new System.Drawing.Size(68, 76);
            this.turnOffRadarBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.turnOffRadarBtn.TabIndex = 12;
            this.turnOffRadarBtn.TabStop = false;
            this.turnOffRadarBtn.Zoom = 10;
            this.turnOffRadarBtn.Click += new System.EventHandler(this.turnOffRadarBtn_Click);
            // 
            // turnOnRadarBtn
            // 
            this.turnOnRadarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.turnOnRadarBtn.BackColor = System.Drawing.Color.Transparent;
            this.turnOnRadarBtn.Image = ((System.Drawing.Image)(resources.GetObject("turnOnRadarBtn.Image")));
            this.turnOnRadarBtn.ImageActive = null;
            this.turnOnRadarBtn.Location = new System.Drawing.Point(39, 367);
            this.turnOnRadarBtn.Name = "turnOnRadarBtn";
            this.turnOnRadarBtn.Size = new System.Drawing.Size(169, 162);
            this.turnOnRadarBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.turnOnRadarBtn.TabIndex = 11;
            this.turnOnRadarBtn.TabStop = false;
            this.turnOnRadarBtn.Zoom = 10;
            this.turnOnRadarBtn.Click += new System.EventHandler(this.turnOnRadarBtn_Click);
            // 
            // stdPoints
            // 
            this.stdPoints.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdPoints.FormattingEnabled = true;
            this.stdPoints.ItemHeight = 17;
            this.stdPoints.Location = new System.Drawing.Point(12, 43);
            this.stdPoints.Margin = new System.Windows.Forms.Padding(4);
            this.stdPoints.Name = "stdPoints";
            this.stdPoints.Size = new System.Drawing.Size(227, 157);
            this.stdPoints.TabIndex = 1;
            // 
            // sortPoints
            // 
            this.sortPoints.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortPoints.FormattingEnabled = true;
            this.sortPoints.ItemHeight = 18;
            this.sortPoints.Location = new System.Drawing.Point(12, 208);
            this.sortPoints.Margin = new System.Windows.Forms.Padding(4);
            this.sortPoints.Name = "sortPoints";
            this.sortPoints.Size = new System.Drawing.Size(227, 130);
            this.sortPoints.TabIndex = 2;
            // 
            // shipTimer
            // 
            this.shipTimer.Interval = 50;
            this.shipTimer.Tick += new System.EventHandler(this.shipTimer_Tick);
            // 
            // metroScrollBar1
            // 
            this.metroScrollBar1.LargeChange = 10;
            this.metroScrollBar1.Location = new System.Drawing.Point(902, -17);
            this.metroScrollBar1.Maximum = 100;
            this.metroScrollBar1.Minimum = 0;
            this.metroScrollBar1.MouseWheelBarPartitions = 10;
            this.metroScrollBar1.Name = "metroScrollBar1";
            this.metroScrollBar1.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.metroScrollBar1.ScrollbarSize = 10;
            this.metroScrollBar1.Size = new System.Drawing.Size(10, 200);
            this.metroScrollBar1.TabIndex = 0;
            this.metroScrollBar1.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 734);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linear MBO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mainTrackBar)).EndInit();
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshAllInfoBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildMBOBtn)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnOffRadarBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnOnRadarBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private ExtendedPanel radarPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.ListBox stdPoints;
        private System.Windows.Forms.ListBox sortPoints;
        public System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TrackBar mainTrackBar;
        private System.Windows.Forms.Timer shipTimer;
        private Bunifu.Framework.UI.BunifuTileButton startMoveShipsBtn;
        private Bunifu.Framework.UI.BunifuTileButton stopMoveShipBtn;
        private Bunifu.Framework.UI.BunifuImageButton refreshAllInfoBtn;
        private Bunifu.Framework.UI.BunifuImageButton buildMBOBtn;
        private Bunifu.Framework.UI.BunifuImageButton turnOffRadarBtn;
        private Bunifu.Framework.UI.BunifuImageButton turnOnRadarBtn;
        private MetroFramework.Controls.MetroScrollBar metroScrollBar1;
    }
}

