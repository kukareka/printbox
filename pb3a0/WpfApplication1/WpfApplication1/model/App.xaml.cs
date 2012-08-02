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

            guiManager = new GuiManager();
            tickers = new ITicker[] { printerWrapper, cashcodeWrapper };

            cashcodeWrapper.OnMoneyIn += new EventHandler(Cashcode_MoneyIn);
            printerWrapper.OnPrintDone += new EventHandler(printerWrapper_OnPrintDone);

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
            if (null != (sessionInfo.userInfo.Phone = guiManager.Prompt("Телефон", (FlowDocument)FindResource("commentEnterPhone"), new PhoneNumberConverter(), 10)))
            {
                if (sessionInfo.userInfo.isNewUser) guiManager.Alert("New user");
                string pwd;
                if (null != (pwd = guiManager.Prompt("Пароль", (FlowDocument)FindResource("commentEnterPassword"), new PasswordConverter(), 7)))
                {
                    if (!sessionInfo.userInfo.IsValidPassword(pwd)) guiManager.Alert("Invalid password");
                    else
                    {
                        MoneyDialog d = new MoneyDialog();
                        d.Owner = MainWindow;
                        if ((bool)d.ShowDialog())
                        {
                            Print();
                        }
                        d.Close();
                    }
                }
            }
            return false;
        }

        public void Print()
        {
            if (!sessionInfo.CanPrint) return;
            PrintingDialog d = new PrintingDialog();
            d.Owner = MainWindow;
            printerWrapper.Print();
            bool r = (bool)d.ShowDialog();
            d.Close();
            if (r) (MainWindow as MainWindow).ShowWelcomeTab();
            else (MainWindow as MainWindow).ShowFolder();
        }

        public void Cashcode_MoneyIn(object sender, EventArgs e)
        {
            MoneyInEventArgs m = e as MoneyInEventArgs;
            sessionInfo.userInfo.Balance += m.balance * 100;
            sessionInfo.userInfo.totalMoneyIn += m.balance;
            state.MoneyInside += m.balance;
            ++state.BanknotesInside;
            ++sessionInfo.userInfo.totalBanknotesIn;
            server.SendMoneyIn(sessionInfo.userInfo.Phone, m.balance);
        }

        public void printerWrapper_OnPrintDone(object sender, EventArgs e)
        {
            if (sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Done)
            {
                sessionInfo.userInfo.Balance -= sessionInfo.printOptions.PrintCost;
            }
            server.SendSession(sessionInfo.userInfo.Phone, 
                sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Done ? 
                sessionInfo.printOptions.PagesToPrint : 0, 
                sessionInfo.userInfo.totalMoneyIn, sessionInfo.userInfo.totalBanknotesIn);
        }

        public void DoService()
        {
            if (config.AdminCode.Equals(guiManager.Prompt("Password", new FlowDocument(), new PasswordConverter(), 6)))
            {
                onService = true;
                ServiceDialog sd = new ServiceDialog();
                sd.Owner = MainWindow;
                sd.ShowDialog();
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
