using System;
using System.ComponentModel;
using System.Windows.Forms;
using PrintBoxMain;
using PrintBox.Logic.Wrappers;
using PrintBox.Logic;

namespace PrintBox.GUI.Forms
{
    public partial class MaintenanceForm : Form
    {
        private System.ComponentModel.ComponentResourceManager resources;

        public MaintenanceForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();
            resources = new ComponentResourceManager(typeof(MaintenanceForm));
            WinApi.ResumeDrawing(this);
        }

        public void Login()
        {
            pnlMaintenance.Visible = false;
            keyboardPassword.Reset();
            keyboardPassword.Visible = true;
            this.Activate();
        }

        private void keyboardPassword_CancelButtonClicked(object sender, EventArgs e)
        {
            PrintBoxApp.instance.guiManager.ShowAds();
        }

        private void keyboardPassword_OkButtonClicked(object sender, EventArgs e)
        {
            if (keyboardPassword.Value == PrintBoxApp.instance.config.AdminCode)
            {
                PrintBoxApp.instance.MaintenanceInProgress = true;
                keyboardPassword.Visible = false;
                pnlMaintenance.Visible = true;
            }
            else
            {
                PrintBoxApp.instance.guiManager.ShowError(ResourcesMessages.msgWrongPassword);
                keyboardPassword.Reset();
            }
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.state.PaperInside = PrintBoxApp.instance.config.MaxPaper;
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.state.BanknotesInside = 0;
            PrintBoxApp.instance.state.MoneyInside = 0;
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            lblTestResult.Text = "Перевірка...";
            Application.DoEvents();
            uint errors = PrintBoxApp.instance.DetectErrors();
            string[] errorDesc = PrintBoxApp.instance.DecodeErrors(errors);
            bool pingRes = PrintBoxApp.instance.server.SendPing();
            lblTestResult.Text = String.Format("Помилки: {0}.\r\nСервер: {1}.", 
                errorDesc.Length > 0 ? string.Join("; ", errorDesc) : "Немає",
                pingRes ? "OK" : "Disconnected");
        }

        private void Logout()
        {
            lblTestResult.Text = "";
            pnlMaintenance.Visible = false;
            keyboardPassword.Reset();
            keyboardPassword.Visible = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.server.SendMaintenance();
            Logout();
            PrintBoxApp.instance.EndMaintenance();
        }

        private void btnPrinterQueue_Click(object sender, EventArgs e)
        {
            PrintBoxApp.instance.printerWrapper.CancelAllJobs();
        }

        private void MaintenanceForm_Deactivate(object sender, EventArgs e)
        {
            Logout();
            this.Hide();
        }
    }
}
