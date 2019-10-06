using Audiometry.ViewModel;

namespace Audiometry.Model.SubTabModel
{
    public class LoudDiscomLvlDataModel : PureToneDataModel
    {
        public LoudDiscomLvlDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneLDL";
        }
    }
}
