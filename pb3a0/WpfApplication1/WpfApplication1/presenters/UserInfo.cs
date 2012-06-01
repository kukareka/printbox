using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication1
{
    public class UserInfo : DependencyObject
    {
        #region Properties
        #region Phone
        public static DependencyProperty PhoneProperty =
            DependencyProperty.Register("Phone", typeof(string), typeof(UserInfo));

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
            DependencyProperty.Register("Balance", typeof(int), typeof(UserInfo), new PropertyMetadata(SessionInfo.CanPrintChanges));

        public int Balance
        {
            get { return (int)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }
        #endregion

        #endregion

    }
}
