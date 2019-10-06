using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class SoundFieldVM : PureToneAMTabVM
    {
        public SoundFieldVM()
        {
            TabTitle = "S";
            PureToneData = new SoundFieldData();
        }
    }
}
