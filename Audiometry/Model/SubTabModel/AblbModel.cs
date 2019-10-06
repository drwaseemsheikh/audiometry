using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.SpecialTestsVM;

namespace Audiometry.Model.SubTabModel
{
    public class AblbModel : SubTabModel
    {
        #region Database
        private const string dbTable = "Ablb";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn re0Col;
        private readonly DbColumn re1Col;
        private readonly DbColumn re2Col;
        private readonly DbColumn re3Col;
        private readonly DbColumn re4Col;
        private readonly DbColumn re5Col;
        private readonly DbColumn re6Col;
        private readonly DbColumn re7Col;
        private readonly DbColumn re8Col;
        private readonly DbColumn re9Col;
        private readonly DbColumn le0Col;
        private readonly DbColumn le1Col;
        private readonly DbColumn le2Col;
        private readonly DbColumn le3Col;
        private readonly DbColumn le4Col;
        private readonly DbColumn le5Col;
        private readonly DbColumn le6Col;
        private readonly DbColumn le7Col;
        private readonly DbColumn le8Col;
        private readonly DbColumn le9Col;
        #endregion

        #region Methods
        public AblbModel(SubTabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            re0Col = new DbColumn(3, "RE0", string.Empty);
            re1Col = new DbColumn(4, "RE1", string.Empty);
            re2Col = new DbColumn(5, "RE2", string.Empty);
            re3Col = new DbColumn(6, "RE3", string.Empty);
            re4Col = new DbColumn(7, "RE4", string.Empty);
            re5Col = new DbColumn(8, "RE5", string.Empty);
            re6Col = new DbColumn(9, "RE6", string.Empty);
            re7Col = new DbColumn(10, "RE7", string.Empty);
            re8Col = new DbColumn(11, "RE8", string.Empty);
            re9Col = new DbColumn(12, "RE9", string.Empty);
            le0Col = new DbColumn(13, "LE0", string.Empty);
            le1Col = new DbColumn(14, "LE1", string.Empty);
            le2Col = new DbColumn(15, "LE2", string.Empty);
            le3Col = new DbColumn(16, "LE3", string.Empty);
            le4Col = new DbColumn(17, "LE4", string.Empty);
            le5Col = new DbColumn(18, "LE5", string.Empty);
            le6Col = new DbColumn(19, "LE6", string.Empty);
            le7Col = new DbColumn(20, "LE7", string.Empty);
            le8Col = new DbColumn(21, "LE8", string.Empty);
            le9Col = new DbColumn(22, "LE9", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate, bool testConducted)
        {
            AblbTabVM ablbViewModel = (AblbTabVM)viewmodel;

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = testConducted.ToString(CultureInfo.InvariantCulture);
            re0Col.Value = ablbViewModel.RightEar0.ToString();
            re1Col.Value = ablbViewModel.RightEar1.ToString();
            re2Col.Value = ablbViewModel.RightEar2.ToString();
            re3Col.Value = ablbViewModel.RightEar3.ToString();
            re4Col.Value = ablbViewModel.RightEar4.ToString();
            re5Col.Value = ablbViewModel.RightEar5.ToString();
            re6Col.Value = ablbViewModel.RightEar6.ToString();
            re7Col.Value = ablbViewModel.RightEar7.ToString();
            re8Col.Value = ablbViewModel.RightEar8.ToString();
            re9Col.Value = ablbViewModel.RightEar9.ToString();
            le0Col.Value = ablbViewModel.LeftEar0.ToString();
            le1Col.Value = ablbViewModel.LeftEar1.ToString();
            le2Col.Value = ablbViewModel.LeftEar2.ToString();
            le3Col.Value = ablbViewModel.LeftEar3.ToString();
            le4Col.Value = ablbViewModel.LeftEar4.ToString();
            le5Col.Value = ablbViewModel.LeftEar5.ToString();
            le6Col.Value = ablbViewModel.LeftEar6.ToString();
            le7Col.Value = ablbViewModel.LeftEar7.ToString();
            le8Col.Value = ablbViewModel.LeftEar8.ToString();
            le9Col.Value = ablbViewModel.LeftEar9.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + re0Col.Name + "," + re1Col.Name + "," +
                           re2Col.Name + "," + re3Col.Name + "," + re4Col.Name + "," + re5Col.Name + "," +
                           re6Col.Name + "," + re7Col.Name + "," + re8Col.Name + "," + re9Col.Name + "," +
                           le0Col.Name + "," + le1Col.Name + "," + le2Col.Name + "," + le3Col.Name + "," +
                           le4Col.Name + "," + le5Col.Name + "," + le6Col.Name + "," + le7Col.Name + "," +
                           le8Col.Name + "," + le9Col.Name + ")" +
                           " values ('" +
                           accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value + "', '" +
                           re0Col.Value + "', '" + re1Col.Value + "', '" + re2Col.Value + "', '" + re3Col.Value + "', '" +
                           re4Col.Value + "', '" + re5Col.Value + "', '" + re6Col.Value + "', '" + re7Col.Value + "', '" +
                           re8Col.Value + "', '" + re9Col.Value + "', '" + le0Col.Value + "', '" + le1Col.Value + "', '" +
                           le2Col.Value + "', '" + le3Col.Value + "', '" + le4Col.Value + "', '" + le5Col.Value + "', '" +
                           le6Col.Value + "', '" + le7Col.Value + "', '" + le8Col.Value + "', '" + le9Col.Value + "')";
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
                msg = "Failed to write ABLB test data to database table " + dbTable + ".";
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
                           re0Col.Name + " = '" + re0Col.Value + "', " +
                           re1Col.Name + " = '" + re1Col.Value + "', " +
                           re2Col.Name + " = '" + re2Col.Value + "', " +
                           re3Col.Name + " = '" + re3Col.Value + "', " +
                           re4Col.Name + " = '" + re4Col.Value + "', " +
                           re5Col.Name + " = '" + re5Col.Value + "', " +
                           re6Col.Name + " = '" + re6Col.Value + "', " +
                           re7Col.Name + " = '" + re7Col.Value + "', " +
                           re8Col.Name + " = '" + re8Col.Value + "', " +
                           re9Col.Name + " = '" + re9Col.Value + "', " +
                           le0Col.Name + " = '" + le0Col.Value + "', " +
                           le1Col.Name + " = '" + le1Col.Value + "', " +
                           le2Col.Name + " = '" + le2Col.Value + "', " +
                           le3Col.Name + " = '" + le3Col.Value + "', " +
                           le4Col.Name + " = '" + le4Col.Value + "', " +
                           le5Col.Name + " = '" + le5Col.Value + "', " +
                           le6Col.Name + " = '" + le6Col.Value + "', " +
                           le7Col.Name + " = '" + le7Col.Value + "', " +
                           le8Col.Name + " = '" + le8Col.Value + "', " +
                           le9Col.Name + " = '" + le9Col.Value + "'" +
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
                AblbTabVM ablbViewModel = (AblbTabVM)viewmodel;                

                testConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                ablbViewModel.RightEar0 = NullDoubleHelper.ToNullableDouble(reader.GetString(re0Col.Index));
                ablbViewModel.RightEar1 = NullDoubleHelper.ToNullableDouble(reader.GetString(re1Col.Index));
                ablbViewModel.RightEar2 = NullDoubleHelper.ToNullableDouble(reader.GetString(re2Col.Index));
                ablbViewModel.RightEar3 = NullDoubleHelper.ToNullableDouble(reader.GetString(re3Col.Index));
                ablbViewModel.RightEar4 = NullDoubleHelper.ToNullableDouble(reader.GetString(re4Col.Index));
                ablbViewModel.RightEar5 = NullDoubleHelper.ToNullableDouble(reader.GetString(re5Col.Index));
                ablbViewModel.RightEar6 = NullDoubleHelper.ToNullableDouble(reader.GetString(re6Col.Index));
                ablbViewModel.RightEar7 = NullDoubleHelper.ToNullableDouble(reader.GetString(re7Col.Index));
                ablbViewModel.RightEar8 = NullDoubleHelper.ToNullableDouble(reader.GetString(re8Col.Index));
                ablbViewModel.RightEar9 = NullDoubleHelper.ToNullableDouble(reader.GetString(re9Col.Index));
                ablbViewModel.LeftEar0 = NullDoubleHelper.ToNullableDouble(reader.GetString(le0Col.Index));
                ablbViewModel.LeftEar1 = NullDoubleHelper.ToNullableDouble(reader.GetString(le1Col.Index));
                ablbViewModel.LeftEar2 = NullDoubleHelper.ToNullableDouble(reader.GetString(le2Col.Index));
                ablbViewModel.LeftEar3 = NullDoubleHelper.ToNullableDouble(reader.GetString(le3Col.Index));
                ablbViewModel.LeftEar4 = NullDoubleHelper.ToNullableDouble(reader.GetString(le4Col.Index));
                ablbViewModel.LeftEar5 = NullDoubleHelper.ToNullableDouble(reader.GetString(le5Col.Index));
                ablbViewModel.LeftEar6 = NullDoubleHelper.ToNullableDouble(reader.GetString(le6Col.Index));
                ablbViewModel.LeftEar7 = NullDoubleHelper.ToNullableDouble(reader.GetString(le7Col.Index));
                ablbViewModel.LeftEar8 = NullDoubleHelper.ToNullableDouble(reader.GetString(le8Col.Index));
                ablbViewModel.LeftEar9 = NullDoubleHelper.ToNullableDouble(reader.GetString(le9Col.Index));
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
