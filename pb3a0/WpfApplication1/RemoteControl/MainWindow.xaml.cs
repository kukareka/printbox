using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Diagnostics;

namespace RemoteControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RemoteControlServer rc = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RemotingConnect_Click(object sender, RoutedEventArgs e)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = TypeFilterLevel.Full;
            if (RemotingConfiguration.CustomErrorsMode != CustomErrorsModes.Off) RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;

            IDictionary propBag = new Hashtable();
            bool isSecure = false;
            propBag["typeFilterLevel"] = TypeFilterLevel.Full;
            propBag["name"] = "pb_test_client2";  // here enter unique channel name
            if (isSecure)  // if you want remoting comm to be secure and encrypted
            {
                propBag["secure"] = isSecure;
                propBag["impersonate"] = false;  // change to true to do impersonation
            }

            TcpChannel chan = new TcpChannel(propBag, null, serverProv);
            ChannelServices.RegisterChannel(chan, isSecure);
            rc = (RemoteControlServer)Activator.GetObject(typeof(RemoteControlServer), remotingUrl.Text);
            Debug.WriteLine(String.Format("Connected to remote host {0}", rc.Version));
        }

        private void RemoteAdd10_Click(object sender, RoutedEventArgs e)
        {
            rc.MoneyIn(10);
        }
    }
}
