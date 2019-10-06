using System.Collections.Generic;
using System.Linq;
using OxyPlot.Axes;

namespace Audiometry.ViewModel.PureToneVM.Audiogram
{
    public class FreqLogAxis : LogarithmicAxis
    {
        public override void GetTickValues(out IList<double> majorLabelValues, out IList<double> majorTickValues, out IList<double> minorTickValues)
        {
            majorTickValues = FreqAxis.MajorMinorAxisTicks.Keys.ToList();
            minorTickValues = FreqAxis.MajorMinorAxisTicks.Values.ToList();
            majorLabelValues = majorTickValues;
        }
    }
}
