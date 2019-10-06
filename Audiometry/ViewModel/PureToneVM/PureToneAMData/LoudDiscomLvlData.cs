using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class LoudDiscomLvlData : PureToneData
    {
        public LoudDiscomLvlData()
        {
            AddBCFreqShift = false;
            AudiogramPlot = new LoudDiscomLvlPlot();
            ptDataModel = new LoudDiscomLvlDataModel(this);
        }
    }
}
