using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;

namespace Audiometry.Model.SubTabModel
{
    public class AirCondUmskDataModel : PureToneDataModel
    {
        #region Database
        private const string disabilityTable = "HearingDisability";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn avgSpPerRtEarCol;
        private readonly DbColumn impairRtEarCol;
        private readonly DbColumn avgSpPerLtEarCol;
        private readonly DbColumn impairLtEarCol;
        private readonly DbColumn disabilityCol;
        #endregion

        #region Methods
        public AirCondUmskDataModel(SubTabVM vm) : base(vm)
        {
            dbTable = "PureToneACUMsk";

            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            avgSpPerRtEarCol = new DbColumn(3, "AvgSpPerRtEar", string.Empty);
            impairRtEarCol = new DbColumn(4, "ImpairRtEar", string.Empty);
            avgSpPerLtEarCol = new DbColumn(5, "AvgSpPerLtEar", string.Empty);
            impairLtEarCol = new DbColumn(6, "ImpairLtEar", string.Empty);
            disabilityCol = new DbColumn(7, "Disability", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            if (!base.AddRecordToDatabase(accNumber, examDate, testConducted, out msg))
            {
                return false;
            }

            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate, bool testConducted)
        {
            AirCondUmskData acUmskDataVM = (AirCondUmskData)viewmodel;

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = testConducted.ToString(CultureInfo.InvariantCulture);
            avgSpPerRtEarCol.Value = acUmskDataVM.AvgSpPerRtEar.ToString();
            impairRtEarCol.Value = acUmskDataVM.ImpairRtEar.ToString();
            avgSpPerLtEarCol.Value = acUmskDataVM.AvgSpPerLtEar.ToString();
            impairLtEarCol.Value = acUmskDataVM.ImpairLtEar.ToString();
            disabilityCol.Value = acUmskDataVM.Disability.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + disabilityTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + avgSpPerRtEarCol.Name + "," + impairRtEarCol.Name + "," +
                           avgSpPerLtEarCol.Name + "," + impairLtEarCol.Name + "," + disabilityCol.Name + ")" +
                           " values ('" + accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value +
                           "', '" +
                           avgSpPerRtEarCol.Value + "', '" + impairRtEarCol.Value + "', '" + avgSpPerLtEarCol.Value + "', '" +
                           impairLtEarCol.Value + "', '" + disabilityCol.Value + "')";
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
                msg = "Failed to write hearing disability data to database table " + disabilityTable + ".";
                return false;
            }
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, bool testConducted, out string msg)
        {
            if (!base.UpdateRecordInDatabase(accNumber, examDate, testConducted, out msg))
            {
                return false;
            }

            GetViewModelPropertyValues(accNumber, examDate, testConducted);
            string query = ConstructUpdateQuery();
            return ExecuteQuery(query, out msg);
        }

        private string ConstructUpdateQuery()
        {
            string query = "UPDATE " + disabilityTable +
                           " SET " +
                           isTestConductedCol.Name + " = '" + isTestConductedCol.Value + "', " +
                           avgSpPerRtEarCol.Name + " = '" + avgSpPerRtEarCol.Value + "', " +
                           impairRtEarCol.Name + " = '" + impairRtEarCol.Value + "', " +
                           avgSpPerLtEarCol.Name + " = '" + avgSpPerLtEarCol.Value + "', " +
                           impairLtEarCol.Name + " = '" + impairLtEarCol.Value + "', " +
                           disabilityCol.Name + " = '" + disabilityCol.Value + "'" +
                           " WHERE " +
                           accNumberCol.Name + " = '" + accNumberCol.Value + "' AND " +
                           dateOfExamCol.Name + " = '" + dateOfExamCol.Value + "'";
            return query;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate, out bool testConducted)
        {
            base.OpenRecordFromDatabase(accNumber, examDate, out testConducted);

            string query = "SELECT * FROM " + disabilityTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand readCmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            SQLiteDataReader reader = readCmd.ExecuteReader();
            testConducted = false;

            if (reader.Read())
            {
                AirCondUmskData acUmskDataVM = (AirCondUmskData)viewmodel;                

                testConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                acUmskDataVM.AvgSpPerRtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(avgSpPerRtEarCol.Index));
                acUmskDataVM.ImpairRtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(impairRtEarCol.Index));
                acUmskDataVM.AvgSpPerLtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(avgSpPerLtEarCol.Index));
                acUmskDataVM.ImpairLtEar = NullDoubleHelper.ToNullableDouble(reader.GetString(impairLtEarCol.Index));
                acUmskDataVM.Disability = NullDoubleHelper.ToNullableDouble(reader.GetString(disabilityCol.Index));
            }
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            bool acumskDel = base.DeleteRecordFromDatabase(accNumber, examDate);

            string query = "DELETE FROM " + disabilityTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            int rows = cmd.ExecuteNonQuery();

            return (acumskDel || rows == 1);
        }
        #endregion
    }
}
