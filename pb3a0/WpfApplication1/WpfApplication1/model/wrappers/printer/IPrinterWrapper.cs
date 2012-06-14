using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public interface IPrinterWrapper : ITicker
    {
        event EventHandler OnPrintDone;
        void Print();
    }
}
