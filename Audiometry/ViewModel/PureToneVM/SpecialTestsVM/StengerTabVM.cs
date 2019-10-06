using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.TuningForkVM;

namespace Audiometry.ViewModel.PureToneVM.SpecialTestsVM
{
    public class StengerTabVM : SubTabVM
    {
        #region Members
        public const int StengerTabIndex = 3;
        private TuningForkTypes.Stenger stgrRtEar;
        private TuningForkTypes.Stenger stgrLtEar;

        private SubTabModel stgModel;
        #endregion

        #region Properties
        public TuningForkTypes.Stenger StgrRtEar
        {
            get { return stgrRtEar; }
            set
            {
                if (stgrRtEar != value)
                {
                    stgrRtEar = value;
                    OnPropertyChanged("StgrRtEar");
                }
            }
        }

        public TuningForkTypes.Stenger StgrLtEar
        {
            get { return stgrLtEar; }
            set
            {
                if (stgrLtEar != value)
                {
                    stgrLtEar = value;
                    OnPropertyChanged("StgrLtEar");
                }
            }
        }
        #endregion

        #region Methods
        public StengerTabVM()
        {
            StgrRtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            StgrLtEar = TuningForkTypes.Stenger.STG_NOT_SET;

            stgModel = new StengerModel(this);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return stgModel.AddRecordToDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return stgModel.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            stgModel.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return stgModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            StgrRtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            StgrLtEar = TuningForkTypes.Stenger.STG_NOT_SET;
        }
        #endregion
    }
}
