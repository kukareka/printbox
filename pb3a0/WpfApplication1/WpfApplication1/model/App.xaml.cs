using System;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Input;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RoutedCommand RemindPassword = new RoutedCommand();

        public SessionInfo sessionInfo = new SessionInfo();
        public GuiManager guiManager;

        public Config config { get; set; }
        public State state { get; set; }
        public Server server;

        public IPrinterWrapper printerWrapper = new TestPrinterWrapper();
        public ICashcodeWrapper cashcodeWrapper = new TestCashCodeWrapper();
        public IReceiptWrapper receiptWrapper = new TestReceiptWrapper();
        public UsbWrapper usbWrapper;

        public XpsWrapper xpsWrapper = new XpsWrapper();
        public ITicker[] tickers;
        public DispatcherTimer dispatcherTimer;
        public RemoteControlServer remoteControlServer = new RemoteControlServer();
        public ErrorManager errorManager = new ErrorManager();

        public bool onService { get; set; }

        public App()
        {
            InitializeComponent();

            config = Config.Load();
            state = State.Load();
            server = new Server();
            usbWrapper = new UsbWrapper();

            guiManager = new GuiManager();
            tickers = new ITicker[] { printerWrapper, cashcodeWrapper };

            cashcodeWrapper.OnMoneyIn += new EventHandler(Cashcode_MoneyIn);
            printerWrapper.OnPrintDone += new EventHandler(printerWrapper_OnPrintDone);
            usbWrapper.OnDriveIn += new EventHandler(Usb_DriveIn);
            usbWrapper.OnDriveOut += new EventHandler(Usb_DriveOut);

            remoteControlServer.Start();
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Background, new EventHandler(Tick), App.Current.Dispatcher);
        }

        public void Tick(Object sender, EventArgs e)
        {
            foreach (ITicker t in tickers) t.Tick();
        }

        public void LoadDocument(string documentPath)
        {
            sessionInfo = new SessionInfo();
            MainWindow.DataContext = sessionInfo;

            guiManager.Loading(true);

            sessionInfo.documentInfo.documentPath = documentPath;

            if (sessionInfo.documentInfo.xpsDocument != null)
            {
                sessionInfo.documentInfo.xpsDocument.Close();
            }

            if (xpsWrapper.ConvertToXPS(sessionInfo.documentInfo.documentPath))
            {
                sessionInfo.documentInfo.xpsDocument = new XpsDocument(sessionInfo.documentInfo.xpsDocumentPath, System.IO.FileAccess.Read);
                sessionInfo.documentInfo.CurrentPage = 0;
                (MainWindow as MainWindow).LoadDocument();
            }

            guiManager.Loading(false);
        }

        public void OpenFolder(string folder)
        {
            (MainWindow as MainWindow).ShowFolder(folder);
        }

        public void AuthAndPrint()
        {
            if (Auth()) Print();
        }

        public bool Auth()
        {
            string ph;
            sessionInfo.userInfo.Phone = null;
            if (null != (ph = guiManager.Prompt("Мобільний телефон", (FlowDocument)FindResource("commentEnterPhone"), new PhoneNumberConverter(), 10)))
            {
                guiManager.Loading(true);
                sessionInfo.userInfo.Phone = ph;
                if (sessionInfo.userInfo.isNewUser) guiManager.Alert("На вказаний номер було відправлено SMS із кодом доступу до особистого рахунку." + 
                    " Збережіть його в надійному місці. Цей код знадобиться Вам при кожному наступному користуванні PrintBox.");
                string pwd;
                while (null != (pwd = guiManager.Prompt("Код доступу", (FlowDocument)FindResource("commentEnterPassword"), new PasswordConverter(), 7)))
                {
                    if (!sessionInfo.userInfo.IsValidPassword(pwd)) guiManager.Alert("Invalid password");
                    else
                    {
                        MoneyDialog d = new MoneyDialog(MainWindow);
                        if ((bool)guiManager.ShowDialog(d))
                        {
                            Print();
                        }
                        d.Close();
                        break;
                    }
                }
            }
            return false;
        }

        public void Print()
        {
            if (sessionInfo.userInfo.BalanceAfterPrint < 0) return;
            PrintingDialog d = new PrintingDialog(MainWindow);
            state.PaperInside -= sessionInfo.printOptions.SheetsToPrint;
            printerWrapper.Print();
            bool r = (bool)guiManager.ShowDialog(d);
            d.Close();
            if (sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Done)
            {
                if (r) (MainWindow as MainWindow).ShowWelcomeTab();
                else (MainWindow as MainWindow).ShowFolder();
            }
            else
            {
                guiManager.Alert("Во время печати произошла ошибка. Деньги возвращены на баланс.");
                (MainWindow as MainWindow).ShowWelcomeTab();
            }                
        }

        public void Cashcode_MoneyIn(object sender, EventArgs e)
        {
            MoneyInEventArgs m = e as MoneyInEventArgs;
            sessionInfo.userInfo.Balance += m.balance * 100;
            sessionInfo.userInfo.totalMoneyIn += m.balance;
            state.MoneyInside += m.balance;
            ++state.BanknotesInside;
            ++sessionInfo.userInfo.totalBanknotesIn;
            guiManager.Loading(true);
            server.SendMoneyIn(sessionInfo.userInfo.Phone, m.balance);
            guiManager.Loading(false);
        }

        public void printerWrapper_OnPrintDone(object sender, EventArgs e)
        {
            if (sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Done)
            {
                sessionInfo.userInfo.Balance -= sessionInfo.printOptions.PrintCost;
            }
            else
            {
                //TODO выдать квитанцию
            }
            server.SendSession(sessionInfo.userInfo.Phone, 
                sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Done ? 
                sessionInfo.printOptions.PagesToPrint : 0, 
                sessionInfo.userInfo.totalMoneyIn, sessionInfo.userInfo.totalBanknotesIn);
        }

        public void Usb_DriveIn(object sender, EventArgs e)
        {
            guiManager.Loading(true);
            if (errorManager.DetectErrors() != 0) guiManager.Alert("Вибачте, термінал тимчасово не працює. Помилка обладнання."); 
            else if (!server.SendPing()) guiManager.Alert("Вибачте, термінал тимчасово не працює. Помилка з'єднання з сервером.");
            else OpenFolder((e as UsbWrapper.DriveEventArgs).driveLetter + '\\');
        }

        public void Usb_DriveOut(object sender, EventArgs e)
        {
            if (sessionInfo.printProgress.Status != PrintProgress.PrintingStatus.InProgress) (MainWindow as MainWindow).ShowWelcomeTab();
            else sessionInfo.printProgress.DriveEjected = true;
        }

        public void DoService()
        {
            if (config.AdminCode.Equals(guiManager.Prompt("Пароль", new FlowDocument(), new PasswordConverter(), 6)))
            {
                onService = true;
                ServiceDialog sd = new ServiceDialog(MainWindow);
                guiManager.ShowDialog(sd);
                server.SendMaintenance();
                onService = false;
            }
        }

        public void RemindPassword_Exec()
        {
            (Current as App).guiManager.Alert("Password SMS sent");
        }
    }
}
