using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class GetBillTableMessage : BasicMessage
    {
        public GetBillTableMessage()
        {
            maxResponseLength = 125;
            CMD = CMD.GET_BILL_TABLE;
            CRC = GetMessageCRC16(null);
        }
    }
}
