using Audiometry.Model.TabModel;

namespace Audiometry.ViewModel.PureToneVM.TuningForkVM
{
    public class TuningForkTestsVM : TabVM
    {
        #region Members
        private bool isTestConducted;
        private TuningForkTypes.Weber wbr512RtEar;
        private TuningForkTypes.Weber wbr512LtEar;
        private TuningForkTypes.Rinne rn256RtEar;
        private TuningForkTypes.Rinne rn256LtEar;
        private TuningForkTypes.Rinne rn512RtEar;
        private TuningForkTypes.Rinne rn512LtEar;
        private TuningForkTypes.Rinne rn1024RtEar;
        private TuningForkTypes.Rinne rn1024LtEar;
        private TuningForkTypes.Schwabach swbRtEar;
        private TuningForkTypes.Schwabach swbLtEar;
        private TuningForkTypes.AbsBoneCond abcRtEar;
        private TuningForkTypes.AbsBoneCond abcLtEar;
        private TuningForkTypes.Stenger stgRtEar;
        private TuningForkTypes.Stenger stgLtEar;
        private TuningForkTypes.Teal tlRtEar;
        private TuningForkTypes.Teal tlLtEar;
        private TuningForkTypes.Gelle glRtEar;
        private TuningForkTypes.Gelle glLtEar;

        private TabModel tfModel;
        #endregion

        #region Properties

        public bool IsTestConducted
        {
            get { return isTestConducted; }
            set
            {
                if (isTestConducted != value)
                {
                    isTestConducted = value;
                    OnPropertyChanged("IsTestConducted");
                }
            }
        }

        public TuningForkTypes.Weber Wbr512RtEar
        {
            get { return wbr512RtEar; }
            set
            {
                if (wbr512RtEar != value)
                {
                    wbr512RtEar = value;
                    OnPropertyChanged("Wbr512RtEar");
                }
            }
        }

        public TuningForkTypes.Weber Wbr512LtEar
        {
            get { return wbr512LtEar; }
            set
            {
                if (wbr512LtEar != value)
                {
                    wbr512LtEar = value;
                    OnPropertyChanged("Wbr512LtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn256RtEar
        {
            get { return rn256RtEar; }
            set
            {
                if (rn256RtEar != value)
                {
                    rn256RtEar = value;
                    OnPropertyChanged("Rn256RtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn256LtEar
        {
            get { return rn256LtEar; }
            set
            {
                if (rn256LtEar != value)
                {
                    rn256LtEar = value;
                    OnPropertyChanged("Rn256LtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn512RtEar
        {
            get { return rn512RtEar; }
            set
            {
                if (rn512RtEar != value)
                {
                    rn512RtEar = value;
                    OnPropertyChanged("Rn512RtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn512LtEar
        {
            get { return rn512LtEar; }
            set
            {
                if (rn512LtEar != value)
                {
                    rn512LtEar = value;
                    OnPropertyChanged("Rn512LtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn1024RtEar
        {
            get { return rn1024RtEar; }
            set
            {
                if (rn1024RtEar != value)
                {
                    rn1024RtEar = value;
                    OnPropertyChanged("Rn1024RtEar");
                }
            }
        }

        public TuningForkTypes.Rinne Rn1024LtEar
        {
            get { return rn1024LtEar; }
            set
            {
                if (rn1024LtEar != value)
                {
                    rn1024LtEar = value;
                    OnPropertyChanged("Rn1024LtEar");
                }
            }
        }

        public TuningForkTypes.Schwabach SwbRtEar
        {
            get { return swbRtEar; }
            set
            {
                if (swbRtEar != value)
                {
                    swbRtEar = value;
                    OnPropertyChanged("SwbRtEar");
                }
            }
        }

        public TuningForkTypes.Schwabach SwbLtEar
        {
            get { return swbLtEar; }
            set
            {
                if (swbLtEar != value)
                {
                    swbLtEar = value;
                    OnPropertyChanged("SwbLtEar");
                }
            }
        }

        public TuningForkTypes.AbsBoneCond AbcRtEar
        {
            get { return abcRtEar; }
            set
            {
                if (abcRtEar != value)
                {
                    abcRtEar = value;
                    OnPropertyChanged("AbcRtEar");
                }
            }
        }

        public TuningForkTypes.AbsBoneCond AbcLtEar
        {
            get { return abcLtEar; }
            set
            {
                if (abcLtEar != value)
                {
                    abcLtEar = value;
                    OnPropertyChanged("AbcLtEar");
                }
            }
        }

        public TuningForkTypes.Stenger StgRtEar
        {
            get { return stgRtEar; }
            set
            {
                if (stgRtEar != value)
                {
                    stgRtEar = value;
                    OnPropertyChanged("StgRtEar");
                }
            }
        }

        public TuningForkTypes.Stenger StgLtEar
        {
            get { return stgLtEar; }
            set
            {
                if (stgLtEar != value)
                {
                    stgLtEar = value;
                    OnPropertyChanged("StgLtEar");
                }
            }
        }

        public TuningForkTypes.Teal TlRtEar
        {
            get { return tlRtEar; }
            set
            {
                if (tlRtEar != value)
                {
                    tlRtEar = value;
                    OnPropertyChanged("TlRtEar");
                }
            }
        }

        public TuningForkTypes.Teal TlLtEar
        {
            get { return tlLtEar; }
            set
            {
                if (tlLtEar != value)
                {
                    tlLtEar = value;
                    OnPropertyChanged("TlLtEar");
                }
            }
        }

        public TuningForkTypes.Gelle GlRtEar
        {
            get { return glRtEar; }
            set
            {
                if (glRtEar != value)
                {
                    glRtEar = value;
                    OnPropertyChanged("GlRtEar");
                }
            }
        }

        public TuningForkTypes.Gelle GlLtEar
        {
            get { return glLtEar; }
            set
            {
                if (glLtEar != value)
                {
                    glLtEar = value;
                    OnPropertyChanged("GlLtEar");
                }
            }
        }
        #endregion

        #region Methods
        public TuningForkTestsVM()
        {
            IsTestConducted = false;
            Wbr512RtEar = TuningForkTypes.Weber.WBR_NOT_SET;
            Wbr512LtEar = TuningForkTypes.Weber.WBR_NOT_SET;
            Rn256RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn256LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn512RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn512LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn1024RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn1024LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            SwbRtEar = TuningForkTypes.Schwabach.SWB_NOT_SET;
            SwbLtEar = TuningForkTypes.Schwabach.SWB_NOT_SET;
            AbcRtEar = TuningForkTypes.AbsBoneCond.ABC_NOT_SET;
            AbcLtEar = TuningForkTypes.AbsBoneCond.ABC_NOT_SET;
            StgRtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            StgLtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            TlRtEar = TuningForkTypes.Teal.TEAL_NOT_SET;
            TlLtEar = TuningForkTypes.Teal.TEAL_NOT_SET;
            GlRtEar = TuningForkTypes.Gelle.GELLE_NOT_SET;
            GlLtEar = TuningForkTypes.Gelle.GELLE_NOT_SET;

            tfModel = new TuningForkModel(this);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            return tfModel.AddRecordToDatabase(accNumber, examDate, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            return tfModel.UpdateRecordInDatabase(accNumber, examDate, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            tfModel.OpenRecordFromDatabase(accNumber, examDate);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return tfModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            IsTestConducted = false;
            Wbr512RtEar = TuningForkTypes.Weber.WBR_NOT_SET;
            Wbr512LtEar = TuningForkTypes.Weber.WBR_NOT_SET;
            Rn256RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn256LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn512RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn512LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn1024RtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            Rn1024LtEar = TuningForkTypes.Rinne.RNE_NOT_SET;
            SwbRtEar = TuningForkTypes.Schwabach.SWB_NOT_SET;
            SwbLtEar = TuningForkTypes.Schwabach.SWB_NOT_SET;
            AbcRtEar = TuningForkTypes.AbsBoneCond.ABC_NOT_SET;
            AbcLtEar = TuningForkTypes.AbsBoneCond.ABC_NOT_SET;
            StgRtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            StgLtEar = TuningForkTypes.Stenger.STG_NOT_SET;
            TlRtEar = TuningForkTypes.Teal.TEAL_NOT_SET;
            TlLtEar = TuningForkTypes.Teal.TEAL_NOT_SET;
            GlRtEar = TuningForkTypes.Gelle.GELLE_NOT_SET;
            GlLtEar = TuningForkTypes.Gelle.GELLE_NOT_SET;
        }
        #endregion
    }
}
