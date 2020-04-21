using System;
using System.Windows.Controls;

namespace Audiometry.Validation
{
    public class PositiveNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string numStr = (string)value;

            if (numStr != null)
            {
                uint num = 0;
                string validationError = "A valid account number must be provided. Valid values include all positive numbers.";

                if (!uint.TryParse(numStr, out num))
                {
                    return new ValidationResult(false, validationError);
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
