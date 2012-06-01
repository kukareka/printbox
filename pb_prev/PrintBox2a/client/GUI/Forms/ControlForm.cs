using System;
using System.Windows.Forms;
using TermoPrinterLib;
using PrintBoxMain;
using PrintBox.Logic;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Text;
using System.Threading;

namespace PrintBox.GUI.Forms
{
    public partial class ControlForm : Form
    {
        private bool _cashCodeEnabled = false;
        public bool CashCodeEnabled { 
            get { return _cashCodeEnabled; }
            set { _cashCodeEnabled = pnlCashCode.Enabled = value; }
        }
        public ControlForm()
        {
            InitializeComponent();
            if (PrintBoxApp.instance.runOptions.topMost) TopMost = true;
        }

        private void buttonLoadTestDoc_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.LoadDocument(@"d:\blank.doc");
        }

        private void btn1uah_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.MoneyIn(1);
        }

        private void btn10uah_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.MoneyIn(10);
        }

        private void buttonOpenDrive_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.DriveIn(@"D:\");
        }

        private void buttonSendPing_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendPing();
        }

        private void buttonSend10uah_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendMoneyIn(textUser.Text, 10);
        }

        private void buttonLogin1_Click(object sender, EventArgs e)
        {
            string pwd = null;
            bool newUser = false;
            float balance = 0;
            PrintBoxApp.instance.server.ReceiveAuthData(textUser.Text, ref pwd, ref newUser, ref balance);
            textPwd.Text = pwd;
            checkNewUser.Checked = newUser;
            textBalance.Text = balance.ToString("F2");
        }

        private void buttonSend10pages_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendSession(textUser.Text, 10, 0, 1);
        }

        private void buttonFixErrors_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendErrors(Errors.ERROR_NONE);
        }

        private void buttonJamPaper_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendErrors(Errors.ERROR_PRINTER_PAPER_JAM);
        }

        private void buttonShowInstruction_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowInstruction();
        }

        private void buttonMessage_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowMessage("Сообщение");
        }

        private void buttonError_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowError("Ошибка");
        }

        private void buttonFixJam_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendErrors(Errors.ERROR_NONE);
        }

        private void buttonFixNoPaper_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendErrors(Errors.ERROR_NONE);
        }

        private void buttonNoPaper_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendErrors(Errors.ERROR_PRINTER_NO_PAPER);
        }

        private void buttonCloseDrive_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.DriveOut();
        }

        private void buttonPrinterStatus_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.printerWrapper.Update();
            textPrinterStatus.Text = String.Format("{0}/{1}", PrintBoxApp.instance.printerWrapper.Status.ToString(),
                    PrintBoxApp.instance.printerWrapper.StatusText);
            textPrinterPages.Text = String.Format("{0}", PrintBoxApp.instance.printerWrapper.PagesPrinted);
            textPrinterToner.Text = String.Format("{0}%", PrintBoxApp.instance.printerWrapper.TonerRemaining);
        }

        private void buttonCashcodeReset_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.cashCode.Reset();
        }

        private void buttonCashcodeEnable_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = true;
            
        }

        private void buttonCashCodeDisable_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.CashCodeEnabled = false;
        }

        private void buttonPoll_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.cashCodeWrapper.cashCode.Poll();
            string newState = PrintBoxApp.instance.cashCodeWrapper.cashCode.CurrentState.ToString();
            if (newState != textCashCodeStatus.Text) textCashCodeStatus.Text = newState;
        }

        private void buttonThermoStatus_Click(object sender, EventArgs e)
        {
            textThermoStatus.Text = PrintBoxApp.instance.thermalWrapper.thermalPrinter.GetPrinterStatus().ToString();
        }

        private void buttonThermoTest_Click(object sender, EventArgs e)
        {
            TermoPrinter printer = PrintBoxApp.instance.thermalWrapper.thermalPrinter;
            printer.Font = 1;
            printer.Bold = false;
            printer.Align = TermoPrinterLib.TextAlign.Center;
            printer.WriteLine("Центр");
            printer.Bold = true;
            printer.WriteLine("Центр bold");
            printer.WriteLine("");
            printer.Bold = false;
            printer.Align = TermoPrinterLib.TextAlign.Left;
            printer.WriteLine("Лево");
            printer.Align = TermoPrinterLib.TextAlign.Right;
            printer.WriteLine("Право");
            printer.Skip(200);
            printer.Cut();
        }

        private void buttonMaintenance_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.BeginMaintenance();
        }

        private void buttonCustomTest_Click(object sender, EventArgs e)
        {
            int i = 0;
            
            int j = 1 / i;
        }

        private void buttonPrintErrorCheck_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.sessionInfo = new SessionInfo();
            PrintBoxApp.instance.sessionInfo.userPhone = "380222222222";
            PrintBoxApp.instance.sessionInfo.moneyInSession = 2;
            PrintBoxApp.instance.sessionInfo.userMoney = 201.5F;
            PrintBoxApp.instance.thermalWrapper.PrintErrorCheck();
        }

        private void textTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint realCode = PrintBoxApp.instance.thermalWrapper.CalculateErrorCode(textPhone.Text, textTime.Text, textTerminal.Text, textError.Text, textMoneyIn.Text, textBalanceA.Text);
            if (realCode.ToString() == textCode.Text) MessageBox.Show("Правильно");
            else MessageBox.Show("Неправильно");
        }

        private void buttonLoadPDF_Click(object sender, EventArgs e)
        {
            pdfReader.setShowToolbar(false);
            pdfReader.setShowScrollbars(false);
            pdfReader.setLayoutMode("SinglePage");
            pdfReader.setPageMode("none");
            pdfReader.LoadFile("d:\\blank.pdf");
            pdfReader.Show();
            
        }

        private void buttonTrySSL_Click(object sender, EventArgs e)
        {
            string password = "qwer86xdeF1ew!";
            X509Certificate2 cert =
                new X509Certificate2("client.pfx", password);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest request =
                //(HttpWebRequest)WebRequest.Create("https://www.verisign.com/");
                (HttpWebRequest)WebRequest.Create("https://aws2.2stat.com/t11.php");
            request.ClientCertificates.Add(cert);
            request.Timeout = 2000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        private void buttonPrinterCancelJob_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.printerWrapper.CancelAllJobs();
        }

        private void btnHang_Click(object sender, EventArgs e)
        {
            Thread.Sleep(30000);
        }

        private void btnHideTaskbar_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.HideTaskBar();
        }

        private void btnMinus10pages_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.state.PaperInside -= 10;
        }

    }
}

