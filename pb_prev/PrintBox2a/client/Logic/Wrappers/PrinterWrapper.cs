using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using log4net;
using System.Management;

namespace PrintBox.Logic.Wrappers
{
    public class PrinterWrapper
    {
        ILog log = LogManager.GetLogger(typeof(PrinterWrapper));

        private const int REQUEST_TIMEOUT = 10000; //milliseconds
        private const string PRINTER_ADDR = "192.168.10.100";        

        private int _tonerRemaining = 0;
        public int TonerRemaining { get { return _tonerRemaining; } }

        private int _pagesPrinted = 0;
        public int PagesPrinted { get { return _pagesPrinted; } }

        private string _statusText;
        public string StatusText { get { return _statusText; } }

        private PrinterStatus _printerStatus;
        public PrinterStatus Status { get { return _printerStatus; } }

        public void Update()
        {
            UpdateStatus();
            if (this.Status != PrinterStatus.Offline)
            {
                UpdatePages();
                UpdateTonerRemaining();
            }
        }

        public void UpdateStatus()
        {
            this._statusText = GetStatusMessage();
            this._printerStatus = ParseStatus(_statusText);
        }

        public void UpdatePages()
        {
            _pagesPrinted = GetTotalPagesPrinted();
        }

        public void UpdateTonerRemaining()
        {
            _tonerRemaining = GetTonerRemaining();
        }

        private int GetTotalPagesPrinted()
        {            
            try
            {
                string url = String.Format("http://{0}/status/generalstatus.html", PRINTER_ADDR);
                WebRequest request = WebRequest.Create(url);
                request.Timeout = REQUEST_TIMEOUT;
                string responseText;
                using (WebResponse response = request.GetResponse())
                {
                    responseText = Server.ReadResponse(response);
                }
                Regex r = new Regex("<td width=40%>(.*?)</td>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Match match = r.Match(responseText);
                return Convert.ToInt32(match.Groups[1].Value);
            }
            catch (Exception e)
            {
                log.Error(e);
                return -1;
            }            
        }

        private string GetStatusMessage()
        {           
            try
            {
                string url = String.Format("http://{0}/script/Common_script.js", PRINTER_ADDR);
                WebRequest request = WebRequest.Create(url);
                request.Timeout = REQUEST_TIMEOUT;
                string responseText;
                using (WebResponse response = request.GetResponse())
                {
                    responseText = Server.ReadResponse(response);
                }
                Regex r = new Regex("<a.*?>Status</a>.*?<font.*?>(.*?)</font>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match match = r.Match(responseText);
                if (match.Success)
                {
                    string status = match.Groups[1].Value.Replace("...", "").Trim();
                    return status;
                }
            }
            catch (WebException we)
            {
                log.Error(we);
            }
            catch (Exception e)
            {
                log.Error(e);
                return e.Message;
            }
            return "offline";
        }

        private int GetTonerRemaining()
        {
            try
            {
                string url = String.Format("http://{0}/status/Supplies.html", PRINTER_ADDR);
                WebRequest request = WebRequest.Create(url);
                request.Timeout = REQUEST_TIMEOUT;
                string responseText;
                using (WebResponse response = request.GetResponse())
                {
                    responseText = Server.ReadResponse(response);
                }
                Regex r = new Regex("<td width=5%>(.*?)%</td>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match match = r.Match(responseText);
                return Convert.ToInt32(match.Groups[1].Value); 
            }
            catch (Exception e)
            {
                log.Error(e);
                return -1;
            }

        }

        private PrinterStatus ParseStatus(string str)
        {
            PrinterStatus status = PrinterStatus.Unknown;

            str = str.ToLower();
            if (str.Length > 0)
            {
                string strStopPrinting = "stop printing,";
                string strWarning = "warning,";
                int index = str.IndexOf(strWarning);
                if (index != -1)
                    str = str.Remove(index, strWarning.Length);
                index = str.IndexOf(strStopPrinting);
                if (index != -1)
                    str = str.Remove(index, strStopPrinting.Length);
                str = str.Trim();
            }
            switch (str)
            {
                case "sleeping":
                    status = PrinterStatus.Sleeping;
                    break;
                case "printing":
                    status = PrinterStatus.Printing;
                    break;
                case "ready":
                    status = PrinterStatus.Ready;
                    break;
                case "warming up":
                    status = PrinterStatus.WarmingUp;
                    break;
                case "service requested":
                    status = PrinterStatus.ServiceRequested;
                    break;
                case "jammed":
                    status = PrinterStatus.PaperJammed;
                    break;
                case "door open":
                    status = PrinterStatus.DoorOpen;
                    break;
                case "marker supply missing":
                    status = PrinterStatus.MarkerSupplyMissing;
                    break;
                case "input tray empty":
                    status = PrinterStatus.InputTrayEmpty;
                    break;
                case "out of toner":
                case "no toner":
                    status = PrinterStatus.NoToner; // ??
                    break;
                case "low toner":
                    status = PrinterStatus.LowToner; // ??
                    break;
                case "input tray missing":
                    status = PrinterStatus.InputTrayMissing; // ??
                    break;
                case "output tray missing":
                    status = PrinterStatus.OutputTrayMissing; // ??
                    break;
                case "output bin full":
                    status = PrinterStatus.OutputBinFull; // ??
                    break;
                case "output bin near full":
                    status = PrinterStatus.OutputBinNearFull; // ??
                    break;
                case "low paper":
                    status = PrinterStatus.LowPaper; // ??
                    break;
                case "out of paper":
                    status = PrinterStatus.OutOfPaper; // ??
                    break;
                case "offline":
                    status = PrinterStatus.Offline; // ??
                    break;
                case "overdue preventative maintenance": 
                    status = PrinterStatus.OverduePreventativeMaintenance; // ??
                    break;
            }
            return status;
        }

        public bool OK()
        {
            return DetectErrors() == 0;
        }

        public uint DetectErrors()
        {
            if (PrintBoxApp.instance.runOptions.testMode) return 0;

            uint errors = 0;            
            UpdateStatus();
            switch (Status)
            {
                case PrinterStatus.Ready:
                case PrinterStatus.Sleeping:
                case PrinterStatus.WarmingUp:
                case PrinterStatus.Printing:
                case PrinterStatus.LowPaper:
                case PrinterStatus.LowToner:
                case PrinterStatus.OutputBinNearFull:
                    break;
                case PrinterStatus.Offline:
                    errors |= Errors.ERROR_PRINTER_OFFLINE; break;
                case PrinterStatus.PaperJammed:
                    errors |= Errors.ERROR_PRINTER_PAPER_JAM; break;
                case PrinterStatus.InputTrayEmpty:
                    errors |= Errors.ERROR_PRINTER_NO_PAPER; break;
                case PrinterStatus.DoorOpen:
                    errors |= Errors.ERROR_PRINTER_DOOR_OPEN; break;
                case PrinterStatus.NoToner:
                    errors |= Errors.ERROR_PRINTER_NO_TONER; break;
                default:
                    errors |= Errors.ERROR_PRINTER_OTHER;
                    break;
            }
            return errors;
        }

        public void CancelAllJobs()
        {
            try
            {
                string searchQuery = "SELECT * FROM Win32_PrintJob";
                ManagementObjectSearcher searchPrintJobs = new ManagementObjectSearcher(searchQuery);
                ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();
                foreach (ManagementObject prntJob in prntJobCollection)
                {
                    try
                    {
                        prntJob.Delete();
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }
    }

    public enum PrinterStatus
    {
        Ready, //+
        Printing, //+
        Sleeping, //+
        WarmingUp, //+
        ServiceRequested, //+
        InputTrayEmpty, //+
        OverduePreventativeMaintenance, //-
        LowToner, //-
        NoToner, //-
        LowPaper, //-
        OutOfPaper, //-
        DoorOpen, //+
        PaperJammed, //+
        Offline, //-
        InputTrayMissing, //-
        OutputTrayMissing, //-
        MarkerSupplyMissing, //+
        OutputBinNearFull, //-
        OutputBinFull, //-
        Unknown
    }
}
