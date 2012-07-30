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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting;
using System.Collections;
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ControlDialog.xaml
    /// </summary>
    public partial class ControlDialog : Window
    {
        OpenFileDialog openFileDlg = new OpenFileDialog();
        App app = Application.Current as App;
        RemoteControlServer rc = null;

        public ControlDialog()
        {
            InitializeComponent();
            openFileDlg.Filter = "Documents|*.doc;*.docx;*.rtf";
        }

        #region Event handlers
        private void RemotingConnect_Click(object sender, RoutedEventArgs e)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = TypeFilterLevel.Full;
            if (RemotingConfiguration.CustomErrorsMode != CustomErrorsModes.Off) RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            
            IDictionary propBag = new Hashtable();            
            bool isSecure = false;
            propBag["typeFilterLevel"] = TypeFilterLevel.Full;
            propBag["name"] = "pb_test_client";  // here enter unique channel name
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

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDlg.ShowDialog() == false) return;

            app.LoadDocument(openFileDlg.FileName);
        }

        private void PromptButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Prompt("message", (FlowDocument)FindResource("commentEnterPhone"), new PhoneNumberConverter(), 10);
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Prompt("message", (FlowDocument)FindResource("commentEnterPassword"), new PasswordConverter(), 10);
        }

        private void AlertButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Alert("message");
        }

        private void LoadingButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Loading((bool)(sender as ToggleButton).IsChecked);
        }

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            app.OpenFolder(@"c:\"); 
        }
        #endregion        

        private void RemoteAdd10_Click(object sender, RoutedEventArgs e)
        {
            (app.cashcodeWrapper as TestCashCodeWrapper).MoneyIn(10);
        }

        private void PrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            (app.receiptWrapper as TestReceiptWrapper).WriteLine("receipt");
        }
    }
}
