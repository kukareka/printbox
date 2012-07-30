using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace WpfApplication1
{
    public class Config
    {
        private static string configFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.xml");

        public int BoxID { get; set; }
        public string Server { get; set; }
        public int MaxPaper { get; set; }
        public int PageCost { get; set; } //cents
        public int PingInterval { get; set; } //seconds
        public int TestInterval { get; set; } //seconds
        public string CashCodePort { get; set; }
        public string ThermoPort { get; set; }
        public int WordTimeout { get; set; }
        public int UsbTimeout { get; set; }
        public string AdminCode { get; set; }

        public static Config Load()
        {
            Config config;
            XmlSerializer x = new XmlSerializer(typeof(Config));
            TextReader t = new StreamReader(configFilePath);
            config = (Config)x.Deserialize(t);
            t.Close();
            return config;
        }
    }
}
