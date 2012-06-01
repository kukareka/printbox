using System.Windows.Forms;
using PrintBoxMain;
using PrintBox.Logic.Wrappers;
using PrintBox.Logic;

namespace PrintBox.GUI.Forms
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();
            InitForm();
            AlignButtons();
            WinApi.ResumeDrawing(this);
        }

        private void InitForm()
        {
            lblBoxID.Text = ResourcesMessages.txtBoxID.Replace("<!--BoxID-->", PrintBoxApp.instance.config.BoxID.ToString());
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

        private void btnInstruction_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowInstruction();
        }

        private void btnLeave_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.EndSession();
        }

        private void btnPrintMore_MouseDown(object sender, MouseEventArgs e)
        {
            PrintBoxApp.instance.OpenFileList(null);
        }

        public void StartPrint()
        {
            btnLeave.Visible = btnPrintMore.Visible = false;
            txtPrintingInfo.Text = ResourcesMessages.txtPrintingWarning;
        }
    }
}
