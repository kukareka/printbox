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
    /// Interaction logic for UpDown.xaml
    /// </summary>
    public partial class UpDown : UserControl
    {
        public static DependencyProperty CurrentValueProperty =
                    DependencyProperty.Register("CurrentValue", typeof(int), typeof(UpDown),
                    new PropertyMetadata(0, new PropertyChangedCallback(CurrentValueChanged)));

        public static DependencyProperty MinProperty =
                    DependencyProperty.Register("Min", typeof(int), typeof(UpDown),
                    new PropertyMetadata(0, new PropertyChangedCallback(MinChanged)));

        public static DependencyProperty MaxProperty =
                    DependencyProperty.Register("Max", typeof(int), typeof(UpDown),
                    new PropertyMetadata(0, new PropertyChangedCallback(MaxChanged)));


        public UpDown()
        {
            InitializeComponent();
            SetValue(CurrentValueProperty, 1);
            int i = (int)GetValue(CurrentValueProperty);
        }

        public int CurrentValue
        {
            get {return (int)GetValue(CurrentValueProperty);}
            set {SetValue(CurrentValueProperty, value);}
        }

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentValue < Max) CurrentValue++;
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentValue > Min) CurrentValue--;
        }

        public static void MinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpDown o = d as UpDown;
            if (o.CurrentValue < o.Min) o.CurrentValue = o.Min;
        }

        public static void MaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpDown o = d as UpDown;
            if (o.CurrentValue > o.Max) o.CurrentValue = o.Max;
        }

        public static void CurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpDown o = d as UpDown;
            o.CurrentValueTextBox.Text = o.CurrentValue.ToString();
        }
    }
}
