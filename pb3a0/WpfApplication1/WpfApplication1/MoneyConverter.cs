using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace WpfApplication1
{
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((float)(int)value / 100).ToString("F2");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)(float.Parse((string)value) * 100);
        }
    }
}
