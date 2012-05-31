using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Diagnostics;

namespace WpfApplication1
{
    public class GuiManager
    {
        public void Prompt(string message, string comment, IValueConverter converter, int length)
        {
            PromptDialog pd = new PromptDialog(message, comment, converter, length);
            pd.Owner = App.Current.MainWindow;
            if ((bool)pd.ShowDialog())
            {
                Debug.WriteLine("OK");
            }
            else
            {
                Debug.WriteLine("Cancel");
            }
        }
    }
}
