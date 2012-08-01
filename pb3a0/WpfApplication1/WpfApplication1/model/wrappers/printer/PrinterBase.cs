using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Management;

namespace WpfApplication1
{
    public abstract class PrinterBase
    {
        ILog log = LogManager.GetLogger(typeof(PrinterBase));
        public void ClearQueue()
        {
            try
            {
                ManagementObjectSearcher searchPrintJobs = new ManagementObjectSearcher("SELECT * FROM Win32_PrintJob");
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
}
