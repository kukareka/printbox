using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Windows.Forms;

namespace PrintBox.Logic
{
    public class ExceptionHandler
    {
        ILog log = LogManager.GetLogger(typeof(ExceptionHandler));

        public ExceptionHandler()
        {
            if (!PrintBoxApp.instance.runOptions.throwUnhandledExceptions)
            {
                log.Debug("Setting exception filter");
                System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionFilter);
            }
        }
        
        private static void UnhandledExceptionFilter(object sender, UnhandledExceptionEventArgs e)
        {
            PrintBoxApp.instance.exceptionHandler.log.Fatal("Unhandled exception");
            PrintBoxApp.instance.exceptionHandler.log.Fatal((Exception)e.ExceptionObject);
            Environment.Exit(0);
        }

    }
}
