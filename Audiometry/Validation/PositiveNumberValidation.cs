using System;
using System.Windows.Controls;

namespace Audiometry.Validation
{
    public class PositiveNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string numStr = (string)value;

            if (!String.IsNullOrEmpty(numStr))
            {
                uint num = 0;
                string validationError = "Invalid input. Account number must be a number.";

                if (!uint.TryParse(numStr, out num))
                {
                    return new ValidationResult(false, validationError);
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
