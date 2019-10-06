using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Model.SubTabModel
{
    public class PureToneDataModel : SubTabModel
    {
        #region Database
        protected string dbTable;
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn re125Col;
        private readonly DbColumn re250Col;
        private readonly DbColumn re500Col;
        private readonly DbColumn re1000Col;
        private readonly DbColumn re2000Col;
        private readonly DbColumn re3000Col;
        private readonly DbColumn re4000Col;
        private readonly DbColumn re6000Col;
        private readonly DbColumn re8000Col;
        private readonly DbColumn le125Col;
        private readonly DbColumn le250Col;
        private readonly DbColumn le500Col;
        private readonly DbColumn le1000Col;
        private readonly DbColumn le2000Col;
        private readonly DbColumn le3000Col;
        private readonly DbColumn le4000Col;
        private readonly DbColumn le6000Col;
        private readonly DbColumn le8000Col;
        #endregion

        #region Methods
        protected PureToneDataModel(SubTabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            re125Col = new DbColumn(3, "RE125", string.Empty);
            re250Col = new DbColumn(4, "RE250", string.Empty);
            re500Col = new DbColumn(5, "RE500", string.Empty);
            re1000Col = new DbColumn(6, "RE1000", string.Empty);
            re2000Col = new DbColumn(7, "RE2000", string.Empty);
            re3000Col = new DbColumn(8, "RE3000", string.Empty);
            re4000Col = new DbColumn(9, "RE4000", string.Empty);
            re6000Col = new DbColumn(10, "RE6000", string.Empty);
            re8000Col = new DbColumn(11, "RE8000", string.Empty);
            le125Col = new DbColumn(12, "LE125", string.Empty);
            le250Col = new DbColumn(13, "LE250", string.Empty);
            le500Col = new DbColumn(14, "LE500", string.Empty);
            le1000Col = new DbColumn(15, "LE1000", string.Empty);
            le2000Col = new DbColumn(16, "LE2000", string.Empty);
            le3000Col = new DbColumn(17, "LE3000", string.Empty);
            le4000Col = new DbColumn(18, "LE4000", string.Empty);
            le6000Col = new DbColumn(19, "LE6000", string.Empty);
            le8000Col = new DbColumn(20, "LE8000", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate, bool testConducted)
        {
            PureToneData ptdViewModel = (PureToneData)viewmodel;            

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = testConducted.ToString(CultureInfo.InvariantCulture);
            re125Col.Value = ptdViewModel.RtEarHLdB125Hz;
            re250Col.Value = ptdViewModel.RtEarHLdB250Hz;
            re500Col.Value = ptdViewModel.RtEarHLdB500Hz;
            re1000Col.Value = ptdViewModel.RtEarHLdB1000Hz;
            re2000Col.Value = ptdViewModel.RtEarHLdB2000Hz;
            re3000Col.Value = ptdViewModel.RtEarHLdB3000Hz;
            re4000Col.Value = ptdViewModel.RtEarHLdB4000Hz;
            re6000Col.Value = ptdViewModel.RtEarHLdB6000Hz;
            re8000Col.Value = ptdViewModel.RtEarHLdB8000Hz;
            le125Col.Value = ptdViewModel.LtEarHLdB125Hz;
            le250Col.Value = ptdViewModel.LtEarHLdB250Hz;
            le500Col.Value = ptdViewModel.LtEarHLdB500Hz;
            le1000Col.Value = ptdViewModel.LtEarHLdB1000Hz;
            le2000Col.Value = ptdViewModel.LtEarHLdB2000Hz;
            le3000Col.Value = ptdViewModel.LtEarHLdB3000Hz;
            le4000Col.Value = ptdViewModel.LtEarHLdB4000Hz;
            le6000Col.Value = ptdViewModel.LtEarHLdB6000Hz;
            le8000Col.Value = ptdViewModel.LtEarHLdB8000Hz;
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + re125Col.Name + "," + re250Col.Name + "," +
                           re500Col.Name + "," + re1000Col.Name + "," + re2000Col.Name + "," + re3000Col.Name + "," +
                           re4000Col.Name + "," + re6000Col.Name + "," + re8000Col.Name + "," + le125Col.Name + "," +
                           le250Col.Name + "," + le500Col.Name + "," + le1000Col.Name + "," + le2000Col.Name + "," +
                           le3000Col.Name + "," + le4000Col.Name + "," + le6000Col.Name + "," + le8000Col.Name + ")" +
                           " values ('" + accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value +
                           "', '" + re125Col.Value + "', '" + re250Col.Value + "', '" + re500Col.Value + "', '" +
                           re1000Col.Value + "', '" + re2000Col.Value + "', '" + re3000Col.Value + "', '" +
                           re4000Col.Value + "', '" + re6000Col.Value + "', '" + re8000Col.Value + "', '" +
                           le125Col.Value + "', '" + le250Col.Value + "', '" + le500Col.Value + "', '" +
                           le1000Col.Value + "', '" + le2000Col.Value + "', '" + le3000Col.Value + "', '" +
                           le4000Col.Value + "', '" + le6000Col.Value + "', '" + le8000Col.Value + "')";
            return query;
        }

        private bool ExecuteQuery(string query, out string msg)
        {
            SQLiteCommand createCommand = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            int rows = createCommand.ExecuteNonQuery();

            if (rows == 1)
            {
                msg = string.Empty;
                return true;
            }
            else
            {
                msg = "Failed to write data to database table " + dbTable + ".";
                return false;
            }
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructUpdateQuery();
            return ExecuteQuery(query, out msg);
        }

        private string ConstructUpdateQuery()
        {
            string query = "UPDATE " + dbTable +
                           " SET " +
                           isTestConductedCol.Name + " = '" + isTestConductedCol.Value + "', " +
                           re125Col.Name + " = '" + re125Col.Value + "', " +
                           re250Col.Name + " = '" + re250Col.Value + "', " +
                           re500Col.Name + " = '" + re500Col.Value + "', " +
                           re1000Col.Name + " = '" + re1000Col.Value + "', " +
                           re2000Col.Name + " = '" + re2000Col.Value + "', " +
                           re3000Col.Name + " = '" + re3000Col.Value + "', " +
                           re4000Col.Name + " = '" + re4000Col.Value + "', " +
                           re6000Col.Name + " = '" + re6000Col.Value + "', " +
                           re8000Col.Name + " = '" + re8000Col.Value + "', " +
                           le125Col.Name + " = '" + le125Col.Value + "', " +
                           le250Col.Name + " = '" + le250Col.Value + "', " +
                           le500Col.Name + " = '" + le500Col.Value + "', " +
                           le1000Col.Name + " = '" + le1000Col.Value + "', " +
                           le2000Col.Name + " = '" + le2000Col.Value + "', " +
                           le3000Col.Name + " = '" + le3000Col.Value + "', " +
                           le4000Col.Name + " = '" + le4000Col.Value + "', " +
                           le6000Col.Name + " = '" + le6000Col.Value + "', " +
                           le8000Col.Name + " = '" + le8000Col.Value + "'" +
                           " WHERE " +
                           accNumberCol.Name + " = '" + accNumberCol.Value + "' AND " +
                           dateOfExamCol.Name + " = '" + dateOfExamCol.Value + "'";
            return query;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            string query = "SELECT * FROM " + dbTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand readCmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            SQLiteDataReader reader = readCmd.ExecuteReader();
            testConducted = false;

            if (reader.Read())
            {
                PureToneData ptdViewModel = (PureToneData)viewmodel;                

                testConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                ptdViewModel.RtEarHLdB125Hz = reader.GetString(re125Col.Index);
                ptdViewModel.RtEarHLdB250Hz = reader.GetString(re250Col.Index);
                ptdViewModel.RtEarHLdB500Hz = reader.GetString(re500Col.Index);
                ptdViewModel.RtEarHLdB1000Hz = reader.GetString(re1000Col.Index);
                ptdViewModel.RtEarHLdB2000Hz = reader.GetString(re2000Col.Index);
                ptdViewModel.RtEarHLdB3000Hz = reader.GetString(re3000Col.Index);
                ptdViewModel.RtEarHLdB4000Hz = reader.GetString(re4000Col.Index);
                ptdViewModel.RtEarHLdB6000Hz = reader.GetString(re6000Col.Index);
                ptdViewModel.RtEarHLdB8000Hz = reader.GetString(re8000Col.Index);
                ptdViewModel.LtEarHLdB125Hz = reader.GetString(le125Col.Index);
                ptdViewModel.LtEarHLdB250Hz = reader.GetString(le250Col.Index);
                ptdViewModel.LtEarHLdB500Hz = reader.GetString(le500Col.Index);
                ptdViewModel.LtEarHLdB1000Hz = reader.GetString(le1000Col.Index);
                ptdViewModel.LtEarHLdB2000Hz = reader.GetString(le2000Col.Index);
                ptdViewModel.LtEarHLdB3000Hz = reader.GetString(le3000Col.Index);
                ptdViewModel.LtEarHLdB4000Hz = reader.GetString(le4000Col.Index);
                ptdViewModel.LtEarHLdB6000Hz = reader.GetString(le6000Col.Index);
                ptdViewModel.LtEarHLdB8000Hz = reader.GetString(le8000Col.Index);
            }
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            string query = "DELETE FROM " + dbTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            int rows = cmd.ExecuteNonQuery();

            return (rows == 1);
        }
        #endregion
    }
}
