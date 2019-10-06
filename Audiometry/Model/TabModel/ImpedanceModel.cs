using System;
using System.Data.SQLite;
using System.Globalization;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.ImpedanceVM;

namespace Audiometry.Model.TabModel
{
    public class ImpedanceModel : TabModel
    {
        #region Database
        private const string dbTable = "ImpedanceAudiometry";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn isTestConductedCol;
        private readonly DbColumn compNeg400RtEarCol;
        private readonly DbColumn compNeg400LtEarCol;
        private readonly DbColumn compNeg300RtEarCol;
        private readonly DbColumn compNeg300LtEarCol;
        private readonly DbColumn compNeg200RtEarCol;
        private readonly DbColumn compNeg200LtEarCol;
        private readonly DbColumn compNeg100RtEarCol;
        private readonly DbColumn compNeg100LtEarCol;
        private readonly DbColumn comp0RtEarCol;
        private readonly DbColumn comp0LtEarCol;
        private readonly DbColumn comp100RtEarCol;
        private readonly DbColumn comp100LtEarCol;
        private readonly DbColumn comp200RtEarCol;
        private readonly DbColumn comp200LtEarCol;
        private readonly DbColumn comp300RtEarCol;
        private readonly DbColumn comp300LtEarCol;
        private readonly DbColumn comp400RtEarCol;
        private readonly DbColumn comp400LtEarCol;
        private readonly DbColumn peakPresRtEarCol;
        private readonly DbColumn peakPresLtEarCol;
        private readonly DbColumn earCnlVolRtEarCol;
        private readonly DbColumn earCnlVolLtEarCol;
        private readonly DbColumn curveRtEarCol;
        private readonly DbColumn curveLtEarCol;
        private readonly DbColumn acRf500RtEarCol;
        private readonly DbColumn acRf500LtEarCol;
        private readonly DbColumn acRf1000RtEarCol;
        private readonly DbColumn acRf1000LtEarCol;
        private readonly DbColumn acRf2000RtEarCol;
        private readonly DbColumn acRf2000LtEarCol;
        private readonly DbColumn acRf4000RtEarCol;
        private readonly DbColumn acRf4000LtEarCol;
        #endregion

        #region Methods
        public ImpedanceModel(TabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            isTestConductedCol = new DbColumn(2, "TestConducted", string.Empty);
            compNeg400RtEarCol = new DbColumn(3, "CompNeg400RtEar", string.Empty);
            compNeg400LtEarCol = new DbColumn(4, "CompNeg400LtEar", string.Empty);
            compNeg300RtEarCol = new DbColumn(5, "CompNeg300RtEar", string.Empty);
            compNeg300LtEarCol = new DbColumn(6, "CompNeg300LtEar", string.Empty);
            compNeg200RtEarCol = new DbColumn(7, "CompNeg200RtEar", string.Empty);
            compNeg200LtEarCol = new DbColumn(8, "CompNeg200LtEar", string.Empty);
            compNeg100RtEarCol = new DbColumn(9, "CompNeg100RtEar", string.Empty);
            compNeg100LtEarCol = new DbColumn(10, "CompNeg100LtEar", string.Empty);
            comp0RtEarCol = new DbColumn(11, "Comp0RtEar", string.Empty);
            comp0LtEarCol = new DbColumn(12, "Comp0LtEar", string.Empty);
            comp100RtEarCol = new DbColumn(13, "Comp100RtEar", string.Empty);
            comp100LtEarCol = new DbColumn(14, "Comp100LtEar", string.Empty);
            comp200RtEarCol = new DbColumn(15, "Comp200RtEar", string.Empty);
            comp200LtEarCol = new DbColumn(16, "Comp200LtEar", string.Empty);
            comp300RtEarCol = new DbColumn(17, "Comp300RtEar", string.Empty);
            comp300LtEarCol = new DbColumn(18, "Comp300LtEar", string.Empty);
            comp400RtEarCol = new DbColumn(19, "Comp400RtEar", string.Empty);
            comp400LtEarCol = new DbColumn(20, "Comp400LtEar", string.Empty);
            peakPresRtEarCol = new DbColumn(21, "PeakPresRtEar", string.Empty);
            peakPresLtEarCol = new DbColumn(22, "PeakPresLtEar", string.Empty);
            earCnlVolRtEarCol = new DbColumn(23, "EarCnlVolRtEar", string.Empty);
            earCnlVolLtEarCol = new DbColumn(24, "EarCnlVolLtEar", string.Empty);
            curveRtEarCol = new DbColumn(25, "CurveRtEar", string.Empty);
            curveLtEarCol = new DbColumn(26, "CurveLtEar", string.Empty);
            acRf500RtEarCol = new DbColumn(27, "AcRf500RtEar", string.Empty);
            acRf500LtEarCol = new DbColumn(28, "AcRf500LtEar", string.Empty);
            acRf1000RtEarCol = new DbColumn(29, "AcRf1000RtEar", string.Empty);
            acRf1000LtEarCol = new DbColumn(30, "AcRf1000LtEar", string.Empty);
            acRf2000RtEarCol = new DbColumn(31, "AcRf2000RtEar", string.Empty);
            acRf2000LtEarCol = new DbColumn(32, "AcRf2000LtEar", string.Empty);
            acRf4000RtEarCol = new DbColumn(33, "AcRf4000RtEar", string.Empty);
            acRf4000LtEarCol = new DbColumn(34, "AcRf4000LtEar", string.Empty);
        }
        #endregion

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues(accNumber, examDate);
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues(string accNumber, string examDate)
        {
            ImpedanceTabVM impViewModel = (ImpedanceTabVM)viewmodel; 

            accNumberCol.Value = accNumber;
            dateOfExamCol.Value = examDate;
            isTestConductedCol.Value = impViewModel.IsImpedanceTestConducted.ToString(CultureInfo.InvariantCulture);
            compNeg400RtEarCol.Value = impViewModel.RtEarComplianceNeg400daPa.ToString();
            compNeg400LtEarCol.Value = impViewModel.LtEarComplianceNeg400daPa.ToString();
            compNeg300RtEarCol.Value = impViewModel.RtEarComplianceNeg300daPa.ToString();
            compNeg300LtEarCol.Value = impViewModel.LtEarComplianceNeg300daPa.ToString();
            compNeg200RtEarCol.Value = impViewModel.RtEarComplianceNeg200daPa.ToString();
            compNeg200LtEarCol.Value = impViewModel.LtEarComplianceNeg200daPa.ToString();
            compNeg100RtEarCol.Value = impViewModel.RtEarComplianceNeg100daPa.ToString();
            compNeg100LtEarCol.Value = impViewModel.LtEarComplianceNeg100daPa.ToString();
            comp0RtEarCol.Value = impViewModel.RtEarCompliance0daPa.ToString();
            comp0LtEarCol.Value = impViewModel.LtEarCompliance0daPa.ToString();
            comp100RtEarCol.Value = impViewModel.RtEarCompliance100daPa.ToString();
            comp100LtEarCol.Value = impViewModel.LtEarCompliance100daPa.ToString();
            comp200RtEarCol.Value = impViewModel.RtEarCompliance200daPa.ToString();
            comp200LtEarCol.Value = impViewModel.LtEarCompliance200daPa.ToString();
            comp300RtEarCol.Value = impViewModel.RtEarCompliance300daPa.ToString();
            comp300LtEarCol.Value = impViewModel.LtEarCompliance300daPa.ToString();
            comp400RtEarCol.Value = impViewModel.RtEarCompliance400daPa.ToString();
            comp400LtEarCol.Value = impViewModel.LtEarCompliance400daPa.ToString();
            peakPresRtEarCol.Value = impViewModel.RtEarPeakPressure.ToString();
            peakPresLtEarCol.Value = impViewModel.LtEarPeakPressure.ToString();
            earCnlVolRtEarCol.Value = impViewModel.RtEarCanalVolume.ToString();
            earCnlVolLtEarCol.Value = impViewModel.LtEarCanalVolume.ToString();
            curveRtEarCol.Value = impViewModel.RtEarCurveType.ToString();
            curveLtEarCol.Value = impViewModel.LtEarCurveType.ToString();
            acRf500RtEarCol.Value = impViewModel.RtEarAcousticReflex500Hz.ToString();
            acRf500LtEarCol.Value = impViewModel.LtEarAcousticReflex500Hz.ToString();
            acRf1000RtEarCol.Value = impViewModel.RtEarAcousticReflex1000Hz.ToString();
            acRf1000LtEarCol.Value = impViewModel.LtEarAcousticReflex1000Hz.ToString();
            acRf2000RtEarCol.Value = impViewModel.RtEarAcousticReflex2000Hz.ToString();
            acRf2000LtEarCol.Value = impViewModel.LtEarAcousticReflex2000Hz.ToString();
            acRf4000RtEarCol.Value = impViewModel.RtEarAcousticReflex4000Hz.ToString();
            acRf4000LtEarCol.Value = impViewModel.LtEarAcousticReflex4000Hz.ToString();
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + dbTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           isTestConductedCol.Name + "," + compNeg400RtEarCol.Name + "," + compNeg400LtEarCol.Name + "," +
                           compNeg300RtEarCol.Name + "," + compNeg300LtEarCol.Name + "," + compNeg200RtEarCol.Name + "," +
                           compNeg200LtEarCol.Name + "," + compNeg100RtEarCol.Name + "," + compNeg100LtEarCol.Name + "," +
                           comp0RtEarCol.Name + "," + comp0LtEarCol.Name + "," + comp100RtEarCol.Name + "," +
                           comp100LtEarCol.Name + "," + comp200RtEarCol.Name + "," + comp200LtEarCol.Name + "," +
                           comp300RtEarCol.Name + "," + comp300LtEarCol.Name + "," + comp400RtEarCol.Name + "," +
                           comp400LtEarCol.Name + "," + peakPresRtEarCol.Name + "," + peakPresLtEarCol.Name + "," +
                           earCnlVolRtEarCol.Name + "," + earCnlVolLtEarCol.Name + "," + curveRtEarCol.Name + "," +
                           curveLtEarCol.Name + "," + acRf500RtEarCol.Name + "," + acRf500LtEarCol.Name + "," +
                           acRf1000RtEarCol.Name + "," + acRf1000LtEarCol.Name + "," + acRf2000RtEarCol.Name + "," +
                           acRf2000LtEarCol.Name + "," + acRf4000RtEarCol.Name + "," + acRf4000LtEarCol.Name + ")" +
                           " values ('" +
                           accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" + isTestConductedCol.Value + "', '" +
                           compNeg400RtEarCol.Value + "', '" + compNeg400LtEarCol.Value + "', '" +
                           compNeg300RtEarCol.Value + "', '" + compNeg300LtEarCol.Value + "', '" +
                           compNeg200RtEarCol.Value + "', '" + compNeg200LtEarCol.Value + "', '" +
                           compNeg100RtEarCol.Value + "', '" + compNeg100LtEarCol.Value + "', '" +
                           comp0RtEarCol.Value + "', '" + comp0LtEarCol.Value + "', '" +
                           comp100RtEarCol.Value + "', '" + comp100LtEarCol.Value + "', '" +
                           comp200RtEarCol.Value + "', '" + comp200LtEarCol.Value + "', '" +
                           comp300RtEarCol.Value + "', '" + comp300LtEarCol.Value + "', '" +
                           comp400RtEarCol.Value + "', '" + comp400LtEarCol.Value + "', '" +
                           peakPresRtEarCol.Value + "', '" + peakPresLtEarCol.Value + "', '" +
                           earCnlVolRtEarCol.Value + "', '" + earCnlVolLtEarCol.Value + "', '" +
                           curveRtEarCol.Value + "', '" + curveLtEarCol.Value + "', '" +
                           acRf500RtEarCol.Value + "', '" + acRf500LtEarCol.Value + "', '" +
                           acRf1000RtEarCol.Value + "', '" + acRf1000LtEarCol.Value + "', '" +
                           acRf2000RtEarCol.Value + "', '" + acRf2000LtEarCol.Value + "', '" +
                           acRf4000RtEarCol.Value + "', '" + acRf4000LtEarCol.Value + "')";
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
                msg = "Failed to write Impedance Audiometry Tests data to database table " + dbTable + ".";
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
                           compNeg400RtEarCol.Name + " = '" + compNeg400RtEarCol.Value + "', " +
                           compNeg400LtEarCol.Name + " = '" + compNeg400LtEarCol.Value + "', " +
                           compNeg300RtEarCol.Name + " = '" + compNeg300RtEarCol.Value + "', " +
                           compNeg300LtEarCol.Name + " = '" + compNeg300LtEarCol.Value + "', " +
                           compNeg200RtEarCol.Name + " = '" + compNeg200RtEarCol.Value + "', " +
                           compNeg200LtEarCol.Name + " = '" + compNeg200LtEarCol.Value + "', " +
                           compNeg100RtEarCol.Name + " = '" + compNeg100RtEarCol.Value + "', " +
                           compNeg100LtEarCol.Name + " = '" + compNeg100LtEarCol.Value + "', " +
                           comp0RtEarCol.Name + " = '" + comp0RtEarCol.Value + "', " +
                           comp0LtEarCol.Name + " = '" + comp0LtEarCol.Value + "', " +
                           comp100RtEarCol.Name + " = '" + comp100RtEarCol.Value + "', " +
                           comp100LtEarCol.Name + " = '" + comp100LtEarCol.Value + "', " +
                           comp200RtEarCol.Name + " = '" + comp200RtEarCol.Value + "', " +
                           comp200LtEarCol.Name + " = '" + comp200LtEarCol.Value + "', " +
                           comp300RtEarCol.Name + " = '" + comp300RtEarCol.Value + "', " +
                           comp300LtEarCol.Name + " = '" + comp300LtEarCol.Value + "', " +
                           comp400RtEarCol.Name + " = '" + comp400RtEarCol.Value + "', " +
                           comp400LtEarCol.Name + " = '" + comp400LtEarCol.Value + "', " +
                           peakPresRtEarCol.Name + " = '" + peakPresRtEarCol.Value + "', " +
                           peakPresLtEarCol.Name + " = '" + peakPresLtEarCol.Value + "', " +
                           earCnlVolRtEarCol.Name + " = '" + earCnlVolRtEarCol.Value + "', " +
                           earCnlVolLtEarCol.Name + " = '" + earCnlVolLtEarCol.Value + "', " +
                           curveRtEarCol.Name + " = '" + curveRtEarCol.Value + "', " +
                           curveLtEarCol.Name + " = '" + curveLtEarCol.Value + "', " +
                           acRf500RtEarCol.Name + " = '" + acRf500RtEarCol.Value + "', " +
                           acRf500LtEarCol.Name + " = '" + acRf500LtEarCol.Value + "', " +
                           acRf1000RtEarCol.Name + " = '" + acRf1000RtEarCol.Value + "', " +
                           acRf1000LtEarCol.Name + " = '" + acRf1000LtEarCol.Value + "', " +
                           acRf2000RtEarCol.Name + " = '" + acRf2000RtEarCol.Value + "', " +
                           acRf2000LtEarCol.Name + " = '" + acRf2000LtEarCol.Value + "', " +
                           acRf4000RtEarCol.Name + " = '" + acRf4000RtEarCol.Value + "', " +
                           acRf4000LtEarCol.Name + " = '" + acRf4000LtEarCol.Value + "'" +
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
                ImpedanceTabVM impViewModel = (ImpedanceTabVM)viewmodel;

                impViewModel.IsImpedanceTestConducted = Convert.ToBoolean(reader.GetString(isTestConductedCol.Index));
                impViewModel.RtEarComplianceNeg400daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg400RtEarCol.Index));
                impViewModel.LtEarComplianceNeg400daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg400LtEarCol.Index));
                impViewModel.RtEarComplianceNeg300daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg300RtEarCol.Index));
                impViewModel.LtEarComplianceNeg300daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg300LtEarCol.Index));
                impViewModel.RtEarComplianceNeg200daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg200RtEarCol.Index));
                impViewModel.LtEarComplianceNeg200daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg200LtEarCol.Index));
                impViewModel.RtEarComplianceNeg100daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg100RtEarCol.Index));
                impViewModel.LtEarComplianceNeg100daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(compNeg100LtEarCol.Index));
                impViewModel.RtEarCompliance0daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp0RtEarCol.Index));
                impViewModel.LtEarCompliance0daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp0LtEarCol.Index));
                impViewModel.RtEarCompliance100daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp100RtEarCol.Index));
                impViewModel.LtEarCompliance100daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp100LtEarCol.Index));
                impViewModel.RtEarCompliance200daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp200RtEarCol.Index));
                impViewModel.LtEarCompliance200daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp200LtEarCol.Index));
                impViewModel.RtEarCompliance300daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp300RtEarCol.Index));
                impViewModel.LtEarCompliance300daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp300LtEarCol.Index));
                impViewModel.RtEarCompliance400daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp400RtEarCol.Index));
                impViewModel.LtEarCompliance400daPa = NullDoubleHelper.ToNullableDouble(reader.GetString(comp400LtEarCol.Index));
                impViewModel.RtEarPeakPressure = NullDoubleHelper.ToNullableDouble(reader.GetString(peakPresRtEarCol.Index));
                impViewModel.LtEarPeakPressure = NullDoubleHelper.ToNullableDouble(reader.GetString(peakPresLtEarCol.Index));
                impViewModel.RtEarCanalVolume = NullDoubleHelper.ToNullableDouble(reader.GetString(earCnlVolRtEarCol.Index));
                impViewModel.LtEarCanalVolume = NullDoubleHelper.ToNullableDouble(reader.GetString(earCnlVolLtEarCol.Index));
                impViewModel.RtEarCurveType = (ImpedanceTabVM.TympanogramType)Enum.Parse(typeof(ImpedanceTabVM.TympanogramType), reader.GetString(curveRtEarCol.Index));
                impViewModel.LtEarCurveType = (ImpedanceTabVM.TympanogramType)Enum.Parse(typeof(ImpedanceTabVM.TympanogramType), reader.GetString(curveLtEarCol.Index));
                impViewModel.RtEarAcousticReflex500Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf500RtEarCol.Index));
                impViewModel.LtEarAcousticReflex500Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf500LtEarCol.Index));
                impViewModel.RtEarAcousticReflex1000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf1000RtEarCol.Index));
                impViewModel.LtEarAcousticReflex1000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf1000LtEarCol.Index));
                impViewModel.RtEarAcousticReflex2000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf2000RtEarCol.Index));
                impViewModel.LtEarAcousticReflex2000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf2000LtEarCol.Index));
                impViewModel.RtEarAcousticReflex4000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf4000RtEarCol.Index));
                impViewModel.LtEarAcousticReflex4000Hz = (ImpedanceTabVM.AcousticReflexType)Enum.Parse(typeof(ImpedanceTabVM.AcousticReflexType), reader.GetString(acRf4000LtEarCol.Index));
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
    }
}
