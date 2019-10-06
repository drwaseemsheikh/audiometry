using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMVM;
using Audiometry.ViewModel.PureToneVM.SpecialTestsVM;
using Audiometry.ViewModel.PureToneVM.TuningForkVM;

namespace Audiometry.ViewModel.PureToneVM
{
    public class PureToneTabVM : TabVM
    {
        #region Members
        private const int ACMskTabIndex = 0;
        private const int ACUmskTabIndex = 1;
        private const int BCMskTabIndex = 2;
        private const int BCUmskTabIndex = 3;
        private const int ACAidedTabIndex = 4;
        private const int LoudnessTabIndex = 5;
        private const int SoundFieldTabIndex = 6;
        private SortedDictionary<int, PureToneAMTabVM> ptamTabDict;
        private DateTime dateOfExam;
        private bool isPureToneTestConducted;
        private bool isSpecialTestConducted;
        #endregion

        #region Properties
        public ObservableCollection<PureToneAMTabVM> PureToneAMTabs { get; private set; }
        public PureToneAMTabVM ACMskTabVM { get; private set; }
        public PureToneAMTabVM ACUmskTabVM { get; private set; }
        public PureToneAMTabVM BCMskTabVM { get; private set; }
        public PureToneAMTabVM BCUmskTabVM { get; private set; }
        public PureToneAMTabVM ACAidedTabVM { get; private set; }
        public PureToneAMTabVM LoudnessTabVM { get; private set; }
        public PureToneAMTabVM SoundFieldTabVM { get; private set; }

        public AblbTabVM AblbTabVM { get; private set; }
        public SisiTabVM SisiTabVM { get; private set; }
        public ToneDecayTabVM ToneDecayTabVM { get; private set; }
        public StengerTabVM StengerTabVM { get; private set; }

        public TuningForkTestsVM TuningForkVM { get; private set; }


        public DateTime DateOfExam
        {
            get { return dateOfExam; }
            set
            {
                if (!dateOfExam.Equals(value))
                {
                    dateOfExam = value;
                    OnPropertyChanged("DateOfExam");
                }
            }
        }

        public bool IsPureToneTestConducted
        {
            get { return isPureToneTestConducted; }
            set
            {
                if (isPureToneTestConducted != value)
                {
                    isPureToneTestConducted = value;
                    OnPropertyChanged("IsPureToneTestConducted");
                }
            }
        }

        public bool IsSpecialTestConducted
        {
            get { return isSpecialTestConducted; }
            set
            {
                if (isSpecialTestConducted != value)
                {
                    isSpecialTestConducted = value;
                    OnPropertyChanged("IsSpecialTestConducted");
                }
            }
        }
        #endregion

        #region Methods
        public PureToneTabVM()
        {
            ACMskTabVM = new AirCondMskVM();
            ACUmskTabVM = new AirCondUmskVM();
            BCMskTabVM = new BoneCondMskVM();
            BCUmskTabVM = new BoneCondUmskVM();
            ACAidedTabVM = new AirCondAidVM();
            LoudnessTabVM = new LoudDiscomLvlVM();
            SoundFieldTabVM = new SoundFieldVM();

            ptamTabDict = new SortedDictionary<int, PureToneAMTabVM>();
            ptamTabDict[ACMskTabIndex] = ACMskTabVM;
            ptamTabDict[ACUmskTabIndex] = ACUmskTabVM;
            ptamTabDict[BCMskTabIndex] = BCMskTabVM;
            ptamTabDict[BCUmskTabIndex] = BCUmskTabVM;
            ptamTabDict[ACAidedTabIndex] = ACAidedTabVM;
            ptamTabDict[LoudnessTabIndex] = LoudnessTabVM;
            ptamTabDict[SoundFieldTabIndex] = SoundFieldTabVM;
            PureToneAMTabs = new ObservableCollection<PureToneAMTabVM>(ptamTabDict.Values);
            AblbTabVM = new AblbTabVM();
            SisiTabVM = new SisiTabVM();
            ToneDecayTabVM = new ToneDecayTabVM();
            StengerTabVM = new StengerTabVM();
            TuningForkVM = new TuningForkTestsVM();

            DateOfExam = DateTime.Now;
            IsPureToneTestConducted = false;
            IsSpecialTestConducted = false;
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            string error;
            bool success = ACMskTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ACUmskTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = BCMskTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = BCUmskTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ACAidedTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = LoudnessTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = SoundFieldTabVM.AddRecordToDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = AblbTabVM.AddRecordToDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = SisiTabVM.AddRecordToDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ToneDecayTabVM.AddRecordToDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = StengerTabVM.AddRecordToDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = TuningForkVM.AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            msg = string.Empty;
            return true;
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            string error;
            bool success = ACMskTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ACUmskTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = BCMskTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = BCUmskTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ACAidedTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = LoudnessTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = SoundFieldTabVM.UpdateRecordInDatabase(accNumber, examDate, isPureToneTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = AblbTabVM.UpdateRecordInDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = SisiTabVM.UpdateRecordInDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = ToneDecayTabVM.UpdateRecordInDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = StengerTabVM.UpdateRecordInDatabase(accNumber, examDate, isSpecialTestConducted, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = TuningForkVM.UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            msg = string.Empty;
            return true;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            bool ptTestConducted;
            bool stTestConducted;
            ACMskTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            ACUmskTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            BCMskTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            BCUmskTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            ACAidedTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            LoudnessTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            SoundFieldTabVM.OpenRecordFromDatabase(accNumber, examDate, out ptTestConducted);
            IsPureToneTestConducted = ptTestConducted;

            AblbTabVM.OpenRecordFromDatabase(accNumber, examDate, out stTestConducted);
            SisiTabVM.OpenRecordFromDatabase(accNumber, examDate, out stTestConducted);
            ToneDecayTabVM.OpenRecordFromDatabase(accNumber, examDate, out stTestConducted);
            StengerTabVM.OpenRecordFromDatabase(accNumber, examDate, out stTestConducted);
            TuningForkVM.OpenRecordFromDatabase(accNumber, examDate);
            IsSpecialTestConducted = stTestConducted;
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            bool acmskDel = ACMskTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool acumskDel = ACUmskTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool bcmskDel = BCMskTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool bcumskDel = BCUmskTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool acaidDel = ACAidedTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool loudDel = LoudnessTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool soundDel = SoundFieldTabVM.DeleteRecordFromDatabase(accNumber, examDate);

            bool ablbDel = AblbTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool sisiDel = SisiTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool tonedecayDel = ToneDecayTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool stengerDel = StengerTabVM.DeleteRecordFromDatabase(accNumber, examDate);
            bool tuningforkDel = TuningForkVM.DeleteRecordFromDatabase(accNumber, examDate);

            return (acmskDel || acumskDel || bcmskDel || bcumskDel || acaidDel || loudDel || soundDel ||
                ablbDel || sisiDel || tonedecayDel || stengerDel || tuningforkDel);
        }

        public override void InitializeProperties()
        {
            ACMskTabVM.InitializeProperties();
            ACUmskTabVM.InitializeProperties();
            BCMskTabVM.InitializeProperties();
            BCUmskTabVM.InitializeProperties();
            ACAidedTabVM.InitializeProperties();
            LoudnessTabVM.InitializeProperties();
            SoundFieldTabVM.InitializeProperties();
            IsPureToneTestConducted = false;

            AblbTabVM.InitializeProperties();
            SisiTabVM.InitializeProperties();
            ToneDecayTabVM.InitializeProperties();
            StengerTabVM.InitializeProperties();
            TuningForkVM.InitializeProperties();
            IsSpecialTestConducted = false;
        }
        #endregion
    }
}
