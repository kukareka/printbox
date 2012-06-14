using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WpfApplication1
{
    public class TestReceiptWrapper : IReceiptWrapper
    {
        public void WriteLine(string s)
        {
            Debug.WriteLine("Receipt: {0}", s, 0);
        }
    }
}
