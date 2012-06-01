using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class IdentificationMessage : BasicMessage
    {
        private string _PartNumber;
        private string _SerialNumber;
        private List<byte> _AssetNumber;

        public string PartNumber
        {
            get
            {
                return _PartNumber;
            }
            set
            {
                _PartNumber = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                _SerialNumber = value;
            }
        }

        public List<byte> AssetNumber
        {
            get
            {
                return _AssetNumber;
            }
            set
            {
                _AssetNumber = value;
            }
        }

        public IdentificationMessage()
        {
            maxResponseLength = 39;
            CMD = CMD.IDENTIFICATION;
            CRC = GetMessageCRC16(null);
            PartNumber = string.Empty;
            SerialNumber = string.Empty;
            AssetNumber = new List<byte>(7);
        }
    }
}
