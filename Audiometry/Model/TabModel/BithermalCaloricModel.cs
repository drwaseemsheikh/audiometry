using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.BithermalCaloricVM;

namespace Audiometry.Model.TabModel
{
    public class BithermalCaloricModel : TabModel
    {
        #region Database
        private const string dbTable = "BithermalCaloric";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn isAirTestCol;
        private readonly DbColumn isWaterTestCol;
        private readonly DbColumn nysStartMin30RtEarCol;
        private readonly DbColumn nysStartSec30RtEarCol;
        private readonly DbColumn nysEndMin30RtEarCol;
        private readonly DbColumn nysEndSec30RtEarCol;
        private readonly DbColumn nysStartMin30LtEarCol;
        private readonly DbColumn nysStartSec30LtEarCol;
        private readonly DbColumn nysEndMin30LtEarCol;
        private readonly DbColumn nysEndSec30LtEarCol;
        private readonly DbColumn nysStartMin44RtEarCol;
        private readonly DbColumn nysStartSec44RtEarCol;
        private readonly DbColumn nysEndMin44RtEarCol;
        private readonly DbColumn nysEndSec44RtEarCol;
        private readonly DbColumn nysStartMin44LtEarCol;
        private readonly DbColumn nysStartSec44LtEarCol;
        private readonly DbColumn nysEndMin44LtEarCol;
        private readonly DbColumn nysEndSec44LtEarCol;
        private readonly DbColumn canalParesisCol;
        private readonly DbColumn dirPrepondCol;
        #endregion

        #region Methods
        public BithermalCaloricModel(TabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            isAirTestCol = new DbColumn(3, "IsAirTest", string.Empty);
            isWaterTestCol = new DbColumn(4, "IsWaterTest", string.Empty);
            nysStartMin30RtEarCol = new DbColumn(5, "NysStartMin30RtEar", string.Empty);
            nysStartSec30RtEarCol = new DbColumn(6, "NysStartSec30RtEar", string.Empty);
            nysEndMin30RtEarCol = new DbColumn(7, "NysEndMin30RtEar", string.Empty);
            nysEndSec30RtEarCol = new DbColumn(8, "NysEndSec30RtEar", string.Empty);
            nysStartMin30LtEarCol = new DbColumn(9, "NysStartMin30LtEar", string.Empty);
            nysStartSec30LtEarCol = new DbColumn(10, "NysStartSec30LtEar", string.Empty);
            nysEndMin30LtEarCol = new DbColumn(11, "NysEndMin30LtEar", string.Empty);
            nysEndSec30LtEarCol = new DbColumn(12, "NysEndSec30LtEar", string.Empty);
            nysStartMin44RtEarCol = new DbColumn(13, "NysStartMin44RtEar", string.Empty);
            nysStartSec44RtEarCol = new DbColumn(14, "NysStartSec44RtEar", string.Empty);
            nysEndMin44RtEarCol = new DbColumn(15, "NysEndMin44RtEar", string.Empty);
            nysEndSec44RtEarCol = new DbColumn(16, "NysEndSec44RtEar", string.Empty);
            nysStartMin44LtEarCol = new DbColumn(17, "NysStartMin44LtEar", string.Empty);
            nysStartSec44LtEarCol = new DbColumn(18, "NysStartSec44LtEar", string.Empty);
            nysEndMin44LtEarCol = new DbColumn(19, "NysEndMin44LtEar", string.Empty);
            nysEndSec44LtEarCol = new DbColumn(20, "NysEndSec44LtEar", string.Empty);
            canalParesisCol = new DbColumn(21, "CanalParesis", string.Empty);
            dirPrepondCol = new DbColumn(22, "DirPrepond", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate)
        {
            BithermalCaloricTabVM bcViewModel = (BithermalCaloricTabVM)viewmodel;            

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = bcViewModel.IsCaloricTestConducted.ToString(CultureInfo.InvariantCulture);
            isAirTestCol.Value = bcViewModel.IsAirTest.ToString(CultureInfo.InvariantCulture);
            isWaterTestCol.Value = bcViewModel.IsWaterTest.ToString(CultureInfo.InvariantCulture);
            nysStartMin30RtEarCol.Value = bcViewModel.NysStartMin30RtEar.ToString();
            nysStartSec30RtEarCol.Value = bcViewModel.NysStartSec30RtEar.ToString();
            nysEndMin30RtEarCol.Value = bcViewModel.NysEndMin30RtEar.ToString();
            nysEndSec30RtEarCol.Value = bcViewModel.NysEndSec30RtEar.ToString();
            nysStartMin30LtEarCol.Value = bcViewModel.NysStartMin30LtEar.ToString();
            nysStartSec30LtEarCol.Value = bcViewModel.NysStartSec30LtEar.ToString();
            nysEndMin30LtEarCol.Value = bcViewModel.NysEndMin30LtEar.ToString();
            nysEndSec30LtEarCol.Value = bcViewModel.NysEndSec30LtEar.ToString();
            nysStartMin44RtEarCol.Value = bcViewModel.NysStartMin44RtEar.ToString();
            nysStartSec44RtEarCol.Value = bcViewModel.NysStartSec44RtEar.ToString();
            nysEndMin44RtEarCol.Value = bcViewModel.NysEndMin44RtEar.ToString();
            nysEndSec44RtEarCol.Value = bcViewModel.NysEndSec44RtEar.ToString();
            nysStartMin44LtEarCol.Value = bcViewModel.NysStartMin44LtEar.ToString();
            nysStartSec44LtEarCol.Value = bcViewModel.NysStartSec44LtEar.ToString();
            nysEndMin44LtEarCol.Value = bcViewModel.NysEndMin44LtEar.ToString();
            nysEndSec44LtEarCol.Value = bcViewModel.NysEndSec44LtEar.ToString();
            canalParesisCol.Value = bcViewModel.CanalParesis.ToString();
            dirPrepondCol.Value = bcViewModel.DirPrepond.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + isAirTestCol.Name + "," + isWaterTestCol.Name + "," +
                           nysStartMin30RtEarCol.Name + "," + nysStartSec30RtEarCol.Name + "," + nysEndMin30RtEarCol.Name + "," +
                           nysEndSec30RtEarCol.Name + "," + nysStartMin30LtEarCol.Name + "," + nysStartSec30LtEarCol.Name + "," +
                           nysEndMin30LtEarCol.Name + "," + nysEndSec30LtEarCol.Name + "," + nysStartMin44RtEarCol.Name + "," +
                           nysStartSec44RtEarCol.Name + "," + nysEndMin44RtEarCol.Name + "," + nysEndSec44RtEarCol.Name + "," +
                           nysStartMin44LtEarCol.Name + "," + nysStartSec44LtEarCol.Name + "," + nysEndMin44LtEarCol.Name + "," +
                           nysEndSec44LtEarCol.Name + "," + canalParesisCol.Name + "," + dirPrepondCol.Name + ")" +
                           " values ('" +
                           accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value + "', '" +
                           isAirTestCol.Value + "', '" + isWaterTestCol.Value + "', '" +
                           nysStartMin30RtEarCol.Value + "', '" + nysStartSec30RtEarCol.Value + "', '" +
                           nysEndMin30RtEarCol.Value + "', '" + nysEndSec30RtEarCol.Value + "', '" +
                           nysStartMin30LtEarCol.Value + "', '" + nysStartSec30LtEarCol.Value + "', '" +
                           nysEndMin30LtEarCol.Value + "', '" + nysEndSec30LtEarCol.Value + "', '" +
                           nysStartMin44RtEarCol.Value + "', '" + nysStartSec44RtEarCol.Value + "', '" +
                           nysEndMin44RtEarCol.Value + "', '" + nysEndSec44RtEarCol.Value + "', '" +
                           nysStartMin44LtEarCol.Value + "', '" + nysStartSec44LtEarCol.Value + "', '" +
                           nysEndMin44LtEarCol.Value + "', '" + nysEndSec44LtEarCol.Value + "', '" +
                           canalParesisCol.Value + "', '" + dirPrepondCol.Value + "')";
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
                msg = "Failed to write Bithermal Caloric Test data to database table " + dbTable + ".";
                return false;
            }
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate);
            string query = ConstructUpdateQuery();
            return ExecuteQuery(query, out msg);
        }

        private string ConstructUpdateQuery()
        {
            string query = "UPDATE " + dbTable +
                           " SET " +
                           isTestConductedCol.Name + " = '" + isTestConductedCol.Value + "', " +
                           isAirTestCol.Name + " = '" + isAirTestCol.Value + "', " +
                           isWaterTestCol.Name + " = '" + isWaterTestCol.Value + "', " +
                           nysStartMin30RtEarCol.Name + " = '" + nysStartMin30RtEarCol.Value + "', " +
                           nysStartSec30RtEarCol.Name + " = '" + nysStartSec30RtEarCol.Value + "', " +
                           nysEndMin30RtEarCol.Name + " = '" + nysEndMin30RtEarCol.Value + "', " +
                           nysEndSec30RtEarCol.Name + " = '" + nysEndSec30RtEarCol.Value + "', " +
                           nysStartMin30LtEarCol.Name + " = '" + nysStartMin30LtEarCol.Value + "', " +
                           nysStartSec30LtEarCol.Name + " = '" + nysStartSec30LtEarCol.Value + "', " +
                           nysEndMin30LtEarCol.Name + " = '" + nysEndMin30LtEarCol.Value + "', " +
                           nysEndSec30LtEarCol.Name + " = '" + nysEndSec30LtEarCol.Value + "', " +
                           nysStartMin44RtEarCol.Name + " = '" + nysStartMin44RtEarCol.Value + "', " +
                           nysStartSec44RtEarCol.Name + " = '" + nysStartSec44RtEarCol.Value + "', " +
                           nysEndMin44RtEarCol.Name + " = '" + nysEndMin44RtEarCol.Value + "', " +
                           nysEndSec44RtEarCol.Name + " = '" + nysEndSec44RtEarCol.Value + "', " +
                           nysStartMin44LtEarCol.Name + " = '" + nysStartMin44LtEarCol.Value + "', " +
                           nysStartSec44LtEarCol.Name + " = '" + nysStartSec44LtEarCol.Value + "', " +
                           nysEndMin44LtEarCol.Name + " = '" + nysEndMin44LtEarCol.Value + "', " +
                           nysEndSec44LtEarCol.Name + " = '" + nysEndSec44LtEarCol.Value + "', " +
                           canalParesisCol.Name + " = '" + canalParesisCol.Value + "', " +
                           dirPrepondCol.Name + " = '" + dirPrepondCol.Value + "'" +
                           " WHERE " +
                           accNumberCol.Name + " = '" + accNumberCol.Value + "' AND " +
                           dateOfExamCol.Name + " = '" + dateOfExamCol.Value + "'";
            return query;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            string query = "SELECT * FROM " + dbTable + " WHERE AccNumber = '" + accNumber +
                "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand readCmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            SQLiteDataReader reader = readCmd.ExecuteReader();

            if (reader.Read())
            {
                BithermalCaloricTabVM bcViewModel = (BithermalCaloricTabVM)viewmodel;

                bcViewModel.IsCaloricTestConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                bcViewModel.IsAirTest = Convert.ToBoolean(reader.GetString(isAirTestCol.Index));
                bcViewModel.IsWaterTest = Convert.ToBoolean(reader.GetString(isWaterTestCol.Index));
                bcViewModel.NysStartMin30RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartMin30RtEarCol.Index));
                bcViewModel.NysStartSec30RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartSec30RtEarCol.Index));
                bcViewModel.NysEndMin30RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndMin30RtEarCol.Index));
                bcViewModel.NysEndSec30RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndSec30RtEarCol.Index));
                bcViewModel.NysStartMin30LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartMin30LtEarCol.Index));
                bcViewModel.NysStartSec30LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartSec30LtEarCol.Index));
                bcViewModel.NysEndMin30LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndMin30LtEarCol.Index));
                bcViewModel.NysEndSec30LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndSec30LtEarCol.Index));
                bcViewModel.NysStartMin44RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartMin44RtEarCol.Index));
                bcViewModel.NysStartSec44RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartSec44RtEarCol.Index));
                bcViewModel.NysEndMin44RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndMin44RtEarCol.Index));
                bcViewModel.NysEndSec44RtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndSec44RtEarCol.Index));
                bcViewModel.NysStartMin44LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartMin44LtEarCol.Index));
                bcViewModel.NysStartSec44LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysStartSec44LtEarCol.Index));
                bcViewModel.NysEndMin44LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndMin44LtEarCol.Index));
                bcViewModel.NysEndSec44LtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(nysEndSec44LtEarCol.Index));
                bcViewModel.CanalParesis = NullDoubleHelper.ToNullableDouble(reader.GetString(canalParesisCol.Index));
                bcViewModel.DirPrepond = NullDoubleHelper.ToNullableDouble(reader.GetString(dirPrepondCol.Index));
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
