using System;
using System.Windows.Controls;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Validation
{
    public class HearingLevelValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string hearingLevelStr = (string)value;
            double hearingLevel = 0;

            if (hearingLevelStr == null)
            {
                return new ValidationResult(true, null);
            }
            else if (hearingLevelStr.Equals(HearingLevelTypes.NotTested.GetDescription(), StringComparison.CurrentCultureIgnoreCase) ||
                hearingLevelStr.Equals(HearingLevelTypes.NoResponse.GetDescription(), StringComparison.CurrentCultureIgnoreCase))
            {
                return new ValidationResult(true, null);
            }
            else if (double.TryParse(hearingLevelStr, out hearingLevel))
            {
                if ((hearingLevel >= HearingPowerLimits.MinHearingLeveldB) && (hearingLevel <= HearingPowerLimits.MaxHearingLeveldB))
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Invalid input. Hearing level must be between " +
                        HearingPowerLimits.MinHearingLeveldB + " and " + HearingPowerLimits.MaxHearingLeveldB + " dB.");
                }

            }
            else
            {
                return new ValidationResult(false, "Invalid input. Valid values include numbers, NT (not tested), or NR (no response).");
            }
        }
    }
}
