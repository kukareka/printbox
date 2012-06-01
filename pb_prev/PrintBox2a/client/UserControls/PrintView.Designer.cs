﻿namespace PrintBoxMain.UserControls
{
    partial class PrintView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintView));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnPrintMore = new System.Windows.Forms.ImageButton();
            this.btnLeave = new System.Windows.Forms.ImageButton();
            this.txtPrintingInfo = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeave)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.btnPrintMore);
            this.pnlMain.Controls.Add(this.btnLeave);
            this.pnlMain.Controls.Add(this.txtPrintingInfo);
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(970, 691);
            this.pnlMain.TabIndex = 3;
            // 
            // btnPrintMore
            // 
            this.btnPrintMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintMore.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintMore.DownImage = null;
            this.btnPrintMore.HoverImage = null;
            this.btnPrintMore.Location = new System.Drawing.Point(466, 397);
            this.btnPrintMore.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintMore.Name = "btnPrintMore";
            this.btnPrintMore.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnPrintMore.NormalImage")));
            this.btnPrintMore.Size = new System.Drawing.Size(259, 79);
            this.btnPrintMore.TabIndex = 19;
            this.btnPrintMore.TabStop = false;
            this.btnPrintMore.Click += new System.EventHandler(this.btnPrintMore_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLeave.DownImage = null;
            this.btnLeave.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLeave.ForeColor = System.Drawing.Color.White;
            this.btnLeave.HoverImage = null;
            this.btnLeave.Location = new System.Drawing.Point(245, 397);
            this.btnLeave.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnLeave.NormalImage")));
            this.btnLeave.Size = new System.Drawing.Size(171, 79);
            this.btnLeave.TabIndex = 18;
            this.btnLeave.TabStop = false;
            this.btnLeave.Text = "Вихід";
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // txtPrintingInfo
            // 
            this.txtPrintingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrintingInfo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrintingInfo.ForeColor = System.Drawing.Color.Red;
            this.txtPrintingInfo.Location = new System.Drawing.Point(43, 245);
            this.txtPrintingInfo.Name = "txtPrintingInfo";
            this.txtPrintingInfo.Size = new System.Drawing.Size(900, 100);
            this.txtPrintingInfo.TabIndex = 14;
            this.txtPrintingInfo.Text = "Іде друк. Не витягуйте флешку.";
            this.txtPrintingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "PrintView";
            this.Size = new System.Drawing.Size(980, 701);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ImageButton btnPrintMore;
        private System.Windows.Forms.ImageButton btnLeave;
        private System.Windows.Forms.Label txtPrintingInfo;
    }
}