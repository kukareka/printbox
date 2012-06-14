using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class MoneyInEventArgs : EventArgs
    {
        public int balance;
        public MoneyInEventArgs(int balance)
        {
            this.balance = balance;
        }
    }

    public interface ICashcodeWrapper : ITicker
    {
        event EventHandler OnMoneyIn;
    }
}
