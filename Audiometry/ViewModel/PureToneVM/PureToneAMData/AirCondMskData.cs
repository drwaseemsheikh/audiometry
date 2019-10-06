using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class AirCondMskData : PureToneData
    {
        public AirCondMskData()
        {
            AddBCFreqShift = false;
            AudiogramPlot = new AirCondMskPlot();
            ptDataModel = new AirCondMskDataModel(this);
        }
    }
}
