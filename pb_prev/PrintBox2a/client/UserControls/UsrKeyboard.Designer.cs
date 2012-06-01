namespace PrintBoxMain.UserControls
{
    partial class KeyboardPanel
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
            this.kBtnCancel = new System.Windows.Forms.ImageButton();
            this.kBtnOk = new System.Windows.Forms.ImageButton();
            this.kBtnBackspace = new System.Windows.Forms.ImageButton();
            this.kBtn0 = new System.Windows.Forms.ImageButton();
            this.kBtn9 = new System.Windows.Forms.ImageButton();
            this.kBtn8 = new System.Windows.Forms.ImageButton();
            this.kBtn7 = new System.Windows.Forms.ImageButton();
            this.kBtn3 = new System.Windows.Forms.ImageButton();
            this.kBtn2 = new System.Windows.Forms.ImageButton();
            this.kBtn1 = new System.Windows.Forms.ImageButton();
            this.kBtn6 = new System.Windows.Forms.ImageButton();
            this.kBtn5 = new System.Windows.Forms.ImageButton();
            this.kBtn4 = new System.Windows.Forms.ImageButton();
            this.innerKeyboardPanel = new System.Windows.Forms.Panel();
            this.innerControlPanel = new System.Windows.Forms.Panel();
            this.pnlText = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.MaskedTextBox();
            this.lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtnBackspace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn4)).BeginInit();
            this.innerKeyboardPanel.SuspendLayout();
            this.innerControlPanel.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.SuspendLayout();
            // 
            // kBtnCancel
            // 
            this.kBtnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtnCancel.DownImage = null;
            this.kBtnCancel.Font = new System.Drawing.Font("Century Gothic", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtnCancel.ForeColor = System.Drawing.Color.White;
            this.kBtnCancel.HoverImage = null;
            this.kBtnCancel.Location = new System.Drawing.Point(210, 70);
            this.kBtnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.kBtnCancel.Name = "kBtnCancel";
            this.kBtnCancel.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_cancel;
            this.kBtnCancel.Size = new System.Drawing.Size(135, 65);
            this.kBtnCancel.TabIndex = 114;
            this.kBtnCancel.TabStop = false;
            this.kBtnCancel.Text = "Відміна";
            this.kBtnCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtnCancel_MouseDown);
            // 
            // kBtnOk
            // 
            this.kBtnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtnOk.DownImage = null;
            this.kBtnOk.Font = new System.Drawing.Font("Century Gothic", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtnOk.ForeColor = System.Drawing.Color.White;
            this.kBtnOk.HoverImage = null;
            this.kBtnOk.Location = new System.Drawing.Point(210, 0);
            this.kBtnOk.Margin = new System.Windows.Forms.Padding(0);
            this.kBtnOk.Name = "kBtnOk";
            this.kBtnOk.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_ok;
            this.kBtnOk.Size = new System.Drawing.Size(135, 65);
            this.kBtnOk.TabIndex = 113;
            this.kBtnOk.TabStop = false;
            this.kBtnOk.Text = "Oк";
            this.kBtnOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtnOk_MouseDown);
            // 
            // kBtnBackspace
            // 
            this.kBtnBackspace.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtnBackspace.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_back_clicked;
            this.kBtnBackspace.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtnBackspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtnBackspace.HoverImage = null;
            this.kBtnBackspace.Location = new System.Drawing.Point(279, 140);
            this.kBtnBackspace.Name = "kBtnBackspace";
            this.kBtnBackspace.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_back;
            this.kBtnBackspace.Size = new System.Drawing.Size(66, 65);
            this.kBtnBackspace.TabIndex = 112;
            this.kBtnBackspace.TabStop = false;
            this.kBtnBackspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn0
            // 
            this.kBtn0.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn0.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn0.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn0.HoverImage = null;
            this.kBtn0.Location = new System.Drawing.Point(210, 140);
            this.kBtn0.Name = "kBtn0";
            this.kBtn0.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn0.Size = new System.Drawing.Size(66, 65);
            this.kBtn0.TabIndex = 111;
            this.kBtn0.TabStop = false;
            this.kBtn0.Text = "0";
            this.kBtn0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn9
            // 
            this.kBtn9.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn9.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn9.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn9.HoverImage = null;
            this.kBtn9.Location = new System.Drawing.Point(140, 140);
            this.kBtn9.Name = "kBtn9";
            this.kBtn9.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn9.Size = new System.Drawing.Size(66, 65);
            this.kBtn9.TabIndex = 110;
            this.kBtn9.TabStop = false;
            this.kBtn9.Text = "9";
            this.kBtn9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn8
            // 
            this.kBtn8.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn8.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn8.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn8.HoverImage = null;
            this.kBtn8.Location = new System.Drawing.Point(70, 140);
            this.kBtn8.Name = "kBtn8";
            this.kBtn8.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn8.Size = new System.Drawing.Size(66, 65);
            this.kBtn8.TabIndex = 109;
            this.kBtn8.TabStop = false;
            this.kBtn8.Text = "8";
            this.kBtn8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn7
            // 
            this.kBtn7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn7.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn7.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn7.HoverImage = null;
            this.kBtn7.Location = new System.Drawing.Point(0, 140);
            this.kBtn7.Name = "kBtn7";
            this.kBtn7.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn7.Size = new System.Drawing.Size(66, 65);
            this.kBtn7.TabIndex = 108;
            this.kBtn7.TabStop = false;
            this.kBtn7.Text = "7";
            this.kBtn7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn3
            // 
            this.kBtn3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn3.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn3.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn3.HoverImage = null;
            this.kBtn3.Location = new System.Drawing.Point(140, 0);
            this.kBtn3.Name = "kBtn3";
            this.kBtn3.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn3.Size = new System.Drawing.Size(66, 65);
            this.kBtn3.TabIndex = 107;
            this.kBtn3.TabStop = false;
            this.kBtn3.Text = "3";
            this.kBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn2
            // 
            this.kBtn2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn2.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn2.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn2.HoverImage = null;
            this.kBtn2.Location = new System.Drawing.Point(70, 0);
            this.kBtn2.Name = "kBtn2";
            this.kBtn2.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn2.Size = new System.Drawing.Size(66, 65);
            this.kBtn2.TabIndex = 106;
            this.kBtn2.TabStop = false;
            this.kBtn2.Text = "2";
            this.kBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn1
            // 
            this.kBtn1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn1.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn1.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn1.HoverImage = null;
            this.kBtn1.Location = new System.Drawing.Point(0, 0);
            this.kBtn1.Name = "kBtn1";
            this.kBtn1.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn1.Size = new System.Drawing.Size(66, 65);
            this.kBtn1.TabIndex = 105;
            this.kBtn1.TabStop = false;
            this.kBtn1.Text = "1";
            this.kBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn6
            // 
            this.kBtn6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn6.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn6.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn6.HoverImage = null;
            this.kBtn6.Location = new System.Drawing.Point(140, 70);
            this.kBtn6.Name = "kBtn6";
            this.kBtn6.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn6.Size = new System.Drawing.Size(66, 65);
            this.kBtn6.TabIndex = 117;
            this.kBtn6.TabStop = false;
            this.kBtn6.Text = "6";
            this.kBtn6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn5
            // 
            this.kBtn5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn5.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn5.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn5.HoverImage = null;
            this.kBtn5.Location = new System.Drawing.Point(70, 70);
            this.kBtn5.Name = "kBtn5";
            this.kBtn5.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn5.Size = new System.Drawing.Size(66, 65);
            this.kBtn5.TabIndex = 116;
            this.kBtn5.TabStop = false;
            this.kBtn5.Text = "5";
            this.kBtn5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // kBtn4
            // 
            this.kBtn4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kBtn4.DownImage = global::PrintBoxMain.ResourcesMessages.keyboard_button_clicked;
            this.kBtn4.Font = new System.Drawing.Font("Century Gothic", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kBtn4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.kBtn4.HoverImage = null;
            this.kBtn4.Location = new System.Drawing.Point(0, 70);
            this.kBtn4.Name = "kBtn4";
            this.kBtn4.NormalImage = global::PrintBoxMain.ResourcesMessages.keyboard_button;
            this.kBtn4.Size = new System.Drawing.Size(66, 65);
            this.kBtn4.TabIndex = 115;
            this.kBtn4.TabStop = false;
            this.kBtn4.Text = "4";
            this.kBtn4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kBtn_MouseDown);
            // 
            // innerKeyboardPanel
            // 
            this.innerKeyboardPanel.BackColor = System.Drawing.Color.Transparent;
            this.innerKeyboardPanel.Controls.Add(this.kBtn6);
            this.innerKeyboardPanel.Controls.Add(this.kBtn1);
            this.innerKeyboardPanel.Controls.Add(this.kBtn5);
            this.innerKeyboardPanel.Controls.Add(this.kBtn2);
            this.innerKeyboardPanel.Controls.Add(this.kBtn4);
            this.innerKeyboardPanel.Controls.Add(this.kBtn3);
            this.innerKeyboardPanel.Controls.Add(this.kBtnCancel);
            this.innerKeyboardPanel.Controls.Add(this.kBtn7);
            this.innerKeyboardPanel.Controls.Add(this.kBtnOk);
            this.innerKeyboardPanel.Controls.Add(this.kBtn8);
            this.innerKeyboardPanel.Controls.Add(this.kBtnBackspace);
            this.innerKeyboardPanel.Controls.Add(this.kBtn9);
            this.innerKeyboardPanel.Controls.Add(this.kBtn0);
            this.innerKeyboardPanel.Location = new System.Drawing.Point(0, 90);
            this.innerKeyboardPanel.Margin = new System.Windows.Forms.Padding(0);
            this.innerKeyboardPanel.Name = "innerKeyboardPanel";
            this.innerKeyboardPanel.Size = new System.Drawing.Size(345, 205);
            this.innerKeyboardPanel.TabIndex = 118;
            // 
            // innerControlPanel
            // 
            this.innerControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.innerControlPanel.Controls.Add(this.pnlText);
            this.innerControlPanel.Controls.Add(this.innerKeyboardPanel);
            this.innerControlPanel.Controls.Add(this.lblText);
            this.innerControlPanel.Location = new System.Drawing.Point(70, 56);
            this.innerControlPanel.Name = "innerControlPanel";
            this.innerControlPanel.Size = new System.Drawing.Size(345, 295);
            this.innerControlPanel.TabIndex = 119;
            // 
            // pnlText
            // 
            this.pnlText.BackgroundImage = global::PrintBoxMain.ResourcesMessages.txt_document;
            this.pnlText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlText.Controls.Add(this.txtText);
            this.pnlText.Location = new System.Drawing.Point(0, 32);
            this.pnlText.Margin = new System.Windows.Forms.Padding(0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(345, 32);
            this.pnlText.TabIndex = 102;
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtText.Location = new System.Drawing.Point(5, 2);
            this.txtText.Margin = new System.Windows.Forms.Padding(0);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(335, 28);
            this.txtText.TabIndex = 1;
            this.txtText.Text = "+38(0";
            this.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtText.Enter += new System.EventHandler(this.txtText_Enter);
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(70)))), ((int)(((byte)(123)))));
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Margin = new System.Windows.Forms.Padding(0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(345, 32);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KeyboardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::PrintBoxMain.ResourcesMessages.keyboard_panel_fon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.innerControlPanel);
            this.DoubleBuffered = true;
            this.Name = "KeyboardPanel";
            this.Size = new System.Drawing.Size(502, 439);
            this.SizeChanged += new System.EventHandler(this.KeyboardPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.kBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtnBackspace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kBtn4)).EndInit();
            this.innerKeyboardPanel.ResumeLayout(false);
            this.innerControlPanel.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageButton kBtnCancel;
        private System.Windows.Forms.ImageButton kBtnOk;
        private System.Windows.Forms.ImageButton kBtnBackspace;
        private System.Windows.Forms.ImageButton kBtn0;
        private System.Windows.Forms.ImageButton kBtn9;
        private System.Windows.Forms.ImageButton kBtn8;
        private System.Windows.Forms.ImageButton kBtn7;
        private System.Windows.Forms.ImageButton kBtn3;
        private System.Windows.Forms.ImageButton kBtn2;
        private System.Windows.Forms.ImageButton kBtn1;
        private System.Windows.Forms.ImageButton kBtn6;
        private System.Windows.Forms.ImageButton kBtn5;
        private System.Windows.Forms.ImageButton kBtn4;
        private System.Windows.Forms.Panel innerKeyboardPanel;
        private System.Windows.Forms.Panel innerControlPanel;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.MaskedTextBox txtText;
        private System.Windows.Forms.Panel pnlText;
    }
}
