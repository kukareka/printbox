namespace PrintBox.GUI.Forms
{
    partial class MaintenanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceForm));
            this.pnlMaintenance = new System.Windows.Forms.Panel();
            this.btnTestAll = new System.Windows.Forms.ImageButton();
            this.btnMoney = new System.Windows.Forms.ImageButton();
            this.btnQuit = new System.Windows.Forms.ImageButton();
            this.btnPrinterQueue = new System.Windows.Forms.ImageButton();
            this.btnPaper = new System.Windows.Forms.ImageButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.keyboardPassword = new PrintBox.UserControls.KeyboardPanel();
            this.pnlMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTestAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrinterQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaper)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaintenance
            // 
            this.pnlMaintenance.BackColor = System.Drawing.Color.Transparent;
            this.pnlMaintenance.Controls.Add(this.lblTestResult);
            this.pnlMaintenance.Controls.Add(this.btnTestAll);
            this.pnlMaintenance.Controls.Add(this.btnMoney);
            this.pnlMaintenance.Controls.Add(this.btnQuit);
            this.pnlMaintenance.Controls.Add(this.btnPrinterQueue);
            this.pnlMaintenance.Controls.Add(this.btnPaper);
            this.pnlMaintenance.Location = new System.Drawing.Point(140, 25);
            this.pnlMaintenance.Name = "pnlMaintenance";
            this.pnlMaintenance.Size = new System.Drawing.Size(633, 660);
            this.pnlMaintenance.TabIndex = 24;
            this.pnlMaintenance.Visible = false;
            // 
            // btnTestAll
            // 
            this.btnTestAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTestAll.DownImage = null;
            this.btnTestAll.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTestAll.ForeColor = System.Drawing.Color.White;
            this.btnTestAll.HoverImage = null;
            this.btnTestAll.Location = new System.Drawing.Point(222, 233);
            this.btnTestAll.Name = "btnTestAll";
            this.btnTestAll.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnTestAll.NormalImage")));
            this.btnTestAll.Size = new System.Drawing.Size(138, 77);
            this.btnTestAll.TabIndex = 105;
            this.btnTestAll.TabStop = false;
            this.btnTestAll.Text = "Тест";
            this.btnTestAll.Click += new System.EventHandler(this.btnTestAll_Click);
            // 
            // btnMoney
            // 
            this.btnMoney.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMoney.DownImage = null;
            this.btnMoney.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMoney.ForeColor = System.Drawing.Color.White;
            this.btnMoney.HoverImage = null;
            this.btnMoney.Location = new System.Drawing.Point(52, 233);
            this.btnMoney.Name = "btnMoney";
            this.btnMoney.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnMoney.NormalImage")));
            this.btnMoney.Size = new System.Drawing.Size(138, 77);
            this.btnMoney.TabIndex = 105;
            this.btnMoney.TabStop = false;
            this.btnMoney.Text = "Гроші";
            this.btnMoney.Click += new System.EventHandler(this.btnMoney_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuit.DownImage = null;
            this.btnQuit.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.HoverImage = null;
            this.btnQuit.Location = new System.Drawing.Point(52, 354);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.NormalImage")));
            this.btnQuit.Size = new System.Drawing.Size(138, 77);
            this.btnQuit.TabIndex = 104;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "Вихід";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnPrinterQueue
            // 
            this.btnPrinterQueue.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrinterQueue.DownImage = null;
            this.btnPrinterQueue.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrinterQueue.ForeColor = System.Drawing.Color.White;
            this.btnPrinterQueue.HoverImage = null;
            this.btnPrinterQueue.Location = new System.Drawing.Point(222, 112);
            this.btnPrinterQueue.Name = "btnPrinterQueue";
            this.btnPrinterQueue.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnPrinterQueue.NormalImage")));
            this.btnPrinterQueue.Size = new System.Drawing.Size(138, 77);
            this.btnPrinterQueue.TabIndex = 104;
            this.btnPrinterQueue.TabStop = false;
            this.btnPrinterQueue.Text = "Черга";
            this.btnPrinterQueue.Click += new System.EventHandler(this.btnPrinterQueue_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPaper.DownImage = null;
            this.btnPaper.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPaper.ForeColor = System.Drawing.Color.White;
            this.btnPaper.HoverImage = null;
            this.btnPaper.Location = new System.Drawing.Point(52, 112);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnPaper.NormalImage")));
            this.btnPaper.Size = new System.Drawing.Size(138, 77);
            this.btnPaper.TabIndex = 104;
            this.btnPaper.TabStop = false;
            this.btnPaper.Text = "Папір";
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.keyboardPassword);
            this.pnlMain.Controls.Add(this.pnlMaintenance);
            this.pnlMain.Location = new System.Drawing.Point(190, 7);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 760);
            this.pnlMain.TabIndex = 108;
            // 
            // lblTestResult
            // 
            this.lblTestResult.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTestResult.Location = new System.Drawing.Point(82, 486);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(469, 139);
            this.lblTestResult.TabIndex = 106;
            this.lblTestResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyboardPassword
            // 
            this.keyboardPassword.BackColor = System.Drawing.Color.Transparent;
            this.keyboardPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyboardPassword.BackgroundImage")));
            this.keyboardPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.keyboardPassword.LabelText = "Код доступу:";
            this.keyboardPassword.Location = new System.Drawing.Point(250, 220);
            this.keyboardPassword.Name = "keyboardPassword";
            this.keyboardPassword.Size = new System.Drawing.Size(400, 322);
            this.keyboardPassword.TabIndex = 117;
            this.keyboardPassword.TextBoxMaxLength = 6;
            this.keyboardPassword.CancelButtonClicked += new PrintBox.UserControls.KeyboardPanel.CancelButtonHandler(this.keyboardPassword_CancelButtonClicked);
            this.keyboardPassword.OkButtonClicked += new PrintBox.UserControls.KeyboardPanel.OkButtonHandler(this.keyboardPassword_OkButtonClicked);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1280, 775);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MaintenanceForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Deactivate += new System.EventHandler(this.MaintenanceForm_Deactivate);
            this.pnlMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnTestAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrinterQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaper)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaintenance;
        private System.Windows.Forms.ImageButton btnTestAll;
        private System.Windows.Forms.ImageButton btnMoney;
        private System.Windows.Forms.ImageButton btnPaper;
        private System.Windows.Forms.Panel pnlMain;
        private PrintBox.UserControls.KeyboardPanel keyboardPassword;
        private System.Windows.Forms.ImageButton btnQuit;
        private System.Windows.Forms.ImageButton btnPrinterQueue;
        private System.Windows.Forms.Label lblTestResult;

    }
}