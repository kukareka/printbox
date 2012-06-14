using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Windows.Threading;
using System.Diagnostics;

namespace WpfApplication1
{
    public class RemoteControlServer : MarshalByRefObject 
    {        
        App app;

        public void Start()
        {
            try
            {
                app = App.Current as App;
                TcpChannel channel = new TcpChannel(8088);
                ChannelServices.RegisterChannel(channel, false);
                RemotingServices.Marshal(this, "pb_test");
            }
            catch (Exception)
            {
            }
        }

        public string Version 
        { 
            get 
            { 
                return "PrintBox/3.0a"; 
            } 
        }

        public void MoneyIn(int balance)
        {
            app.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action(() => (app.cashcodeWrapper as TestCashCodeWrapper).MoneyIn(balance)));
        }
    }
}
