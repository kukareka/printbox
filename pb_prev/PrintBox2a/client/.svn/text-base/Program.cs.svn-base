using System;
using System.Windows.Forms;
using log4net.Config;

namespace PrintBox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] commandLine)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PrintBoxApp.CreateInstance(commandLine);
            PrintBoxApp.instance.Run();
        }
    }
}
