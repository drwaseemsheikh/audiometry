using Audiometry.ViewModel.PureToneVM.Audiogram.Marker;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;
using OxyPlot.Series;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public sealed class LoudDiscomLvlPlot : AudiogramPlot
    {
        protected override LineSeries AddLineSeries(EarType earType, bool isNoResponse)
        {
            LineSeries lineSeries = new LineSeries();
            SetCommonValues(earType, lineSeries);
            lineSeries.MarkerType = MarkerType.Custom;
            lineSeries.MarkerOutline = LdlMarker.CreateCustomMarker(earType, isNoResponse, true);
            lineSeries.LineStyle = LineStyle.None;

            return lineSeries;
        }
    }
}
