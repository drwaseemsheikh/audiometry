using System;
using System.Globalization;
using System.Windows.Data;

namespace Audiometry.Converter
{
    public class FormattedStringToNullableDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? d = (double?)value;

            if (d.HasValue)
            {
                return d.Value.ToString("F2");
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;

            if (String.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return (double?)Double.Parse(s, culture);
            }
        }
    }
}
