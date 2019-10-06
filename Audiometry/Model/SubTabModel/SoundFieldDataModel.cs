using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class SoundFieldDataModel : PureToneDataModel
    {
        public SoundFieldDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneS";
        }
    }
}
