using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class SessionInfo
    {
        public DocumentInfo documentInfo { get; set; }
        public PrintOptions printOptions { get; set; }

        public SessionInfo()
        {
            documentInfo = new DocumentInfo();
            printOptions = new PrintOptions();
        }        
    }
}
