using System;
using System.Globalization;
using System.Windows.Controls;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Validation
{
    public class CaloricTimeSecValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string caloricStr = (string)value;

            if (!String.IsNullOrEmpty(caloricStr))
            {
                double caloric = 0;
                string validationError = "Invalid input. Caloric Time in seconds must be between " +
                         CaloricTimeSecLimits.MinTime + " and " +
                         CaloricTimeSecLimits.MaxTime + ".";

                if (double.TryParse(caloricStr, out caloric))
                {
                    if ((caloric < CaloricTimeSecLimits.MinTime) || (caloric > CaloricTimeSecLimits.MaxTime))
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
