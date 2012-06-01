using System.Drawing;
using System.Windows.Forms;
using log4net;
using PrintBox.GUI.Forms;
using System;
using PrintBox.Logic;
using System.Threading;

namespace PrintBox.GUI
{
    public class GUIManager
    {
        private ILog log = LogManager.GetLogger(typeof(GUIManager));
        
        private LoadingForm loadingForm;
        private MessageForm messageForm;        
        private InstructionForm instructionForm;
        private MaintenanceForm maintenanceForm;

        private ControlForm controlForm;

        private PB_MainFrm mainFrm;

        public void Run()
        {
            log.Debug("Up and running");
            if (!PrintBoxApp.instance.runOptions.showCursor) Cursor.Hide();
            ShowAds();
            System.Windows.Forms.Application.Run(mainFrm);
        }

        #region Form tools
        public void InitForm(Form form)
        {
            if (PrintBoxApp.instance.runOptions.fullScreen)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.ControlBox = form.MinimizeBox = false;
                form.TopMost = PrintBoxApp.instance.runOptions.topMost;
                form.Width = 1280;
                form.Height = 1024;
                form.Top = form.Left = 0;
            }
        }

        private void ActivateForm(Form form)
        {
            Application.DoEvents();
            form.Show();
            form.BringToFront();
            form.Activate();
            Application.DoEvents();
        }

        #endregion

        #region Init
        public GUIManager()
        {
            log.Debug("Initializing forms");
            InitForms();
        }

        private void InitForms()
        {
            loadingForm = new LoadingForm();
            messageForm = new MessageForm();
            InitForm(instructionForm = new InstructionForm());
            InitForm(maintenanceForm = new MaintenanceForm());
            InitForm(mainFrm = new PB_MainFrm());
            mainFrm.Width = 1280;
            mainFrm.Height = 1024;

            Application.DoEvents();
            loadingForm.Hide();
            messageForm.Hide();
            instructionForm.Hide();
            maintenanceForm.Hide();

            /*
            InitForm(adsForm = new AdsForm());            
            InitForm(documentChooseForm = new DocumentChooseForm());
            //InitForm(prePrintForm = new PrePrintForm());
            InitForm(printForm = new PrintForm());
            */

            if (PrintBoxApp.instance.runOptions.testMode)
            {
                controlForm = new ControlForm();
                controlForm.Show();
            }
        }
        #endregion

        #region Steps

        public void ShowAds()
        {
            mainFrm.ShowAds();
            ActivateForm(mainFrm);
        }

        public void ShowDirectory(string path)
        {
            mainFrm.ShowDirectory(path);
        }

        public void EmbedWord(int wordWnd)
        {
            mainFrm.EmbedWord(wordWnd);
        }

        public void ShowDocument()
        {
            log.Debug("set window pos");
            mainFrm.ShowDocument();
            PrintBoxApp.instance.sessionInfo.documentWrapper.Show();

            for (int i = 0; i < 5; ++i)
            {
                Thread.Sleep(100);
                System.Windows.Forms.Application.DoEvents();
                ActivateForm(mainFrm);
            }
        }

        public void StartPrint()
        {
            mainFrm.StartPrint();
            ActivateForm(mainFrm);
        }

        public void PrintDone(bool success, bool flashEjectedWhilePrinting)
        {
            mainFrm.PrintDone(success, flashEjectedWhilePrinting);
        }

        public void StartLoading()
        {
            ActivateForm(loadingForm);
        }

        public void EndLoading()
        {
            ActivateForm(mainFrm);
        }

        public void ShowInstruction()
        {
            log.DebugFormat("Show instruction");
            instructionForm.Owner = mainFrm;
            ActivateForm(instructionForm);
        }

        public void ShowMaintenance()
        {
            ActivateForm(maintenanceForm);
        }
        #endregion        

        #region Callbacks

        public void RefreshMoney()
        {
            mainFrm.RefreshMoney();
        }

        public void EnableCashCode(bool value)
        {
            controlForm.CashCodeEnabled = value;
        }
        #endregion

        #region Messages
        public void ShowMessage(Color color, string msg, params string[] list)
        {
            if (!messageForm.Visible)
            {
                Application.DoEvents();
                messageForm.SetMessage(color, String.Format(msg, list));
                messageForm.Show();
                messageForm.BringToFront();
                messageForm.Activate();
                Application.DoEvents();
            }
        }

        public void ShowMessage(string msg, params string[] list)
        {
            log.DebugFormat(msg, list);
            ShowMessage(Color.Black, msg, list);
        }

        public void ShowError(string msg, params string[] list)
        {
            log.ErrorFormat(msg, list);
            ShowMessage(Color.Red, msg, list);
        }
        #endregion

        public IntPtr GetMainFormHandle()
        {
            return mainFrm.Handle;
        }
    }
}
