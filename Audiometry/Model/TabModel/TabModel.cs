using Audiometry.ViewModel;

namespace Audiometry.Model.TabModel
{
    public abstract class TabModel : ModelBase
    {
        protected TabVM viewmodel;

        protected TabModel(TabVM vm)
        {
            viewmodel = vm;
        }

        public abstract bool AddRecordToDatabase(string accNumber, string examDate, out string msg);
        public abstract bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg);
        public abstract void OpenRecordFromDatabase(string accNumber, string examDate);
        public abstract bool DeleteRecordFromDatabase(string accNumber, string examDate);
    }
}
