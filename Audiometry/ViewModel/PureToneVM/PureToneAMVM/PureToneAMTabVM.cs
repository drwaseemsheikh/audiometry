using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public abstract class PureToneAMTabVM : SubTabVM
    {
        #region Properties
        public string TabTitle { get; set; }
        public PureToneData PureToneData { get; set; }
        #endregion

        #region Methods
        protected PureToneAMTabVM()
        {
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            string error;
            bool success = PureToneData.AddRecordToDatabase(accNumber, examDate, testConducted, out error);

            if (success)
            {
                msg = string.Empty;
                return true;   
            }
            else
            {
                msg = error;
                return false;
            }
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            string error;
            bool success = PureToneData.UpdateRecordInDatabase(accNumber, examDate, testConducted, out error);

            if (success)
            {
                msg = string.Empty;
                return true;
            }
            else
            {
                msg = error;
                return false;
            }
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            PureToneData.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return PureToneData.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            PureToneData.InitializeProperties();
        }
        #endregion
    }
}
