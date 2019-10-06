using System.Collections.Generic;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public static class HLThreshold
    {
        public const double ProfoundHLdB = 90;
        public const double SevereHLdB = 70;
        public const double ModerateHLdB = 40;
        public const double MildHLdB = 20;
        public const double NormalHLdB = 0;
    }

    public static class AudiogramAxes
    {
        public const double FreqAxisLeftMargin = 25;
        public const double FreqAxisRightMargin = 2000;
        public const double PowerAxisMargin = 9;
        public const double FreqAxisMinHz = HearingFrequencyLimits.MinHearingFreqHz - FreqAxisLeftMargin;
        public const double FreqAxisMaxHz = HearingFrequencyLimits.MaxHearingFreqHz + FreqAxisRightMargin;
        public const double PowerAxisMindB = HearingPowerLimits.MinHearingLeveldB - PowerAxisMargin;
        public const double PowerAxisMaxdB = HearingPowerLimits.MaxHearingLeveldB + PowerAxisMargin;
    }

    public static class FreqAxis
    {
        public static SortedDictionary<double, double> MajorMinorAxisTicks = new SortedDictionary<double, double>()
                                                                             {
                                                                                 {125, 187.5},
                                                                                 {250, 375},
                                                                                 {500, 750},
                                                                                 {1000, 1500},
                                                                                 {2000, 2500},
                                                                                 {3000, 3500},
                                                                                 {4000, 5000},
                                                                                 {6000, 7000},
                                                                                 {8000, 9000}
                                                                             };
    }

    public static class AnnotationText
    {
        public const int AnnotationTextOffset = 5;
        public const string ProfoundHL = "Profound Hearing Loss";
        public const string SevereHL = "Severe Hearing Loss";
        public const string ModerateHL = "Moderate Hearing Loss";
        public const string MildHL = "Mild Hearing Loss";
        public const string NormalHL = "Normal Hearing";
    }

    public static class ProfoundHLFill
    {
        public const int Red = 255;
        public const int Green = 153;
        public const int Blue = 153;
    }

    public static class SevereHLFill
    {
        public const int Red = 255;
        public const int Green = 204;
        public const int Blue = 204;
    }

    public static class ModerateHLFill
    {
        public const int Red = 204;
        public const int Green = 229;
        public const int Blue = 255;
    }

    public static class MildHLFill
    {
        public const int Red = 255;
        public const int Green = 255;
        public const int Blue = 204;
    }

    public static class NormalFill
    {
        public const int Red = 255;
        public const int Green = 255;
        public const int Blue = 255;
    }

    public class AGPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public AGPoint()
        {
        }

        public AGPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
