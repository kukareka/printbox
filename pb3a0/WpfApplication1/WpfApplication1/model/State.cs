using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace WpfApplication1
{
    public class State : DependencyObject
    {
        private static string stateFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "state.xml");

        #region PaperInside
        public static DependencyProperty PaperInsideProperty =
           DependencyProperty.Register("PaperInside", typeof(int), typeof(State), new PropertyMetadata(new PropertyChangedCallback(PropertyChanged)));

        public int PaperInside
        {
            get { return (int)GetValue(PaperInsideProperty); }
            set { SetValue(PaperInsideProperty, value); }
        }
        #endregion

        private bool initialized = false;

        #region BanknotesInside
        public static DependencyProperty BanknotesInsideProperty =
           DependencyProperty.Register("BanknotesInside", typeof(int), typeof(State), new PropertyMetadata(new PropertyChangedCallback(PropertyChanged)));

        public int BanknotesInside
        {
            get { return (int)GetValue(BanknotesInsideProperty); }
            set { SetValue(BanknotesInsideProperty, value); }
        }
        #endregion

        #region MoneyInside
        public static DependencyProperty MoneyInsideProperty =
           DependencyProperty.Register("MoneyInside", typeof(int), typeof(State), new PropertyMetadata(new PropertyChangedCallback(PropertyChanged)));

        public int MoneyInside
        {
            get { return (int)GetValue(MoneyInsideProperty); }
            set { SetValue(MoneyInsideProperty, value); }
        }
        #endregion

        public void Save()
        {
            if (initialized)
            {
                XmlSerializer x = new XmlSerializer(typeof(State));
                TextWriter t = new StreamWriter(stateFilePath);
                x.Serialize(t, this);
                t.Close();
            }
        }

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
                state.PaperInside = (App.Current as App).config.MaxPaper;
                state.MoneyInside = state.BanknotesInside = 0;
            }
            state.initialized = true;
            return state;
        }

        public static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as State).Save();
        }
    };
}
