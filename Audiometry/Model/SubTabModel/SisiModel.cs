using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.SpecialTestsVM;

namespace Audiometry.Model.SubTabModel
{
    public class SisiModel : SubTabModel
    {
        #region Database
        private const string dbTable = "Sisi";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn sisiRtEarCol;
        private readonly DbColumn sisiLtEarCol;
        #endregion

        #region Methods
        public SisiModel(SubTabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            sisiRtEarCol = new DbColumn(3, "SisiRtEar", string.Empty);
            sisiLtEarCol = new DbColumn(4, "SisiLtEar", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate, bool testConducted)
        {
            SisiTabVM sisiViewModel = (SisiTabVM)viewmodel;

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = testConducted.ToString(CultureInfo.InvariantCulture);
            sisiRtEarCol.Value = sisiViewModel.SisiRtEar.ToString();
            sisiLtEarCol.Value = sisiViewModel.SisiLtEar.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + sisiRtEarCol.Name + "," + sisiLtEarCol.Name + ")" +
                           " values ('" + accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" +
                           isTestConductedCol.Value + "', '" + sisiRtEarCol.Value + "', '" + sisiLtEarCol.Value + "')";
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
                msg = "Failed to write SISI test data to database table " + dbTable + ".";
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
                           sisiRtEarCol.Name + " = '" + sisiRtEarCol.Value + "', " +
                           sisiLtEarCol.Name + " = '" + sisiLtEarCol.Value + "'" +
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
                SisiTabVM sisiViewModel = (SisiTabVM)viewmodel;

                testConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                sisiViewModel.SisiRtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(sisiRtEarCol.Index));
                sisiViewModel.SisiLtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(sisiLtEarCol.Index));
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
