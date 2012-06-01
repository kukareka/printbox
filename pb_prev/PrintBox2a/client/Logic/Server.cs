using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Specialized;
using log4net;
using System.Security.Cryptography.X509Certificates;

namespace PrintBox.Logic
{    
    public class Server
    {
        ILog log = LogManager.GetLogger(typeof(Server));

        const int MAX_READ_LEN = 512;
        const int REQUEST_TIMEOUT = 30000; //ms

        const int SLEEP_INTERVAL = 1; //seconds
        const string SCRIPT_PING = "{0}/ping.php?box={1}&paper={2}&money={3}&banknotes={4}&toner={5}&errors={6}";
        const string SCRIPT_SESSION = "{0}/session.php?box={1}&user={2}&pages={3}&money={4}&banknotes={5}&errors={6}&cost={7}";
        const string SCRIPT_MONEY = "{0}/money.php?box={1}&user={2}&money={3}";
        const string SCRIPT_AUTH = "{0}/auth.php?box={1}&user={2}";
        const string SCRIPT_ERRORS = "{0}/error.php?box={1}&errors={2}";
        const string SCRIPT_MAINTENANCE = "{0}/ping.php?box={1}&paper={2}&money={3}&banknotes={4}&errors={5}&maintenance=1";
        const string SCRIPT_REMIND_PASSWORD = "{0}/remind.php?box={1}&user={2}";

        const string clientCertificatePassword = "qwer86xdeF1ew!";

        X509Certificate2 clientCertificate = new X509Certificate2("client.pfx", clientCertificatePassword);

        private struct AsyncSessionInfo
        {
            public string user;
            public int pages;
            public int money;
            public int banknotes;
            public uint errors;

            public AsyncSessionInfo(string user, int pages, int money, int banknotes, uint errors)
            {
                this.user = user;
                this.pages = pages;
                this.money = money;
                this.banknotes = banknotes;
                this.errors = errors;
            }
        }

        string serverUrl = PrintBoxApp.instance.config.Server;
        int boxId = PrintBoxApp.instance.config.BoxID;
        int pingInterval = PrintBoxApp.instance.config.PingInterval;
        int testInterval = PrintBoxApp.instance.config.TestInterval;
        
        Thread pingThread;
        DateTime lastPingTime;
        DateTime lastTestTime;
        uint lastErrors;

        private ListDictionary asyncMoney = new ListDictionary();
        private LinkedList<AsyncSessionInfo> asyncSessions = new LinkedList<AsyncSessionInfo>();


        public Server()
        {
            log.Debug("Initializing server");
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            
            lastTestTime = lastPingTime = DateTime.Parse("1980-01-01 00:00:00");
            pingThread = new Thread(new ThreadStart(PingThreadProc));
            pingThread.Start();
        }

        public void Stop()
        {
            log.Debug("Stopping server");
            do
            {
                pingThread.Interrupt();
                pingThread.Join(1000);
            }
            while (pingThread.IsAlive);
        }

        private void MarkPing()
        {
            lock (this)
            {
                lastPingTime = DateTime.Now;
            }
        }

        public void SyncSessions()
        {
            lock (asyncSessions)
            {
                while (asyncSessions.Count > 0)
                {
                    AsyncSessionInfo s = asyncSessions.First.Value;
                    string url = String.Format(SCRIPT_SESSION, serverUrl, boxId, s.user, s.pages, s.money, s.banknotes, s.errors, 
                        PrintBoxApp.instance.config.PageCost);
                    if (SendRequest(url))
                    {
                        lastErrors = s.errors;
                        asyncSessions.RemoveFirst();
                    }
                    else break;
                }                
            }
        }

        public void SyncMoney()
        {
            lock (asyncMoney)
            {
                string[] users = new string[asyncMoney.Count];
                asyncMoney.Keys.CopyTo(users, 0);
                foreach (string user in users)
                {
                    int money = (int)asyncMoney[user];
                    string url = String.Format(SCRIPT_MONEY, serverUrl, boxId, user, money);
                    if (SendRequest(url))
                    {
                        asyncMoney.Remove(user);
                    }
                    else break;
                }
            }
        }

        public void SyncErrors()
        {
            DateTime now = DateTime.Now;
            DateTime nextTestTime = lastTestTime.AddSeconds(testInterval);
            if (!PrintBoxApp.instance.MaintenanceInProgress && (nextTestTime.CompareTo(now) <= 0))
            {
                uint errors = PrintBoxApp.instance.DetectErrors();

                if (errors != lastErrors)
                {
                    if (SendErrors(errors))
                    {
                        lastErrors = errors;
                        lastTestTime = now;
                    }
                }
                else
                {
                    lastTestTime = now;
                }
            }
        }

        private void PingThreadProc()
        {
            while (true)
            {
                SyncMoney();
                SyncSessions();
                SyncErrors();

                DateTime now = DateTime.Now;
                DateTime nextPingTime = lastPingTime.AddSeconds(pingInterval);
                if (nextPingTime.CompareTo(now) <= 0)
                {
                    SendPing();
                }
                
                try
                {
                    Thread.Sleep(1000 * SLEEP_INTERVAL);
                }
                catch (ThreadInterruptedException)
                {
                    return;
                }
            }
        }

        public static string ReadResponse(WebResponse response)
        {
            Stream rcvStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(rcvStream, System.Text.Encoding.GetEncoding("utf-8"));
            Char[] read = new Char[MAX_READ_LEN];
            StringBuilder responseText = new StringBuilder();
            while (true)
            {
                int count = readStream.Read(read, 0, MAX_READ_LEN);
                if (count > 0) responseText.Append(new String(read, 0, count).Replace("\r", ""));
                else break;
            }
            return responseText.ToString();
        }

        private bool GetBool(string val)
        {
            return val.Equals("1");
        }

        private HttpWebRequest CreateRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = REQUEST_TIMEOUT;
            request.ClientCertificates.Add(clientCertificate);
            return request;
        }

        public bool SendRequest(string url)
        {
            WebRequest request = CreateRequest(url);            
            try
            {
                using (WebResponse response = request.GetResponse()) { }
                MarkPing();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool SendPing()
        {
            int paper = PrintBoxApp.instance.state.PaperInside;
            int money = PrintBoxApp.instance.state.MoneyInside;
            int banknotes = PrintBoxApp.instance.state.BanknotesInside;
            PrintBoxApp.instance.printerWrapper.UpdateTonerRemaining();
            int toner = PrintBoxApp.instance.printerWrapper.TonerRemaining;
            uint errors = PrintBoxApp.instance.MaintenanceInProgress ? lastErrors : PrintBoxApp.instance.DetectErrors();
            string url = String.Format(SCRIPT_PING, serverUrl, boxId, paper, money, banknotes, toner, errors);
            if (SendRequest(url))
            {
                lastErrors = errors;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendSession(string user, int pages, int money, int banknotes)
        {
            uint errors = PrintBoxApp.instance.DetectErrors();
            AsyncSessionInfo s = new AsyncSessionInfo(user, pages, money, banknotes, errors);            
            lock (asyncSessions)
            {
                asyncSessions.AddLast(s);
            }            
        }

        public void SendMoneyIn(string user, int money)
        {
            lock (asyncMoney)
            {
                int prevMoney = asyncMoney.Contains(user) ? (int)asyncMoney[user] : 0;
                asyncMoney[user] = prevMoney + money;
            }               
        }

        public bool SendErrors(uint errorCodes)
        {
            string url = String.Format(SCRIPT_ERRORS, serverUrl, boxId, errorCodes);
            return SendRequest(url);
        }

        public void ReceiveAuthData(string user, ref string passwordHash, ref bool newUser, ref float balance)
        {
            string url = String.Format(SCRIPT_AUTH, serverUrl, boxId, user);
            WebRequest request = CreateRequest(url);
            string responseText;
            using (WebResponse response = request.GetResponse())
            {
                responseText = Server.ReadResponse(response);
            }
            string[] data = responseText.Split(new char[] { '\n' });
            passwordHash = data[0];
            newUser = GetBool(data[1]);
            balance = Convert.ToSingle(data[2], new CultureInfo("en-US"));
            MarkPing();
        }

        public void SendMaintenance()
        {
            int paper = PrintBoxApp.instance.state.PaperInside;
            int money = PrintBoxApp.instance.state.MoneyInside;
            int banknotes = PrintBoxApp.instance.state.BanknotesInside;
            uint errors = PrintBoxApp.instance.DetectErrors();
            string url = String.Format(SCRIPT_MAINTENANCE, serverUrl, boxId, paper, money, banknotes, errors);
            if (SendRequest(url))
            {
                lastErrors = errors;
            }
        }

        public bool RemindPassword(string user)
        {
            string url = String.Format(SCRIPT_REMIND_PASSWORD, serverUrl, boxId, user);
            WebRequest request = CreateRequest(url);
            string responseText;
            using (WebResponse response = request.GetResponse())
            {
                responseText = Server.ReadResponse(response);
            }
            MarkPing();
            return responseText.IndexOf("OK") != -1;            
        }
    }
}
