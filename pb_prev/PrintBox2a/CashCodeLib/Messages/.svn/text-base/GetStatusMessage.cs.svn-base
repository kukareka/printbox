using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class GetStatusMessage : BasicMessage
    {
        private List<byte> _BillType;
        private List<byte> _BillSecutityLevels;

        public List<byte> BillType
        {
            get
            {
                return _BillType;
            }
            set
            {
                _BillType = value;
            }
        }

        public List<byte> BillSecurityLevels
        {
            get
            {
                return _BillSecutityLevels;
            }
            set
            {
                _BillSecutityLevels = value;
            }
        }

        public GetStatusMessage()
        {
            BillType = new List<byte>(3);
            BillSecurityLevels = new List<byte>(3);
            maxResponseLength = 11;
            CMD = CMD.GET_STATUS;
            CRC = GetMessageCRC16(null);
        }
    }
}
