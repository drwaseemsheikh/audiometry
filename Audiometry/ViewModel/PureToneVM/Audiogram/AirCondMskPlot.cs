using Audiometry.ViewModel.PureToneVM.Audiogram.Marker;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;
using OxyPlot.Series;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public sealed class AirCondMskPlot : AudiogramPlot
    {
        protected override LineSeries AddLineSeries(EarType earType, bool isNoResponse)
        {
            LineSeries lineSeries = new LineSeries();
            SetCommonValues(earType, lineSeries);

            if (isNoResponse)
            {
                lineSeries.MarkerType = MarkerType.Custom;
                lineSeries.MarkerOutline = ACMskMarker.CreateCustomMarkerWithArrow(earType);
                lineSeries.LineStyle = LineStyle.None;
            }
            else
            {
                lineSeries.MarkerType = ACMskMarker.GetDefaultMarker(earType);
            }
            
            return lineSeries;
        }
    }
}
