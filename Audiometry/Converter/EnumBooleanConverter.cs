using System;
using System.Windows.Data;

namespace Audiometry.Converter
{
    public class EnumBooleanConverter : IValueConverter
    {
        #region IValueConverter Members        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return false; // or return parameter.Equals(YourEnumType.SomeDefaultValue);
            }

            return value.Equals(parameter);
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }

            return value.Equals(true) == true ? parameter : Binding.DoNothing;
        }
        #endregion
    }
}
