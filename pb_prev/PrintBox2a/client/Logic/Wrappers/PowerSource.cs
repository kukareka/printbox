using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using log4net;

namespace PrintBox.Logic.Wrappers
{
    public class PowerSource
    {
        public static bool IsOnBattery()
        {
            bool battery = false;
            try
            {
                DateTime lastTime = new DateTime(1980, 1, 1);
                using (EventLog log = new EventLog("System"))
                {
                    int i = log.Entries.Count - 1;
                    while ((i >= 0) && (log.Entries.Count - i < 200))
                    {
                        EventLogEntry entry = log.Entries[i];
                        if (((lastTime == null) || (lastTime < entry.TimeGenerated))
                            && ((entry.Source.ToLower() == "ups") || (entry.Source.ToLower() == "eventlog")))
                        {
                            int EventID = Convert.ToInt32(entry.InstanceId & 0xffff);
                            if (EventID == 3230)
                            {
                                lastTime = entry.TimeGenerated;
                                battery = true;
                            }
                            else if ((EventID == 3234) || (EventID == 6005))
                            {
                                lastTime = entry.TimeGenerated;
                                battery = false;
                            }
                        }
                        --i;
                    }
                }
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PowerSource));
                log.Error(e);
            }
            return battery;            
        }
    }
}
