using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows;

namespace WpfApplication1
{
    public class GuiManager
    {
        LoadingDialog loadingDialog = null;
        Window modalDialog = null;

        public bool? ShowDialog(Window dialog)
        {
            HideDialogs();
            modalDialog = dialog;
            bool? r = dialog.ShowDialog();
            modalDialog = null;
            return r;
        }

        public void HideDialogs()
        {
            Loading(false);
            if (modalDialog != null) modalDialog.DialogResult = false;
        }
        
        public string Prompt(string message, FlowDocument comment, IValueConverter converter, int length)
        {
            PromptDialog pd = new PromptDialog(App.Current.MainWindow, message, comment, converter, length);
            string r = (bool) ShowDialog(pd) ? pd.Keypad.Text : null;
            pd.Close();
            return r;
        }

        public void Alert(string message)
        {
            AlertDialog ad = new AlertDialog(message);
            ad.Owner = App.Current.MainWindow;
            ShowDialog(ad);
            ad.Close();
        }

        public void Loading(bool loading)
        {         
            if (loading)
            {
                if (loadingDialog == null) loadingDialog = new LoadingDialog();
                loadingDialog.Owner = App.Current.MainWindow;
                App.Current.MainWindow.IsEnabled = false;
                loadingDialog.Show();
            }
            else
            {
                if (loadingDialog != null) loadingDialog.Hide();
                App.Current.MainWindow.IsEnabled = true;
            }
        }

        public void ShowInstruction()
        {
            InstructionDialog instructionDialog = new InstructionDialog(App.Current.MainWindow);
            ShowDialog(instructionDialog);
        }
    }
}
