using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrintBox;

namespace PrintBoxMain.UserControls
{
    public partial class PrintView : UserControl
    {
        public PrintView()
        {
            InitializeComponent();
            AlignButtons();
        }

        private void AlignButtons()
        {
            if (btnPrintMore.Visible)
            {
                int space = 50;
                int blockWidth = btnLeave.Width + btnPrintMore.Width + space;
                int blockStart = (btnLeave.Parent.Width - blockWidth) / 2;
                btnLeave.Left = blockStart;
                btnPrintMore.Left = blockStart + btnLeave.Width + space;
            }
            else
            {
                btnLeave.Left = (btnLeave.Parent.Width - btnLeave.Width) / 2;
            }
        }

        public void PrintDone(bool success, bool flashEjected)
        {
            btnLeave.Visible = true;
            if (!success)
            {
                txtPrintingInfo.Text = ResourcesMessages.txtPrintError + "\r\n" + ResourcesMessages.txtMoneyReturnedToBalance;
            }
            else
            {
                txtPrintingInfo.Text = ResourcesMessages.txtPrintSuccess + "\r\n" + ResourcesMessages.txtThanksForUsingPrintBox;
                if (!flashEjected) btnPrintMore.Visible = true;
            }
            AlignButtons();
        }

        public void StartPrint()
        {
            btnLeave.Visible = btnPrintMore.Visible = false;
            txtPrintingInfo.Text = ResourcesMessages.txtPrintingWarning;
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.EndSession();
        }

        private void btnPrintMore_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.OpenFileList(null);
        }
    }
}
