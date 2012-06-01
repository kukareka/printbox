using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using log4net;
using PrintBox.GUI;
using PrintBox.Logic.Wrappers;
using PrintBox.Logic;
using PrintBoxMain;
using System.Diagnostics;

namespace PrintBox
{
    public class PrintBoxApp
    {
        public ILog log = LogManager.GetLogger(typeof(PrintBoxApp));

        public static PrintBoxApp instance;

        public Config config = Config.Load();
        public State state = new State();
        public RunOptions runOptions;
        
        public PrinterWrapper printerWrapper = new PrinterWrapper();
        public ThermalWrapper thermalWrapper;
        public CashCodeWrapper cashCodeWrapper;
        public UsbWrapper usbWrapper;
        public FormatManager formatManager = new FormatManager();
        public WordWrapper wordWrapper = new WordWrapper();
        public PdfWrapper pdfWrapper = new PdfWrapper();

        public PrintOptions printOptions = new PrintOptions();
        public SessionInfo sessionInfo = null;
        public GUIManager guiManager;
        public Server server;

        public Tools tools = new Tools();
        public ExceptionHandler exceptionHandler;

        private System.Windows.Forms.Timer appTimer = new System.Windows.Forms.Timer();

        private bool _maintenanceInProgress = false;
        public bool MaintenanceInProgress
        {
            get { lock (this) { return _maintenanceInProgress; } }
            set { lock (this) { _maintenanceInProgress = value; } }
        }

        private bool printInProgress = false;
        private bool flashEjectedWhilePrinting = false;

        public static void CreateInstance(string[] commandLine)
        {
            instance = new PrintBoxApp(commandLine);
            instance.Init();
        }

        public PrintBoxApp(string[] commandLine)
        {
            runOptions = new RunOptions(commandLine);            
        }

        public void Init()
        {
            exceptionHandler = new ExceptionHandler();
            thermalWrapper = new ThermalWrapper();
            cashCodeWrapper = new CashCodeWrapper();
            state = State.Load();
            server = new Server();
            guiManager = new GUIManager();
        }

        public void Run()
        {
            log.Info("Run");

            appTimer.Tick += new EventHandler(appTimer_Tick);
            appTimer.Interval = 100;
            appTimer.Enabled = true;
            usbWrapper = new UsbWrapper();

            guiManager.Run();

            usbWrapper.Stop();            
            server.Stop();
        }

        void appTimer_Tick(object sender, EventArgs e)
        {
            if (config.HideTaskBar) HideTaskBar();
            cashCodeWrapper.Tick();
            usbWrapper.Tick();
        }

        public void HideTaskBar()
        {
            int wnd = WinApi.FindWindow("Shell_TrayWnd", "");
            WinApi.ShowWindow(wnd, WinApi.SW_HIDE);
        }
        
        public void LoadDocument(string filePath)
        {
            log.DebugFormat("Load document {0}", filePath);
            if (!File.Exists(filePath)) return;
            guiManager.StartLoading();
            System.Windows.Forms.Application.DoEvents();
            StringBuilder shortFileName = new StringBuilder(255);
            WinApi.GetShortPathName(filePath, shortFileName, shortFileName.Capacity);
            if (shortFileName.Length == 0)
            {
                guiManager.ShowError(ResourcesMessages.msgTooLongFileName);
                return;
            }

            log.Debug("Creating session");
            sessionInfo = new SessionInfo();
            sessionInfo.shortDocPath = shortFileName.ToString();
            sessionInfo.longDocPath = filePath;
            sessionInfo.docName = Path.GetFileName(filePath);

            try
            {
                sessionInfo.documentWrapper = formatManager.LoadDocument();
                if (sessionInfo.documentWrapper != null) guiManager.ShowDocument();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                guiManager.EndLoading();
            }            
        }

        public void MoneyIn(int money)
        {
            log.DebugFormat("Money in: {0}", money);
            guiManager.StartLoading();
            if (sessionInfo != null)
            {
                sessionInfo.userMoney += money;
                sessionInfo.moneyInSession += money;
                sessionInfo.banknotesInSession++;
                server.SendMoneyIn(sessionInfo.userPhone, money);
            }
            state.MoneyInside += money;
            state.BanknotesInside++;
            guiManager.RefreshMoney();
            guiManager.EndLoading();
        }

        public void PrintDoc()
        {
            log.Debug("Print started");
            guiManager.StartPrint();
            Application.DoEvents();
            printInProgress = true;
            flashEjectedWhilePrinting = false;

            printerWrapper.UpdatePages();
            string userId = sessionInfo.userPhone;
            int pagesInPrinterBeforePrint = printerWrapper.PagesPrinted;
            log.DebugFormat("Printer counter: {0}", pagesInPrinterBeforePrint);
            int pagesToPrint = printOptions.pagesToPrint;
            log.DebugFormat("Pages to print: {0}", pagesToPrint);
            int moneyInSession = sessionInfo.moneyInSession;
            log.DebugFormat("Money in session: {0}", moneyInSession);
            int banknotesInSession = sessionInfo.banknotesInSession;
            log.DebugFormat("Banknotes in session: {0}", banknotesInSession);
            int pagesPrinted = 0;
            bool success = false;
            log.DebugFormat("Paper inside: {0}", state.PaperInside);
            log.DebugFormat("Print range: {0}-{1}x{2}", printOptions.from, printOptions.to, printOptions.copies);            

            try
            {
                if (!printerWrapper.OK()) throw new Exception(printerWrapper.StatusText);
                log.DebugFormat("printer OK");

                state.PaperInside -= pagesToPrint;

                sessionInfo.documentWrapper.PrintDocument();

                DateTime printStartTime = DateTime.Now;
                for (;;)
                {
                    Thread.Sleep(200);
                    System.Windows.Forms.Application.DoEvents();
                    printerWrapper.Update();                    
                    if (printerWrapper.PagesPrinted >= pagesInPrinterBeforePrint + pagesToPrint)
                    {
                        break;
                    }
                    if (!printerWrapper.OK())
                    {
                        throw new Exception(printerWrapper.StatusText);
                    }
                    if (printStartTime.AddMinutes(2).AddSeconds(10 * pagesToPrint) < DateTime.Now) // макс. 2 минуты на прогрев + 10 сек на страницу
                    {
                        throw new Exception("timeout");
                    }
                }
                pagesPrinted = pagesToPrint;
                log.Debug("print ok");
                success = true;                
            }
            catch (Exception e)
            {
                log.Error(e);
                thermalWrapper.PrintErrorCheck();                
            }

            log.Debug("Print done");
            guiManager.PrintDone(success, flashEjectedWhilePrinting);
            log.DebugFormat("Send session {0} {1} {2} {3}", userId, pagesPrinted, moneyInSession, banknotesInSession);
            server.SendSession(userId, pagesPrinted, moneyInSession, banknotesInSession);
            EndSession();
            printInProgress = false;
            flashEjectedWhilePrinting = false;
        }

        public void EndSession()
        {
            log.Debug("End session");
            if (!printInProgress) guiManager.ShowAds();
            if ((sessionInfo != null) && (sessionInfo.documentWrapper != null)) sessionInfo.documentWrapper.CloseDocument();
            sessionInfo = null;                        
        }

        public void OpenFileList(string path)
        {
            log.DebugFormat("Open file list {0}", path);
            if (path == null)
            {
                if (usbWrapper.currentDrive != null) path = usbWrapper.currentDrive;
                else return;
            }

            if (Directory.Exists(path))
            {
                guiManager.ShowDirectory(path);
            }
        }

        public void ProcessMessage(Message m)
        {
            usbWrapper.ProcessMessage(m);
        }

        public void DriveIn(string driveLetter)
        {
            log.DebugFormat("Drive in: {0}", driveLetter);
            usbWrapper.currentDrive = driveLetter;
            if (printInProgress) return;
            if (state.PaperInside <= 0)
            {
                guiManager.ShowError(ResourcesMessages.msgNoPaper);
                return;
            }
            if (!runOptions.testMode)
            {
                if (0 != DetectErrors())
                {
                    guiManager.ShowError(ResourcesMessages.msgTerminalIsNotWorking);
                    return;
                }
            }
            EndSession();
            OpenFileList(driveLetter);
        }

        public void DriveOut()
        {
            if (printInProgress)
            {
                flashEjectedWhilePrinting = true;
            }
            else
            {
                guiManager.ShowAds();
                EndSession();
            }
        }

        public void BeginMaintenance()
        {
            guiManager.ShowMaintenance();
        }

        public void EndMaintenance()
        {
            MaintenanceInProgress = false;
            guiManager.ShowAds();
        }

        public string[] DecodeErrors(uint errors)
        {
            LinkedList<string> ret = new LinkedList<string>();
            Type errorTypes = typeof(Errors);
            FieldInfo [] fields = errorTypes.GetFields();
            foreach (FieldInfo fi in fields)
            {
                string name = fi.Name;
                uint value = (uint)fi.GetValue(null);
                if ((errors & value) != 0)
                {
                    ret.AddLast(name);
                    errors ^= value;
                }
            }
            if (errors != 0) ret.AddLast("Інші помилки");
            return ret.ToArray();
        }


        public uint DetectErrors()
        {
            uint errors = 0;

            errors |= printerWrapper.DetectErrors();
            errors |= thermalWrapper.DetectErrors();

            if (PowerSource.IsOnBattery()) errors |= Errors.ERROR_BATTERY_POWER;

            return errors;

        }
    }
}
