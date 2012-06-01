namespace PrintBox.GUI.Forms
{
    partial class PB_MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PB_MainFrm));
            this.btnInstruction = new System.Windows.Forms.ImageButton();
            this.lblBoxID = new System.Windows.Forms.Label();
            this.lblPagesLeft = new System.Windows.Forms.Label();
            this.lblSupportPhone = new System.Windows.Forms.Label();
            this.printView = new PrintBoxMain.UserControls.PrintView();
            this.docView = new PrintBoxMain.UserControls.DocView();
            this.openFileView = new PrintBox.UserControls.OpenFileView();
            this.adsView = new PrintBox.UserControls.AdsView();
            ((System.ComponentModel.ISupportInitialize)(this.btnInstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInstruction
            // 
            this.btnInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstruction.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnInstruction.DownImage = null;
            this.btnInstruction.HoverImage = null;
            this.btnInstruction.Location = new System.Drawing.Point(1176, 20);
            this.btnInstruction.Margin = new System.Windows.Forms.Padding(0);
            this.btnInstruction.Name = "btnInstruction";
            this.btnInstruction.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnInstruction.NormalImage")));
            this.btnInstruction.Size = new System.Drawing.Size(64, 84);
            this.btnInstruction.TabIndex = 8;
            this.btnInstruction.TabStop = false;
            this.btnInstruction.Click += new System.EventHandler(this.btnInstruction_Click);
            // 
            // lblBoxID
            // 
            this.lblBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBoxID.BackColor = System.Drawing.Color.White;
            this.lblBoxID.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBoxID.Location = new System.Drawing.Point(21, 931);
            this.lblBoxID.Name = "lblBoxID";
            this.lblBoxID.Size = new System.Drawing.Size(195, 42);
            this.lblBoxID.TabIndex = 10;
            this.lblBoxID.Text = "Термінал: {0}";
            this.lblBoxID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblBoxID.Click += new System.EventHandler(this.lblBoxID_Click);
            // 
            // lblPagesLeft
            // 
            this.lblPagesLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPagesLeft.BackColor = System.Drawing.Color.White;
            this.lblPagesLeft.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPagesLeft.Location = new System.Drawing.Point(1003, 945);
            this.lblPagesLeft.Name = "lblPagesLeft";
            this.lblPagesLeft.Size = new System.Drawing.Size(250, 28);
            this.lblPagesLeft.TabIndex = 11;
            this.lblPagesLeft.Text = "Сторінок у лотку: {0}";
            this.lblPagesLeft.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblSupportPhone
            // 
            this.lblSupportPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupportPhone.BackColor = System.Drawing.Color.White;
            this.lblSupportPhone.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSupportPhone.Location = new System.Drawing.Point(428, 955);
            this.lblSupportPhone.Name = "lblSupportPhone";
            this.lblSupportPhone.Size = new System.Drawing.Size(409, 18);
            this.lblSupportPhone.TabIndex = 10;
            this.lblSupportPhone.Text = "В разі виникнення проблем будь-ласка зателефонуйте (067) 238-24-96";
            this.lblSupportPhone.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSupportPhone.Click += new System.EventHandler(this.lblBoxID_Click);
            // 
            // printView
            // 
            this.printView.BackColor = System.Drawing.Color.White;
            this.printView.Location = new System.Drawing.Point(493, 43);
            this.printView.Name = "printView";
            this.printView.Size = new System.Drawing.Size(808, 558);
            this.printView.TabIndex = 14;
            // 
            // docView
            // 
            this.docView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.docView.Location = new System.Drawing.Point(683, 82);
            this.docView.Name = "docView";
            this.docView.Size = new System.Drawing.Size(715, 474);
            this.docView.TabIndex = 13;
            // 
            // openFileView
            // 
            this.openFileView.Location = new System.Drawing.Point(324, 338);
            this.openFileView.Name = "openFileView";
            this.openFileView.Size = new System.Drawing.Size(707, 575);
            this.openFileView.TabIndex = 12;
            // 
            // adsView
            // 
            this.adsView.BackColor = System.Drawing.Color.White;
            this.adsView.Location = new System.Drawing.Point(172, 0);
            this.adsView.Margin = new System.Windows.Forms.Padding(0);
            this.adsView.Name = "adsView";
            this.adsView.Size = new System.Drawing.Size(1108, 837);
            this.adsView.TabIndex = 0;
            // 
            // PB_MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 988);
            this.Controls.Add(this.btnInstruction);
            this.Controls.Add(this.printView);
            this.Controls.Add(this.docView);
            this.Controls.Add(this.openFileView);
            this.Controls.Add(this.lblPagesLeft);
            this.Controls.Add(this.lblSupportPhone);
            this.Controls.Add(this.lblBoxID);
            this.Controls.Add(this.adsView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PB_MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PB_MainFrm";
            ((System.ComponentModel.ISupportInitialize)(this.btnInstruction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PrintBox.UserControls.AdsView adsView;
        private System.Windows.Forms.ImageButton btnInstruction;
        private System.Windows.Forms.Label lblBoxID;
        private System.Windows.Forms.Label lblPagesLeft;
        private PrintBox.UserControls.OpenFileView openFileView;
        private PrintBoxMain.UserControls.DocView docView;
        private PrintBoxMain.UserControls.PrintView printView;
        private System.Windows.Forms.Label lblSupportPhone;
    }
}