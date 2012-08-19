using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using log4net;
using System.Security.Cryptography;

namespace WpfApplication1
{
    public class UserInfo : DependencyObject
    {
        ILog log = LogManager.GetLogger(typeof(UserInfo));
        public bool isNewUser;
        public int totalMoneyIn = 0, totalBanknotesIn = 0;

        #region Properties
        #region Phone
        public static DependencyProperty PhoneProperty =
            DependencyProperty.Register("Phone", typeof(string), typeof(UserInfo), new PropertyMetadata(PhoneChanged));

        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        #endregion

        #region Password
        public static DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(UserInfo));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        #endregion

        #region Balance
        public static DependencyProperty BalanceProperty =
            DependencyProperty.Register("Balance", typeof(int), typeof(UserInfo), new PropertyMetadata(UpdateBalance));

        public int Balance
        {
            get { return (int)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }
        #endregion

        #region BalanceAfterPrint
        public static DependencyProperty BalanceAfterPrintProperty =
            DependencyProperty.Register("BalanceAfterPrint", typeof(int), typeof(SessionInfo));

        public int BalanceAfterPrint
        {
            get { return (int)GetValue(BalanceAfterPrintProperty); }
            set { SetValue(BalanceAfterPrintProperty, value); }
        }
        #endregion

        #endregion

        #region Event handlers
        public static void PhoneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserInfo u = d as UserInfo;
            if (u.Phone == null) return;
            string pwd = "";
            bool newUser = false;
            int balance = 0;
            try
            {
                (App.Current as App).server.ReceiveAuthData(u.Phone, ref pwd, ref newUser, ref balance);
                u.Password = pwd;
                u.isNewUser = newUser;
                u.Balance = balance;
            }
            catch (Exception ex)
            {
                u.log.Error("Failed to receive auth data", ex);
            }
        }

        #endregion


        public bool IsValidPassword(string pwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] hash = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in hash) s.Append(b.ToString("x2").ToLower());
            string ret = s.ToString();
            return ret.Equals(Password);
        }

        public static void UpdateBalance(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserInfo u = (App.Current as App).sessionInfo.userInfo;
            u.BalanceAfterPrint = u.Balance - (App.Current as App).sessionInfo.printOptions.PrintCost;
        }
    }
}
