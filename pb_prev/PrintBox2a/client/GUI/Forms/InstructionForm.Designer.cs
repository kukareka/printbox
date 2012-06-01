namespace PrintBox.GUI.Forms
{
    partial class InstructionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnCloseInstruction = new System.Windows.Forms.ImageButton();
            this.pnlInstructionContainer = new System.Windows.Forms.Panel();
            this.txtInstruction = new HtmlRichText.HtmlRichTextBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseInstruction)).BeginInit();
            this.pnlInstructionContainer.SuspendLayout();
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
            this.pnlMain.Controls.Add(this.btnCloseInstruction);
            this.pnlMain.Controls.Add(this.pnlInstructionContainer);
            this.pnlMain.Location = new System.Drawing.Point(125, 9);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1004, 766);
            this.pnlMain.TabIndex = 3;
            // 
            // btnCloseInstruction
            // 
            this.btnCloseInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseInstruction.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseInstruction.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCloseInstruction.DownImage = null;
            this.btnCloseInstruction.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCloseInstruction.ForeColor = System.Drawing.Color.White;
            this.btnCloseInstruction.HoverImage = null;
            this.btnCloseInstruction.Location = new System.Drawing.Point(453, 575);
            this.btnCloseInstruction.Margin = new System.Windows.Forms.Padding(0);
            this.btnCloseInstruction.Name = "btnCloseInstruction";
            this.btnCloseInstruction.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCloseInstruction.NormalImage")));
            this.btnCloseInstruction.Size = new System.Drawing.Size(138, 78);
            this.btnCloseInstruction.TabIndex = 100;
            this.btnCloseInstruction.TabStop = false;
            this.btnCloseInstruction.Text = "Ok";
            this.btnCloseInstruction.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCloseInstruction_MouseDown);
            // 
            // pnlInstructionContainer
            // 
            this.pnlInstructionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInstructionContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlInstructionContainer.BackgroundImage")));
            this.pnlInstructionContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInstructionContainer.Controls.Add(this.txtInstruction);
            this.pnlInstructionContainer.Location = new System.Drawing.Point(32, 18);
            this.pnlInstructionContainer.Name = "pnlInstructionContainer";
            this.pnlInstructionContainer.Size = new System.Drawing.Size(940, 540);
            this.pnlInstructionContainer.TabIndex = 3;
            // 
            // txtInstruction
            // 
            this.txtInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInstruction.Location = new System.Drawing.Point(47, 111);
            this.txtInstruction.Name = "txtInstruction";
            this.txtInstruction.Size = new System.Drawing.Size(846, 411);
            this.txtInstruction.TabIndex = 1;
            this.txtInstruction.Text = "";
            this.txtInstruction.Enter += new System.EventHandler(this.txtInstruction_Enter);
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1254, 787);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InstructionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Інструкція користувача";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseInstruction)).EndInit();
            this.pnlInstructionContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInstructionContainer;
        private HtmlRichText.HtmlRichTextBox txtInstruction;
        private System.Windows.Forms.ImageButton btnCloseInstruction;
    }
}