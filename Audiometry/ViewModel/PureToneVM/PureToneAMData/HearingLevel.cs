using System;
using Audiometry.Converter;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class HearingLevel
    {
        private double? rightEarHLdB;
        private double? leftEarHLdB;
        private string rightEarHLdBStr = String.Empty;
        private string leftEarHLdBStr = String.Empty;

        public double? RightEarHLdB
        {
            get { return rightEarHLdB; }
            set
            {
                if (rightEarHLdB != value)
                {
                    rightEarHLdB = value;
                    RightEarHLdBStr = value.ToString();
                }
            }
        }
        
        public double? LeftEarHLdB
        {
            get { return leftEarHLdB; }
            set
            {
                if (leftEarHLdB != value)
                {
                    leftEarHLdB = value;
                    LeftEarHLdBStr = value.ToString();
                }
            }
        }

        public string RightEarHLdBStr
        {
            get { return rightEarHLdBStr; }
            set
            {
                if (rightEarHLdBStr != value)
                {
                    rightEarHLdBStr = value;
                    rightEarHLdB = ConvertHLStringToDouble(value);
                }
            }
        }

        public string LeftEarHLdBStr
        {
            get { return leftEarHLdBStr; }
            set
            {
                if (leftEarHLdBStr != value)
                {
                    leftEarHLdBStr = value;
                    leftEarHLdB = ConvertHLStringToDouble(value);
                }
            }
        }

        private double? ConvertHLStringToDouble(string hearingLevelStr)
        {
            if (String.IsNullOrEmpty(hearingLevelStr) || 
                String.IsNullOrWhiteSpace(hearingLevelStr) || 
                hearingLevelStr.Equals(HearingLevelTypes.NotTested.GetDescription(), StringComparison.CurrentCultureIgnoreCase) || 
                (hearingLevelStr.Equals(HearingLevelTypes.NoResponse.GetDescription(), StringComparison.CurrentCultureIgnoreCase)))
            {
                return null;
            }
            else
            {
                return double.Parse(hearingLevelStr);
            }
        }
    }
}
