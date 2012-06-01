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
        #region Constructors
        public Keypad()
        {
            InitializeComponent();
        }
        #endregion

        #region Events

        #region OK
        public static RoutedEvent OKEvent = EventManager.RegisterRoutedEvent("OK", RoutingStrategy.Bubble,
                    typeof(RoutedEventHandler), typeof(Keypad));
        public event RoutedEventHandler OK
        {
            add { AddHandler(OKEvent, value); }
            remove { RemoveHandler(OKEvent, value); }
        }

        protected virtual void OnOK()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = OKEvent;
            RaiseEvent(args);
        }
        #endregion

        #region Cancel
        public static RoutedEvent CancelEvent = EventManager.RegisterRoutedEvent("Cancel", RoutingStrategy.Bubble,
                    typeof(RoutedEventHandler), typeof(Keypad));
        public event RoutedEventHandler Cancel
        {
            add { AddHandler(CancelEvent, value); }
            remove { RemoveHandler(CancelEvent, value); }
        }

        protected virtual void OnCancel()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = CancelEvent;
            RaiseEvent(args);
        }
        #endregion

        #endregion
        
        #region Properties

        #region Text
        public static DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Keypad), new PropertyMetadata("", new PropertyChangedCallback(TextLengthChanged)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static void TextLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Keypad k = d as Keypad;
            if (k.DesiredTextLength != -1)
            {
                if (k.Text.Length > k.DesiredTextLength) k.Text = k.Text.Remove(k.DesiredTextLength);
                k.OKButton.IsEnabled = !(k.Text.Length < k.DesiredTextLength);
                k.KeysGrid.IsEnabled = !k.OKButton.IsEnabled;

            }
        }
        #endregion

        #region DesiredTextLength
        public static DependencyProperty DesiredTextLengthProperty =
            DependencyProperty.Register("DesiredTextLength", typeof(int), typeof(Keypad), new PropertyMetadata(-1, new PropertyChangedCallback(TextLengthChanged)));

        public int DesiredTextLength
        {
            get { return (int)GetValue(DesiredTextLengthProperty); }
            set { SetValue(DesiredTextLengthProperty, value); }
        }
        #endregion

        #endregion
        
        #region Event handlers

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Text += (sender as Button).Content.ToString();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Length > 0) Text = Text.Remove(Text.Length - 1);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            OnOK();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OnCancel();
        }

        #endregion
    }
}
