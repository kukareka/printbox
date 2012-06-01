using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class NAKMessage : BasicMessage
    {
        private static volatile NAKMessage instance;

        private static object syncRoot = new Object();

        public static NAKMessage GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NAKMessage();
                        }
                    }
                }
                return instance;
            }
        }

        private NAKMessage()
        {
            CMD = CMD.NO_COMMAND;
            DATA.Add(0xFF);
            CRC = GetMessageCRC16(null);
        }
    }
}
