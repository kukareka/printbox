using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CashCodeLib
{
    public class BasicMessage
    {
        public const byte ACK_DATA = 0x00;
        public const byte NAK_DATA = 0xff;
        public const byte ILLEGAL_COMMAND_DATA = 0x30;
        const int POLYNOMIAL = 0x08408;
        const byte sync = 0x02;
        private byte _SYNC = sync;
        private ADR _ADR;
        private byte _LNG;
        private CMD _CMD;
        private List<byte> _DATA;
        private ushort _CRC;
        private ushort _CRC_RESPONSE;
        private RESPONSE_TYPE _responseType;
        private int _minResponseLength;
        private int _maxResponseLength;
        private string _responseStatusString;
        private List<string> _TEXT_RESPONSE;

        private List<byte> _MSG;
        private List<byte> _MSG_RESPONSE;

        public ADR ADR
        {
            get
            {
                return _ADR;
            }
            set
            {
                _ADR = value;
            }
        }

        public byte LNG
        {
            get
            {
                return _LNG;
            }
            set
            {
                _LNG = value;
            }
        }

        public CMD CMD
        {
            get
            {
                return _CMD;
            }
            set
            {
                _CMD = value;
            }
        }

        public List<byte> DATA
        {
            get
            {
                return _DATA;
            }
            set
            {
                _DATA = value;
            }
        }

        public ushort CRC
        {
            get
            {
                return _CRC;
            }
            set
            {
                _CRC = value;
            }
        }

        public ushort CRC_RESPONSE
        {
            get
            {
                return _CRC_RESPONSE;
            }
            set
            {
                _CRC_RESPONSE = value;
            }
        }

        public List<byte> MSG
        {
            get
            {
                _MSG = GetFormedMessage();
                return _MSG;
            }
        }

        public List<byte> MSG_RESPONSE
        {
            get
            {
                return _MSG_RESPONSE;
            }
            set
            {
                _MSG_RESPONSE = value;
            }
        }

        public List<string> TEXT_RESPONSE
        {
            get
            {
                return _TEXT_RESPONSE;
            }
            set
            {
                _TEXT_RESPONSE = value;
            }
        }

        public RESPONSE_TYPE responseType
        {
            get
            {
                return _responseType;
            }
            set
            {
                _responseType = value;
            }
        }

        public int minResponseLength
        {
            get
            {
                return _minResponseLength;
            }
            set
            {
                _minResponseLength = value;
            }
        }

        public int maxResponseLength
        {
            get
            {
                return _maxResponseLength;
            }
            set
            {
                _maxResponseLength = value;
            }
        }

        public string responseStatusString
        {
            get
            {
                return _responseStatusString;
            }
            set
            {
                _responseStatusString = value;
            }
        }

        public BasicMessage()
        {
            _SYNC = sync;
            _ADR = ADR.BillValidator;
            _DATA = new List<byte>();
            _CMD = CMD.NO_COMMAND;
            _LNG = 6;
            _CRC = GetMessageCRC16(null);
            _MSG = GetFormedMessage();
            _MSG_RESPONSE = new List<byte>();
            _TEXT_RESPONSE = new List<string>();
            _responseType = RESPONSE_TYPE.DATA;
            _minResponseLength = 6;
            _maxResponseLength = _minResponseLength;
            _responseStatusString = string.Empty;
        }

        protected ushort GetMessageCRC16(List<byte> message)
        {
            List<byte> data = new List<byte>();
            if (message == null)
            {
                data.Add(this._SYNC);
                data.Add(Convert.ToByte(Enum.Parse(typeof(ADR), _ADR.ToString())));
                data.Add(this._LNG);
                if (_CMD != CMD.NO_COMMAND)
                    data.Add(Convert.ToByte(Enum.Parse(typeof(CMD), _CMD.ToString())));
                for (int t = 0; t < this._DATA.Count; t++)
                    data.Add(this._DATA[t]);
            }
            else
                data.AddRange(message.GetRange(0, message.Count - 2));

            ushort CRC = 0, i;
            byte j;
            for (i = 0; i < data.Count; i++)
            {
                CRC ^= data[i];
                for (j = 0; j < 8; j++)
                {
                    if ((CRC & 0x0001) == 1)
                    {
                        CRC >>= 1;
                        CRC ^= POLYNOMIAL;
                    }
                    else
                    {
                        CRC >>= 1;
                    }
                }
            }
            return CRC;
        }

        private List<byte> GetFormedMessage()
        {
            List<byte> data = new List<byte>();
            data.Add(this._SYNC);
            data.Add(Convert.ToByte(Enum.Parse(typeof(ADR), this._ADR.ToString())));
            data.Add(this._LNG);
            if (_CMD != CMD.NO_COMMAND)
                data.Add(Convert.ToByte(Enum.Parse(typeof(CMD), this._CMD.ToString())));
            for (int i = 0; i < this._DATA.Count; i++)
            {
                data.Add(this._DATA[i]);
            }
            byte MSB = Convert.ToByte((this._CRC & 0xff00) >> 8);
            byte LSB = Convert.ToByte(this._CRC & 0x00ff);
            data.Add(LSB);
            data.Add(MSB);
            return data;
        }
    }

    public enum ADR
    {
        Forbidden = 0x00,
        BillToBillUnit = 0x01,
        CoinChanger = 0x02,
        BillValidator = 0x03,
        CardReader = 0x04,
        ReservedForFutureStandardPeripherals1 = 0x05,
        ReservedForFutureStandardPeripherals2 = 0x06,
        ReservedForFutureStandardPeripherals3 = 0x07,
        ReservedForFutureStandardPeripherals4 = 0x08,
        ReservedForFutureStandardPeripherals5 = 0x09,
        ReservedForFutureStandardPeripherals6 = 0x0a,
        ReservedForFutureStandardPeripherals7 = 0x0b,
        ReservedForFutureStandardPeripherals8 = 0x0c,
        ReservedForFutureStandardPeripherals9 = 0x0d,
        ReservedForFutureBroadcastTransmissions = 0x0e,
        ReservedForFutureStandardPeripherals10 = 0x0f
    }

    public enum CMD
    {
        RESET = 0x30,
        GET_STATUS = 0x31,
        SET_SECURITY = 0x32,
        POLL = 0x33,
        ENABLE_BILL_TYPES = 0x34,
        STACK = 0x35,
        RETURN = 0x36,
        IDENTIFICATION = 0x37,
        HOLD = 0x38,
        SET_BARCODE_PARAMETERS = 0x39,
        EXTRACT_BARCODE_DATA = 0x3a,
        GET_BILL_TABLE = 0x41,
        DOWNLOAD = 0x50,
        GET_CRC32_OF_THE_CODE = 0x51,
        REQUEST_STATISTICS = 0x60,
        ILLEGAL_COMMAND,
        NO_COMMAND
    }

    public enum RESPONSE_TYPE
    {
        ACK,
        NAK,
        DATA,
        ILLEGAL_COMMAND
    }

    
}
