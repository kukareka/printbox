using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Documents;

namespace WpfApplication1
{
    public class GuiManager
    {
        LoadingDialog loadingDialog = null;

        public string Prompt(string message, FlowDocument comment, IValueConverter converter, int length)
        {
            PromptDialog pd = new PromptDialog(message, comment, converter, length);
            pd.Owner = App.Current.MainWindow;
            string r = (bool) pd.ShowDialog() ? pd.Keypad.Text : null;
            pd.Close();
            return r;
        }

        public void Alert(string message)
        {
            AlertDialog ad = new AlertDialog(message);
            ad.Owner = App.Current.MainWindow;
            ad.ShowDialog();
            ad.Close();
        }

        public void Loading(bool loading)
        {         
            if (loading)
            {
                this.loadingDialog = new LoadingDialog();
                loadingDialog.Owner = App.Current.MainWindow;
                App.Current.MainWindow.IsEnabled = false;
                loadingDialog.Show();
            }
            else
            {
                loadingDialog.Close();
                loadingDialog = null;
                App.Current.MainWindow.IsEnabled = true;
            }
        }
    }
}
