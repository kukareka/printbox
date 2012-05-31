using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    public class PhoneNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string v = (string)value;
            string r = "";
            for (int i = 0; i < v.Length; ++i)
            {
                if (i == 0) r += '(';
                r += v[i];
                if (i == 2) r += ") ";
                if (i == 5) r += '-';
                if (i == 7) r += '-';
            }
            return r;
            /*
            while (v.Length < 10) v = v + '_';
            string code = v.Substring(0, 3), p1 = v.Substring(3, 3), p2 = v.Substring(6, 2), p3 = v.Substring(8, 2);
            return String.Format("({0}) {1}-{2}-{3}", code, p1, p2, p3);
            */
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Regex.Replace(value as string, @"[()- ]", "");
        }
    }
}
