using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WpfApplication1
{
    public class TestPrinterWrapper : IPrinterWrapper
    {
        public event EventHandler OnPrintDone;

        public void Print()
        {
            App app = App.Current as App;
            app.sessionInfo.printProgress.PagesPrinted = 0;
            app.sessionInfo.printProgress.Status = PrintProgress.PrintingStatus.InProgress;
        }

        public void Tick()
        {
            App app = App.Current as App;
            if (app.sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.InProgress)
            {
                if (++app.sessionInfo.printProgress.PagesPrinted == app.sessionInfo.printOptions.SheetsToPrint)
                {
                    app.sessionInfo.printProgress.Status = PrintProgress.PrintingStatus.Done;
                    OnPrintDone(this, new EventArgs());
                }
            }
        }
    }
}
