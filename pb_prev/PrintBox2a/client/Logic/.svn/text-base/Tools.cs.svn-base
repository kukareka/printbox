using System.Security.Cryptography;
using log4net;

namespace PrintBox.Logic
{
    public class Tools
    {
        ILog log = LogManager.GetLogger(typeof(Tools));

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public string MD5(string data)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] hash = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in hash) s.Append(b.ToString("x2").ToLower());
            string ret = s.ToString();
            return ret;
        }

        public bool AuthorizeUser(string phone, string password)
        {
            bool ok = (MD5(password) == PrintBoxApp.instance.sessionInfo.passwordMD5);
            log.DebugFormat("authorizing user {0}:{1}", phone, ok);
            return ok;
        }

        public bool IsExistingUser(string phoneNumber)
        {
            log.DebugFormat("checking user {0}", phoneNumber);
            string passwordHash = "";
            bool newUser = false;
            float balance = 0;
            for (int i = 0; ; ++i)
            {
                try
                {
                    log.DebugFormat("receive auth data");
                    PrintBoxApp.instance.server.ReceiveAuthData(phoneNumber, ref passwordHash, ref newUser, ref balance);
                    break;
                }
                catch
                {
                    if (i > 5) throw;
                }
            }
            log.DebugFormat("got user info: new={0}, balance={1}", newUser, balance);
            PrintBoxApp.instance.sessionInfo.userPhone = phoneNumber;
            PrintBoxApp.instance.sessionInfo.passwordMD5 = passwordHash;
            PrintBoxApp.instance.sessionInfo.userMoney = balance;
            return !newUser;
        }
    }
}
