using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CashCodeLib
{
    public delegate void StateChangedEventHandler(object sender, StateChangedEventArgs e);
    public delegate void ResponseReceivedEventHandler(object sender, ResponseReceivedEventArgs e);
    public delegate void BillStackedEventHandler(object sender, BillStackedEventArgs e);

    public class StateChangedEventArgs : EventArgs
    {
        private DeviceState _currentState;
        private DeviceState _previousState;

        public StateChangedEventArgs()
        {
            _currentState = DeviceState.Unknown_state;
            _previousState = DeviceState.Unknown_state;
        }

        public StateChangedEventArgs(DeviceState CurrentState)
        {
            _currentState = CurrentState;
            _previousState = DeviceState.Unknown_state;
        }

        public StateChangedEventArgs(DeviceState CurrentState, DeviceState PreviousState)
        {
            _currentState = CurrentState;
            _previousState = PreviousState;
        }

        public DeviceState CurrentState
        {
            get
            {
                return _currentState;
            }
        }

        public DeviceState PreviousState
        {
            get
            {
                return _previousState;
            }
        }
    }

    public class ResponseReceivedEventArgs : EventArgs
    {
        private List<string> _currentResponse;
        private List<string> _previousResponse;

        public List<string> CurrentResponse
        {
            get
            {
                return _currentResponse;
            }
            set
            {
                _currentResponse = value;
            }
        }

        public List<string> PreviousResponse
        {
            get
            {
                return _previousResponse;
            }
            set
            {
                _previousResponse = value;
            }
        }

        public ResponseReceivedEventArgs()
        {
            CurrentResponse = new List<string>();
            PreviousResponse = new List<string>();
        }

        public ResponseReceivedEventArgs(List<string> CurrentResponse)
        {
            this.CurrentResponse = CurrentResponse;
            PreviousResponse = new List<string>();
        }

        public ResponseReceivedEventArgs(List<string> CurrentResponse, List<string> PreviousResponse)
        {
            this.CurrentResponse = CurrentResponse;
            this.PreviousResponse = PreviousResponse;
        }
    }

    public class BillStackedEventArgs : EventArgs
    {
        private int _denomination;

        public int denomination
        {
            get
            {
                return _denomination;
            }
            set
            {
                _denomination = value;
            }
        }

        public BillStackedEventArgs(int denomination)
        {
            this.denomination = denomination;
        }
    }

    public class CashCode
    {
        public event StateChangedEventHandler StateChanged;
        public event ResponseReceivedEventHandler ResponseReceived;
        public event BillStackedEventHandler BillStacked;

        private ushort _currentCRC;
        private ushort _previousCRC;
        private DeviceState _CurrentState;
        private DeviceState _PreviousState;
        private PollMessage _poll;
        private ResetMessage _reset;
        private EnableBillTypesMessage _enableBillTypes;
        private IdentificationMessage _identification;
        private SetSecurityMessage _setSecurity;
        private GetStatusMessage _getStatus;
        private COMPort _com;
        private ACKMessage _ACK;
        private NAKMessage _NAK;
        private List<string> _CurrentResponse;
        private List<string> _PreviousResponse;

        private static object syncRoot = new Object();

        public CashCode(string portName)
        {
            _CurrentState = DeviceState.Unknown_state;
            _PreviousState = DeviceState.Unknown_state;
            _com = new COMPort(portName);
            _com.OpenPort(); //!!!!!!!!!!!!!
            _poll = new PollMessage();
            _reset = new ResetMessage();
            _enableBillTypes = new EnableBillTypesMessage();
            _identification = new IdentificationMessage();
            _setSecurity = new SetSecurityMessage();
            _getStatus = new GetStatusMessage();
            _ACK = ACKMessage.GetInstance;
            _NAK = NAKMessage.GetInstance;
            _currentCRC = 0;
            _previousCRC = 0;
        }

        ~CashCode()
        {
            if (_com != null)
                _com.ClosePort();
        }

        public DeviceState CurrentState
        {
            get
            {
                return _CurrentState;
            }
            private set
            {
                _CurrentState = value;
            }
        }

        public DeviceState PreviousState
        {
            get
            {
                return _PreviousState;
            }
            private set
            {
                _PreviousState = value;
            }
        }

        public List<string> CurrentResponse
        {
            get
            {
                return _CurrentResponse;
            }
            set
            {
                _CurrentResponse = value;
            }
        }

        public List<string> PreviousResponse
        {
            get
            {
                return _PreviousResponse;
            }
            set
            {
                _PreviousResponse = value;
            }
        }

        public void Reset()
        {
            _com.SendMessage(_reset);
            _com.GetResponse(_reset);

            //OnResponseReceived(_reset);
            _com.SendMessage(_identification);
            _com.GetResponse(_identification);
            //OnResponseReceived(_identification);
            _com.SendMessage(_ACK);
            Thread.Sleep(200);

            _com.SendMessage(_setSecurity);
            _com.GetResponse(_setSecurity);
            //OnResponseReceived(_setSecurity);

            _com.SendMessage(_getStatus);
            _com.GetResponse(_getStatus);
            _com.SendMessage(_ACK);

            //_enableBillTypes.EnableAllBillTypes();
            _enableBillTypes.DisableAllBillTypes();
            _com.SendMessage(_enableBillTypes);
            _com.GetResponse(_enableBillTypes);
            //OnResponseReceived(_enableBillTypes);
        }

        public void Enable()
        {
            _com.SendMessage(_identification);
            _com.GetResponse(_identification);
            _com.SendMessage(_ACK);
            Thread.Sleep(200);

            _com.SendMessage(_setSecurity);
            _com.GetResponse(_setSecurity);

            _com.SendMessage(_getStatus);
            _com.GetResponse(_getStatus);
            _com.SendMessage(_ACK);

            _enableBillTypes.EnableAllBillTypes();
            _com.SendMessage(_enableBillTypes);
            _com.GetResponse(_enableBillTypes);
        }

        public void Disable()
        {
            _enableBillTypes.DisableAllBillTypes();
            _com.SendMessage(_enableBillTypes);
            _com.GetResponse(_enableBillTypes);
        }

        public void Poll()
        {
            _com.SendMessage(_poll);
            _com.GetResponse(_poll);
            _com.SendMessage(_ACK);
            OnStateChanged(_poll.state);
            OnResponseReceived(_poll);
        }

        private void OnStateChanged(DeviceState state)
        {
            if (CurrentState != state)
            {
                CurrentState = state;
                StateChangedEventArgs e = new StateChangedEventArgs(CurrentState, PreviousState);
                if (StateChanged != null)
                {
                    StateChanged(this, e);
                }
                PreviousState = CurrentState;
                OnBillStacked();
            }
        }

        private void OnResponseReceived(BasicMessage msg)
        {
            if (_currentCRC != msg.CRC)
            {
                _currentCRC = msg.CRC;
                ResponseReceivedEventArgs e = null;
                CurrentResponse = msg.TEXT_RESPONSE;
                if (PreviousResponse != null)
                    e = new ResponseReceivedEventArgs(CurrentResponse, PreviousResponse);
                else
                    e = new ResponseReceivedEventArgs(CurrentResponse);
                if (ResponseReceived != null)
                {
                    ResponseReceived(this, e);
                }
                PreviousResponse = CurrentResponse;
                _previousCRC = _currentCRC;
            }
        }

        private void OnBillStacked()
        {
            BillStackedEventArgs e = null;
            if (BillStacked != null)
            {
                switch (CurrentState)
                {
                    case DeviceState.Bill_stacked_0:
                        e = new BillStackedEventArgs(1);
                        break;
                    case DeviceState.Bill_stacked_1:
                        e = new BillStackedEventArgs(2);
                        break;
                    case DeviceState.Bill_stacked_2:
                        e = new BillStackedEventArgs(5);
                        break;
                    case DeviceState.Bill_stacked_3:
                        e = new BillStackedEventArgs(10);
                        break;
                    case DeviceState.Bill_stacked_4:
                        e = new BillStackedEventArgs(20);
                        break;
                    case DeviceState.Bill_stacked_5:
                        e = new BillStackedEventArgs(50);
                        break;
                    case DeviceState.Bill_stacked_6:
                        e = new BillStackedEventArgs(100);
                        break;
                    case DeviceState.Bill_stacked_7:
                        e = new BillStackedEventArgs(200);
                        break;
                    case DeviceState.Bill_stacked_8:
                        e = new BillStackedEventArgs(500);
                        break;
                    default:
                        e = null;
                        break;
                }
                if (e != null)
                    BillStacked(this, e);
            }
        }
    }
}
