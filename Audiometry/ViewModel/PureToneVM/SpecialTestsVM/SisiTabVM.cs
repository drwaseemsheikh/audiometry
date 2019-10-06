using Audiometry.Model.SubTabModel;

namespace Audiometry.ViewModel.PureToneVM.SpecialTestsVM
{
    public class SisiTabVM : SubTabVM
    {
        #region Members
        public const int SisiTabIndex = 1;
        private double? sisiRtEar;
        private double? sisiLtEar;

        private SubTabModel sisiModel;
        #endregion

        #region Properties
        public double? SisiRtEar
        {
            get { return sisiRtEar; }
            set
            {
                if (sisiRtEar != value)
                {
                    sisiRtEar = value;
                    OnPropertyChanged("SisiRtEar");
                }
            }
        }

        public double? SisiLtEar
        {
            get { return sisiLtEar; }
            set
            {
                if (sisiLtEar != value)
                {
                    sisiLtEar = value;
                    OnPropertyChanged("SisiLtEar");
                }
            }
        }
        #endregion

        #region Methods
        public SisiTabVM()
        {
            SisiRtEar = null;
            SisiLtEar = null;

            sisiModel = new SisiModel(this);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return sisiModel.AddRecordToDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return sisiModel.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            sisiModel.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return sisiModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            SisiRtEar = null;
            SisiLtEar = null;
        }
        #endregion
    }
}
