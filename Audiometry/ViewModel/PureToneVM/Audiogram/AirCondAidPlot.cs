using Audiometry.ViewModel.PureToneVM.Audiogram.Marker;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;
using OxyPlot.Series;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public sealed class AirCondAidPlot : AudiogramPlot
    {
        protected override LineSeries AddLineSeries(EarType earType, bool isNoResponse)
        {
            LineSeries lineSeries = new LineSeries();
            SetCommonValues(earType, lineSeries);
            lineSeries.MarkerType = MarkerType.Custom;
            lineSeries.MarkerOutline = ACAidMarker.CreateCustomMarker(earType, isNoResponse, true);                        
            lineSeries.LineStyle = LineStyle.None;

            return lineSeries;
        }
    }
}
