using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class IllegalCommandMessage : BasicMessage
    {
        private static volatile IllegalCommandMessage instance;

        private static object syncRoot = new Object();

        public static IllegalCommandMessage GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new IllegalCommandMessage();
                        }
                    }
                }
                return instance;
            }
        }

        private IllegalCommandMessage()
        {
            CMD = CMD.NO_COMMAND;
            DATA.Add(0x30);
            CRC = GetMessageCRC16(null);
        }
    }
}
