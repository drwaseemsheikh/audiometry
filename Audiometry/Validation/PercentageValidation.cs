using System;
using System.Windows.Controls;

namespace Audiometry.Validation
{
    public class PercentageValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string percentStr = (string)value;

            if (!String.IsNullOrEmpty(percentStr))
            {
                double percent = 0;
                string validationError = "Invalid input. Percentage value must be between " + 0 + " and " + 100 + " %.";

                if (double.TryParse(percentStr, out percent))
                {
                    if ((percent < 0) || (percent > 100))
                    {
                        return new ValidationResult(false, validationError);
                    }   
                }
                else
                {
                    return new ValidationResult(false, validationError);
                }
            }

            return new ValidationResult(true, null);
        }
    }
}
