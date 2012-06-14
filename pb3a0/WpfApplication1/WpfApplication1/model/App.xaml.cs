using System;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SessionInfo sessionInfo = new SessionInfo();
        public GuiManager guiManager;
        
        public IPrinterWrapper printerWrapper = new TestPrinterWrapper();
        public ICashcodeWrapper cashcodeWrapper = new TestCashCodeWrapper();
        public IReceiptWrapper receiptWrapper = new TestReceiptWrapper();

        public XpsWrapper xpsWrapper = new XpsWrapper();
        public ITicker[] tickers;
        public DispatcherTimer dispatcherTimer;
        public RemoteControlServer remoteControlServer = new RemoteControlServer();

        public App()
        {
            InitializeComponent();
            guiManager = new GuiManager();
            tickers = new ITicker[] { printerWrapper, cashcodeWrapper };

            cashcodeWrapper.OnMoneyIn += Cashcode_MoneyIn;

            remoteControlServer.Start();
            dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Background, new EventHandler(Tick), App.Current.Dispatcher);
        }

        public void Tick(Object sender, EventArgs e)
        {
            foreach (ITicker t in tickers) t.Tick();
        }

        public bool LoadDocument(string documentPath)
        {
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
                return true;
            }
            else return false;
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
                if (null != (sessionInfo.userInfo.Password = guiManager.Prompt("Пароль", (FlowDocument)FindResource("commentEnterPassword"), new PasswordConverter(), 8)))
                {
                    if (!sessionInfo.userInfo.isValidPassword) guiManager.Alert("Invalid password");
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
            sessionInfo.userInfo.Balance += m.balance;
        }
    }
}
