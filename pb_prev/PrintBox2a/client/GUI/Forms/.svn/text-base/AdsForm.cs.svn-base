using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using PrintBoxMain;
using PrintBox.Logic;
using PrintBox.Logic.Wrappers;

namespace PrintBox.GUI.Forms
{
    public partial class AdsForm : Form
    {
        public AdsForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {            
            lblBoxID.Text = ResourcesMessages.txtBoxID.Replace("<!--BoxID-->", PrintBoxApp.instance.config.BoxID.ToString());
            lblLine2.Text = String.Format(lblLine2.Text, PrintBoxApp.instance.config.PageCost);
            SetCleanPaperLeftText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetCleanPaperLeftText()
        {
            lblPagesLeft.Text = ResourcesMessages.txtCleanPaperLeft.Replace("<!--paperLeft-->", PrintBoxApp.instance.state.PaperInside.ToString());
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinApi.WM_DEVICECHANGE) PrintBoxApp.instance.ProcessMessage(m);
            base.WndProc(ref m);
        }

        private void btnInstruction_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowInstruction();
        }

        private void lblBoxID_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.BeginMaintenance();
        }

        private void AdsForm_Activated(object sender, EventArgs e)
        {
            SetCleanPaperLeftText();
        }
    }
}
