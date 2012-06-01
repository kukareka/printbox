namespace PrintBox.UserControls
{
    partial class OpenFileView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFileView));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnScrollDown = new System.Windows.Forms.ImageButton();
            this.pnlFilesList = new System.Windows.Forms.Panel();
            this.btnScrollUp = new System.Windows.Forms.ImageButton();
            this.pnlAddressLine = new System.Windows.Forms.Panel();
            this.txtAddressLine = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnUpper = new System.Windows.Forms.ImageButton();
            this.lvFiles = new PrintBox.UserControls.CustomListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScrollDown)).BeginInit();
            this.pnlFilesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScrollUp)).BeginInit();
            this.pnlAddressLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpper)).BeginInit();
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
            this.pnlMain.Controls.Add(this.btnScrollDown);
            this.pnlMain.Controls.Add(this.pnlFilesList);
            this.pnlMain.Controls.Add(this.btnScrollUp);
            this.pnlMain.Controls.Add(this.pnlAddressLine);
            this.pnlMain.Controls.Add(this.lblAddress);
            this.pnlMain.Controls.Add(this.btnUpper);
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(915, 811);
            this.pnlMain.TabIndex = 25;
            // 
            // btnScrollDown
            // 
            this.btnScrollDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollDown.BackColor = System.Drawing.Color.Transparent;
            this.btnScrollDown.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScrollDown.DownImage = ((System.Drawing.Image)(resources.GetObject("btnScrollDown.DownImage")));
            this.btnScrollDown.HoverImage = null;
            this.btnScrollDown.Location = new System.Drawing.Point(823, 618);
            this.btnScrollDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnScrollDown.Name = "btnScrollDown";
            this.btnScrollDown.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnScrollDown.NormalImage")));
            this.btnScrollDown.Size = new System.Drawing.Size(78, 78);
            this.btnScrollDown.TabIndex = 94;
            this.btnScrollDown.TabStop = false;
            this.btnScrollDown.Visible = false;
            this.btnScrollDown.Click += new System.EventHandler(this.btnScrollDown_Click);
            // 
            // pnlFilesList
            // 
            this.pnlFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilesList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFilesList.BackgroundImage")));
            this.pnlFilesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFilesList.Controls.Add(this.lvFiles);
            this.pnlFilesList.Location = new System.Drawing.Point(19, 128);
            this.pnlFilesList.Name = "pnlFilesList";
            this.pnlFilesList.Size = new System.Drawing.Size(788, 568);
            this.pnlFilesList.TabIndex = 22;
            // 
            // btnScrollUp
            // 
            this.btnScrollUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrollUp.BackColor = System.Drawing.Color.Transparent;
            this.btnScrollUp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScrollUp.DownImage = ((System.Drawing.Image)(resources.GetObject("btnScrollUp.DownImage")));
            this.btnScrollUp.HoverImage = null;
            this.btnScrollUp.Location = new System.Drawing.Point(823, 128);
            this.btnScrollUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnScrollUp.Name = "btnScrollUp";
            this.btnScrollUp.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnScrollUp.NormalImage")));
            this.btnScrollUp.Size = new System.Drawing.Size(78, 78);
            this.btnScrollUp.TabIndex = 93;
            this.btnScrollUp.TabStop = false;
            this.btnScrollUp.Visible = false;
            this.btnScrollUp.Click += new System.EventHandler(this.btnScrollUp_Click);
            // 
            // pnlAddressLine
            // 
            this.pnlAddressLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddressLine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAddressLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAddressLine.BackgroundImage")));
            this.pnlAddressLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAddressLine.Controls.Add(this.txtAddressLine);
            this.pnlAddressLine.Location = new System.Drawing.Point(144, 59);
            this.pnlAddressLine.Name = "pnlAddressLine";
            this.pnlAddressLine.Size = new System.Drawing.Size(490, 36);
            this.pnlAddressLine.TabIndex = 21;
            // 
            // txtAddressLine
            // 
            this.txtAddressLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressLine.AutoSize = true;
            this.txtAddressLine.BackColor = System.Drawing.Color.Transparent;
            this.txtAddressLine.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAddressLine.Location = new System.Drawing.Point(3, 3);
            this.txtAddressLine.Margin = new System.Windows.Forms.Padding(3);
            this.txtAddressLine.Name = "txtAddressLine";
            this.txtAddressLine.Size = new System.Drawing.Size(53, 30);
            this.txtAddressLine.TabIndex = 14;
            this.txtAddressLine.Text = "D:\\";
            this.txtAddressLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAddress.Location = new System.Drawing.Point(13, 60);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(131, 38);
            this.lblAddress.TabIndex = 20;
            this.lblAddress.Text = "Адреса: ";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpper
            // 
            this.btnUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpper.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpper.DownImage = null;
            this.btnUpper.HoverImage = null;
            this.btnUpper.Location = new System.Drawing.Point(654, 34);
            this.btnUpper.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpper.Name = "btnUpper";
            this.btnUpper.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnUpper.NormalImage")));
            this.btnUpper.Size = new System.Drawing.Size(153, 64);
            this.btnUpper.TabIndex = 18;
            this.btnUpper.TabStop = false;
            this.btnUpper.Click += new System.EventHandler(this.btnUpper_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvFiles.LargeImageList = this.imgList;
            this.lvFiles.Location = new System.Drawing.Point(3, 3);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(782, 562);
            this.lvFiles.TabIndex = 16;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.Layout += new System.Windows.Forms.LayoutEventHandler(this.lvFiles_Layout);
            this.lvFiles.ListSelectionChanged += new System.EventHandler<PrintBox.UserControls.CustomListViewSelectionChangedEventArgs>(this.lvFiles_ListSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 320;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "folder_open.png");
            this.imgList.Images.SetKeyName(1, "word.ico");
            this.imgList.Images.SetKeyName(2, "acrobat.png");
            // 
            // OpenFileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "OpenFileView";
            this.Size = new System.Drawing.Size(925, 821);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnScrollDown)).EndInit();
            this.pnlFilesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnScrollUp)).EndInit();
            this.pnlAddressLine.ResumeLayout(false);
            this.pnlAddressLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ImageButton btnScrollDown;
        private System.Windows.Forms.Panel pnlFilesList;
        private PrintBox.UserControls.CustomListView lvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageButton btnScrollUp;
        private System.Windows.Forms.Panel pnlAddressLine;
        private System.Windows.Forms.Label txtAddressLine;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ImageButton btnUpper;
        private System.Windows.Forms.ImageList imgList;
    }
}
