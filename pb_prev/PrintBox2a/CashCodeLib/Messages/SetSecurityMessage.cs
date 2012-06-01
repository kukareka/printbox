using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class SetSecurityMessage : BasicMessage
    {
        public SetSecurityMessage()
        {
            CMD = CMD.SET_SECURITY;
            DATA = new List<byte>(3);
            DATA.Add(0x00);
            DATA.Add(0x00);
            DATA.Add(0x00);
            LNG = Convert.ToByte(LNG + DATA.Count);
            CRC = GetMessageCRC16(null);
        }
    }
}
