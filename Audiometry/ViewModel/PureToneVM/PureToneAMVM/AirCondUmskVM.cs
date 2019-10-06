using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class AirCondUmskVM : PureToneAMTabVM
    {
        public AirCondUmskVM()
        {
            TabTitle = "AC(U/Msk)";
            PureToneData = new AirCondUmskData();
        }
    }
}
