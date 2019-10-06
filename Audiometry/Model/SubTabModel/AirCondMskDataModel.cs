using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class AirCondMskDataModel : PureToneDataModel
    {
        public AirCondMskDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneACMsk";
        }
    }
}
