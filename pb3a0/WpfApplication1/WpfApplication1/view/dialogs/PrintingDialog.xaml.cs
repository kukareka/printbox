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
    /// Interaction logic for PrintingDialog.xaml
    /// </summary>
    public partial class PrintingDialog : Window
    {
        App app = App.Current as App;
        public PrintingDialog()
        {
            DataContext = app.sessionInfo;
            InitializeComponent();
            app.printerWrapper.OnPrintDone += new EventHandler(PrintDone);
        }

        private void PrintDone(object sender, EventArgs e)
        {
            if (app.sessionInfo.printProgress.Status == PrintProgress.PrintingStatus.Error)
            {
                app.guiManager.Alert("Printing error");
                DialogResult = true;
            }
            else
            {
                doneGrid.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void PrintMore_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
