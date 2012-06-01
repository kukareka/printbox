using System;
using log4net;

namespace PrintBox.Logic
{
    public class RunOptions
    {
        ILog log = LogManager.GetLogger(typeof(RunOptions));

        public bool fullScreen = true;
        public bool testMode = false;
        public bool throwUnhandledExceptions = false;
        public bool showCursor = false;
        public bool topMost = true;

        public RunOptions(string[] commandLine)
        {
            log.Debug("Parse command line");
            for (uint i = 0; i < commandLine.Length; ++i)
            {
                if (commandLine[i].Equals("/nofullscreen",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    fullScreen = false;
                }
                else if (commandLine[i].Equals("/test",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    testMode = true;
                }
                else if (commandLine[i].Equals("/exceptions",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    throwUnhandledExceptions = true;
                }
                else if (commandLine[i].Equals("/cursor",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    showCursor = true;
                }
                else if (commandLine[i].Equals("/notopmost",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    topMost = false;
                }
            }
        }
    }
}
