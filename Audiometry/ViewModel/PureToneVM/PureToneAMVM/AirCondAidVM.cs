using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class AirCondAidVM : PureToneAMTabVM
    {
        public AirCondAidVM()
        {
            TabTitle = "AC(Aid)";
            PureToneData = new AirCondAidData();
        }
    }
}
