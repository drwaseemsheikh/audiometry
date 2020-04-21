using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Audiometry.Model.TabModel;
using Microsoft.Practices.Prism.Commands;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Audiometry.ViewModel.SpeechVM
{
    public class SpeechTabVM : TabVM
    {
        #region Members
        private bool isSpeechTestConducted;
        private DateTime dateSpeechTest;

        private bool isRtEarTest;
        private bool isLtEarTest;
        private bool isBilateralTest;

        private const int NumOfSpeechScores = 10;
        private List<SpeechScore> speechScores;

        private double? srtdB;
        private double? sdScore;
        private double? sdIntensitydB;

        private ICommand srtSdCommand;

        private const double HAxisMin = -2;
        private const double HAxisMax = 112;
        private const double HStepSize = 5;
        private const double VStepSize = 10;
        private const double VAxisMin = -2;
        private const double VAxisMax = 112;

        private TabModel spModel;
        #endregion

        #region Properties
        public bool IsSpeechTestConducted
        {
            get { return isSpeechTestConducted; }
            set
            {
                if (isSpeechTestConducted != value)
                {
                    isSpeechTestConducted = value;
                    OnPropertyChanged("IsSpeechTestConducted");
                }
            }
        }

        public DateTime DateSpeechTest
        {
            get { return dateSpeechTest; }
            set
            {
                if (dateSpeechTest != value)
                {
                    dateSpeechTest = value;
                    OnPropertyChanged("DateSpeechTest");
                }
            }
        }

        public bool IsRtEarTest
        {
            get { return isRtEarTest; }
            set
            {
                if (isRtEarTest != value)
                {
                    isRtEarTest = value;
                    UpdateSpeechPlot();
                    OnPropertyChanged("IsRtEarTest");
                }
            }
        }

        public bool IsLtEarTest
        {
            get { return isLtEarTest; }
            set
            {
                if (isLtEarTest != value)
                {
                    isLtEarTest = value;
                    UpdateSpeechPlot();
                    OnPropertyChanged("IsLtEarTest");
                }
            }
        }

        public bool IsBilateralTest
        {
            get { return isBilateralTest; }
            set
            {
                if (isBilateralTest != value)
                {
                    isBilateralTest = value;
                    UpdateSpeechPlot();
                    OnPropertyChanged("IsBilateralTest");
                }
            }
        }

        public double? Intensity0dB
        {
            get { return speechScores[0].IntensitydB; }
            set
            {
                if (speechScores[0].IntensitydB != value)
                {
                    speechScores[0].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity0dB");
                }
            }
        }

        public double? Intensity1dB
        {
            get { return speechScores[1].IntensitydB; }
            set
            {
                if (speechScores[1].IntensitydB != value)
                {
                    speechScores[1].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity1dB");
                }
            }
        }

        public double? Intensity2dB
        {
            get { return speechScores[2].IntensitydB; }
            set
            {
                if (speechScores[2].IntensitydB != value)
                {
                    speechScores[2].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity2dB");
                }
            }
        }

        public double? Intensity3dB
        {
            get { return speechScores[3].IntensitydB; }
            set
            {
                if (speechScores[3].IntensitydB != value)
                {
                    speechScores[3].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity3dB");
                }
            }
        }

        public double? Intensity4dB
        {
            get { return speechScores[4].IntensitydB; }
            set
            {
                if (speechScores[4].IntensitydB != value)
                {
                    speechScores[4].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity4dB");
                }
            }
        }

        public double? Intensity5dB
        {
            get { return speechScores[5].IntensitydB; }
            set
            {
                if (speechScores[5].IntensitydB != value)
                {
                    speechScores[5].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity5dB");
                }
            }
        }

        public double? Intensity6dB
        {
            get { return speechScores[6].IntensitydB; }
            set
            {
                if (speechScores[6].IntensitydB != value)
                {
                    speechScores[6].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity6dB");
                }
            }
        }

        public double? Intensity7dB
        {
            get { return speechScores[7].IntensitydB; }
            set
            {
                if (speechScores[7].IntensitydB != value)
                {
                    speechScores[7].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity7dB");
                }
            }
        }

        public double? Intensity8dB
        {
            get { return speechScores[8].IntensitydB; }
            set
            {
                if (speechScores[8].IntensitydB != value)
                {
                    speechScores[8].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity8dB");
                }
            }
        }

        public double? Intensity9dB
        {
            get { return speechScores[9].IntensitydB; }
            set
            {
                if (speechScores[9].IntensitydB != value)
                {
                    speechScores[9].IntensitydB = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Intensity9dB");
                }
            }
        }

        public double? Score0
        {
            get { return speechScores[0].Score; }
            set
            {
                if (speechScores[0].Score != value)
                {
                    speechScores[0].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score0");
                }
            }
        }

        public double? Score1
        {
            get { return speechScores[1].Score; }
            set
            {
                if (speechScores[1].Score != value)
                {
                    speechScores[1].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score1");
                }
            }
        }

        public double? Score2
        {
            get { return speechScores[2].Score; }
            set
            {
                if (speechScores[2].Score != value)
                {
                    speechScores[2].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score2");
                }
            }
        }

        public double? Score3
        {
            get { return speechScores[3].Score; }
            set
            {
                if (speechScores[3].Score != value)
                {
                    speechScores[3].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score3");
                }
            }
        }

        public double? Score4
        {
            get { return speechScores[4].Score; }
            set
            {
                if (speechScores[4].Score != value)
                {
                    speechScores[4].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score4");
                }
            }
        }

        public double? Score5
        {
            get { return speechScores[5].Score; }
            set
            {
                if (speechScores[5].Score != value)
                {
                    speechScores[5].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score5");
                }
            }
        }

        public double? Score6
        {
            get { return speechScores[6].Score; }
            set
            {
                if (speechScores[6].Score != value)
                {
                    speechScores[6].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score6");
                }
            }
        }

        public double? Score7
        {
            get { return speechScores[7].Score; }
            set
            {
                if (speechScores[7].Score != value)
                {
                    speechScores[7].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score7");
                }
            }
        }

        public double? Score8
        {
            get { return speechScores[8].Score; }
            set
            {
                if (speechScores[8].Score != value)
                {
                    speechScores[8].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score8");
                }
            }
        }

        public double? Score9
        {
            get { return speechScores[9].Score; }
            set
            {
                if (speechScores[9].Score != value)
                {
                    speechScores[9].Score = value;

                    if (SrtSdCommand.CanExecute(null))
                    {
                        SrtSdCommand.Execute(null);
                    }

                    UpdateSpeechPlot();
                    OnPropertyChanged("Score9");
                }
            }
        }

        public double? SRTdB
        {
            get { return srtdB; }
            set
            {
                if (srtdB != value)
                {
                    srtdB = value;
                    OnPropertyChanged("SRTdB");
                }
            }
        }

        public double? SDScore
        {
            get { return sdScore; }
            set
            {
                if (sdScore != value)
                {
                    sdScore = value;
                    OnPropertyChanged("SDScore");
                }
            }
        }

        public double? SDIntensitydB
        {
            get { return sdIntensitydB; }
            set
            {
                if (sdIntensitydB != value)
                {
                    sdIntensitydB = value;
                    OnPropertyChanged("SDIntensitydB");
                }
            }
        }

        public ICommand SrtSdCommand
        {
            get { return srtSdCommand ?? (srtSdCommand = new DelegateCommand(FindSRTandSD, CanSrtSdExecute)); }
        }

        public PlotModel SpeechPlotModel { get; private set; }
        #endregion

        #region Methods
        public SpeechTabVM()
        {
            speechScores = new List<SpeechScore>();

            for (int i = 0; i < NumOfSpeechScores; i++)
            {
                speechScores.Add(new SpeechScore());
            }

            DateSpeechTest = DateTime.Now;
            IsBilateralTest = true;
            IsSpeechTestConducted = false;
            SpeechPlotModel = new PlotModel();
            AddPlotAxes();

            spModel = new SpeechModel(this);
        }

        private void AddPlotAxes()
        {
            SpeechPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = HAxisMin,
                Maximum = HAxisMax,
                MajorStep = HStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Amplification in dB"
            });

            SpeechPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = VAxisMin,
                Maximum = VAxisMax,
                MajorStep = VStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Score Percentage"
            });
        }

        private void UpdateSpeechPlot()
        {
            if (SpeechPlotModel != null)
            {
                SpeechPlotModel.Series.Clear();
                SpeechPlotModel.Annotations.Clear();

                LineSeries series = new LineSeries();
                series.MarkerType = MarkerType.Circle;
                series.MarkerFill = OxyColors.Green;
                series.Color = OxyColors.Black;
                series.LineStyle = LineStyle.Solid;

                bool srtFound = false;

                foreach (var scoreItem in speechScores)
                {
                    double? intensity = scoreItem.IntensitydB;
                    double? score = scoreItem.Score;

                    if (intensity != null && score != null)
                    {
                        if (!srtFound && score.Value >= 50)
                        {
                            srtFound = true;
                            SpeechPlotModel.Annotations.Add(new EllipseAnnotation
                            {
                                X = scoreItem.IntensitydB.Value,
                                Y = score.Value,
                                Width = 1,
                                Height = 2,
                                Text = "SRT",
                                Fill = OxyColors.Red,
                                Stroke = OxyColors.Red,
                                StrokeThickness = 1,
                                TextPosition = new DataPoint(scoreItem.IntensitydB.Value, score.Value + 5)
                            });
                        }

                        series.Points.Add(new DataPoint(intensity.Value, score.Value));
                    }
                }

                if (series.Points.Count > 1)
                {
                    series.Smooth = true;
                }

                SpeechPlotModel.Series.Add(series);
                SpeechPlotModel.InvalidatePlot(true);   
            }
        }

        private void FindSRTandSD()
        {
            List<SpeechScore> sortedSpeechScores = speechScores.OrderBy(x => x.IntensitydB).ToList();
            SpeechScore srt = sortedSpeechScores.Find(x => (x.IntensitydB != null) && (x.Score >= 50));
            double? sdValue = sortedSpeechScores.Max(x => x.Score);

            if (sdValue != null)
            {
                SpeechScore sd = sortedSpeechScores.Find(x => x.Score == sdValue);
                SDScore = sd.Score;
                SDIntensitydB = sd.IntensitydB;
            }

            if (srt != null)
            {
                SRTdB = srt.IntensitydB;
            }
        }

        private bool CanSrtSdExecute()
        {
            return true;
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            return spModel.AddRecordToDatabase(accNumber, examDate, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            return spModel.UpdateRecordInDatabase(accNumber, examDate, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            spModel.OpenRecordFromDatabase(accNumber, examDate);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return spModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            IsSpeechTestConducted = false;
            IsRtEarTest = true;
            IsLtEarTest = false;
            IsBilateralTest = false;
            Intensity0dB = null;
            Intensity1dB = null;
            Intensity2dB = null;
            Intensity3dB = null;
            Intensity4dB = null;
            Intensity5dB = null;
            Intensity6dB = null;
            Intensity7dB = null;
            Intensity8dB = null;
            Intensity9dB = null;
            Score0 = null;
            Score1 = null;
            Score2 = null;
            Score3 = null;
            Score4 = null;
            Score5 = null;
            Score6 = null;
            Score7 = null;
            Score8 = null;
            Score9 = null;
            SRTdB = null;
            SDScore = null;
            SDIntensitydB = null;
        }
        #endregion
    }
}
