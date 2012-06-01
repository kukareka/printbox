using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintBox.Logic
{
    public class PrintOptions
    {
        public int copies = 0;
        public int from = 0;
        public int to = 0;
        public int pagesPerSheet = 0;
        public int pagesToPrint = 0;
        public float printCost = 0;
        public bool valid = false;
    };
}
