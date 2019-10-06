using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class BoneCondMskData : PureToneData
    {
        public BoneCondMskData()
        {
            AddBCFreqShift = true;
            AudiogramPlot = new BoneCondMskPlot();
            ptDataModel = new BoneCondMskDataModel(this);
        }
    }
}
