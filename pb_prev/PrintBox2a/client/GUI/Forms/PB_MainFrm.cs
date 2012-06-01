using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using PrintBox.Logic.Wrappers;

namespace PrintBox.GUI.Forms
{
    public partial class PB_MainFrm : Form
    {
        public ILog log = LogManager.GetLogger(typeof(PB_MainFrm));

        List<UserControl> views = new List<UserControl>();
        public PB_MainFrm()
        {            
            InitializeComponent();           
            LoadParams();
            LoadParamTags();
            PrintBoxApp.instance.state.OnStateChanged += UpdatePaperInside;
            UpdatePaperInside();
            InitViews();
        }

        private void LoadParams()
        {
            lblBoxID.Text = String.Format(lblBoxID.Text, PrintBoxApp.instance.config.BoxID.ToString());
        }

        private void LoadParamTags()
        {
            lblPagesLeft.Tag = lblPagesLeft.Text;
        }

        private void UpdatePaperInside()
        {
            string txt = String.Format((string)lblPagesLeft.Tag, PrintBoxApp.instance.state.PaperInside.ToString());
            if (txt != lblPagesLeft.Text) lblPagesLeft.Text = txt;
        }

        private void InitViews()
        {
            InitView(adsView);
            InitView(openFileView);
            InitView(docView);
            InitView(printView);
        }

        private void InitView(UserControl view)
        {
            this.views.Add(view);
            view.Left = 9;
            view.Top = 0;
            view.Width = this.Width;
            view.Height = this.Height;
        }

        private void ShowView(UserControl view)
        {
            view.Show();
            foreach (UserControl v in this.views) if (v != view) v.Hide();            
        }

        public void ShowAds()
        {
            ShowView(adsView);
        }

        public void ShowDirectory(string path)
        {
            try
            {
                if (openFileView.OpenDirectory(path)) ShowView(openFileView);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void ShowDocument()
        {
            docView.LoadDocument();
            ShowView(docView);
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowInstruction();
        }

        private void lblBoxID_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowMaintenance();
        }

        public void EmbedWord(int wordWnd)
        {
            docView.Invoke(docView.ExecEmbedWordWindow, wordWnd);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinApi.WM_DEVICECHANGE) PrintBoxApp.instance.ProcessMessage(m);
            base.WndProc(ref m);
        }

        public void RefreshMoney()
        {
            docView.RefreshMoney();
        }

        public void StartPrint()
        {
            printView.StartPrint();
            ShowView(printView);
        }

        internal void PrintDone(bool success, bool flashEjectedWhilePrinting)
        {
            printView.PrintDone(success, flashEjectedWhilePrinting);
        }
    }
}
