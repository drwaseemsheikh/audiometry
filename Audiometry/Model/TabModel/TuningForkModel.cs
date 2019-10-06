using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PureToneVM.TuningForkVM;

namespace Audiometry.Model.TabModel
{
    public class TuningForkModel : TabModel
    {
        #region Database
        private const string dbTable = "TuningFork";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn wbr512RtEarCol;
        private readonly DbColumn wbr512LtEarCol;
        private readonly DbColumn rn256RtEarCol;
        private readonly DbColumn rn256LtEarCol;
        private readonly DbColumn rn512RtEarCol;
        private readonly DbColumn rn512LtEarCol;
        private readonly DbColumn rn1024RtEarCol;
        private readonly DbColumn rn1024LtEarCol;
        private readonly DbColumn swbRtEarCol;
        private readonly DbColumn swbLtEarCol;
        private readonly DbColumn abcRtEarCol;
        private readonly DbColumn abcLtEarCol;
        private readonly DbColumn stgRtEarCol;
        private readonly DbColumn stgLtEarCol;
        private readonly DbColumn tlRtEarCol;
        private readonly DbColumn tlLtEarCol;
        private readonly DbColumn glRtEarCol;
        private readonly DbColumn glLtEarCol;
        #endregion

        #region Methods
        public TuningForkModel(TabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            wbr512RtEarCol = new DbColumn(3, "Wbr512RtEar", string.Empty);
            wbr512LtEarCol = new DbColumn(4, "Wbr512LtEar", string.Empty);
            rn256RtEarCol = new DbColumn(5, "Rn256RtEar", string.Empty);
            rn256LtEarCol = new DbColumn(6, "Rn256LtEar", string.Empty);
            rn512RtEarCol = new DbColumn(7, "Rn512RtEar", string.Empty);
            rn512LtEarCol = new DbColumn(8, "Rn512LtEar", string.Empty);
            rn1024RtEarCol = new DbColumn(9, "Rn1024RtEar", string.Empty);
            rn1024LtEarCol = new DbColumn(10, "Rn1024LtEar", string.Empty);
            swbRtEarCol = new DbColumn(11, "SwbRtEar", string.Empty);
            swbLtEarCol = new DbColumn(12, "SwbLtEar", string.Empty);
            abcRtEarCol = new DbColumn(13, "AbcRtEar", string.Empty);
            abcLtEarCol = new DbColumn(14, "AbcLtEar", string.Empty);
            stgRtEarCol = new DbColumn(15, "StgRtEar", string.Empty);
            stgLtEarCol = new DbColumn(16, "StgLtEar", string.Empty);
            tlRtEarCol = new DbColumn(17, "TlRtEar", string.Empty);
            tlLtEarCol = new DbColumn(18, "TlLtEar", string.Empty);
            glRtEarCol = new DbColumn(19, "GlRtEar", string.Empty);
            glLtEarCol = new DbColumn(20, "GlLtEar", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate)
        {
            TuningForkTestsVM tfViewModel = (TuningForkTestsVM)viewmodel;            

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = tfViewModel.IsTestConducted.ToString(CultureInfo.InvariantCulture);
            wbr512RtEarCol.Value = tfViewModel.Wbr512RtEar.ToString();
            wbr512LtEarCol.Value = tfViewModel.Wbr512LtEar.ToString();
            rn256RtEarCol.Value = tfViewModel.Rn256RtEar.ToString();
            rn256LtEarCol.Value = tfViewModel.Rn256LtEar.ToString();
            rn512RtEarCol.Value = tfViewModel.Rn512RtEar.ToString();
            rn512LtEarCol.Value = tfViewModel.Rn512LtEar.ToString();
            rn1024RtEarCol.Value = tfViewModel.Rn1024RtEar.ToString();
            rn1024LtEarCol.Value = tfViewModel.Rn1024LtEar.ToString();
            swbRtEarCol.Value = tfViewModel.SwbRtEar.ToString();
            swbLtEarCol.Value = tfViewModel.SwbLtEar.ToString();
            abcRtEarCol.Value = tfViewModel.AbcRtEar.ToString();
            abcLtEarCol.Value = tfViewModel.AbcLtEar.ToString();
            stgRtEarCol.Value = tfViewModel.StgRtEar.ToString();
            stgLtEarCol.Value = tfViewModel.StgLtEar.ToString();
            tlRtEarCol.Value = tfViewModel.TlRtEar.ToString();
            tlLtEarCol.Value = tfViewModel.TlLtEar.ToString();
            glRtEarCol.Value = tfViewModel.GlRtEar.ToString();
            glLtEarCol.Value = tfViewModel.GlLtEar.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + wbr512RtEarCol.Name + "," + wbr512LtEarCol.Name + "," +
                           rn256RtEarCol.Name + "," + rn256LtEarCol.Name + "," + rn512RtEarCol.Name + "," +
                           rn512LtEarCol.Name + "," + rn1024RtEarCol.Name + "," + rn1024LtEarCol.Name + "," +
                           swbRtEarCol.Name + "," + swbLtEarCol.Name + "," + abcRtEarCol.Name + "," +
                           abcLtEarCol.Name + "," + stgRtEarCol.Name + "," + stgLtEarCol.Name + "," +
                           tlRtEarCol.Name + "," + tlLtEarCol.Name + "," + glRtEarCol.Name + "," + glLtEarCol.Name + ")" +
                           " values ('" +
                           accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value + "', '" +
                           wbr512RtEarCol.Value + "', '" + wbr512LtEarCol.Value + "', '" + rn256RtEarCol.Value + "', '" +
                           rn256LtEarCol.Value + "', '" + rn512RtEarCol.Value + "', '" + rn512LtEarCol.Value + "', '" +
                           rn1024RtEarCol.Value + "', '" + rn1024LtEarCol.Value + "', '" + swbRtEarCol.Value + "', '" +
                           swbLtEarCol.Value + "', '" + abcRtEarCol.Value + "', '" + abcLtEarCol.Value + "', '" +
                           stgRtEarCol.Value + "', '" + stgLtEarCol.Value + "', '" + tlRtEarCol.Value + "', '" +
                           tlLtEarCol.Value + "', '" + glRtEarCol.Value + "', '" + glLtEarCol.Value + "')";
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
                msg = "Failed to write Tuning Fork Tests data to database table " + dbTable + ".";
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
                           wbr512RtEarCol.Name + " = '" + wbr512RtEarCol.Value + "', " +
                           wbr512LtEarCol.Name + " = '" + wbr512LtEarCol.Value + "', " +
                           rn256RtEarCol.Name + " = '" + rn256RtEarCol.Value + "', " +
                           rn256LtEarCol.Name + " = '" + rn256LtEarCol.Value + "', " +
                           rn512RtEarCol.Name + " = '" + rn512RtEarCol.Value + "', " +
                           rn512LtEarCol.Name + " = '" + rn512LtEarCol.Value + "', " +
                           rn1024RtEarCol.Name + " = '" + rn1024RtEarCol.Value + "', " +
                           rn1024LtEarCol.Name + " = '" + rn1024LtEarCol.Value + "', " +
                           swbRtEarCol.Name + " = '" + swbRtEarCol.Value + "', " +
                           swbLtEarCol.Name + " = '" + swbLtEarCol.Value + "', " +
                           abcRtEarCol.Name + " = '" + abcRtEarCol.Value + "', " +
                           abcLtEarCol.Name + " = '" + abcLtEarCol.Value + "', " +
                           stgRtEarCol.Name + " = '" + stgRtEarCol.Value + "', " +
                           stgLtEarCol.Name + " = '" + stgLtEarCol.Value + "', " +
                           tlRtEarCol.Name + " = '" + tlRtEarCol.Value + "', " +
                           tlLtEarCol.Name + " = '" + tlLtEarCol.Value + "', " +
                           glRtEarCol.Name + " = '" + glRtEarCol.Value + "', " +
                           glLtEarCol.Name + " = '" + glLtEarCol.Value + "'" +
                           " WHERE " +
                           accNumberCol.Name + " = '" + accNumberCol.Value + "' AND " +
                           dateOfExamCol.Name + " = '" + dateOfExamCol.Value + "'";
            return query;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            TuningForkTestsVM tfViewModel = (TuningForkTestsVM)viewmodel;           

            string query = "SELECT * FROM " + dbTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand readCmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            SQLiteDataReader reader = readCmd.ExecuteReader();

            if (reader.Read())
            {
                tfViewModel.IsTestConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                tfViewModel.Wbr512RtEar = (TuningForkTypes.Weber)Enum.Parse(typeof(TuningForkTypes.Weber), reader.GetString(wbr512RtEarCol.Index));
                tfViewModel.Wbr512LtEar = (TuningForkTypes.Weber)Enum.Parse(typeof(TuningForkTypes.Weber), reader.GetString(wbr512LtEarCol.Index));
                tfViewModel.Rn256RtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn256RtEarCol.Index));
                tfViewModel.Rn256LtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn256LtEarCol.Index));
                tfViewModel.Rn512RtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn512RtEarCol.Index));
                tfViewModel.Rn512LtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn512LtEarCol.Index));
                tfViewModel.Rn1024RtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn1024RtEarCol.Index));
                tfViewModel.Rn1024LtEar = (TuningForkTypes.Rinne)Enum.Parse(typeof(TuningForkTypes.Rinne), reader.GetString(rn1024LtEarCol.Index));
                tfViewModel.SwbRtEar = (TuningForkTypes.Schwabach)Enum.Parse(typeof(TuningForkTypes.Schwabach), reader.GetString(swbRtEarCol.Index));
                tfViewModel.SwbLtEar = (TuningForkTypes.Schwabach)Enum.Parse(typeof(TuningForkTypes.Schwabach), reader.GetString(swbLtEarCol.Index));
                tfViewModel.AbcRtEar = (TuningForkTypes.AbsBoneCond)Enum.Parse(typeof(TuningForkTypes.AbsBoneCond), reader.GetString(abcRtEarCol.Index));
                tfViewModel.AbcLtEar = (TuningForkTypes.AbsBoneCond)Enum.Parse(typeof(TuningForkTypes.AbsBoneCond), reader.GetString(abcLtEarCol.Index));
                tfViewModel.StgRtEar = (TuningForkTypes.Stenger)Enum.Parse(typeof(TuningForkTypes.Stenger), reader.GetString(stgRtEarCol.Index));
                tfViewModel.StgLtEar = (TuningForkTypes.Stenger)Enum.Parse(typeof(TuningForkTypes.Stenger), reader.GetString(stgLtEarCol.Index));
                tfViewModel.TlRtEar = (TuningForkTypes.Teal)Enum.Parse(typeof(TuningForkTypes.Teal), reader.GetString(tlRtEarCol.Index));
                tfViewModel.TlLtEar = (TuningForkTypes.Teal)Enum.Parse(typeof(TuningForkTypes.Teal), reader.GetString(tlLtEarCol.Index));
                tfViewModel.GlRtEar = (TuningForkTypes.Gelle)Enum.Parse(typeof(TuningForkTypes.Gelle), reader.GetString(glRtEarCol.Index));
                tfViewModel.GlLtEar = (TuningForkTypes.Gelle)Enum.Parse(typeof(TuningForkTypes.Gelle), reader.GetString(glLtEarCol.Index));
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
