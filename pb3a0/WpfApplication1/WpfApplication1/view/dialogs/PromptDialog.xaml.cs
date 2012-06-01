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
using System.Windows.Markup;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PromptDialog.xaml
    /// </summary>
    public partial class PromptDialog : Window
    {
        App app = App.Current as App;

        public PromptDialog(string message, FlowDocument comment, IValueConverter converter, int length)
        {
            InitializeComponent();
            Message.Text = message;
            Comment.Document = comment;
            this.Keypad.DesiredTextLength = length;
            Binding valueBinding = new Binding();
            valueBinding.Source = this.Keypad;
            valueBinding.Path = new PropertyPath("Text");
            valueBinding.Mode = BindingMode.OneWay;
            valueBinding.Converter = converter;
            Value.SetBinding(TextBox.TextProperty, valueBinding);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Comment.Document = new FlowDocument();
        }
    }
}
