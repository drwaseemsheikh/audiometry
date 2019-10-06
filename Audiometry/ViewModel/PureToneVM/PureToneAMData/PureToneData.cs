using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Audiometry.Converter;
using Audiometry.Model.SubTabModel;
using Audiometry.Validation;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public abstract class PureToneData : SubTabVM
    {
        #region Members
        private bool hasRtEarValidData;
        private bool hasLtEarValidData;
        private bool showRtEarPlot;
        private bool showLtEarPlot;
        private bool showPlot;

        protected SubTabModel ptDataModel;
        #endregion

        #region Properties
        public SortedDictionary<double, HearingLevel> HearingLevels { get; private set; }
        public AudiogramPlot AudiogramPlot { get; set; }
        public bool AddBCFreqShift { get; set; }

        public bool HasRtEarValidData
        {
            get { return hasRtEarValidData; }
            set
            {
                if (hasRtEarValidData != value)
                {
                    hasRtEarValidData = value;
                    OnPropertyChanged("HasRtEarValidData");
                }
            }
        }

        public bool HasLtEarValidData
        {
            get { return hasLtEarValidData; }
            set
            {
                if (hasLtEarValidData != value)
                {
                    hasLtEarValidData = value;
                    OnPropertyChanged("HasLtEarValidData");
                }
            }
        }

        public bool ShowRtEarPlot
        {
            get { return showRtEarPlot; }
            set
            {
                if (showRtEarPlot != value)
                {
                    showRtEarPlot = value;

                    if (showPlot)
                    {
                        foreach (var series in AudiogramPlot.RtEarSeriesList)
                        {
                            series.IsVisible = showRtEarPlot;
                        }
                    }

                    AudiogramPlot.PlotModel.InvalidatePlot(true);
                }
            }
        }

        public bool ShowLtEarPlot
        {
            get { return showLtEarPlot; }
            set
            {
                if (showLtEarPlot != value)
                {
                    showLtEarPlot = value;

                    if (showPlot)
                    {
                        foreach (var series in AudiogramPlot.LtEarSeriesList)
                        {
                            series.IsVisible = showLtEarPlot;
                        }
                    }

                    AudiogramPlot.PlotModel.InvalidatePlot(true);
                }
            }
        }

        public bool ShowPlot
        {
            get { return showPlot; }
            set
            {
                if (showPlot != value)
                {
                    showPlot = value;

                    if (showRtEarPlot)
                    {
                        foreach (var series in AudiogramPlot.RtEarSeriesList)
                        {
                            series.IsVisible = showPlot;
                        }
                    }

                    if (showLtEarPlot)
                    {
                        foreach (var series in AudiogramPlot.LtEarSeriesList)
                        {
                            series.IsVisible = showPlot;
                        }
                    }

                    AudiogramPlot.PlotModel.InvalidatePlot(true);
                }
            }
        }

        public string RtEarHLdB125Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 125); }
            set
            {
                SetHearingLevel(EarType.RightEar, 125, value);
                OnPropertyChanged("RtEarHLdB125Hz");
            }
        }

        public string RtEarHLdB250Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 250); }
            set
            {
                SetHearingLevel(EarType.RightEar, 250, value);
                OnPropertyChanged("RtEarHLdB250Hz");
            }
        }

        public virtual string RtEarHLdB500Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 500); }
            set
            {
                SetHearingLevel(EarType.RightEar, 500, value);
                OnPropertyChanged("RtEarHLdB500Hz");
            }
        }

        public virtual string RtEarHLdB1000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 1000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 1000, value);
                OnPropertyChanged("RtEarHLdB1000Hz");
            }
        }

        public virtual string RtEarHLdB2000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 2000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 2000, value);
                OnPropertyChanged("RtEarHLdB2000Hz");
            }
        }

        public virtual string RtEarHLdB3000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 3000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 3000, value);
                OnPropertyChanged("RtEarHLdB3000Hz");
            }
        }

        public string RtEarHLdB4000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 4000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 4000, value);
                OnPropertyChanged("RtEarHLdB4000Hz");
            }
        }

        public string RtEarHLdB6000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 6000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 6000, value);
                OnPropertyChanged("RtEarHLdB6000Hz");
            }
        }

        public string RtEarHLdB8000Hz
        {
            get { return GetHearingLevel(EarType.RightEar, 8000); }
            set
            {
                SetHearingLevel(EarType.RightEar, 8000, value);
                OnPropertyChanged("RtEarHLdB8000Hz");
            }
        }

        public string LtEarHLdB125Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 125); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 125, value);
                OnPropertyChanged("LtEarHLdB125Hz");
            }
        }

        public string LtEarHLdB250Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 250); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 250, value);
                OnPropertyChanged("LtEarHLdB250Hz");
            }
        }

        public virtual string LtEarHLdB500Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 500); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 500, value);
                OnPropertyChanged("LtEarHLdB500Hz");
            }
        }

        public virtual string LtEarHLdB1000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 1000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 1000, value);
                OnPropertyChanged("LtEarHLdB1000Hz");
            }
        }

        public virtual string LtEarHLdB2000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 2000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 2000, value);
                OnPropertyChanged("LtEarHLdB2000Hz");
            }
        }

        public virtual string LtEarHLdB3000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 3000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 3000, value);
                OnPropertyChanged("LtEarHLdB3000Hz");
            }
        }

        public string LtEarHLdB4000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 4000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 4000, value);
                OnPropertyChanged("LtEarHLdB4000Hz");
            }
        }

        public string LtEarHLdB6000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 6000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 6000, value);
                OnPropertyChanged("LtEarHLdB6000Hz");
            }
        }

        public string LtEarHLdB8000Hz
        {
            get { return GetHearingLevel(EarType.LeftEar, 8000); }
            set
            {
                SetHearingLevel(EarType.LeftEar, 8000, value);
                OnPropertyChanged("LtEarHLdB8000Hz");
            }
        }

        public string HLValidationError { get; set; }

        #endregion

        #region Methods
        protected PureToneData()
        {
            HearingLevels = new SortedDictionary<double, HearingLevel>();
            showLtEarPlot = true;
            showRtEarPlot = true;
            showPlot = true;
        }

        protected void SetHearingLevel(EarType ear, double freqHz, string hearingLevel)
        {
            HearingLevelValidation hlValidator = new HearingLevelValidation();
            ValidationResult validResult = hlValidator.Validate(hearingLevel, CultureInfo.InvariantCulture);
            HLValidationError = validResult.IsValid ? String.Empty : validResult.ErrorContent.ToString();

            if (validResult.IsValid)
            {
                if (HearingLevels.ContainsKey(freqHz))
                {
                    if (ear == EarType.RightEar)
                    {
                        HearingLevels[freqHz].RightEarHLdBStr = hearingLevel;
                    }
                    else if (ear == EarType.LeftEar)
                    {
                        HearingLevels[freqHz].LeftEarHLdBStr = hearingLevel;
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException();
                    }
                }
                else
                {
                    if (ear == EarType.RightEar)
                    {
                        HearingLevels.Add(freqHz, new HearingLevel { RightEarHLdBStr = hearingLevel });
                    }
                    else if (ear == EarType.LeftEar)
                    {
                        HearingLevels.Add(freqHz, new HearingLevel { LeftEarHLdBStr = hearingLevel });
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException();
                    }
                }

                AudiogramPlot.UpdateEarPlot(ear, HearingLevels, AddBCFreqShift);

                if (ear == EarType.RightEar)
                {
                    HasRtEarValidData = HearingLevels.Values.Any(hl => hl.RightEarHLdB != null ||
                                                 hl.RightEarHLdBStr == HearingLevelTypes.NoResponse.GetDescription());
                }
                else if (ear == EarType.LeftEar)
                {
                    HasLtEarValidData = HearingLevels.Values.Any(hl => hl.LeftEarHLdB != null ||
                                              hl.LeftEarHLdBStr == HearingLevelTypes.NoResponse.GetDescription());
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
        }

        protected string GetHearingLevel(EarType ear, double freqHz)
        {
            string hearingLevel = string.Empty;

            if (ear == EarType.RightEar)
            {
                hearingLevel = (HearingLevels.ContainsKey(freqHz)) ? HearingLevels[freqHz].RightEarHLdBStr : String.Empty;
            }
            else if (ear == EarType.LeftEar)
            {
                hearingLevel = (HearingLevels.ContainsKey(freqHz)) ? HearingLevels[freqHz].LeftEarHLdBStr : String.Empty;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            return hearingLevel;
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
            RtEarHLdB125Hz = null;
            RtEarHLdB250Hz = null;
            RtEarHLdB500Hz = null;
            RtEarHLdB1000Hz = null;
            RtEarHLdB2000Hz = null;
            RtEarHLdB3000Hz = null;
            RtEarHLdB4000Hz = null;
            RtEarHLdB6000Hz = null;
            RtEarHLdB8000Hz = null;
            LtEarHLdB125Hz = null;
            LtEarHLdB250Hz = null;
            LtEarHLdB500Hz = null;
            LtEarHLdB1000Hz = null;
            LtEarHLdB2000Hz = null;
            LtEarHLdB3000Hz = null;
            LtEarHLdB4000Hz = null;
            LtEarHLdB6000Hz = null;
            LtEarHLdB8000Hz = null;
        }
        #endregion
    }
}
