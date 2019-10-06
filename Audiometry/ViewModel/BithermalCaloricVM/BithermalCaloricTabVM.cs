using System;
using System.ComponentModel;
using System.Windows.Input;
using Audiometry.Converter;
using Audiometry.Model.TabModel;
using Microsoft.Practices.Prism.Commands;
using OxyPlot;
using OxyPlot.Axes;
using LinearAxis = OxyPlot.Axes.LinearAxis;
using LineSeries = OxyPlot.Series.LineSeries;

namespace Audiometry.ViewModel.BithermalCaloricVM
{
    public class BithermalCaloricTabVM : TabVM
    {
        #region Types

        public enum CalorigramType 
        {
            [Description("Calorigram 30°C")]
            CALORIGRAM_30C,
            [Description("Calorigram 44°C")]
            CALORIGRAM_44C
        }
        #endregion

        #region Members
        private bool isCaloricTestConducted;
        private DateTime dateCaloricTest;
        private bool isAirTest;
        private bool isWaterTest;
        private double? nysStartMin30RtEar;
        private double? nysStartSec30RtEar;
        private double? nysEndMin30RtEar;
        private double? nysEndSec30RtEar;
        private double? nysStartMin30LtEar;
        private double? nysStartSec30LtEar;
        private double? nysEndMin30LtEar;
        private double? nysEndSec30LtEar;
        private double? nysStartMin44RtEar;
        private double? nysStartSec44RtEar;
        private double? nysEndMin44RtEar;
        private double? nysEndSec44RtEar;
        private double? nysStartMin44LtEar;
        private double? nysStartSec44LtEar;
        private double? nysEndMin44LtEar;
        private double? nysEndSec44LtEar;
        private double? canalParesis;
        private double? dirPrepond;
        private ICommand canalParesisCommand;
        private ICommand dirPrepondCommand;

        private const double HAxisMinutesMin = 0;
        private const double HAxisMinutesMax = 4;
        private const double HAxisSecondsMin = HAxisMinutesMin*60;
        private const double HAxisSecondsMax = HAxisMinutesMax*60;
        private const double HMinutesStepSize = 1;
        private const double HSecondsStepSize = 20;
        private const double VStepSize = 1;
        private const double VAxisMin = 0;
        private const double VAxisMax = 10;

        private TabModel bcModel;
        #endregion

        #region Properties
        public bool IsCaloricTestConducted
        {
            get { return isCaloricTestConducted; }
            set
            {
                if (isCaloricTestConducted != value)
                {
                    isCaloricTestConducted = value;
                    OnPropertyChanged("IsCaloricTestConducted");
                }
            }
        }

        public DateTime DateCaloricTest
        {
            get { return dateCaloricTest; }
            set
            {
                if (dateCaloricTest != value)
                {
                    dateCaloricTest = value;
                    OnPropertyChanged("DateCaloricTest");
                }
            }
        }

        public bool IsAirTest
        {
            get { return isAirTest; }
            set
            {
                if (isAirTest != value)
                {
                    isAirTest = value;
                    OnPropertyChanged("IsAirTest");
                }
            }
        }

        public bool IsWaterTest
        {
            get { return isWaterTest; }
            set
            {
                if (isWaterTest != value)
                {
                    isWaterTest = value;
                    OnPropertyChanged("IsWaterTest");
                }
            }
        }

        public double? NysStartMin30RtEar
        {
            get { return nysStartMin30RtEar; }
            set
            {
                if (nysStartMin30RtEar != value)
                {
                    nysStartMin30RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysStartMin30RtEar");
                }
            }
        }

        public double? NysStartSec30RtEar
        {
            get { return nysStartSec30RtEar; }
            set
            {
                if (nysStartSec30RtEar != value)
                {
                    nysStartSec30RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysStartSec30RtEar");
                }
            }
        }

        public double? NysEndMin30RtEar
        {
            get { return nysEndMin30RtEar; }
            set
            {
                if (nysEndMin30RtEar != value)
                {
                    nysEndMin30RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysEndMin30RtEar");
                }
            }
        }

        public double? NysEndSec30RtEar
        {
            get { return nysEndSec30RtEar; }
            set
            {
                if (nysEndSec30RtEar != value)
                {
                    nysEndSec30RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysEndSec30RtEar");
                }
            }
        }

        public double? NysStartMin30LtEar
        {
            get { return nysStartMin30LtEar; }
            set
            {
                if (nysStartMin30LtEar != value)
                {
                    nysStartMin30LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysStartMin30LtEar");
                }
            }
        }

        public double? NysStartSec30LtEar
        {
            get { return nysStartSec30LtEar; }
            set
            {
                if (nysStartSec30LtEar != value)
                {
                    nysStartSec30LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysStartSec30LtEar");
                }
            }
        }

        public double? NysEndMin30LtEar
        {
            get { return nysEndMin30LtEar; }
            set
            {
                if (nysEndMin30LtEar != value)
                {
                    nysEndMin30LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysEndMin30LtEar");
                }
            }
        }

        public double? NysEndSec30LtEar
        {
            get { return nysEndSec30LtEar; }
            set
            {
                if (nysEndSec30LtEar != value)
                {
                    nysEndSec30LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_30C);
                    OnPropertyChanged("NysEndSec30LtEar");
                }
            }
        }

        public double? NysStartMin44RtEar
        {
            get { return nysStartMin44RtEar; }
            set
            {
                if (nysStartMin44RtEar != value)
                {
                    nysStartMin44RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysStartMin44RtEar");
                }
            }
        }

        public double? NysStartSec44RtEar
        {
            get { return nysStartSec44RtEar; }
            set
            {
                if (nysStartSec44RtEar != value)
                {
                    nysStartSec44RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysStartSec44RtEar");
                }
            }
        }

        public double? NysEndMin44RtEar
        {
            get { return nysEndMin44RtEar; }
            set
            {
                if (nysEndMin44RtEar != value)
                {
                    nysEndMin44RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysEndMin44RtEar");
                }
            }
        }

        public double? NysEndSec44RtEar
        {
            get { return nysEndSec44RtEar; }
            set
            {
                if (nysEndSec44RtEar != value)
                {
                    nysEndSec44RtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysEndSec44RtEar");
                }
            }
        }

        public double? NysStartMin44LtEar
        {
            get { return nysStartMin44LtEar; }
            set
            {
                if (nysStartMin44LtEar != value)
                {
                    nysStartMin44LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysStartMin44LtEar");
                }
            }
        }

        public double? NysStartSec44LtEar
        {
            get { return nysStartSec44LtEar; }
            set
            {
                if (nysStartSec44LtEar != value)
                {
                    nysStartSec44LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysStartSec44LtEar");
                }
            }
        }

        public double? NysEndMin44LtEar
        {
            get { return nysEndMin44LtEar; }
            set
            {
                if (nysEndMin44LtEar != value)
                {
                    nysEndMin44LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysEndMin44LtEar");
                }
            }
        }

        public double? NysEndSec44LtEar
        {
            get { return nysEndSec44LtEar; }
            set
            {
                if (nysEndSec44LtEar != value)
                {
                    nysEndSec44LtEar = value;

                    if (CanalParesisCommand.CanExecute(null))
                    {
                        CanalParesisCommand.Execute(null);
                    }

                    if (DirPrepondCommand.CanExecute(null))
                    {
                        DirPrepondCommand.Execute(null);
                    }

                    UpdateCalorigram(CalorigramType.CALORIGRAM_44C);
                    OnPropertyChanged("NysEndSec44LtEar");
                }
            }
        }

        public double? CanalParesis
        {
            get { return canalParesis; }
            set
            {
                if (canalParesis != value)
                {
                    canalParesis = value;
                    OnPropertyChanged("CanalParesis");
                }
            }
        }

        public double? DirPrepond
        {
            get { return dirPrepond; }
            set
            {
                if (dirPrepond != value)
                {
                    dirPrepond = value;
                    OnPropertyChanged("DirPrepond");
                }
            }
        }

        public ICommand CanalParesisCommand
        {
            get { return canalParesisCommand ?? (canalParesisCommand = new DelegateCommand(FindCanalParesis, CanFindCanalParesisExecute)); }
        }

        public ICommand DirPrepondCommand
        {
            get { return dirPrepondCommand ?? (dirPrepondCommand = new DelegateCommand(FindDirPrepond, CanFindDirPrepondExecute)); }
        }

        public PlotModel Calorigram30 { get; private set; }

        public PlotModel Calorigram44 { get; private set; }
        #endregion

        #region Methods
        public BithermalCaloricTabVM()
        {
            IsCaloricTestConducted = false;
            DateCaloricTest = DateTime.Now;
            IsAirTest = true;
            Calorigram30 = new PlotModel();
            Calorigram44 = new PlotModel();
            AddPlotAxes(Calorigram30, "Calorigram 30° C");
            AddPlotAxes(Calorigram44, "Calorigram 44° C");

            bcModel = new BithermalCaloricModel(this);
        }
        private void AddPlotAxes(PlotModel calorigram, string title)
        {
            calorigram.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = HAxisSecondsMin,
                Maximum = HAxisSecondsMax,
                MajorStep = HSecondsStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Time in seconds"
            });

            calorigram.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Top,
                Minimum = HAxisMinutesMin,
                Maximum = HAxisMinutesMax,
                MajorStep = HMinutesStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Title = "Time in minutes"
            });

            calorigram.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = VAxisMin,
                Maximum = VAxisMax,
                MajorStep = VStepSize,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                IsAxisVisible = false,
                Title = title
            });
        }

        public void UpdateCalorigram(CalorigramType calType)
        {
            PlotModel calorigram;
            double lineThickness = 14;
            double vOffsetRtEar = 4;
            double vOffsetLtEar = 2;
            string testTemp;
            double? nysStartMinRtEar;
            double? nysStartSecRtEar;
            double? nysEndMinRtEar;
            double? nysEndSecRtEar;
            double? nysStartMinLtEar;
            double? nysStartSecLtEar;
            double? nysEndMinLtEar;
            double? nysEndSecLtEar;

            if (calType == CalorigramType.CALORIGRAM_30C)
            {
                calorigram = Calorigram30;
                testTemp = "30° C";
                nysStartMinRtEar = NysStartMin30RtEar;
                nysStartSecRtEar = NysStartSec30RtEar;
                nysEndMinRtEar = NysEndMin30RtEar;
                nysEndSecRtEar = NysEndSec30RtEar;
                nysStartMinLtEar = NysStartMin30LtEar;
                nysStartSecLtEar = NysStartSec30LtEar;
                nysEndMinLtEar = NysEndMin30LtEar;
                nysEndSecLtEar = NysEndSec30LtEar;
            }
            else if (calType == CalorigramType.CALORIGRAM_44C)
            {
                calorigram = Calorigram44;
                testTemp = "44° C";
                nysStartMinRtEar = NysStartMin44RtEar;
                nysStartSecRtEar = NysStartSec44RtEar;
                nysEndMinRtEar = NysEndMin44RtEar;
                nysEndSecRtEar = NysEndSec44RtEar;
                nysStartMinLtEar = NysStartMin44LtEar;
                nysStartSecLtEar = NysStartSec44LtEar;
                nysEndMinLtEar = NysEndMin44LtEar;
                nysEndSecLtEar = NysEndSec44LtEar;
            }
            else
            {
                throw new NotImplementedException("Unimplemented Calorigram Type: " + calType.Description());
            }

            calorigram.Series.Clear();
            
            if (nysStartMinRtEar != null && nysStartSecRtEar != null
                && nysEndMinRtEar != null && nysEndSecRtEar != null)
            {
                LineSeries rtEarSeries = new LineSeries();
                rtEarSeries.MarkerType = MarkerType.None;
                rtEarSeries.Color = OxyColors.Red;
                rtEarSeries.LineStyle = LineStyle.Solid;
                rtEarSeries.Title = "Right Ear " + testTemp;
                rtEarSeries.StrokeThickness = lineThickness;
                double rtEarStart = nysStartMinRtEar.Value * 60 + nysStartSecRtEar.Value;
                double rtEarEnd = nysEndMinRtEar.Value * 60 + nysEndSecRtEar.Value;
                rtEarSeries.Points.Add(new DataPoint(rtEarStart, vOffsetRtEar));
                rtEarSeries.Points.Add(new DataPoint(rtEarEnd, vOffsetRtEar));
                calorigram.Series.Add(rtEarSeries);
            }

            if (nysStartMinLtEar != null && nysStartSecLtEar != null
                && nysEndMinLtEar != null && nysEndSecLtEar != null)
            {
                LineSeries ltEarSeries = new LineSeries();
                ltEarSeries.MarkerType = MarkerType.None;
                ltEarSeries.Color = OxyColors.Blue;
                ltEarSeries.LineStyle = LineStyle.Solid;
                ltEarSeries.Title = "Left Ear " + testTemp;
                ltEarSeries.StrokeThickness = lineThickness;
                double ltEarStart = nysStartMinLtEar.Value * 60 + nysStartSecLtEar.Value;
                double ltEarEnd = nysEndMinLtEar.Value * 60 + nysEndSecLtEar.Value;
                ltEarSeries.Points.Add(new DataPoint(ltEarStart, vOffsetLtEar));
                ltEarSeries.Points.Add(new DataPoint(ltEarEnd, vOffsetLtEar));
                calorigram.Series.Add(ltEarSeries);
            }

            calorigram.InvalidatePlot(true);
        }

        private void FindCanalParesis()
        {
            if (NysStartMin30RtEar != null && NysStartSec30RtEar != null &&
                NysEndMin30RtEar != null && NysEndSec30RtEar != null &&
                NysStartMin30LtEar != null && NysStartSec30LtEar != null &&
                NysEndMin30LtEar != null && NysEndSec30LtEar != null &&
                NysStartMin44RtEar != null && NysStartSec44RtEar != null &&
                NysEndMin44RtEar != null && NysEndSec44RtEar != null &&
                NysStartMin44LtEar != null && NysStartSec44LtEar != null &&
                NysEndMin44LtEar != null && NysEndSec44LtEar != null)
            {
                double R44 = GetNystagmusDurationSec(NysStartMin44RtEar, NysStartSec44RtEar, NysEndMin44RtEar,
                    NysEndSec44RtEar);
                double R30 = GetNystagmusDurationSec(NysStartMin30RtEar, NysStartSec30RtEar, NysEndMin30RtEar,
                    NysEndSec30RtEar);
                double L44 = GetNystagmusDurationSec(NysStartMin44LtEar, NysStartSec44LtEar, NysEndMin44LtEar, 
                    NysEndSec44LtEar);
                double L30 = GetNystagmusDurationSec(NysStartMin30LtEar, NysStartSec30LtEar, NysEndMin30LtEar,
                    NysEndSec30LtEar);

                CanalParesis = ((R44 + R30) - (L44 + L30))/(R44 + L44 + R30 + L30) * 100;
            }
        }

        private double GetNystagmusDurationSec(double? startMin, double? startSec, double? endMin, double? endSec)
        {
            double start = startMin.Value * 60 + startSec.Value;
            double end = endMin.Value * 60 + endSec.Value;
            return (end - start);
        }

        private bool CanFindCanalParesisExecute()
        {
            return true;
        }

        private void FindDirPrepond()
        {
            if (NysStartMin30RtEar != null && NysStartSec30RtEar != null &&
                NysEndMin30RtEar != null && NysEndSec30RtEar != null && 
                NysStartMin30LtEar != null && NysStartSec30LtEar != null && 
                NysEndMin30LtEar != null && NysEndSec30LtEar != null && 
                NysStartMin44RtEar != null && NysStartSec44RtEar != null && 
                NysEndMin44RtEar != null && NysEndSec44RtEar != null && 
                NysStartMin44LtEar != null && NysStartSec44LtEar != null && 
                NysEndMin44LtEar != null && NysEndSec44LtEar != null)
            {
                double R44 = GetNystagmusDurationSec(NysStartMin44RtEar, NysStartSec44RtEar, NysEndMin44RtEar, 
                    NysEndSec44RtEar);
                double R30 = GetNystagmusDurationSec(NysStartMin30RtEar, NysStartSec30RtEar, NysEndMin30RtEar,
                    NysEndSec30RtEar);
                double L44 = GetNystagmusDurationSec(NysStartMin44LtEar, NysStartSec44LtEar, NysEndMin44LtEar,
                    NysEndSec44LtEar);
                double L30 = GetNystagmusDurationSec(NysStartMin30LtEar, NysStartSec30LtEar, NysEndMin30LtEar,
                    NysEndSec30LtEar);

                DirPrepond = ((R44 + L30) - (L44 + R30))/(R44 + L44 + R30 + L30) * 100;
            }
        }

        private bool CanFindDirPrepondExecute()
        {
            return true;
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            return bcModel.AddRecordToDatabase(accNumber, examDate, out msg);
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            return bcModel.UpdateRecordInDatabase(accNumber, examDate, out msg);
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            bcModel.OpenRecordFromDatabase(accNumber, examDate);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            return bcModel.DeleteRecordFromDatabase(accNumber, examDate);
        }

        public override void InitializeProperties()
        {
            IsCaloricTestConducted = false;
            IsAirTest = true;
            IsWaterTest = false;
            NysStartMin30RtEar = null;
            NysStartSec30RtEar = null;
            NysEndMin30RtEar = null;
            NysEndSec30RtEar = null;
            NysStartMin30LtEar = null;
            NysStartSec30LtEar = null;
            NysEndMin30LtEar = null;
            NysEndSec30LtEar = null;
            NysStartMin44RtEar = null;
            NysStartSec44RtEar = null;
            NysEndMin44RtEar = null;
            NysEndSec44RtEar = null;
            NysStartMin44LtEar = null;
            NysStartSec44LtEar = null;
            NysEndMin44LtEar = null;
            NysEndSec44LtEar = null;
            CanalParesis = null;
            DirPrepond = null;
        }
        #endregion
    }
}
