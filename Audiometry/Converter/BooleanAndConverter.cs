using System;
using System.Globalization;
using System.Windows.Data;

namespace Audiometry.Converter
{
    public class BooleanAndConverter : IMultiValueConverter
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
            int paramInt = System.Convert.ToInt32(parameter);
            object[] convValues = new object[paramInt];
            
            for (int i = 0; i < paramInt; i++)
            {
                convValues[i] = value;
            }  

            return convValues;
        }
    }
}
