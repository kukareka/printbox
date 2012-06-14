using System;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for LoadingDialog.xaml
    /// </summary>
    public partial class LoadingDialog : Window
    {
        public LoadingDialog()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (App.Current as App).guiManager.Loading(false);
        }
    }
}
