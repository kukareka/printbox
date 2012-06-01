using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class ResetMessage : BasicMessage
    {
        public ResetMessage()
        {
            CMD = CMD.RESET;
            CRC = GetMessageCRC16(null);
        }
    }
}
