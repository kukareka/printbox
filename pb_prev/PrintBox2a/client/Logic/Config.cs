using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace PrintBox.Logic
{
    public class Config
    {
        private const string configFileName = "config.xml";

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
        public int WordLeft { get; set; }
        public int WordTop { get; set; }
        public int WordRight { get; set; }
        public int WordBottom { get; set; }
        public int PdfLeft { get; set; }
        public int PdfTop { get; set; }
        public int PdfRight { get; set; }
        public int PdfBottom { get; set; }
        public string AdminCode { get; set; }
        public bool HideTaskBar { get; set; }

        public static Config Load()
        {
            Config config;
            string configFilePath = GetConfigFilePath();
            XmlSerializer x = new XmlSerializer(typeof(Config));
            TextReader t = new StreamReader(configFilePath);
            config = (Config)x.Deserialize(t);
            t.Close();
            return config;
        }

        public static string GetConfigFilePath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + configFileName;
        }
    }
}
