using System;
using System.Globalization;
using System.Windows.Controls;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Validation
{
    public class CaloricTimeMinValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string caloricStr = (string)value;

            if (!String.IsNullOrEmpty(caloricStr))
            {
                double caloric = 0;
                string validationError = "Invalid input. Caloric Time in minutes must be between " +
                         CaloricTimeMinLimits.MinTime + " and " +
                         CaloricTimeMinLimits.MaxTime + ".";

                if (double.TryParse(caloricStr, out caloric))
                {
                    if ((caloric < CaloricTimeMinLimits.MinTime) || (caloric > CaloricTimeMinLimits.MaxTime))
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
