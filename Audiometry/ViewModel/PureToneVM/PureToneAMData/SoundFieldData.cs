using Audiometry.Model.SubTabModel;
using Audiometry.ViewModel.PureToneVM.Audiogram;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMData
{
    public class SoundFieldData : PureToneData
    {
        public SoundFieldData()
        {
            AddBCFreqShift = false;
            AudiogramPlot = new SoundFieldPlot();
            ptDataModel = new SoundFieldDataModel(this);
        }
    }
}
