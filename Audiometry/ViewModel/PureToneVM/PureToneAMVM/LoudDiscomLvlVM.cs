using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.ViewModel.PureToneVM.PureToneAMVM
{
    public class LoudDiscomLvlVM : PureToneAMTabVM
    {
        public LoudDiscomLvlVM()
        {
            TabTitle = "LDL";
            PureToneData = new LoudDiscomLvlData();
        }
    }
}
