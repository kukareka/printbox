using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class EnableBillTypesMessage : BasicMessage
    {
        public EnableBillTypesMessage()
        {
            CMD = CMD.ENABLE_BILL_TYPES;
            DATA = new List<byte>(6);
            DATA.Add(0x00);
            DATA.Add(0x00);
            DATA.Add(0x00);
            DATA.Add(0x00);
            DATA.Add(0x00);
            DATA.Add(0x00);
            LNG = Convert.ToByte(LNG + DATA.Count);
            CRC = GetMessageCRC16(null);
        }

        public void EnableAllBillTypes()
        {
            for (int i = 0; i < 3; i++)
                DATA[i] = 0xFF;
            CRC = GetMessageCRC16(null);
        }

        public void DisableAllBillTypes()
        {
            for (int i = 0; i < 3; i++)
                DATA[i] = 0x00;
            CRC = GetMessageCRC16(null);
        }
    }
}
