using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Audiometry.Converter;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public abstract class AudiogramPlot
    {
        public List<LineSeries> RtEarSeriesList { get; set; }
        public List<LineSeries> LtEarSeriesList { get; set; }
        protected OxyColor RtEarMarkerColor { get; set; }
        protected OxyColor LtEarMarkerColor { get; set; }
        protected double MarkerStrokeThickness { get; set; }
        protected double MarkerSize { get; set; }
        protected OxyColor RtEarLineColor { get; set; }
        protected OxyColor LtEarLineColor { get; set; }

        public static PlotModel PlotModel { get; private set; }

        protected AudiogramPlot()
        {
            RtEarSeriesList = new List<LineSeries>();
            LtEarSeriesList = new List<LineSeries>();

            RtEarMarkerColor = OxyColors.Red;
            RtEarLineColor = OxyColors.Red;
            LtEarMarkerColor = OxyColors.Blue;
            LtEarLineColor = OxyColors.Blue;
            MarkerStrokeThickness = 2;
            MarkerSize = 8;

            PlotModel = new PlotModel();
            AddAxes();
            //AddHLThresholdsAnnotation();
        }

        private static void AddAxes()
        {
            PlotModel.Axes.Add(new FreqLogAxis
            {
                Position = AxisPosition.Top,
                Minimum = AudiogramAxes.FreqAxisMinHz,
                Maximum = AudiogramAxes.FreqAxisMaxHz,
                Title = "Frequency (Hz)",
                MajorGridlineStyle = OxyPlot.LineStyle.Solid,
                MinorGridlineStyle = OxyPlot.LineStyle.Dot,
                IsZoomEnabled = false,                
                IsPanEnabled = false
            });

            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = AudiogramAxes.PowerAxisMindB,
                Maximum = AudiogramAxes.PowerAxisMaxdB,
                StartPosition = 1,
                EndPosition = 0,
                Title = "Hearing Level in dB HL (ANSI 1996)",
                MajorGridlineStyle = OxyPlot.LineStyle.Solid,
                MinorGridlineStyle = OxyPlot.LineStyle.Dot,
                MajorStep = 10,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });
        }

        private static void AddHLThresholdsAnnotation()
        {
            PolygonAnnotation profoundHL = new PolygonAnnotation();
            profoundHL.Text = AnnotationText.ProfoundHL;
            profoundHL.TextPosition = new DataPoint(AudiogramAxes.FreqAxisMinHz + AnnotationText.AnnotationTextOffset,
                HLThreshold.ProfoundHLdB + AnnotationText.AnnotationTextOffset);
            profoundHL.TextHorizontalAlignment = HorizontalAlignment.Left;
            profoundHL.Layer = AnnotationLayer.BelowAxes;
            profoundHL.Fill = OxyColor.FromRgb(ProfoundHLFill.Red, ProfoundHLFill.Green, ProfoundHLFill.Blue);
            profoundHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, AudiogramAxes.PowerAxisMaxdB));
            profoundHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, AudiogramAxes.PowerAxisMaxdB));
            profoundHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.ProfoundHLdB));
            profoundHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.ProfoundHLdB));

            PolygonAnnotation severeHL = new PolygonAnnotation();
            severeHL.Text = AnnotationText.SevereHL;
            severeHL.TextPosition = new DataPoint(AudiogramAxes.FreqAxisMinHz + AnnotationText.AnnotationTextOffset,
                HLThreshold.SevereHLdB + AnnotationText.AnnotationTextOffset);
            severeHL.TextHorizontalAlignment = HorizontalAlignment.Left;
            severeHL.Layer = AnnotationLayer.BelowAxes;
            severeHL.Fill = OxyColor.FromRgb(SevereHLFill.Red, SevereHLFill.Green, SevereHLFill.Blue);
            severeHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.ProfoundHLdB));
            severeHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.ProfoundHLdB));
            severeHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.SevereHLdB));
            severeHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.SevereHLdB));

            PolygonAnnotation moderateHL = new PolygonAnnotation();
            moderateHL.Text = AnnotationText.ModerateHL;
            moderateHL.TextPosition = new DataPoint(AudiogramAxes.FreqAxisMinHz + AnnotationText.AnnotationTextOffset,
                HLThreshold.ModerateHLdB + AnnotationText.AnnotationTextOffset);
            moderateHL.TextHorizontalAlignment = HorizontalAlignment.Left;
            moderateHL.Layer = AnnotationLayer.BelowAxes;
            moderateHL.Fill = OxyColor.FromRgb(ModerateHLFill.Red, ModerateHLFill.Green, ModerateHLFill.Blue);
            moderateHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.SevereHLdB));
            moderateHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.SevereHLdB));
            moderateHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.ModerateHLdB));
            moderateHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.ModerateHLdB));

            PolygonAnnotation mildHL = new PolygonAnnotation();
            mildHL.Text = AnnotationText.MildHL;
            mildHL.TextPosition = new DataPoint(AudiogramAxes.FreqAxisMinHz + AnnotationText.AnnotationTextOffset,
                HLThreshold.MildHLdB + AnnotationText.AnnotationTextOffset);
            mildHL.TextHorizontalAlignment = HorizontalAlignment.Left;
            mildHL.Layer = AnnotationLayer.BelowAxes;
            mildHL.Fill = OxyColor.FromRgb(MildHLFill.Red, MildHLFill.Green, MildHLFill.Blue);
            mildHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.ModerateHLdB));
            mildHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.ModerateHLdB));
            mildHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.MildHLdB));
            mildHL.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.MildHLdB));

            PolygonAnnotation normal = new PolygonAnnotation();
            normal.Text = AnnotationText.NormalHL;
            normal.TextPosition = new DataPoint(AudiogramAxes.FreqAxisMinHz + AnnotationText.AnnotationTextOffset,
                HLThreshold.NormalHLdB + AnnotationText.AnnotationTextOffset);
            normal.TextHorizontalAlignment = HorizontalAlignment.Left;
            normal.Layer = AnnotationLayer.BelowAxes;
            normal.Fill = OxyColor.FromRgb(NormalFill.Red, NormalFill.Green, NormalFill.Blue);
            normal.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.MildHLdB));
            normal.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.MildHLdB));
            normal.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMaxHz, HLThreshold.NormalHLdB));
            normal.Points.Add(new DataPoint(AudiogramAxes.FreqAxisMinHz, HLThreshold.NormalHLdB));

            PlotModel.Annotations.Add(normal);
            PlotModel.Annotations.Add(mildHL);
            PlotModel.Annotations.Add(moderateHL);
            PlotModel.Annotations.Add(severeHL);
            PlotModel.Annotations.Add(profoundHL);
        }


        public void UpdateEarPlot(EarType earType, SortedDictionary<double, HearingLevel> hearingLevels, bool addBCShift)
        {
            ClearPlot(earType);

            HearingLevelTypes prevSeriesHLType = HearingLevelTypes.InitialEmptyState;
            HearingLevelTypes currElementHLType = HearingLevelTypes.InitialEmptyState;
            LineSeries lineSeries = null;

            for (int i = 0; i < hearingLevels.Count; i++)
            {
                KeyValuePair<double, HearingLevel> keyValue = hearingLevels.ElementAt(i);
                double freqHz = keyValue.Key;
                HearingLevel hearingLevel = keyValue.Value;
                double? earHearingLevel = null;
                string earHearingLevelStr = null;

                if (addBCShift)
                {
                    freqHz = FreqAxis.MajorMinorAxisTicks[freqHz];
                }

                if (earType == EarType.RightEar)
                {
                    earHearingLevel = hearingLevel.RightEarHLdB;
                    earHearingLevelStr = hearingLevel.RightEarHLdBStr;

                }
                else if (earType == EarType.LeftEar)
                {
                    earHearingLevel = hearingLevel.LeftEarHLdB;
                    earHearingLevelStr = hearingLevel.LeftEarHLdBStr;
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }

                if (earHearingLevel != null)
                {
                    currElementHLType = HearingLevelTypes.TestedAndResponded;
                }
                else if (earHearingLevelStr != null && 
                    earHearingLevelStr.Equals(HearingLevelTypes.NoResponse.GetDescription(), StringComparison.CurrentCultureIgnoreCase))
                {
                    currElementHLType = HearingLevelTypes.NoResponse;
                }
                else if (earHearingLevelStr != null &&
                    earHearingLevelStr.Equals(HearingLevelTypes.NotTested.GetDescription(), StringComparison.CurrentCultureIgnoreCase))
                {
                    currElementHLType = HearingLevelTypes.NotTested;
                }
                else
                {
                    currElementHLType = HearingLevelTypes.InitialEmptyState;
                }

                if (currElementHLType != prevSeriesHLType)
                {
                    prevSeriesHLType = currElementHLType;

                    if (currElementHLType == HearingLevelTypes.TestedAndResponded)
                    {
                        lineSeries = AddLineSeries(earType, false);
                        lineSeries.Points.Add(new DataPoint(freqHz, earHearingLevel.Value));
                    }
                    else if (currElementHLType == HearingLevelTypes.NoResponse)
                    {
                        lineSeries = AddLineSeries(earType, true);
                        lineSeries.Points.Add(new DataPoint(freqHz, HearingPowerLimits.MaxHearingLeveldB));
                    }
                }
                else
                {
                    if (currElementHLType == HearingLevelTypes.TestedAndResponded)
                    {
                        lineSeries.Points.Add(new DataPoint(freqHz, earHearingLevel.Value));
                    }
                    else if (currElementHLType == HearingLevelTypes.NoResponse)
                    {
                        lineSeries.Points.Add(new DataPoint(freqHz, HearingPowerLimits.MaxHearingLeveldB));
                    }
                }
            }

            PlotModel.InvalidatePlot(true);
        }

        private void ClearPlot(EarType earType)
        {
            List<LineSeries> lineSeriesList = null;
            if (earType == EarType.RightEar)
            {
                lineSeriesList = RtEarSeriesList;
            }
            else if (earType == EarType.LeftEar)
            {
                lineSeriesList = LtEarSeriesList;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            foreach (var lineSeries in lineSeriesList)
            {
                List<DataPoint> points = lineSeries.Points;
                points.Clear();
            }

            lineSeriesList.Clear();
        }

        protected void SetCommonValues(EarType earType, LineSeries lineSeries)
        {
            if (earType == EarType.RightEar)
            {
                RtEarSeriesList.Add(lineSeries);
                lineSeries.MarkerStroke = RtEarMarkerColor;
                lineSeries.Color = RtEarLineColor;
            }
            else if (earType == EarType.LeftEar)
            {
                LtEarSeriesList.Add(lineSeries);
                lineSeries.MarkerStroke = LtEarMarkerColor;
                lineSeries.Color = LtEarLineColor;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            lineSeries.MarkerStrokeThickness = MarkerStrokeThickness;
            lineSeries.MarkerSize = MarkerSize;
            PlotModel.Series.Add(lineSeries);
        }

        protected abstract LineSeries AddLineSeries(EarType earType, bool isNoResponse);
    }
}
