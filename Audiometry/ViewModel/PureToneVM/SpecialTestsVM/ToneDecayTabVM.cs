using Audiometry.Model.SubTabModel;

namespace Audiometry.ViewModel.PureToneVM.SpecialTestsVM
{
    public class ToneDecayTabVM : SubTabVM
    {
        #region Members
        public const int ToneDecayTabIndex = 2;
        private double? tdRtEar;
        private double? tdLtEar;

        private SubTabModel tdModel;
        #endregion

        #region Properties
        public double? TdRtEar
        {
            get { return tdRtEar; }
            set
            {
                if (tdRtEar != value)
                {
                    tdRtEar = value;
                    OnPropertyChanged("TdRtEar");
                }
            }
        }

        public double? TdLtEar
        {
            get { return tdLtEar; }
            set
            {
                if (tdLtEar != value)
                {
                    tdLtEar = value;
                    OnPropertyChanged("TdLtEar");
                }
            }
        }
        #endregion

        #region Methods
        public ToneDecayTabVM()
        {
            TdRtEar = null;
            TdLtEar = null;

            tdModel = new ToneDecayModel(this);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return tdModel.AddRecordToDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return tdModel.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            tdModel.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return tdModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            TdRtEar = null;
            TdLtEar = null;
        }
        #endregion
    }
}
