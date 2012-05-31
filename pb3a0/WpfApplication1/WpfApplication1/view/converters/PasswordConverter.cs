using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string v = (string)value;
            string r = "";
            for (int i = 0; i < v.Length; ++i) r += '*';
            return r;            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
