using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class ACKMessage : BasicMessage
    {
        private static volatile ACKMessage instance;

        private static object syncRoot = new Object();

        private ACKMessage()
        {
            CMD = CMD.NO_COMMAND;
            DATA.Add(0x00);
            CRC = GetMessageCRC16(null);
        }

        public static ACKMessage GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ACKMessage();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
