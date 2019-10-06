using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.SpecialTestsVM;
using Audiometry.ViewModel.PureToneVM.TuningForkVM;

namespace Audiometry.Model.SubTabModel
{
    public class StengerModel : SubTabModel
    {
        #region Database
        private const string dbTable = "Stenger";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn stgrRtEarCol;
        private readonly DbColumn stgrLtEarCol;
        #endregion

        #region Methods
        public StengerModel(SubTabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            stgrRtEarCol = new DbColumn(3, "StgrRtEar", string.Empty);
            stgrLtEarCol = new DbColumn(4, "StgrLtEar", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate, bool testConducted)
        {
            StengerTabVM stgViewModel = (StengerTabVM)viewmodel;

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = testConducted.ToString(CultureInfo.InvariantCulture);
            stgrRtEarCol.Value = stgViewModel.StgrRtEar.ToString();
            stgrLtEarCol.Value = stgViewModel.StgrLtEar.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + stgrRtEarCol.Name + "," + stgrLtEarCol.Name + ")" +
                           " values ('" + accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" +
                           isTestConductedCol.Value + "', '" + stgrRtEarCol.Value + "', '" + stgrLtEarCol.Value + "')";
            return query;
        }

        private static bool ExecuteQuery(string query, out string msg)
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
                msg = "Failed to write Stenger test data to database table " + dbTable + ".";
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
                           stgrRtEarCol.Name + " = '" + stgrRtEarCol.Value + "', " +
                           stgrLtEarCol.Name + " = '" + stgrLtEarCol.Value + "'" +
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
                StengerTabVM stgViewModel = (StengerTabVM)viewmodel;

                testConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                stgViewModel.StgrRtEar = (TuningForkTypes.Stenger)Enum.Parse(typeof(TuningForkTypes.Stenger), reader.GetString(stgrRtEarCol.Index));
                stgViewModel.StgrLtEar = (TuningForkTypes.Stenger)Enum.Parse(typeof(TuningForkTypes.Stenger), reader.GetString(stgrLtEarCol.Index));
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
