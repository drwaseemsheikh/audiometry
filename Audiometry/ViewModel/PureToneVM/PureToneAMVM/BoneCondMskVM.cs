using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class BoneCondMskVM : PureToneAMTabVM
    {
        public BoneCondMskVM()
        {
            TabTitle = "BC(Msk)";
            PureToneData = new BoneCondMskData();
        }
    }
}
