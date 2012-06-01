namespace PrintBox.UserControls
{
    partial class AdsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdsView));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblStartWorkTooltip = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.pbLargeLogo = new System.Windows.Forms.PictureBox();
            this.lblFormats = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLargeLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.lblStartWorkTooltip);
            this.pnlMain.Controls.Add(this.lblLine2);
            this.pnlMain.Controls.Add(this.lblLine1);
            this.pnlMain.Controls.Add(this.pbLargeLogo);
            this.pnlMain.Controls.Add(this.lblFormats);
            this.pnlMain.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(915, 668);
            this.pnlMain.TabIndex = 12;
            // 
            // lblStartWorkTooltip
            // 
            this.lblStartWorkTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartWorkTooltip.BackColor = System.Drawing.Color.Transparent;
            this.lblStartWorkTooltip.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStartWorkTooltip.Location = new System.Drawing.Point(0, 586);
            this.lblStartWorkTooltip.Name = "lblStartWorkTooltip";
            this.lblStartWorkTooltip.Size = new System.Drawing.Size(915, 25);
            this.lblStartWorkTooltip.TabIndex = 13;
            this.lblStartWorkTooltip.Text = "Для початку роботи вставте флешку в USB-порт";
            this.lblStartWorkTooltip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine2
            // 
            this.lblLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine2.BackColor = System.Drawing.Color.Transparent;
            this.lblLine2.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(37)))), ((int)(((byte)(29)))));
            this.lblLine2.Location = new System.Drawing.Point(0, 500);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(915, 56);
            this.lblLine2.TabIndex = 12;
            this.lblLine2.Text = "{0} коп./стор.";
            this.lblLine2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLine1
            // 
            this.lblLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine1.BackColor = System.Drawing.Color.Transparent;
            this.lblLine1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(37)))), ((int)(((byte)(29)))));
            this.lblLine1.Location = new System.Drawing.Point(0, 437);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(915, 56);
            this.lblLine1.TabIndex = 11;
            this.lblLine1.Text = "Друк формату А4";
            this.lblLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbLargeLogo
            // 
            this.pbLargeLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLargeLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLargeLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLargeLogo.BackgroundImage")));
            this.pbLargeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLargeLogo.Location = new System.Drawing.Point(110, 105);
            this.pbLargeLogo.Name = "pbLargeLogo";
            this.pbLargeLogo.Size = new System.Drawing.Size(695, 358);
            this.pbLargeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLargeLogo.TabIndex = 8;
            this.pbLargeLogo.TabStop = false;
            // 
            // lblFormats
            // 
            this.lblFormats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormats.BackColor = System.Drawing.Color.Transparent;
            this.lblFormats.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFormats.Location = new System.Drawing.Point(0, 633);
            this.lblFormats.Name = "lblFormats";
            this.lblFormats.Size = new System.Drawing.Size(915, 25);
            this.lblFormats.TabIndex = 13;
            this.lblFormats.Text = "Підтримуються формати файлів DOC, DOCX, PDF, RTF";
            this.lblFormats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "AdsView";
            this.Size = new System.Drawing.Size(925, 678);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLargeLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblStartWorkTooltip;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.PictureBox pbLargeLogo;
        private System.Windows.Forms.Label lblFormats;



    }
}
