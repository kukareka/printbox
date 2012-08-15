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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ServiceDialog.xaml
    /// </summary>
    public partial class ServiceDialog : Window
    {
        public ServiceDialog(Window owner)
        {
            InitializeComponent();
            this.Owner = owner;
            DataContext = (App.Current as App).state;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).state.PaperInside = (App.Current as App).config.MaxPaper;
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).state.MoneyInside = (App.Current as App).state.BanknotesInside = 0;
        }

        private void PrintQueue_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).printerWrapper.ClearQueue();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            App app = (App.Current as App);
            app.guiManager.Loading(true);
            uint errors = app.errorManager.DetectErrors();
            string[] errorDesc = app.errorManager.DecodeErrors(errors);
            bool pingRes = app.server.SendPing();
            app.guiManager.Loading(false);

            app.guiManager.Alert(String.Format("Помилки: {0}.\r\nСервер: {1}.",
                errorDesc.Length > 0 ? string.Join("; ", errorDesc) : "Немає",
                pingRes ? "OK" : "Disconnected"));
        }
    }
}
