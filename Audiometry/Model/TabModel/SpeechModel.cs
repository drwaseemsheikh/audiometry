using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.SpeechVM;

namespace Audiometry.Model.TabModel
{
    public class SpeechModel : TabModel
    {
        #region Database
        private const string dbTable = "SpeechAudiometry";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn isRtEarTestCol;
        private readonly DbColumn isLtEarTestCol;
        private readonly DbColumn isBltTestCol;
        private readonly DbColumn int0dBCol;
        private readonly DbColumn int1dBCol;
        private readonly DbColumn int2dBCol;
        private readonly DbColumn int3dBCol;
        private readonly DbColumn int4dBCol;
        private readonly DbColumn int5dBCol;
        private readonly DbColumn int6dBCol;
        private readonly DbColumn int7dBCol;
        private readonly DbColumn int8dBCol;
        private readonly DbColumn int9dBCol;
        private readonly DbColumn score0Col;
        private readonly DbColumn score1Col;
        private readonly DbColumn score2Col;
        private readonly DbColumn score3Col;
        private readonly DbColumn score4Col;
        private readonly DbColumn score5Col;
        private readonly DbColumn score6Col;
        private readonly DbColumn score7Col;
        private readonly DbColumn score8Col;
        private readonly DbColumn score9Col;
        private readonly DbColumn srtdBCol;
        private readonly DbColumn sdScoreCol;
        private readonly DbColumn sdIntdBCol;
        #endregion

        #region Methods
        public SpeechModel(TabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            isRtEarTestCol = new DbColumn(3, "IsRtEarTest", string.Empty);
            isLtEarTestCol = new DbColumn(4, "IsLtEarTest", string.Empty);
            isBltTestCol = new DbColumn(5, "IsBltTest", string.Empty);
            int0dBCol = new DbColumn(6, "Int0dB", string.Empty);
            int1dBCol = new DbColumn(7, "Int1dB", string.Empty);
            int2dBCol = new DbColumn(8, "Int2dB", string.Empty);
            int3dBCol = new DbColumn(9, "Int3dB", string.Empty);
            int4dBCol = new DbColumn(10, "Int4dB", string.Empty);
            int5dBCol = new DbColumn(11, "Int5dB", string.Empty);
            int6dBCol = new DbColumn(12, "Int6dB", string.Empty);
            int7dBCol = new DbColumn(13, "Int7dB", string.Empty);
            int8dBCol = new DbColumn(14, "Int8dB", string.Empty);
            int9dBCol = new DbColumn(15, "Int9dB", string.Empty);
            score0Col = new DbColumn(16, "Score0", string.Empty);
            score1Col = new DbColumn(17, "Score1", string.Empty);
            score2Col = new DbColumn(18, "Score2", string.Empty);
            score3Col = new DbColumn(19, "Score3", string.Empty);
            score4Col = new DbColumn(20, "Score4", string.Empty);
            score5Col = new DbColumn(21, "Score5", string.Empty);
            score6Col = new DbColumn(22, "Score6", string.Empty);
            score7Col = new DbColumn(23, "Score7", string.Empty);
            score8Col = new DbColumn(24, "Score8", string.Empty);
            score9Col = new DbColumn(25, "Score9", string.Empty);
            srtdBCol = new DbColumn(26, "SrtdB", string.Empty);
            sdScoreCol = new DbColumn(27, "SdScore", string.Empty);
            sdIntdBCol = new DbColumn(28, "SdIntdB", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate)
        {
            SpeechTabVM spViewModel = (SpeechTabVM)viewmodel;

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = spViewModel.IsSpeechTestConducted.ToString(CultureInfo.InvariantCulture);
            isRtEarTestCol.Value = spViewModel.IsRtEarTest.ToString();
            isLtEarTestCol.Value = spViewModel.IsLtEarTest.ToString();
            isBltTestCol.Value = spViewModel.IsBilateralTest.ToString();
            int0dBCol.Value = spViewModel.Intensity0dB.ToString();
            int1dBCol.Value = spViewModel.Intensity1dB.ToString();
            int2dBCol.Value = spViewModel.Intensity2dB.ToString();
            int3dBCol.Value = spViewModel.Intensity3dB.ToString();
            int4dBCol.Value = spViewModel.Intensity4dB.ToString();
            int5dBCol.Value = spViewModel.Intensity5dB.ToString();
            int6dBCol.Value = spViewModel.Intensity6dB.ToString();
            int7dBCol.Value = spViewModel.Intensity7dB.ToString();
            int8dBCol.Value = spViewModel.Intensity8dB.ToString();
            int9dBCol.Value = spViewModel.Intensity9dB.ToString();
            score0Col.Value = spViewModel.Score0.ToString();
            score1Col.Value = spViewModel.Score1.ToString();
            score2Col.Value = spViewModel.Score2.ToString();
            score3Col.Value = spViewModel.Score3.ToString();
            score4Col.Value = spViewModel.Score4.ToString();
            score5Col.Value = spViewModel.Score5.ToString();
            score6Col.Value = spViewModel.Score6.ToString();
            score7Col.Value = spViewModel.Score7.ToString();
            score8Col.Value = spViewModel.Score8.ToString();
            score9Col.Value = spViewModel.Score9.ToString();
            srtdBCol.Value = spViewModel.SRTdB.ToString();
            sdScoreCol.Value = spViewModel.SDScore.ToString();
            sdIntdBCol.Value = spViewModel.SDIntensitydB.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + isRtEarTestCol.Name + "," + isLtEarTestCol.Name + "," +
                           isBltTestCol.Name + "," + int0dBCol.Name + "," + int1dBCol.Name + "," + int2dBCol.Name + "," +
                           int3dBCol.Name + "," + int4dBCol.Name + "," + int5dBCol.Name + "," + int6dBCol.Name + "," +
                           int7dBCol.Name + "," + int8dBCol.Name + "," + int9dBCol.Name + "," + score0Col.Name + "," +
                           score1Col.Name + "," + score2Col.Name + "," + score3Col.Name + "," + score4Col.Name + "," +
                           score5Col.Name + "," + score6Col.Name + "," + score7Col.Name + "," + score8Col.Name + "," +
                           score9Col.Name + "," + srtdBCol.Name + "," + sdScoreCol.Name + "," + sdIntdBCol.Name + ")" +
                           " values ('" +
                           accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value + "', '" +
                           isRtEarTestCol.Value + "', '" + isLtEarTestCol.Value + "', '" + isBltTestCol.Value + "', '" +
                           int0dBCol.Value + "', '" + int1dBCol.Value + "', '" + int2dBCol.Value + "', '" +
                           int3dBCol.Value + "', '" + int4dBCol.Value + "', '" + int5dBCol.Value + "', '" +
                           int6dBCol.Value + "', '" + int7dBCol.Value + "', '" + int8dBCol.Value + "', '" +
                           int9dBCol.Value + "', '" + score0Col.Value + "', '" + score1Col.Value + "', '" +
                           score2Col.Value + "', '" + score3Col.Value + "', '" + score4Col.Value + "', '" +
                           score5Col.Value + "', '" + score6Col.Value + "', '" + score7Col.Value + "', '" +
                           score8Col.Value + "', '" + score9Col.Value + "', '" + srtdBCol.Value + "', '" +
                           sdScoreCol.Value + "', '" + sdIntdBCol.Value + "')";
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
                msg = "Failed to write Speech Audiometry Tests data to database table " + dbTable + ".";
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
                           isRtEarTestCol.Name + " = '" + isRtEarTestCol.Value + "', " +
                           isLtEarTestCol.Name + " = '" + isLtEarTestCol.Value + "', " +
                           isBltTestCol.Name + " = '" + isBltTestCol.Value + "', " +
                           int0dBCol.Name + " = '" + int0dBCol.Value + "', " +
                           int1dBCol.Name + " = '" + int1dBCol.Value + "', " +
                           int2dBCol.Name + " = '" + int2dBCol.Value + "', " +
                           int3dBCol.Name + " = '" + int3dBCol.Value + "', " +
                           int4dBCol.Name + " = '" + int4dBCol.Value + "', " +
                           int5dBCol.Name + " = '" + int5dBCol.Value + "', " +
                           int6dBCol.Name + " = '" + int6dBCol.Value + "', " +
                           int7dBCol.Name + " = '" + int7dBCol.Value + "', " +
                           int8dBCol.Name + " = '" + int8dBCol.Value + "', " +
                           int9dBCol.Name + " = '" + int9dBCol.Value + "', " +
                           score0Col.Name + " = '" + score0Col.Value + "', " +
                           score1Col.Name + " = '" + score1Col.Value + "', " +
                           score2Col.Name + " = '" + score2Col.Value + "', " +
                           score3Col.Name + " = '" + score3Col.Value + "', " +
                           score4Col.Name + " = '" + score4Col.Value + "', " +
                           score5Col.Name + " = '" + score5Col.Value + "', " +
                           score6Col.Name + " = '" + score6Col.Value + "', " +
                           score7Col.Name + " = '" + score7Col.Value + "', " +
                           score8Col.Name + " = '" + score8Col.Value + "', " +
                           score9Col.Name + " = '" + score9Col.Value + "', " +
                           srtdBCol.Name + " = '" + srtdBCol.Value + "', " +
                           sdScoreCol.Name + " = '" + sdScoreCol.Value + "', " +
                           sdIntdBCol.Name + " = '" + sdIntdBCol.Value + "'" +
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
                SpeechTabVM spViewModel = (SpeechTabVM)viewmodel;

                spViewModel.IsSpeechTestConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                spViewModel.IsRtEarTest = Convert.ToBoolean(reader.GetString(isRtEarTestCol.Index));
                spViewModel.IsLtEarTest = Convert.ToBoolean(reader.GetString(isLtEarTestCol.Index));
                spViewModel.IsBilateralTest = Convert.ToBoolean(reader.GetString(isBltTestCol.Index));
                spViewModel.Intensity0dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int0dBCol.Index));
                spViewModel.Intensity1dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int1dBCol.Index));
                spViewModel.Intensity2dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int2dBCol.Index));
                spViewModel.Intensity3dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int3dBCol.Index));
                spViewModel.Intensity4dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int4dBCol.Index));
                spViewModel.Intensity5dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int5dBCol.Index));
                spViewModel.Intensity6dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int6dBCol.Index));
                spViewModel.Intensity7dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int7dBCol.Index));
                spViewModel.Intensity8dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int8dBCol.Index));
                spViewModel.Intensity9dB = NullDoubleHelper.ToNullableDouble(reader.GetString(int9dBCol.Index));
                spViewModel.Score0 = NullDoubleHelper.ToNullableDouble(reader.GetString(score0Col.Index));
                spViewModel.Score1 = NullDoubleHelper.ToNullableDouble(reader.GetString(score1Col.Index));
                spViewModel.Score2 = NullDoubleHelper.ToNullableDouble(reader.GetString(score2Col.Index));
                spViewModel.Score3 = NullDoubleHelper.ToNullableDouble(reader.GetString(score3Col.Index));
                spViewModel.Score4 = NullDoubleHelper.ToNullableDouble(reader.GetString(score4Col.Index));
                spViewModel.Score5 = NullDoubleHelper.ToNullableDouble(reader.GetString(score5Col.Index));
                spViewModel.Score6 = NullDoubleHelper.ToNullableDouble(reader.GetString(score6Col.Index));
                spViewModel.Score7 = NullDoubleHelper.ToNullableDouble(reader.GetString(score7Col.Index));
                spViewModel.Score8 = NullDoubleHelper.ToNullableDouble(reader.GetString(score8Col.Index));
                spViewModel.Score9 = NullDoubleHelper.ToNullableDouble(reader.GetString(score9Col.Index));
                spViewModel.SRTdB = NullDoubleHelper.ToNullableDouble(reader.GetString(srtdBCol.Index));
                spViewModel.SDScore = NullDoubleHelper.ToNullableDouble(reader.GetString(sdScoreCol.Index));
                spViewModel.SDIntensitydB = NullDoubleHelper.ToNullableDouble(reader.GetString(sdIntdBCol.Index));
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
