using System;
using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class AirCondUmskData : PureToneData
    {
        #region Members
        private double? avgSpPerRtEar;
        private double? impairRtEar;
        private double? avgSpPerLtEar;
        private double? impairLtEar;
        private double? disability;
        #endregion

        #region Properties
        public override string RtEarHLdB500Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 500); }
            set
            {
                SetHearingLevel(EarType.RightEar, 500, value);
                UpdateAvgSpPercImpairDisability(EarType.RightEar);
                OnPropertyChanged("RtEarHLdB500Hz");
            }
        }

        public override string RtEarHLdB1000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 1000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 1000, value);
                UpdateAvgSpPercImpairDisability(EarType.RightEar);
                OnPropertyChanged("RtEarHLdB1000Hz");
            }
        }

        public override string RtEarHLdB2000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 2000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 2000, value);
                UpdateAvgSpPercImpairDisability(EarType.RightEar);
                OnPropertyChanged("RtEarHLdB2000Hz");
            }
        }

        public override string RtEarHLdB3000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 3000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 3000, value);
                UpdateAvgSpPercImpairDisability(EarType.RightEar);
                OnPropertyChanged("RtEarHLdB3000Hz");
            }
        }

        public override string LtEarHLdB500Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 500); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 500, value);
                UpdateAvgSpPercImpairDisability(EarType.LeftEar);
                OnPropertyChanged("LtEarHLdB500Hz");
            }
        }

        public override string LtEarHLdB1000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 1000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 1000, value);
                UpdateAvgSpPercImpairDisability(EarType.LeftEar);
                OnPropertyChanged("LtEarHLdB1000Hz");
            }
        }

        public override string LtEarHLdB2000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 2000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 2000, value);
                UpdateAvgSpPercImpairDisability(EarType.LeftEar);
                OnPropertyChanged("LtEarHLdB2000Hz");
            }
        }

        public override string LtEarHLdB3000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 3000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 3000, value);
                UpdateAvgSpPercImpairDisability(EarType.LeftEar);
                OnPropertyChanged("LtEarHLdB3000Hz");
            }
        }

        public double? AvgSpPerRtEar
        {
            get { return avgSpPerRtEar; }
            set
            {
                if (avgSpPerRtEar != value)
                {
                    avgSpPerRtEar = value;
                    OnPropertyChanged("AvgSpPerRtEar");
                }
            }
        }

        public double? ImpairRtEar
        {
            get { return impairRtEar; }
            set
            {
                if (impairRtEar != value)
                {
                    impairRtEar = value;
                    OnPropertyChanged("ImpairRtEar");
                }
            }
        }

        public double? AvgSpPerLtEar
        {
            get { return avgSpPerLtEar; }
            set
            {
                if (avgSpPerLtEar != value)
                {
                    avgSpPerLtEar = value;
                    OnPropertyChanged("AvgSpPerLtEar");
                }
            }
        }

        public double? ImpairLtEar
        {
            get { return impairLtEar; }
            set
            {
                if (impairLtEar != value)
                {
                    impairLtEar = value;
                    OnPropertyChanged("ImpairLtEar");
                }
            }
        }

        public double? Disability
        {
            get { return disability; }
            set
            {
                if (disability != value)
                {
                    disability = value;
                    OnPropertyChanged("Disability");
                }
            }
        }
        #endregion

        #region Methods
        public AirCondUmskData()
        {
            AddBCFreqShift = false;
            AudiogramPlot = new AirCondUmskPlot();
            ptDataModel = new AirCondUmskDataModel(this);
        }

        private void UpdateAvgSpPercImpairDisability(EarType earType)
        {
            double? th500;
            double? th1000;
            double? th2000;
            double? th3000;

            if (earType == EarType.RightEar)
            {
                if (HearingLevels.ContainsKey(500) && HearingLevels.ContainsKey(1000) &&
                    HearingLevels.ContainsKey(2000) && HearingLevels.ContainsKey(3000))
                {
                    th500 = HearingLevels[500].RightEarHLdB;
                    th1000 = HearingLevels[1000].RightEarHLdB;
                    th2000 = HearingLevels[2000].RightEarHLdB;
                    th3000 = HearingLevels[3000].RightEarHLdB;

                    if (th500 != null && th1000 != null && th2000 != null && th3000 != null)
                    {
                        AvgSpPerRtEar = (th500.Value + th1000.Value + th2000.Value + th3000.Value) / 4;

                        if (AvgSpPerRtEar > 25)
                        {
                            ImpairRtEar = (AvgSpPerRtEar - 25) * 1.5;   
                        }
                        else
                        {
                            ImpairRtEar = 0;
                        }
                    }
                }
            }
            else if (earType == EarType.LeftEar)
            {
                if (HearingLevels.ContainsKey(500) && HearingLevels.ContainsKey(1000) &&
                    HearingLevels.ContainsKey(2000) && HearingLevels.ContainsKey(3000))
                {
                    th500 = HearingLevels[500].LeftEarHLdB;
                    th1000 = HearingLevels[1000].LeftEarHLdB;
                    th2000 = HearingLevels[2000].LeftEarHLdB;
                    th3000 = HearingLevels[3000].LeftEarHLdB;

                    if (th500 != null && th1000 != null && th2000 != null && th3000 != null)
                    {
                        AvgSpPerLtEar = (th500.Value + th1000.Value + th2000.Value + th3000.Value) / 4;

                        if (AvgSpPerLtEar > 25)
                        {
                            ImpairLtEar = (AvgSpPerLtEar - 25) * 1.5;                            
                        }
                        else
                        {
                            ImpairLtEar = 0;
                        }
                    }
                }
            }
            else
            {
                throw new NotImplementedException("Unimplemented EarType " + earType.ToString());
            }

            if (ImpairRtEar < ImpairLtEar)
            {
                Disability = ((ImpairRtEar * 5) + ImpairLtEar) / 6;
            }
            else
            {
                Disability = ((ImpairLtEar * 5) + ImpairRtEar) / 6;
            }
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return ptDataModel.AddRecordToDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return ptDataModel.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            ptDataModel.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return ptDataModel.DeleteRecordFromDatabase(accNumber, examDate);           
        }

        public override void InitializeProperties()
        {
            base.InitializeProperties();

            AvgSpPerRtEar = null;
            ImpairRtEar = null;
            AvgSpPerLtEar = null;
            ImpairLtEar = null;
            Disability = null;
        }
        #endregion
    }
}
