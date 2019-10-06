using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Audiometry.Model.TabModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Microsoft.Practices.Prism.Commands;

namespace Audiometry.ViewModel.ImpedanceVM
{
    public class ImpedanceTabVM : TabVM
    {
        #region TypeDefinitions
        public enum TympanogramType
        {
            [Description("")]
            NOT_SET,
            [Description("A")]
            A,
            [Description("As")]
            As,
            [Description("Ad")]
            Ad,
            [Description("B")]
            B,
            [Description("C1")]
            C1,
            [Description("C2")]
            C2
        }

        public enum AcousticReflexType
        {
            [Description("")]
            NOT_SET,
            [Description("Pass")]
            Pass,
            [Description("NR")]
            NR
        }
        #endregion

        #region Members
        private bool isImpedanceTestConducted;
        private DateTime dateImpedanceTest;
        private double? rtEarPeakPressure;
        private double? ltEarPeakPressure;

        private SortedDictionary<double, Compliance> complianceDict;
        private SortedDictionary<double, AcousticReflex> acousticReflexDict;

        private double? rtEarCanalVolume;
        private double? ltEarCanalVolume;

        private TympanogramType rtEarCurveType;
        private TympanogramType ltEarCurveType;

        private const double HAxisMin = -450;
        private const double HAxisMax = 450;
        private const double HStepSize = 100;
        private const double VAxisMin = 0;
        private const double VAxisMax = 4;
        private const double VStepSize = 0.5;

        private ICommand peakPressureCommand;

        private TabModel impModel;
        #endregion

        #region Properties
        public bool IsImpedanceTestConducted
        {
            get { return isImpedanceTestConducted; }
            set
            {
                if (isImpedanceTestConducted != value)
                {
                    isImpedanceTestConducted = value;
                    OnPropertyChanged("IsImpedanceTestConducted");
                }
            }
        }

        public DateTime DateImpedanceTest
        {
            get { return dateImpedanceTest; }
            set
            {
                if (dateImpedanceTest != value)
                {
                    dateImpedanceTest = value;
                    OnPropertyChanged("DateImpedanceTest");
                }
            }
        }

        public double? RtEarComplianceNeg400daPa
        {
            get { return complianceDict[-400].RtEarCompliance; }
            set
            {
                if (complianceDict[-400].RtEarCompliance != value)
                {
                    complianceDict[-400].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarComplianceNeg400daPa");
                }
            }
        }

        public double? LtEarComplianceNeg400daPa
        {
            get { return complianceDict[-400].LtEarCompliance; }
            set
            {
                if (complianceDict[-400].LtEarCompliance != value)
                {
                    complianceDict[-400].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarComplianceNeg400daPa");
                }
            }
        }

        public double? RtEarComplianceNeg300daPa
        {
            get { return complianceDict[-300].RtEarCompliance; }
            set
            {
                if (complianceDict[-300].RtEarCompliance != value)
                {
                    complianceDict[-300].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarComplianceNeg300daPa");
                }
            }
        }

        public double? LtEarComplianceNeg300daPa
        {
            get { return complianceDict[-300].LtEarCompliance; }
            set
            {
                if (complianceDict[-300].LtEarCompliance != value)
                {
                    complianceDict[-300].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarComplianceNeg300daPa");
                }
            }
        }

        public double? RtEarComplianceNeg200daPa
        {
            get { return complianceDict[-200].RtEarCompliance; }
            set
            {
                if (complianceDict[-200].RtEarCompliance != value)
                {
                    complianceDict[-200].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarComplianceNeg200daPa");
                }
            }
        }

        public double? LtEarComplianceNeg200daPa
        {
            get { return complianceDict[-200].LtEarCompliance; }
            set
            {
                if (complianceDict[-200].LtEarCompliance != value)
                {
                    complianceDict[-200].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarComplianceNeg200daPa");
                }
            }
        }

        public double? RtEarComplianceNeg100daPa
        {
            get { return complianceDict[-100].RtEarCompliance; }
            set
            {
                if (complianceDict[-100].RtEarCompliance != value)
                {
                    complianceDict[-100].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarComplianceNeg100daPa");
                }
            }
        }

        public double? LtEarComplianceNeg100daPa
        {
            get { return complianceDict[-100].LtEarCompliance; }
            set
            {
                if (complianceDict[-100].LtEarCompliance != value)
                {
                    complianceDict[-100].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarComplianceNeg100daPa");
                }
            }
        }

        public double? RtEarCompliance0daPa
        {
            get { return complianceDict[0].RtEarCompliance; }
            set
            {
                if (complianceDict[0].RtEarCompliance != value)
                {
                    complianceDict[0].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarCompliance0daPa");
                }
            }
        }

        public double? LtEarCompliance0daPa
        {
            get { return complianceDict[0].LtEarCompliance; }
            set
            {
                if (complianceDict[0].LtEarCompliance != value)
                {
                    complianceDict[0].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarCompliance0daPa");
                }
            }
        }

        public double? RtEarCompliance100daPa
        {
            get { return complianceDict[100].RtEarCompliance; }
            set
            {
                if (complianceDict[100].RtEarCompliance != value)
                {
                    complianceDict[100].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarCompliance100daPa");
                }
            }
        }

        public double? LtEarCompliance100daPa
        {
            get { return complianceDict[100].LtEarCompliance; }
            set
            {
                if (complianceDict[100].LtEarCompliance != value)
                {
                    complianceDict[100].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarCompliance100daPa");
                }
            }
        }

        public double? RtEarCompliance200daPa
        {
            get { return complianceDict[200].RtEarCompliance; }
            set
            {
                if (complianceDict[200].RtEarCompliance != value)
                {
                    complianceDict[200].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarCompliance200daPa");
                }
            }
        }

        public double? LtEarCompliance200daPa
        {
            get { return complianceDict[200].LtEarCompliance; }
            set
            {
                if (complianceDict[200].LtEarCompliance != value)
                {
                    complianceDict[200].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarCompliance200daPa");
                }
            }
        }

        public double? RtEarCompliance300daPa
        {
            get { return complianceDict[300].RtEarCompliance; }
            set
            {
                if (complianceDict[300].RtEarCompliance != value)
                {
                    complianceDict[300].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarCompliance300daPa");
                }
            }
        }

        public double? LtEarCompliance300daPa
        {
            get { return complianceDict[300].LtEarCompliance; }
            set
            {
                if (complianceDict[300].LtEarCompliance != value)
                {
                    complianceDict[300].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarCompliance300daPa");
                }
            }
        }

        public double? RtEarCompliance400daPa
        {
            get { return complianceDict[400].RtEarCompliance; }
            set
            {
                if (complianceDict[400].RtEarCompliance != value)
                {
                    complianceDict[400].RtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("RtEarCompliance400daPa");
                }
            }
        }

        public double? LtEarCompliance400daPa
        {
            get { return complianceDict[400].LtEarCompliance; }
            set
            {
                if (complianceDict[400].LtEarCompliance != value)
                {
                    complianceDict[400].LtEarCompliance = value;

                    if (PeakPressureCommand.CanExecute(null))
                    {
                        PeakPressureCommand.Execute(null);
                    }

                    UpdateTympanogramPlot();
                    OnPropertyChanged("LtEarCompliance400daPa");
                }
            }
        }

        public double? RtEarPeakPressure
        {
            get { return rtEarPeakPressure; }
            set
            {
                if (rtEarPeakPressure != value)
                {
                    rtEarPeakPressure = value;
                    OnPropertyChanged("RtEarPeakPressure");
                }
            }
        }

        public double? LtEarPeakPressure
        {
            get { return ltEarPeakPressure; }
            set
            {
                if (ltEarPeakPressure != value)
                {
                    ltEarPeakPressure = value;
                    OnPropertyChanged("LtEarPeakPressure");
                }
            }
        }

        public double? RtEarCanalVolume
        {
            get { return rtEarCanalVolume; }
            set
            {
                if (rtEarCanalVolume != value)
                {
                    rtEarCanalVolume = value;
                    OnPropertyChanged("RtEarCanalVolume");
                }
            }
        }

        public double? LtEarCanalVolume
        {
            get { return ltEarCanalVolume; }
            set
            {
                if (ltEarCanalVolume != value)
                {
                    ltEarCanalVolume = value;
                    OnPropertyChanged("LtEarCanalVolume");
                }
            }
        }

        public TympanogramType RtEarCurveType
        {
            get { return rtEarCurveType; }
            set
            {
                if (rtEarCurveType != value)
                {
                    rtEarCurveType = value;
                    OnPropertyChanged("RtEarCurveType");
                }
            }
        }

        public TympanogramType LtEarCurveType
        {
            get { return ltEarCurveType; }
            set
            {
                if (ltEarCurveType != value)
                {
                    ltEarCurveType = value;
                    OnPropertyChanged("LtEarCurveType");
                }
            }
        }

        public AcousticReflexType RtEarAcousticReflex500Hz
        {
            get { return acousticReflexDict[500].RtEarAR; }
            set
            {
                if (acousticReflexDict[500].RtEarAR != value)
                {
                    acousticReflexDict[500].RtEarAR = value;
                    OnPropertyChanged("RtEarAcousticReflex500Hz");
                }
            }
        }

        public AcousticReflexType LtEarAcousticReflex500Hz
        {
            get { return acousticReflexDict[500].LtEarAR; }
            set
            {
                if (acousticReflexDict[500].LtEarAR != value)
                {
                    acousticReflexDict[500].LtEarAR = value;
                    OnPropertyChanged("LtEarAcousticReflex500Hz");
                }
            }
        }

        public AcousticReflexType RtEarAcousticReflex1000Hz
        {
            get { return acousticReflexDict[1000].RtEarAR; }
            set
            {
                if (acousticReflexDict[1000].RtEarAR != value)
                {
                    acousticReflexDict[1000].RtEarAR = value;
                    OnPropertyChanged("RtEarAcousticReflex1000Hz");
                }
            }
        }

        public AcousticReflexType LtEarAcousticReflex1000Hz
        {
            get { return acousticReflexDict[1000].LtEarAR; }
            set
            {
                if (acousticReflexDict[1000].LtEarAR != value)
                {
                    acousticReflexDict[1000].LtEarAR = value;
                    OnPropertyChanged("LtEarAcousticReflex1000Hz");
                }
            }
        }

        public AcousticReflexType RtEarAcousticReflex2000Hz
        {
            get { return acousticReflexDict[2000].RtEarAR; }
            set
            {
                if (acousticReflexDict[2000].RtEarAR != value)
                {
                    acousticReflexDict[2000].RtEarAR = value;
                    OnPropertyChanged("RtEarAcousticReflex2000Hz");
                }
            }
        }

        public AcousticReflexType LtEarAcousticReflex2000Hz
        {
            get { return acousticReflexDict[2000].LtEarAR; }
            set
            {
                if (acousticReflexDict[2000].LtEarAR != value)
                {
                    acousticReflexDict[2000].LtEarAR = value;
                    OnPropertyChanged("LtEarAcousticReflex2000Hz");
                }
            }
        }

        public AcousticReflexType RtEarAcousticReflex4000Hz
        {
            get { return acousticReflexDict[4000].RtEarAR; }
            set
            {
                if (acousticReflexDict[4000].RtEarAR != value)
                {
                    acousticReflexDict[4000].RtEarAR = value;
                    OnPropertyChanged("RtEarAcousticReflex4000Hz");
                }
            }
        }

        public AcousticReflexType LtEarAcousticReflex4000Hz
        {
            get { return acousticReflexDict[4000].LtEarAR; }
            set
            {
                if (acousticReflexDict[4000].LtEarAR != value)
                {
                    acousticReflexDict[4000].LtEarAR = value;
                    OnPropertyChanged("LtEarAcousticReflex4000Hz");
                }
            }
        }
        public PlotModel Tympanogram { get; private set; }

        public ICommand PeakPressureCommand
        {
            get { return peakPressureCommand ?? (peakPressureCommand = new DelegateCommand(FindPeakPressure, CanFindPeakPressureExecute)); }
        }
        #endregion

        #region Methods
        public ImpedanceTabVM()
        {
            dateImpedanceTest = DateTime.Now;
            complianceDict = new SortedDictionary<double, Compliance>();
            complianceDict[-400] = new Compliance();
            complianceDict[-300] = new Compliance();
            complianceDict[-200] = new Compliance();
            complianceDict[-100] = new Compliance();
            complianceDict[0] = new Compliance();
            complianceDict[100] = new Compliance();
            complianceDict[200] = new Compliance();
            complianceDict[300] = new Compliance();
            complianceDict[400] = new Compliance();
            
            acousticReflexDict = new SortedDictionary<double, AcousticReflex>();
            acousticReflexDict[500] = new AcousticReflex();
            acousticReflexDict[1000] = new AcousticReflex();
            acousticReflexDict[2000] = new AcousticReflex();
            acousticReflexDict[4000] = new AcousticReflex();

            Tympanogram = new PlotModel();
            AddPlotAxes();

            impModel = new ImpedanceModel(this);
        }

        private void AddPlotAxes()
        {
            Tympanogram.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = HAxisMin,
                Maximum = HAxisMax,
                MajorStep = HStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Pressure (daPa)"
            });

            Tympanogram.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = VAxisMin,
                Maximum = VAxisMax,
                MajorStep = VStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Compliance (cm\u00B3)"
            });
        }

        private void UpdateTympanogramPlot()
        {
            Tympanogram.Series.Clear();

            LineSeries rtEarSeries = new LineSeries();
            rtEarSeries.MarkerType = MarkerType.Circle;
            rtEarSeries.MarkerFill = OxyColors.Red;
            rtEarSeries.Color = OxyColors.Red;
            rtEarSeries.LineStyle = LineStyle.Solid;
            rtEarSeries.Smooth = true;
            rtEarSeries.Title = "Right Ear Tympanogram";

            LineSeries ltEarSeries = new LineSeries();
            ltEarSeries.MarkerType = MarkerType.Circle;
            ltEarSeries.MarkerFill = OxyColors.Blue;
            ltEarSeries.Color = OxyColors.Blue;
            ltEarSeries.LineStyle = LineStyle.Solid;
            ltEarSeries.Smooth = true;
            ltEarSeries.Title = "Left Ear Tympanogram";

            foreach (var keyValuePair in complianceDict)
            {
                double pressure = keyValuePair.Key;
                double? rtEarComp = keyValuePair.Value.RtEarCompliance;
                double? ltEarComp = keyValuePair.Value.LtEarCompliance;

                if (rtEarComp != null)
                {
                    rtEarSeries.Points.Add(new DataPoint(pressure, rtEarComp.Value));
                }

                if (ltEarComp != null)
                {
                    ltEarSeries.Points.Add(new DataPoint(pressure, ltEarComp.Value));
                }
            }

            Tympanogram.Series.Add(rtEarSeries);
            Tympanogram.Series.Add(ltEarSeries);
            Tympanogram.InvalidatePlot(true);
        }

        private void FindPeakPressure()
        {
            double? maxRtEarCompliance = complianceDict.Values.Max(x => x.RtEarCompliance);

            if (maxRtEarCompliance != null)
            {
                KeyValuePair<double, Compliance> maxRtEarKvp = complianceDict.FirstOrDefault(x => x.Value.RtEarCompliance == maxRtEarCompliance);
                RtEarPeakPressure = maxRtEarKvp.Key;
            }

            double? maxLtEarCompliance = complianceDict.Values.Max(x => x.LtEarCompliance);

            if (maxLtEarCompliance != null)
            {
                KeyValuePair<double, Compliance> maxLtEarKvp = complianceDict.FirstOrDefault(x => x.Value.LtEarCompliance == maxLtEarCompliance);
                LtEarPeakPressure = maxLtEarKvp.Key;
            }
        }

        private bool CanFindPeakPressureExecute()
        {
            return true;
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            return impModel.AddRecordToDatabase(accNumber, examDate, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            return impModel.UpdateRecordInDatabase(accNumber, examDate, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            impModel.OpenRecordFromDatabase(accNumber, examDate);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return impModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            IsImpedanceTestConducted = false;
            RtEarComplianceNeg400daPa = null;
            LtEarComplianceNeg400daPa = null;
            RtEarComplianceNeg300daPa = null;
            LtEarComplianceNeg300daPa = null;
            RtEarComplianceNeg200daPa = null;
            LtEarComplianceNeg200daPa = null;
            RtEarComplianceNeg100daPa = null;
            LtEarComplianceNeg100daPa = null;
            RtEarCompliance0daPa = null;
            LtEarCompliance0daPa = null;
            RtEarCompliance100daPa = null;
            LtEarCompliance100daPa = null;
            RtEarCompliance200daPa = null;
            LtEarCompliance200daPa = null;
            RtEarCompliance300daPa = null;
            LtEarCompliance300daPa = null;
            RtEarCompliance400daPa = null;
            LtEarCompliance400daPa = null;
            RtEarPeakPressure = null;
            LtEarPeakPressure = null;
            RtEarCanalVolume = null;
            LtEarCanalVolume = null;
            RtEarCurveType = TympanogramType.NOT_SET;
            LtEarCurveType = TympanogramType.NOT_SET;
            RtEarAcousticReflex500Hz = AcousticReflexType.NOT_SET;
            LtEarAcousticReflex500Hz = AcousticReflexType.NOT_SET;
            RtEarAcousticReflex1000Hz = AcousticReflexType.NOT_SET;
            LtEarAcousticReflex1000Hz = AcousticReflexType.NOT_SET;
            RtEarAcousticReflex2000Hz = AcousticReflexType.NOT_SET;
            LtEarAcousticReflex2000Hz = AcousticReflexType.NOT_SET;
            RtEarAcousticReflex4000Hz = AcousticReflexType.NOT_SET;
            LtEarAcousticReflex4000Hz = AcousticReflexType.NOT_SET;
        }
        #endregion
    }
}
