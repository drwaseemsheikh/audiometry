using System.ComponentModel;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public enum EarType
    {
        RightEar,
        LeftEar
    }

    public enum HearingLevelTypes
    {
        [Description("TAR")]
        TestedAndResponded,
        [Description("NT")]
        NotTested,
        [Description("NR")]
        NoResponse,
        [Description("IES")]
        InitialEmptyState
    }

    public static class HearingPowerLimits
    {
        public const double MinHearingLeveldB = -10;                
        public const double MaxHearingLeveldB = 120;
    }

    public static class HearingFrequencyLimits
    {
        public const double MinHearingFreqHz = 125;
        public const double MaxHearingFreqHz = 8000;
    }

    public static class ComplianceLevelLimits
    {
        public const double MinComplianceLevel = 0;
        public const double MaxComplianceLevel = 4;
    }

    public static class CaloricTimeMinLimits
    {
        public const double MinTime = 0;
        public const double MaxTime = 4;
    }

    public static class CaloricTimeSecLimits
    {
        public const double MinTime = 0;
        public const double MaxTime = 60;
    }
}
