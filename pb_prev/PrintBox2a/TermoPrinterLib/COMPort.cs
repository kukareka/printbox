using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections;

namespace TermoPrinterLib
{
    class COM4Port
    {
        private SerialPort port;

        public string PortName
        {
            get
            {
                return port.PortName;
            }
            set
            {
                port.PortName = value;
            }
        }

        public int BaudRate
        {
            get
            {
                return port.BaudRate;
            }
            set
            {
                port.BaudRate = value;
            }
        }

        public StopBits StopBits
        {
            get
            {
                return port.StopBits;
            }
            set
            {
                port.StopBits = value;
            }
        }

        public Parity Parity
        {
            get
            {
                return port.Parity;
            }
            set
            {
                port.Parity = value;
            }
        }

        public int DataBits
        {
            get
            {
                return port.DataBits;
            }
            set
            {
                port.DataBits = value;
            }
        }

        public COM4Port(string portName)
        {
            port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = 19200;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.ReceivedBytesThreshold = 4;
            port.ReadTimeout = 5000;
        }

        public void OpenPort()
        {
            port.Open();
        }

        private byte[] ConvertToCP866(string message)
        {
            message = message.Replace('і', 'i').Replace('І', 'I'); // Заменяем украинские буквы на английские
            List<byte> result = new List<byte>();
            Encoding unicode = Encoding.Unicode;
            Encoding cp866 = Encoding.GetEncoding(866);

            byte[] unicodeBytes = unicode.GetBytes(message);
            byte[] cp866Bytes = Encoding.Convert(unicode, cp866, unicodeBytes);

            return cp866Bytes;
        }

        public void SendMessage(string message)
        {
            byte[] m = ConvertToCP866(message);

            port.Write(m, 0, m.Length);
        }

        public void SendMessage(List<byte> msg)
        {
            port.Write(msg.ToArray(), 0, msg.Count);
        }

        public void SendMessage(PrintControlCommand command)
        {
            List<byte> result = GetCommandBytes(Convert.ToInt32(command));
            port.Write(result.ToArray(), 0, result.Count);
        }

        public void SendMessage(PrintControlCommand command, byte n)
        {
            List<byte> result = GetCommandBytes(Convert.ToInt32(command));
            result.Add(n);
            port.Write(result.ToArray(), 0, result.Count);
        }

        public void SendMessage(CutterCommand command)
        {
            List<byte> result = GetCommandBytes(Convert.ToInt32(command));
            port.Write(result.ToArray(), 0, result.Count);
        }

        public void SendMessage(PrintCharacterCommand command, byte n)
        {
            List<byte> result = GetCommandBytes(Convert.ToInt32(command));
            result.Add(n);
            port.Write(result.ToArray(), 0, result.Count);
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

        public void ClosePort()
        {
            port.Close();
        }

        public byte GetResponse()
        {
            return (byte)port.ReadByte();
        }

    }
}
