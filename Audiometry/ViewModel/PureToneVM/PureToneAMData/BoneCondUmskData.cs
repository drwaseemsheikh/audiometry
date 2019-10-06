using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class BoneCondUmskData : PureToneData
    {
        public BoneCondUmskData()
        {
            AddBCFreqShift = true;
            AudiogramPlot = new BoneCondUmskPlot();
            ptDataModel = new BoneCondUmskDataModel(this);
        }
    }
}
