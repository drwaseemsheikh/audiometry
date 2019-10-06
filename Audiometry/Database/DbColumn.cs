namespace Audiometry.Database
{
    public class DbColumn
    {
        private int ind;
        private string name;
        private string val;

        public int Index
        {
            get { return ind; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        public DbColumn(int colInd, string colName, string colValue)
        {
            ind = colInd;
            name = colName;
            val = colValue;
        }
    }
}
