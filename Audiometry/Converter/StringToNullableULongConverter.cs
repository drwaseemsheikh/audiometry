using System;
using System.Globalization;
using System.Windows.Data;

namespace Audiometry.Converter
{
    public class StringToNullableULongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ulong? d = (ulong?)value;

            if (d.HasValue)
            {
                return d.Value.ToString(culture);
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
                return (ulong?) ulong.Parse(s, culture);
            }
        }
    }
}
