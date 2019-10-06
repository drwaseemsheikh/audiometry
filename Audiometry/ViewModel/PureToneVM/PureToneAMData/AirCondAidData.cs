using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class AirCondAidData : PureToneData
    {
        public AirCondAidData()
        {
            AddBCFreqShift = false;
            AudiogramPlot = new AirCondAidPlot();
            ptDataModel = new AirCondAidDataModel(this);
        }
    }
}
