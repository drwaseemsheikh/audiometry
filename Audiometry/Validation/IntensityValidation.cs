using System;
using System.Globalization;
using System.Windows.Controls;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Validation
{
    public class IntensityValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string intensityStr = (string)value;

            if (!String.IsNullOrEmpty(intensityStr))
            {
                double intensity = 0;
                string validationError = "Invalid input. Intensity level must be between " +
                         HearingPowerLimits.MinHearingLeveldB + " and " +
                         HearingPowerLimits.MaxHearingLeveldB + " dB.";

                if (double.TryParse(intensityStr, out intensity))
                {
                    if ((intensity < HearingPowerLimits.MinHearingLeveldB) || (intensity > HearingPowerLimits.MaxHearingLeveldB))
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
