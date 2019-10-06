using System;
using System.Globalization;
using System.Windows.Data;

namespace Audiometry.Converter
{
    public class BooleanOrConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var entry in values)
            {
                bool value = (bool)entry;

                if (value)
                {
                    return true; 
                }
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
