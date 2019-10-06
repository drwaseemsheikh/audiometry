using System.Collections.ObjectModel;
using Audiometry.Model.SubTabModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Audiometry.ViewModel.PureToneVM.SpecialTestsVM
{
    public class AblbTabVM : SubTabVM
    {
        #region Type Definitions
        public class IntensityPair
        {
            public double? RightEardB { get; set; }
            public double? LeftEardB { get; set; }
        }
        #endregion

        #region Members
        public const int AblbTabIndex = 0;
        private const double HAxisMin = -5;
        private const double HAxisMax = 95;
        private const double StepSize = 10;
        private const double VAxisMin = 0;
        private const double VAxisMax = 10;
        private const int NumOfIntensities = 10;
        private static readonly ObservableCollection<string> intensitiesdB = new ObservableCollection<string>()
                                                                    {
                                                                        "", "0", "10", "20", "30", "40", "50", "60", "70", "80", "90"
                                                                    };

        private SubTabModel ablbModel;
        #endregion

        #region Properties
        public static ObservableCollection<string> IntensitiesdB
        {
            get { return intensitiesdB; }
        }
        public PlotModel AblbPlotModel { get; private set; }
        private static ObservableCollection<IntensityPair> IntensityPairs { get; set; }
        public double? RightEar0
        {
            get { return IntensityPairs[0].RightEardB; }
            set
            {
                if (IntensityPairs[0].RightEardB != value)
                {
                    IntensityPairs[0].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar0");
                }
            }
        }

        public double? RightEar1
        {
            get { return IntensityPairs[1].RightEardB; }
            set
            {
                if (IntensityPairs[1].RightEardB != value)
                {
                    IntensityPairs[1].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar1");
                }
            }
        }

        public double? RightEar2
        {
            get { return IntensityPairs[2].RightEardB; }
            set
            {
                if (IntensityPairs[2].RightEardB != value)
                {
                    IntensityPairs[2].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar2");
                }
            }
        }

        public double? RightEar3
        {
            get { return IntensityPairs[3].RightEardB; }
            set
            {
                if (IntensityPairs[3].RightEardB != value)
                {
                    IntensityPairs[3].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar3");
                }
            }
        }

        public double? RightEar4
        {
            get { return IntensityPairs[4].RightEardB; }
            set
            {
                if (IntensityPairs[4].RightEardB != value)
                {
                    IntensityPairs[4].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar4");
                }
            }
        }

        public double? RightEar5
        {
            get { return IntensityPairs[5].RightEardB; }
            set
            {
                if (IntensityPairs[5].RightEardB != value)
                {
                    IntensityPairs[5].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar5");
                }
            }
        }

        public double? RightEar6
        {
            get { return IntensityPairs[6].RightEardB; }
            set
            {
                if (IntensityPairs[6].RightEardB != value)
                {
                    IntensityPairs[6].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar6");
                }
            }
        }

        public double? RightEar7
        {
            get { return IntensityPairs[7].RightEardB; }
            set
            {
                if (IntensityPairs[7].RightEardB != value)
                {
                    IntensityPairs[7].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar7");
                }
            }
        }

        public double? RightEar8
        {
            get { return IntensityPairs[8].RightEardB; }
            set
            {
                if (IntensityPairs[8].RightEardB != value)
                {
                    IntensityPairs[8].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar8");
                }
            }
        }

        public double? RightEar9
        {
            get { return IntensityPairs[9].RightEardB; }
            set
            {
                if (IntensityPairs[9].RightEardB != value)
                {
                    IntensityPairs[9].RightEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("RightEar9");
                }
            }
        }

        public double? LeftEar0
        {
            get { return IntensityPairs[0].LeftEardB; }
            set
            {
                if (IntensityPairs[0].LeftEardB != value)
                {
                    IntensityPairs[0].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar0");
                }
            }
        }

        public double? LeftEar1
        {
            get { return IntensityPairs[1].LeftEardB; }
            set
            {
                if (IntensityPairs[1].LeftEardB != value)
                {
                    IntensityPairs[1].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar1");
                }
            }
        }

        public double? LeftEar2
        {
            get { return IntensityPairs[2].LeftEardB; }
            set
            {
                if (IntensityPairs[2].LeftEardB != value)
                {
                    IntensityPairs[2].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar2");
                }
            }
        }

        public double? LeftEar3
        {
            get { return IntensityPairs[3].LeftEardB; }
            set
            {
                if (IntensityPairs[3].LeftEardB != value)
                {
                    IntensityPairs[3].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar3");
                }
            }
        }

        public double? LeftEar4
        {
            get { return IntensityPairs[4].LeftEardB; }
            set
            {
                if (IntensityPairs[4].LeftEardB != value)
                {
                    IntensityPairs[4].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar4");
                }
            }
        }

        public double? LeftEar5
        {
            get { return IntensityPairs[5].LeftEardB; }
            set
            {
                if (IntensityPairs[5].LeftEardB != value)
                {
                    IntensityPairs[5].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar5");
                }
            }
        }

        public double? LeftEar6
        {
            get { return IntensityPairs[6].LeftEardB; }
            set
            {
                if (IntensityPairs[6].LeftEardB != value)
                {
                    IntensityPairs[6].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar6");
                }
            }
        }

        public double? LeftEar7
        {
            get { return IntensityPairs[7].LeftEardB; }
            set
            {
                if (IntensityPairs[7].LeftEardB != value)
                {
                    IntensityPairs[7].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar7");
                }
            }
        }

        public double? LeftEar8
        {
            get { return IntensityPairs[8].LeftEardB; }
            set
            {
                if (IntensityPairs[8].LeftEardB != value)
                {
                    IntensityPairs[8].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar8");
                }
            }
        }

        public double? LeftEar9
        {
            get { return IntensityPairs[9].LeftEardB; }
            set
            {
                if (IntensityPairs[9].LeftEardB != value)
                {
                    IntensityPairs[9].LeftEardB = value;
                    UpdateAblbPlot();
                    OnPropertyChanged("LeftEar9");
                }
            }
        }
        #endregion

        #region Methods
        public AblbTabVM()
        {
            AblbPlotModel = new PlotModel();
            AddPlotAxes();
            IntensityPairs = new ObservableCollection<IntensityPair>();

            for (int i = 0; i < NumOfIntensities; i++)
            {
                IntensityPairs.Add(new IntensityPair());
            }

            ablbModel = new AblbModel(this);
        }

        private void AddPlotAxes()
        {
            AblbPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Top,
                Minimum = HAxisMin,
                Maximum = HAxisMax,
                MajorStep = StepSize,
                Title = "Right Ear (dB)",
                MajorGridlineStyle = LineStyle.None,
                MinorGridlineStyle = LineStyle.None,
                TickStyle = TickStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });

            AblbPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = HAxisMin,
                Maximum = HAxisMax,
                MajorStep = StepSize,
                Title = "Left Ear (dB)",
                MajorGridlineStyle = LineStyle.None,
                MinorGridlineStyle = LineStyle.None,
                TickStyle = TickStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });

            AblbPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = VAxisMin,
                Maximum = VAxisMax,
                MajorGridlineStyle = LineStyle.None,
                MinorGridlineStyle = LineStyle.None,
                TickStyle = TickStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = false
            });
        }


        public void UpdateAblbPlot()
        {
            AblbPlotModel.Series.Clear();

            for (int i = 0; i < NumOfIntensities; i++)
            {
                if ((IntensityPairs[i].RightEardB != null) && (IntensityPairs[i].LeftEardB != null))
                {
                    LineSeries series = new LineSeries();
                    series.LineStyle = LineStyle.Dash;
                    series.Color = OxyColors.Black;
                    series.Points.Add(new DataPoint(IntensityPairs[i].LeftEardB.Value, VAxisMin));
                    series.Points.Add(new DataPoint(IntensityPairs[i].RightEardB.Value, VAxisMax));
                    AblbPlotModel.Series.Add(series);
                }
            }

            AblbPlotModel.InvalidatePlot(true);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return ablbModel.AddRecordToDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            return ablbModel.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            ablbModel.OpenRecordFromDatabase(accNumber, examDate, out testConducted);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return ablbModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            RightEar0 = null;
            RightEar1 = null;
            RightEar2 = null;
            RightEar3 = null;
            RightEar4 = null;
            RightEar5 = null;
            RightEar6 = null;
            RightEar7 = null;
            RightEar8 = null;
            RightEar9 = null;
            LeftEar0 = null;
            LeftEar1 = null;
            LeftEar2 = null;
            LeftEar3 = null;
            LeftEar4 = null;
            LeftEar5 = null;
            LeftEar6 = null;
            LeftEar7 = null;
            LeftEar8 = null;
            LeftEar9 = null;
        }
        #endregion
    }
}
