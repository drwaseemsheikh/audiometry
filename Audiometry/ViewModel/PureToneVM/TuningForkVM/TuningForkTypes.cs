using System.ComponentModel;

namespace Audiometry.ViewModel.PureToneVM.TuningForkVM
{
    public static class TuningForkTypes
    {
        #region Types
        public enum Weber
        {
            [Description("")]
            WBR_NOT_SET,
            [Description("Centralized")]
            WBR_CENTRALIZED,
            [Description("Lateralized to right")]
            WBR_LATERALIZED_TO_RIGHT,
            [Description("Lateralized to left")]
            WBR_LATERALIZED_TO_LEFT,
            [Description("No response")]
            WBR_NO_RESPONSE
        }

        public enum Rinne
        {
            [Description("")]
            RNE_NOT_SET,
            [Description("Positive")]
            RNE_POSITIVE,
            [Description("Negative")]
            RNE_NEGATIVE,
            [Description("Reduced")]
            RNE_REDUCED
        }

        public enum Schwabach
        {
            [Description("")]
            SWB_NOT_SET,
            [Description("Equal to normal")]
            SWB_EQUAL_TO_NORMAL,
            [Description("Prolonged")]
            SWB_PROLONGED
        }

        public enum AbsBoneCond
        {
            [Description("")]
            ABC_NOT_SET,
            [Description("Equal to normal")]
            ABC_EQUAL_TO_NORMAL,
            [Description("Reduced")]
            ABC_REDUCED
        }

        public enum Stenger
        {
            [Description("")]
            STG_NOT_SET,
            [Description("Positive")]
            STGR_POSITIVE,
            [Description("Negative")]
            STGR_NEGATIVE
        }

        public enum Teal
        {
            [Description("")]
            TEAL_NOT_SET,
            [Description("Positive")]
            TEAL_POSITIVE,
            [Description("Negative")]
            TEAL_NEGATIVE
        }

        public enum Gelle
        {
            [Description("")]
            GELLE_NOT_SET,
            [Description("Positive")]
            GELLE_POSITIVE,
            [Description("Negative")]
            GELLE_NEGATIVE
        }
        #endregion
    }
}
