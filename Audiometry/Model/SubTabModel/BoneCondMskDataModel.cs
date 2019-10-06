using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class BoneCondMskDataModel : PureToneDataModel
    {
        public BoneCondMskDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneBCMsk";
        }
    }
}
