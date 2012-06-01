using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections;

namespace CashCodeLib
{
    class COMPort
    {
        private ACKMessage ACK;
        private NAKMessage NAK;
        private IllegalCommandMessage ILLEGAL_COMMAND;
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

        public COMPort(string portName)
        {
            port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = 9600;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.ReceivedBytesThreshold = 6;
            port.ReadTimeout = 5000;
            ACK = ACKMessage.GetInstance;
            NAK = NAKMessage.GetInstance;
            ILLEGAL_COMMAND = IllegalCommandMessage.GetInstance;
        }

        public void OpenPort()
        {
            port.Open();
        }

        public void SendMessage(BasicMessage message)
        {
            message.MSG_RESPONSE = new List<byte>();
            message.TEXT_RESPONSE = new List<string>();
            message.responseType = RESPONSE_TYPE.DATA;
            
            List<byte> msg = message.MSG;
            port.Write(msg.ToArray(), 0, msg.Count);
        }

        public void ClosePort()
        {
            port.Close();
        }

        public void GetResponse(BasicMessage msg)
        {
            List<byte> data = new List<byte>();
            data = ReadBytes(msg.minResponseLength);
            msg.MSG_RESPONSE = data;
            if (!IsACKorNAKorILLEGALCOMMAND(msg))
            {
                msg.responseType = RESPONSE_TYPE.DATA;
                ReadDataReminder(msg);
                ParseResponseData(msg);
            }
        }

        private List<byte> ReadBytes(int num)
        {
            List<byte> msg = new List<byte>(num);
            int bytesRead = 0;
            while (num != bytesRead)
            {
                try
                {
                    msg.Add(Convert.ToByte(port.ReadByte()));
                }
                catch (TimeoutException ex)
                {
                    throw new Exception(ex.Message);
                }
                bytesRead++;
            }
            return msg;
        }

        private ushort GetCRC(List<byte> data)
        {
            ushort CRC = 0;
            if (data.Count == data[2])
            {
                CRC = Convert.ToUInt16((data[data.Count - 1] << 8) + data[data.Count - 2]);
            }
            return CRC;
        }

        private bool IsACKorNAKorILLEGALCOMMAND(BasicMessage msg)
        {
            if (msg.MSG_RESPONSE.Count == msg.MSG_RESPONSE[2])
            {
                List<byte> data = msg.MSG_RESPONSE;
                ushort CRC = GetCRC(data);
                if ((CRC == ACK.CRC) && (data[3] == ACK.DATA[0]))
                {
                    msg.responseType = RESPONSE_TYPE.ACK;
                    msg.TEXT_RESPONSE.Add("ACK");
                    return true;
                }
                else
                    if ((CRC == NAK.CRC) && (data[3] == NAK.DATA[0]))
                    {
                        msg.responseType = RESPONSE_TYPE.NAK;
                        msg.TEXT_RESPONSE.Add("NAK");
                        return true;
                    }
                    else
                        if ((CRC == ILLEGAL_COMMAND.CRC) && (data[3] == ILLEGAL_COMMAND.DATA[0]))
                        {
                            msg.responseType = RESPONSE_TYPE.ILLEGAL_COMMAND;
                            msg.TEXT_RESPONSE.Add("Illegal Command");
                            return true;
                        }
            }
            return false;
        }

        private void ReadDataReminder(BasicMessage msg)
        {
            int bytesToRead = msg.MSG_RESPONSE[2] - msg.minResponseLength;
            if (bytesToRead > 0)
            {
                List<byte> data = ReadBytes(bytesToRead);
                msg.MSG_RESPONSE.AddRange(data);
            }
        }

        private void ParseResponseData(BasicMessage msg)
        {
            List<string> text = new List<string>();
            List<byte> data = GetResponseDataFromResposeMessage(msg.MSG_RESPONSE);
            if (msg is PollMessage)
            {
                ushort z1z2 = (ushort)(data[0] << 8);
                if (data.Count == 2)
                    z1z2 += data[1];
                try
                {
                    string stateName = Enum.GetName(typeof(DeviceState), z1z2);
                    (msg as PollMessage).state = (DeviceState)Enum.Parse(typeof(DeviceState), stateName);
                }
                catch (ArgumentException)
                {
                    (msg as PollMessage).state = DeviceState.Unknown_state;
                }
                msg.TEXT_RESPONSE.Add((msg as PollMessage).state.ToString().Replace("_", " "));
            }
            else
                if (msg is IdentificationMessage)
                {
                    List<byte> PartNumer = data.GetRange(0, 15);
                    StringBuilder str = new StringBuilder();
                    foreach (byte b in PartNumer)
                    {
                        str.Append(Convert.ToChar(b));
                    }
                    (msg as IdentificationMessage).PartNumber = str.ToString();
                    msg.TEXT_RESPONSE.Add("Part Number: " + str.ToString());

                    List<byte> SerialNumber = data.GetRange(15, 12);
                    str = new StringBuilder();
                    foreach (byte b in SerialNumber)
                    {
                        str.Append(Convert.ToChar(b));
                    }
                    (msg as IdentificationMessage).SerialNumber = str.ToString();
                    msg.TEXT_RESPONSE.Add("Serial Number: " + str.ToString());

                    List<byte> AssetNumber = data.GetRange(27, 7);
                    str = new StringBuilder();
                    (msg as IdentificationMessage).AssetNumber = AssetNumber;
                    foreach (byte b in AssetNumber)
                    {
                        str.AppendFormat("{0:X2}", b);
                    }
                    msg.TEXT_RESPONSE.Add("Asset Number: " + str.ToString());
                }
                else
                    if (msg is GetStatusMessage)
                    {
                        StringBuilder billtype = new StringBuilder();
                        StringBuilder billsecuritylevels = new StringBuilder();
                        List<byte> BillType = data.GetRange(0, 3);
                        List<byte> BillSecurityLevels = data.GetRange(3, 3);
                        for (int i = 0; i < 3; i++)
                        {
                            billtype.AppendFormat("{0:X2}", BillType[i]);
                            billsecuritylevels.AppendFormat("{0:X2}", BillSecurityLevels[i]);
                        }
                        msg.TEXT_RESPONSE.Add("Bill Type: " + billtype.ToString());
                        msg.TEXT_RESPONSE.Add("Bill Security Levels: " + billsecuritylevels.ToString());
                        (msg as GetStatusMessage).BillType = BillType;
                        (msg as GetStatusMessage).BillSecurityLevels = BillSecurityLevels;
                    }
                    else
                        if (msg is GetBillTableMessage)
                        {
                            int denomination = 0;
                            byte denominationCode1 = 0;
                            byte denominationCode2 = 0;
                            StringBuilder countryCode = new StringBuilder(3);
                            List<byte> bill = new List<byte>(5);
                            for (int i = 0; i < 24; i++)
                            {
                                denominationCode1 = 0;
                                denominationCode2 = 0;
                                countryCode = new StringBuilder(3);
                                bill = data.GetRange(i * 5, 5);
                                denominationCode1 = bill[0];
                                for (int j = 1; j <= 3; j++)
                                    countryCode.Append(Convert.ToChar(bill[j]));
                                denominationCode2 = bill[4];
                                denomination = denominationCode1 * ParseDenomination(denominationCode2);
                                msg.TEXT_RESPONSE.Add("Bill type " + i + ":\t" + denomination.ToString() + " " + countryCode.ToString());
                            }
                        }
        }

        private List<byte> GetResponseDataFromResposeMessage(List<byte> data)
        {
            return data.GetRange(3, data[2] - 5);
        }

        private int ParseDenomination(byte code)
        {
            int res = 1;
            if ((code > 1) && ((code & 0x80) == 0))
            {
                while (code != 0)
                {
                    code >>= 1;
                    res *= 10;
                }
            }
            return res;
        }
    }
}
