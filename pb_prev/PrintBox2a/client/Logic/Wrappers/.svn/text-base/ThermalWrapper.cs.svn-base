using System;
using TermoPrinterLib;
using log4net;

namespace PrintBox.Logic.Wrappers
{
    public class ThermalWrapper
    {
        ILog log = LogManager.GetLogger(typeof(ThermalWrapper));
        public TermoPrinter thermalPrinter;

        public ThermalWrapper()
        {
            log.Debug("Initializing thermal printer");
            if (!PrintBoxApp.instance.runOptions.testMode) thermalPrinter =
                new TermoPrinter(PrintBoxApp.instance.config.ThermoPort);
        }

        public uint DetectErrors()
        {
            uint errors = 0;

            if (!PrintBoxApp.instance.runOptions.testMode)
            {
                PPU700Status thermalStatus = thermalPrinter.GetPaperStatus();

                switch (thermalStatus)
                {
                    case PPU700Status.Paper_Not_Found_By_Paperend_Sensor:
                    case PPU700Status.Paper_Not_Found_By_Paper_Nearend_1_Sensor:
                    case PPU700Status.Paper_Not_Found_By_Paper_Nearend_2_Sensor:
                        errors |= Errors.ERROR_THERMAL_NO_PAPER;
                        break;
                }

                thermalStatus = thermalPrinter.GetErrorStatus();
                if (thermalStatus != PPU700Status.Ok) errors |= Errors.ERROR_THERMAL_OTHER;
            }

            return errors;
        }

        public void PrintErrorLine(string line)
        {
            if (!PrintBoxApp.instance.runOptions.testMode) thermalPrinter.WriteLine(line);
            else Console.WriteLine(line);
        }

        public uint CalculateErrorCode(string userPhone, string dateString, string boxId, string errors, string moneyIn, string moneyTotal)
        {
            string dataToHash = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|Hjsmx;!lksjl12",
                dateString, boxId, userPhone, errors, moneyIn, moneyTotal);
            string hash = PrintBoxApp.instance.tools.MD5(dataToHash).Substring(0, 4);
            uint code = Convert.ToUInt32(hash, 16);
            return code;
        }

        public void PrintErrorCheck()
        {
            bool testMode = PrintBoxApp.instance.runOptions.testMode;
            if (!testMode)
            {
                thermalPrinter.Align = TextAlign.Center;
                thermalPrinter.Bold = true;
                thermalPrinter.Font = 1;
            }

            PrintErrorLine("PRINTBOX");
            PrintErrorLine("Повідомлення про помилку");
            PrintErrorLine("");
            if (!testMode)
            {
                thermalPrinter.Bold = false;
                thermalPrinter.Align = TextAlign.Left;
            }

            string dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string boxId = PrintBoxApp.instance.config.BoxID.ToString();
            string errors = PrintBoxApp.instance.DetectErrors().ToString();
            string moneyIn = PrintBoxApp.instance.sessionInfo.moneyInSession.ToString();
            string moneyTotal = PrintBoxApp.instance.sessionInfo.userMoney.ToString("F2");

            uint code = CalculateErrorCode(PrintBoxApp.instance.sessionInfo.userPhone, 
                dateString, boxId, errors, moneyIn, moneyTotal);

            PrintErrorLine("Час: " + dateString);
            PrintErrorLine("Термінал: " + boxId);
            PrintErrorLine("Код помилки: " + errors);
            PrintErrorLine("Внесено: " + moneyIn + "грн");
            PrintErrorLine("Баланс: " + moneyTotal + "грн");
            PrintErrorLine("Код: " + code.ToString());
            PrintErrorLine("");
            if (!testMode)
            {
                thermalPrinter.Align = TextAlign.Center;
            }
            PrintErrorLine("Внесені кошти повернуто на Ваш рахунок.");
            PrintErrorLine("Ви можете скористатись ними в");
            PrintErrorLine("іншому терміналі PrintBox.");
            PrintErrorLine("Приносимо щирі вибачення.");
            PrintErrorLine("");
            PrintErrorLine("");
            if (!testMode)
            {
                thermalPrinter.Cut();
            }
        }
    }
}
