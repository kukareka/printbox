using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class TestCashCodeWrapper : ICashcodeWrapper
    {
        public event EventHandler OnMoneyIn;

        public void Tick()
        {
        }

        public void MoneyIn(int balance)
        {
            OnMoneyIn(this, new MoneyInEventArgs(balance));
        }

    }
}
