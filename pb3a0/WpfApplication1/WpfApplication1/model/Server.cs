using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using log4net;
using System.Globalization;

namespace WpfApplication1
{
    public class Server : ITicker
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

        string serverUrl;
        int boxId;
        int pingInterval;
        int testInterval;

        DateTime lastPingTime;
        DateTime lastTestTime;
        uint lastErrors;

        public Server()
        {
            log.Debug("Initializing server");

            serverUrl = (App.Current as App).config.Server;
            boxId = (App.Current as App).config.BoxID;
            pingInterval = (App.Current as App).config.PingInterval;
            testInterval = (App.Current as App).config.TestInterval;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            lastTestTime = lastPingTime = DateTime.Parse("1980-01-01 00:00:00");
        }

        private void MarkPing()
        {
            lastPingTime = DateTime.Now;
        }

        public void SyncErrors()
        {
            DateTime now = DateTime.Now;
            DateTime nextTestTime = lastTestTime.AddSeconds(testInterval);
            if (!(App.Current as App).MaintenanceInProgress && (nextTestTime.CompareTo(now) <= 0))
            {
                uint errors = (App.Current as App).DetectErrors();

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
            int paper = (App.Current as App).state.PaperInside;
            int money = (App.Current as App).state.MoneyInside;
            int banknotes = (App.Current as App).state.BanknotesInside;
            (App.Current as App).printerWrapper.UpdateTonerRemaining();
            int toner = (App.Current as App).printerWrapper.TonerRemaining;
            uint errors = (App.Current as App).MaintenanceInProgress ? lastErrors : (App.Current as App).DetectErrors();
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

        public bool SendSession(string user, int pages, int money, int banknotes)
        {
            uint errors = (App.Current as App).DetectErrors();
            string url = String.Format(SCRIPT_SESSION, serverUrl, boxId, user, pages, money, banknotes, errors,
                        (App.Current as App).config.PageCost);
            if (SendRequest(url))
            {
                log.InfoFormat("Sent session box={0}, user={1}, pages={2}, money={3}, banknotes={4}, errors={5}, cost={6}",
                    serverUrl, boxId, user, pages, money, banknotes, errors,
                        (App.Current as App).config.PageCost);
                lastErrors = errors;
                return true;
            }
            else
            {
                log.ErrorFormat("Failed to send session box={0}, user={1}, pages={2}, money={3}, banknotes={4}, errors={5}, cost={6}",
                    serverUrl, boxId, user, pages, money, banknotes, errors,
                        (App.Current as App).config.PageCost);
                return false;
            }
        }

        public bool SendMoneyIn(string user, int money)
        {
            string url = String.Format(SCRIPT_MONEY, serverUrl, boxId, user, money);
            if (SendRequest(url))
            {
                log.InfoFormat("Sent money in box={0}, user={1}, money={2}",
                    serverUrl, boxId, user, money);
                return true;
            }
            else
            {
                log.ErrorFormat("Failed to send money in box={0}, user={1}, money={2}",
                    serverUrl, boxId, user, money);
                return false;
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
            int paper = (App.Current as App).state.PaperInside;
            int money = (App.Current as App).state.MoneyInside;
            int banknotes = (App.Current as App).state.BanknotesInside;
            uint errors = (App.Current as App).DetectErrors();
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

        public void Tick()
        {
            DateTime now = DateTime.Now;
            DateTime nextTestTime = lastTestTime.AddSeconds(testInterval);
            DateTime nextPingTime = lastPingTime.AddSeconds(pingInterval);

            if (!(App.Current as App).MaintenanceInProgress && (nextTestTime.CompareTo(now) <= 0))
            {
                uint errors = (App.Current as App).DetectErrors();

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
            
            if (nextPingTime.CompareTo(now) <= 0)
            {
                SendPing();
            }
        }
    }
}
