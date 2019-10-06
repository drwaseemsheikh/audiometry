using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class BoneCondUmskVM : PureToneAMTabVM
    {
        public BoneCondUmskVM()
        {
            TabTitle = "BC(U/Msk)";
            PureToneData = new BoneCondUmskData();
        }
    }
}
