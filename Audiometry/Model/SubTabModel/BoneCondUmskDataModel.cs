using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class BoneCondUmskDataModel : PureToneDataModel
    {
        public BoneCondUmskDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneBCUMsk";
        }
    }
}
