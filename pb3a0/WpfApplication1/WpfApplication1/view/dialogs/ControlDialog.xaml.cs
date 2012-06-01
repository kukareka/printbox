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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ControlDialog.xaml
    /// </summary>
    public partial class ControlDialog : Window
    {
        OpenFileDialog openFileDlg = new OpenFileDialog();
        App app = Application.Current as App;

        public ControlDialog()
        {
            InitializeComponent();
            openFileDlg.Filter = "Documents|*.doc;*.docx;*.rtf";
        }

        #region Event handlers
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDlg.ShowDialog() == false) return;

            app.LoadDocument(openFileDlg.FileName);
        }

        private void PromptButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Prompt("message", (FlowDocument)app.FindResource("commentEnterPhone"), new PhoneNumberConverter(), 10);
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.Prompt("message", (FlowDocument)app.FindResource("commentEnterPassword"), new PasswordConverter(), 10);
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
    }
}
