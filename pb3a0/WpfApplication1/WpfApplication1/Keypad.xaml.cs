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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Keypad.xaml
    /// </summary>
    public partial class Keypad : UserControl
    {
        public static DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Keypad));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Keypad()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Text += (sender as Button).Content.ToString();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Length > 0) Text = Text.Remove(Text.Length - 1);
        }
    }
}
