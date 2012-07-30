using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace WpfApplication1
{
    public class State
    {
        private static string stateFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "state.xml");

        private bool initialized = false;

        private int _paperInside;
        private int _banknotesInside;
        private int _moneyInside;

        public int PaperInside
        {
            get { return _paperInside; }
            set { _paperInside = value; Save(); }
        }

        public int BanknotesInside
        {
            get { return _banknotesInside; }
            set { _banknotesInside = value; Save(); }
        }

        public int MoneyInside
        {
            get { return _moneyInside; }
            set { _moneyInside = value; Save(); }
        }

        public void Save()
        {
            if (initialized)
            {
                XmlSerializer x = new XmlSerializer(typeof(State));
                TextWriter t = new StreamWriter(stateFilePath);
                x.Serialize(t, this);
                t.Close();
                OnStateChanged();
            }
        }


        public delegate void OnStateChangedEvent();
        [field: NonSerializedAttribute()]
        public event OnStateChangedEvent OnStateChanged;

        public static State Load()
        {
            State state;
            
            if (File.Exists(stateFilePath))
            {
                XmlSerializer x = new XmlSerializer(typeof(State));
                TextReader t = new StreamReader(stateFilePath);
                state = (State)x.Deserialize(t);
                t.Close();
            }
            else
            {
                state = new State();
                state._paperInside = (App.Current as App).config.MaxPaper;
                state._moneyInside = state._banknotesInside = 0;
            }
            state.initialized = true;
            return state;
        }
    };
}
