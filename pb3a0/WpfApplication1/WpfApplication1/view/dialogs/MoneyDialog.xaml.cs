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
    /// Interaction logic for MoneyDialog.xaml
    /// </summary>
    public partial class MoneyDialog : Window
    {
        App app = App.Current as App;
        public MoneyDialog(Window owner)
        {
            this.Owner = owner;
            DataContext = (App.Current as App).sessionInfo;
            InitializeComponent();            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
