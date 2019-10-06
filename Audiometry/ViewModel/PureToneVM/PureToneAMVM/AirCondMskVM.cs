using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class AirCondMskVM : PureToneAMTabVM
    {
        public AirCondMskVM()
        {
            TabTitle = "AC(Msk)";
            PureToneData = new AirCondMskData();
        }
    }
}
