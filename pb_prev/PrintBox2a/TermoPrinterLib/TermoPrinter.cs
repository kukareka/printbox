using System;
using System.Collections.Generic;
using System.Text;

namespace TermoPrinterLib
{
    public class TermoPrinter
    {
        private nLnH _LeftMargin;

        private PagingMode _PageMode;

        private nLnH _PrintAreaWidth;

        public TextAlign _Align;

        public CodePages _CodePage;

        public nLnH LeftMargin
        {
            get
            {
                return _LeftMargin;
            }
            set
            {
                _LeftMargin = value;
                port.SendMessage(CommandToByteList(PrintPositionCommand.GS_L_nL_nH, _LeftMargin.nL, _LeftMargin.nH));
            }
        }

        public PagingMode PageMode
        {
            get
            {
                return _PageMode;
            }
            set
            {
                _PageMode = value;
                switch (_PageMode)
                {
                    case PagingMode.StandardMode:
                        port.SendMessage(CommandToByteList(OtherCommand.ESC_S));
                        break;
                    case PagingMode.PageMode:
                        port.SendMessage(CommandToByteList(OtherCommand.ESC_L));
                        break;
                    default:
                        port.SendMessage(CommandToByteList(OtherCommand.ESC_S));
                        break;
                }

            }
        }

        public nLnH PrintAreaWidth
        {
            get
            {
                return _PrintAreaWidth;
            }
            set
            {
                _PrintAreaWidth = value;
                port.SendMessage(CommandToByteList(PrintPositionCommand.GS_W_nL_nH, _PrintAreaWidth.nL, _PrintAreaWidth.nH));
            }
        }

        public TextAlign Align
        {
            get
            {
                return _Align;
            }
            set
            {
                _Align = value;
                //port.SendMessage(CommandToByteList(PrintControlCommand.LF));
                port.SendMessage(CommandToByteList(PrintPositionCommand.ESC_a_n, (byte)_Align));
            }
        }

        public bool Bold
        {
            set
            {
                WriteCommand(PrintCharacterCommand.ESC_E_n, (byte)(value ? 1 : 0));
            }
        }

        public byte Font
        {
            set
            {
                WriteCommand(PrintCharacterCommand.ESC_M_n, value);
            }
        }

        public CodePages CodePage
        {
            get
            {
                return _CodePage;
            }
            set
            {
                _CodePage = value;
                WriteCommand(PrintCharacterCommand.ESC_t_n, Convert.ToByte(value));
            }
        }

        public TermoPrinter(string portName)
        {
            port = new COM4Port(portName);
            port.OpenPort();
            this.PageMode = PagingMode.StandardMode;
            port.SendMessage(CommandToByteList(OtherCommand.GS_P_x_y, 0, 0));
            this.LeftMargin = new nLnH(160);
            this.PrintAreaWidth = new nLnH(150, 1);
            this.CodePage = CodePages.Russian;
        }

        private COM4Port port;

        public List<byte> CommandToByteList(OtherCommand cmd)
        {
            return GetCommandBytes(Convert.ToInt32(cmd));
        }

        public List<byte> CommandToByteList(OtherCommand cmd, byte x, byte y)
        {
            List<byte> result = new List<byte>();
            result.AddRange(GetCommandBytes(Convert.ToInt32(cmd)));
            result.Add(x);
            result.Add(y);
            return result;
        }

        public List<byte> CommandToByteList(StatusCommand cmd, byte n)
        {
            List<byte> result = new List<byte>();
            result.AddRange(GetCommandBytes(Convert.ToInt32(cmd)));
            result.Add(n);
            return result;
        }

        public List<byte> CommandToByteList(PrintControlCommand cmd)
        {
            return GetCommandBytes(Convert.ToInt32(cmd));
        }

        public List<byte> CommandToByteList(CutterCommand cmd)
        {
            return GetCommandBytes(Convert.ToInt32(cmd));
        }

        public List<byte> CommandToByteList(PrintControlCommand cmd, byte n)
        {
            List<byte> result = new List<byte>();
            result.AddRange(GetCommandBytes(Convert.ToInt32(cmd)));
            result.Add(n);
            return result;
        }

        public List<byte> CommandToByteList(PrintPositionCommand cmd, byte nL, byte nH)
        {
            List<byte> result = new List<byte>();
            result.AddRange(GetCommandBytes(Convert.ToInt32(cmd)));
            result.Add(nL);
            //result.Add(Convert.ToByte(','));
            result.Add(nH);
            return result;
        }

        public List<byte> CommandToByteList(PrintPositionCommand cmd, byte n)
        {
            List<byte> result = new List<byte>();
            result.AddRange(GetCommandBytes(Convert.ToInt32(cmd)));
            result.Add(n);
            return result;
        }

        private List<byte> GetCommandBytes(int cmd)
        {
            List<byte> command = new List<byte>();
            byte lowByte = (byte)(cmd & 0xFF);
            byte highByte = (byte)(cmd >> 8);
            command.Add(highByte);
            command.Add(lowByte);
            return command;
        }

        public static List<byte> MessageToByteList(string message)
        {
            List<byte> msg = new List<byte>();
            for (int i = 0; i < message.Length; i++)
                msg.Add(Convert.ToByte(message[i]));
            return msg;
        }

        public void Write(string message)
        {
            if (message.Length > 0)
            {
                List<byte> msg = new List<byte>();
                port.SendMessage(message);
            }
        }

        public void WriteLine(string message)
        {
            this.Write(message);
            port.SendMessage(PrintControlCommand.LF);
        }

        public void WriteCommand(PrintControlCommand command)
        {
            port.SendMessage(command);
        }

        public void WriteCommand(PrintControlCommand command, byte n)
        {
            port.SendMessage(command, n);
        }

        public void WriteCommand(CutterCommand command)
        {
            port.SendMessage(command);
        }

        public void WriteCommand(PrintCharacterCommand command, byte n)
        {
            port.SendMessage(command, n);
        }

        public PPU700Status GetPrinterStatus()
        {
            PPU700Status status = PPU700Status.Ok;

            byte response = 0;
            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 1));
            response = port.GetResponse();
            PPU700Status statusGeneral = ParseResponse(response, 1);

            if (statusGeneral != PPU700Status.Ok)
            {
                if (statusGeneral == PPU700Status.Offline)
                {
                    port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 2));
                    response = port.GetResponse();
                    statusGeneral = ParseResponse(response, 2);
                    if (statusGeneral == PPU700Status.Ok)
                    {
                        port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 3));
                        response = port.GetResponse();
                        PPU700Status statusError = ParseResponse(response, 3);
                        if (statusError != PPU700Status.Ok)
                        {
                            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 5));
                            response = port.GetResponse();
                            PPU700Status statusError1 = ParseResponse(response, 5);
                            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 6));
                            response = port.GetResponse();
                            PPU700Status statusError2 = ParseResponse(response, 6);
                            if (statusError1 != PPU700Status.Ok)
                                statusError = statusError1;
                            else
                                if (statusError2 != PPU700Status.Ok)
                                    statusError = statusError2;
                        }
                        statusGeneral = statusError;
                    }
                }
            }
            status = statusGeneral;

            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 4));
            response = port.GetResponse();
            PPU700Status paperStatus = ParseResponse(response, 4);
            if (statusGeneral == PPU700Status.Ok)
            {
                status = paperStatus;
            }

            return status;
        }

        public PPU700Status GetPaperStatus()
        {
            byte response = 0;
            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 4));
            response = port.GetResponse();
            PPU700Status status = ParseResponse(response, 4);
            return status;
        }

        public PPU700Status GetErrorStatus()
        {
            byte response = 0;
            port.SendMessage(this.CommandToByteList(StatusCommand.DLE_EOT_n, 3));
            response = port.GetResponse();
            PPU700Status statusError = ParseResponse(response, 3);
            return statusError;
        }

        private PPU700Status ParseResponse(byte response, byte n)
        {
            PPU700Status status = PPU700Status.Error_occured;
            response = (byte)(response & 108);

            if (response != 0)
                switch (n)
                {
                    case 1:
                        {
                            switch (response)
                            {
                                case 0x08:
                                    status = PPU700Status.Offline;
                                    break;
                                case 0x20:
                                    status = PPU700Status.Waiting_Online_Recovery;
                                    break;
                                case 0x40:
                                    status = PPU700Status.FEED_Switch_Is_Pressed;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(1): " + response);
                            }
                        }
                        break;
                    case 2:
                        {
                            switch (response)
                            {
                                case 0x04:
                                    status = PPU700Status.Cover_Is_Open;
                                    break;
                                case 0x08:
                                    status = PPU700Status.In_Paper_Feed_State_Triggered_By_FEED_Switch;
                                    break;
                                case 0x20:
                                    status = PPU700Status.Printing_Is_Stopped_Because_Of_PAPER_OUT_State;
                                    break;
                                case 0x40:
                                    status = PPU700Status.Error_occured;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(2): " + response);
                            }
                        }
                        break;
                    case 3:
                        {
                            switch (response)
                            {
                                case 0x04:
                                    status = PPU700Status.BM_Detection_Error_Or_Presenter_Error_Occurred;
                                    break;
                                case 0x08:
                                    status = PPU700Status.Auto_Cutter_Error_Occurred;
                                    break;
                                case 0x20:
                                    status = PPU700Status.Unrecoverable_Error_Occurred;
                                    break;
                                case 0x40:
                                    status = PPU700Status.Auto_Recovery_Error_Occurred;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(3): " + response);
                            }
                        }
                        break;
                    case 4:
                        {
                            switch (response)
                            {
                                case 0x04:
                                    status = PPU700Status.Paper_Not_Found_By_Paper_Nearend_1_Sensor;
                                    break;
                                case 0x08:
                                    status = PPU700Status.Paper_Not_Found_By_Paper_Nearend_2_Sensor;
                                    break;
                                case 0x20:
                                case 0x24:
                                case 0x28:
                                    status = PPU700Status.Paper_Not_Found_By_Paperend_Sensor;
                                    break;
                                case 0x40:
                                    status = PPU700Status.Paper_Not_Found_By_Presenter_Sensor;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(4): " + response);
                            }
                        }
                        break;
                    case 5:
                        {
                            switch (response)
                            {
                                case 0x04:
                                    status = PPU700Status.Cover_Is_Open;
                                    break;
                                case 0x08:
                                    status = PPU700Status.Head_Overheat_Error_Occurs;
                                    break;
                                case 0x20:
                                    status = PPU700Status.Low_Voltage_Error_Occurs;
                                    break;
                                case 0x40:
                                    status = PPU700Status.High_Voltage_Error_Occurs;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(5): " + response);
                            }
                        }
                        break;
                    case 6:
                        {
                            switch (response)
                            {
                                case 0x04:
                                    status = PPU700Status.Memory_Check_Error_Occurs;
                                    break;
                                case 0x08:
                                    status = PPU700Status.Sum_Check_Error_Occurs;
                                    break;
                                case 0x20:
                                    status = PPU700Status.Presentor_Error_Occurs;
                                    break;
                                case 0x40:
                                    status = PPU700Status.CPU_Abnormal_Error_Occurs;
                                    break;
                                default:
                                    throw new Exception("Wrong response to PrinterStatus(6): " + response);
                            }
                        }
                        break;
                    default:
                        throw new Exception("Wrong n. Can be 1-6" + n);
                }
            else
                status = PPU700Status.Ok;

            return status;
        }

        public void PrintTest()
        {
            WriteCommand(PrintCharacterCommand.ESC_M_n, 1);
            WriteLine("PRINTBOX");
            WriteCommand(PrintControlCommand.ESC_J_n, 200);
            WriteCommand(CutterCommand.ESC_I);
        }

        /*
        public void PrintInfoCheck(int pagesPrinted, double pageCost, double printCost, List<CardInfo> cards, double moneyInByCashCode, double moneyDeposit, double moneyDelivery, int boxID, string checkCounter, string printboxAddress)
        {
            this.Align = TextAlign.Center;
            this.Font = 1;
            WriteLine("PRINTBOX");
            WriteLine("www.printbox.kiev.ua");
            WriteLine("тел. (044) 596-15-23");
            WriteLine("");
            this.Bold = true;
            WriteLine("ПОВІДОМЛЕННЯ ПРО СПЛАТУ");
            this.Bold = false;
            this.Align = TextAlign.Left;
            WriteLine("Послуга: Друк");
            WriteLine("Використано: " + pagesPrinted.ToString() + "стор.х" + pageCost.ToString("F2") + "грн.");
            WriteLine("До сплати: " + printCost.ToString("F2") + "грн.");
            WriteLine("Внесено готівкою: " + moneyInByCashCode.ToString("F2") + "грн.");
            foreach (CardInfo card in cards)
                WriteLine("Використано картку: " + card.Code.ToString() + " на " + card.Sum.ToString("F2") + "грн.");
            WriteLine("Всього на рахунку до друку: " + moneyDeposit.ToString("F2") + "грн.");
            this.Bold = true;
            WriteLine("Залишок на рахунку: " + moneyDelivery.ToString("F2") + "грн.");
            WriteCommand(PrintControlCommand.LF);
            this.Bold = false;
            this.Align = TextAlign.Center;
            WriteLine("Сайт: www.printbox.kiev.ua");
            WriteLine("Термінал: №" + boxID.ToString());
            WriteLine("Кв.№" + checkCounter + " від " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            WriteLine("Адреса: " + printboxAddress);
            WriteLine("ДЯКУЄМО ЗА КОРИСТУВАННЯ ТЕРМІНАЛОМ!");
            this.Skip(200);
            this.Cut();
        }
        */

        public void Skip(byte space)
        {
            WriteCommand(PrintControlCommand.ESC_J_n, space);
        }

        public void Cut()
        {
            WriteCommand(CutterCommand.ESC_I);
        }

        public void PrintErrorCheck(string approveCode, long phoneNumber, DateTime transactionTime, double accountSum, double noteSum, int boxID, string checkCounter, string printboxAddress)
        {
            int noteValue = Convert.ToInt32(noteSum);
            this.Align = TextAlign.Center;
            WriteCommand(PrintCharacterCommand.ESC_M_n, 1);
            WriteLine("PRINTBOX");
            WriteLine("www.printbox.kiev.ua");
            WriteLine("тел. (044) 596-15-23");
            WriteCommand(PrintControlCommand.LF);
            WriteCommand(PrintCharacterCommand.ESC_E_n, 1);
            WriteLine("ПОВІДОМЛЕННЯ ПРО ПОМИЛКУ");
            WriteCommand(PrintCharacterCommand.ESC_E_n, 0);
            this.Align = TextAlign.Left;
            WriteLine("Через відсутність з'єднання з сервером");
            WriteLine("остання купюра номіналом " + Convert.ToInt32(noteSum).ToString() + "грн. не була");
            WriteLine("зарахована на Ваш рахунок. Це відбудеться");
            WriteLine("автоматично після відновлення зв'язку");
            WriteLine("із сервером.");
            WriteLine("Для термінового оновлення рахунку");
            WriteLine("зателефонуйте у службу підтримки");
            WriteLine("за телефоном: (044) 596-15-23");
            WriteCommand(PrintCharacterCommand.ESC_E_n, 1);
            WriteLine("Залишок на рахунку: " + accountSum.ToString("F2") + "грн.");
            WriteCommand(PrintCharacterCommand.ESC_E_n, 0);
            WriteLine("Номер телефону: " + phoneNumber.ToString());
            WriteLine("Номінал останньої купюри: " + noteValue.ToString());
            WriteLine("Номер терміналу: " + boxID.ToString());
            WriteLine("Час транзакції: " + transactionTime.ToString("dd.MM.yyyy HH:mm:ss") + " UTC");
            WriteLine("Код підтвердження: " + approveCode);
            WriteCommand(PrintControlCommand.LF);
            WriteCommand(PrintCharacterCommand.ESC_E_n, 0);
            this.Align = TextAlign.Center;
            WriteLine("Сайт: www.printbox.kiev.ua");
            WriteLine("Термінал: №" + boxID.ToString());
            WriteLine("Кв.№" + checkCounter + " від " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            WriteLine("Адреса: " + printboxAddress);
            WriteLine("ДЯКУЄМО ЗА КОРИСТУВАННЯ ТЕРМІНАЛОМ!");
            WriteCommand(PrintControlCommand.ESC_J_n, 200);
            WriteCommand(CutterCommand.ESC_I);
        }

        public bool OK()
        {
            PPU700Status status;
            status = GetPaperStatus();
            switch (status)
            {
                case PPU700Status.Paper_Not_Found_By_Paperend_Sensor:
                case PPU700Status.Paper_Not_Found_By_Paper_Nearend_1_Sensor:
                case PPU700Status.Paper_Not_Found_By_Paper_Nearend_2_Sensor:
                    return false;
            }
            status = GetErrorStatus();
            if (status != PPU700Status.Ok) return false;
            else return true;
        }
    }

    public enum PPU700Status
    {
        Ok,
        Offline,
        Waiting_Online_Recovery,
        FEED_Switch_Is_Pressed,
        In_Paper_Feed_State_Triggered_By_FEED_Switch,
        Printing_Is_Stopped_Because_Of_PAPER_OUT_State,
        Error_occured,
        BM_Detection_Error_Or_Presenter_Error_Occurred,
        Auto_Cutter_Error_Occurred,
        Unrecoverable_Error_Occurred,
        Auto_Recovery_Error_Occurred,
        Paper_Not_Found_By_Paper_Nearend_1_Sensor,
        Paper_Not_Found_By_Paper_Nearend_2_Sensor,
        Paper_Not_Found_By_Paperend_Sensor,
        Paper_Not_Found_By_Presenter_Sensor, // ???
        Cover_Is_Open, // Cover_Is_Open == Cover_Open (n=2)
        Head_Overheat_Error_Occurs,
        Low_Voltage_Error_Occurs,
        High_Voltage_Error_Occurs,
        Memory_Check_Error_Occurs,
        Sum_Check_Error_Occurs,
        Presentor_Error_Occurs,
        CPU_Abnormal_Error_Occurs
    }

    public enum PagingMode
    {
        PageMode,
        StandardMode
    }

    public class nLnH
    {
        public nLnH(byte nL)
        {
            this.nL = nL;
            this.nH = 0;
        }

        public nLnH(byte nL, byte nH)
        {
            this.nL = nL;
            this.nH = nH;
        }

        public byte nL { get; set; }
        public byte nH { get; set; }
    }

    public enum TextAlign
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public enum CodePages
    {
        Russian = 7
    }
}
