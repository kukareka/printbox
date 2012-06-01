using System;
using System.Collections.Generic;
using System.Text;

namespace CashCodeLib
{
    public class PollMessage : BasicMessage
    {
        //private ushort _Z1Z2;

        //public ushort Z1Z2
        //{
        //    get
        //    {
        //        return _Z1Z2;
        //    }
        //    set
        //    {
        //        _Z1Z2 = value;
        //    }
        //}
        private DeviceState _state;

        public DeviceState state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public PollMessage()
        {
            _state = DeviceState.Unknown_state;
            maxResponseLength = 7;
            CMD = CMD.POLL;
            CRC = GetMessageCRC16(null);
        }
    }

    public enum DeviceState : ushort
    {
        Power_Up = 0x1000,
        Power_Up_with_Bill_in_Validator = 0x1100,
        Power_Up_with_Bill_in_Stacker = 0x1200,
        Initialize = 0x1300,
        Idling = 0x1400,
        Accepting = 0x1500,
        Stacking = 0x1700,
        Returning = 0x1800,
        Unit_Disabled = 0x1900,
        Holding = 0x1a00,
        Device_Busy = 0x1b17, //?????????????????????
        Drop_Cassette_Full = 0x4100,
        Drop_Cassette_out_of_position = 0x4200,
        Validator_Jammed = 0x4300,
        Drop_Cassette_Jammed = 0x4400,
        Cheated = 0x4500,
        Pause = 0x4600,
        //0x1Cxx Generic rejecting code. Always followed by rejection reason byte
        Rejecting_due_to_Insertion = 0x1c60,
        Rejecting_due_to_Magnetic = 0x1c61,
        Rejecting_due_to_Remained_bill_in_head = 0x1c62,
        Rejecting_due_to_Multiplying = 0x1c63,
        Rejecting_due_to_Conveying = 0x1c64,
        Rejecting_due_to_Identification = 0x1c65,
        Rejecting_due_to_Verification = 0x1c66,
        Rejecting_due_to_Optic = 0x1c67,
        Rejecting_due_to_Inhibit = 0x1c68,
        Rejecting_due_to_Capacity = 0x1c69,
        Rejecting_due_to_Operation = 0x1c6a,
        Rejecting_due_to_Length = 0x1c6c,
        Rejecting_due_to_unrecognised_barcode = 0x1c92,
        Rejecting_due_to_UV = 0x1c6d,
        Rejecting_due_to_incorrect_number_of_characters_in_barcode = 0x1c93,
        Rejecting_due_to_unknown_barcode_start_sequence = 0x1c94,
        Rejecting_due_to_unknown_barcode_stop_sequence = 0x1c95,
        //47H Generic Failure codes. Always followed by failure description byte.
        Stack_Motor_Failure = 0x4750,
        Transport_Motor_Speed_Failure = 0x4751,
        Transport_Motor_Failure = 0x4752,
        Aligning_Motor_Failure = 0x4753,
        Initial_Cassette_Status_Failure = 0x4754,
        Optic_Canal_Failure = 0x4755,
        Magnetic_Canal_Failure = 0x4756,
        Capacitance_Canal_Failure = 0x475f,
        //Events with credit.
        Escrow_position_0 = 0x8000,
        Escrow_position_1 = 0x8001,
        Escrow_position_2 = 0x8002,
        Escrow_position_3 = 0x8003,
        Escrow_position_4 = 0x8004,
        Escrow_position_5 = 0x8005,
        Escrow_position_6 = 0x8006,
        Escrow_position_7 = 0x8007,
        Escrow_position_8 = 0x8008,
        Escrow_position_9 = 0x8009,
        Escrow_position_10 = 0x800a,
        Escrow_position_11 = 0x800b,
        Escrow_position_12 = 0x800c,
        Escrow_position_13 = 0x800d,
        Escrow_position_14 = 0x800e,
        Escrow_position_15 = 0x800f,
        Escrow_position_16 = 0x8010,
        Escrow_position_17 = 0x8011,
        Escrow_position_18 = 0x8012,
        Escrow_position_19 = 0x8013,
        Escrow_position_20 = 0x8014,
        Escrow_position_21 = 0x8015,
        Escrow_position_22 = 0x8016,
        Escrow_position_23 = 0x8017,
        Bill_stacked_0 = 0x8100,
        Bill_stacked_1 = 0x8101,
        Bill_stacked_2 = 0x8102,
        Bill_stacked_3 = 0x8103,
        Bill_stacked_4 = 0x8104,
        Bill_stacked_5 = 0x8105,
        Bill_stacked_6 = 0x8106,
        Bill_stacked_7 = 0x8107,
        Bill_stacked_8 = 0x8108,
        Bill_stacked_9 = 0x8109,
        Bill_stacked_10 = 0x810a,
        Bill_stacked_11 = 0x810b,
        Bill_stacked_12 = 0x810c,
        Bill_stacked_13 = 0x810d,
        Bill_stacked_14 = 0x810e,
        Bill_stacked_15 = 0x810f,
        Bill_stacked_16 = 0x8110,
        Bill_stacked_17 = 0x8111,
        Bill_stacked_18 = 0x8112,
        Bill_stacked_19 = 0x8113,
        Bill_stacked_20 = 0x8114,
        Bill_stacked_21 = 0x8115,
        Bill_stacked_22 = 0x8116,
        Bill_stacked_23 = 0x8117,
        Bill_returned_0 = 0x8200,
        Bill_returned_1 = 0x8201,
        Bill_returned_2 = 0x8202,
        Bill_returned_3 = 0x8203,
        Bill_returned_4 = 0x8204,
        Bill_returned_5 = 0x8205,
        Bill_returned_6 = 0x8206,
        Bill_returned_7 = 0x8207,
        Bill_returned_8 = 0x8208,
        Bill_returned_9 = 0x8209,
        Bill_returned_10 = 0x820a,
        Bill_returned_11 = 0x820b,
        Bill_returned_12 = 0x820c,
        Bill_returned_13 = 0x820d,
        Bill_returned_14 = 0x820e,
        Bill_returned_15 = 0x820f,
        Bill_returned_16 = 0x8210,
        Bill_returned_17 = 0x8211,
        Bill_returned_18 = 0x8212,
        Bill_returned_19 = 0x8213,
        Bill_returned_20 = 0x8214,
        Bill_returned_21 = 0x8215,
        Bill_returned_22 = 0x8216,
        Bill_returned_23 = 0x8217,
        Unknown_state = 0xffff
    }
}
