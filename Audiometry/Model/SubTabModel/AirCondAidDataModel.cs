using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class AirCondAidDataModel : PureToneDataModel
    {
        public AirCondAidDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneACAid";
        }
    }
}
