using System;
using System.Globalization;
using System.Windows.Controls;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Validation
{
    public class ComplianceValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string compStr = (string)value;

            if (!String.IsNullOrEmpty(compStr))
            {
                double compliance = 0;
                string validationError = "Invalid input. Compliance level must be between " +
                         ComplianceLevelLimits.MinComplianceLevel + " and " +
                         ComplianceLevelLimits.MaxComplianceLevel + ".";

                if (double.TryParse(compStr, out compliance))
                {
                    if ((compliance < ComplianceLevelLimits.MinComplianceLevel) || (compliance > ComplianceLevelLimits.MaxComplianceLevel))
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
