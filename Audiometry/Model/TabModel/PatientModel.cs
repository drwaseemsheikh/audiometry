using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel;
using Audiometry.ViewModel.PatientVM;

namespace Audiometry.Model.TabModel
{
    public class PatientModel : TabModel
    {
        #region Database
        private const string patientTable = "PatientInfo";
        private readonly DbColumn accNumberCol;
        private readonly DbColumn dateOfExamCol;
        private readonly DbColumn firstNameCol;
        private readonly DbColumn middleNameCol;
        private readonly DbColumn lastNameCol;
        private readonly DbColumn titleCol;
        private readonly DbColumn phoneCol;
        private readonly DbColumn dependeeNameCol;
        private readonly DbColumn dependeeRelationCol;
        private readonly DbColumn addressCol;
        private readonly DbColumn dateOfBirthCol;
        private readonly DbColumn sexCol;
        private readonly DbColumn professionCol;
        private readonly DbColumn hospitalIDCol;
        private readonly DbColumn symptomsCol;
        private readonly DbColumn symptomsRemarksCol;
        private readonly DbColumn diagnosesCol;
        private readonly DbColumn diagnosisRemarksCol;
        private readonly DbColumn prescriptionCol;
        #endregion

        #region Methods
        public PatientModel(TabVM vm) : base(vm)
        {
            accNumberCol = new DbColumn(0, "AccNumber", string.Empty);
            dateOfExamCol = new DbColumn(1, "DateOfExam", string.Empty);
            firstNameCol = new DbColumn(2, "FirstName", string.Empty);
            middleNameCol = new DbColumn(3, "MiddleName", string.Empty);
            lastNameCol = new DbColumn(4, "LastName", string.Empty);
            titleCol = new DbColumn(5, "Title", string.Empty);
            phoneCol = new DbColumn(6, "Phone", string.Empty);
            dependeeNameCol = new DbColumn(7, "DependeeName", string.Empty);
            dependeeRelationCol = new DbColumn(8, "DependeeRelation", string.Empty);
            addressCol = new DbColumn(9, "Address", string.Empty);
            dateOfBirthCol = new DbColumn(10, "DateOfBirth", string.Empty);
            sexCol = new DbColumn(11, "Sex", string.Empty);
            professionCol = new DbColumn(12, "Profession", string.Empty);
            hospitalIDCol = new DbColumn(13, "HospitalID", string.Empty);
            symptomsCol = new DbColumn(14, "Symptoms", string.Empty);
            symptomsRemarksCol = new DbColumn(15, "SymptomsRemarks", string.Empty);
            diagnosesCol = new DbColumn(16, "Diagnoses", string.Empty);
            diagnosisRemarksCol = new DbColumn(17, "DiagnosisRemarks", string.Empty);
            prescriptionCol = new DbColumn(18, "Prescription", string.Empty);
        }

        public override bool AddRecordToDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues();
            string query = ConstructInsertQuery();
            return ExecuteQuery(query, out msg);
        }

        private void GetViewModelPropertyValues()
        {
            PatientTabVM ptViewModel = (PatientTabVM)viewmodel;

            string symptomsStr = String.Empty;

            foreach (Symptom symptom in ptViewModel.Symptoms)
            {
                if (symptom.IsChecked)
                {
                    symptomsStr += symptom.Description + ",";
                }
            }

            symptomsStr = symptomsStr.TrimEnd(',');

            string diagnosesStr = String.Empty;

            foreach (Diagnosis disorder in ptViewModel.Diagnoses)
            {
                if (disorder.IsChecked)
                {
                    diagnosesStr += disorder.Description + ",";
                }
            }

            diagnosesStr = diagnosesStr.TrimEnd(',');

            accNumberCol.Value = ptViewModel.AccNumber;
            dateOfExamCol.Value = SqliteDateTimeHelper.ToSqliteDateTime(ptViewModel.DateOfExam);
            firstNameCol.Value = ptViewModel.FirstName;
            middleNameCol.Value = ptViewModel.MiddleName;
            lastNameCol.Value = ptViewModel.LastName;
            titleCol.Value = ptViewModel.Title;
            phoneCol.Value = ptViewModel.Phone;
            dependeeNameCol.Value = ptViewModel.DependeeName;
            dependeeRelationCol.Value = ptViewModel.DependeeRelation.ToString();
            addressCol.Value = ptViewModel.Address;
            dateOfBirthCol.Value = SqliteDateTimeHelper.ToSqliteDateTime(ptViewModel.DateOfBirth);
            sexCol.Value = ptViewModel.Sex.ToString();
            professionCol.Value = ptViewModel.Profession;
            hospitalIDCol.Value = ptViewModel.HospitalID;
            symptomsCol.Value = symptomsStr;
            symptomsRemarksCol.Value = ptViewModel.SymptomsRemarks;
            diagnosesCol.Value = diagnosesStr;
            diagnosisRemarksCol.Value = ptViewModel.DiagnosisRemarks;
            prescriptionCol.Value = ptViewModel.Prescription;
        }

        private string ConstructInsertQuery()
        {
            string query = "INSERT into " + patientTable + " (" + accNumberCol.Name + "," + dateOfExamCol.Name + "," +
                           firstNameCol.Name + "," + middleNameCol.Name + "," + lastNameCol.Name + "," + titleCol.Name + "," +
                           phoneCol.Name + "," + dependeeNameCol.Name + "," + dependeeRelationCol.Name + "," +
                           addressCol.Name + "," + dateOfBirthCol.Name + "," + sexCol.Name + "," + professionCol.Name + "," +
                           hospitalIDCol.Name + "," + symptomsCol.Name + "," + symptomsRemarksCol.Name + "," +
                           diagnosesCol.Name + "," + diagnosisRemarksCol.Name + "," + prescriptionCol.Name + ")" +
                           " values ('" + accNumberCol.Value + "', '" + dateOfExamCol.Value + "', '" +
                           firstNameCol.Value + "', '" + middleNameCol.Value + "', '" + lastNameCol.Value + "', '" +
                           titleCol.Value + "', '" + phoneCol.Value + "', '" + dependeeNameCol.Value + "', '" +
                           dependeeRelationCol.Value + "', '" + addressCol.Value + "', '" + dateOfBirthCol.Value + "', '" +
                           sexCol.Value + "', '" + professionCol.Value + "', '" + hospitalIDCol.Value + "', '" +
                           symptomsCol.Value + "', '" + symptomsRemarksCol.Value + "', '" + diagnosesCol.Value + "', '" +
                           diagnosisRemarksCol.Value + "', '" + prescriptionCol.Value + "')";
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
                msg = "Failed to write patient data to database table " + patientTable + ".";
                return false;
            }
        }

        public override bool UpdateRecordInDatabase(string accNumber, string examDate, out string msg)
        {
            GetViewModelPropertyValues();
            string query = ConstructUpdateQuery();
            return ExecuteQuery(query, out msg);
        }

        private string ConstructUpdateQuery()
        {
            string query = "UPDATE " + patientTable +
                           " SET " +
                           firstNameCol.Name + " = '" + firstNameCol.Value + "', " +
                           middleNameCol.Name + " = '" + middleNameCol.Value + "', " +
                           lastNameCol.Name + " = '" + lastNameCol.Value + "', " +
                           titleCol.Name + " = '" + titleCol.Value + "', " +
                           phoneCol.Name + " = '" + phoneCol.Value + "', " +
                           dependeeNameCol.Name + " = '" + dependeeNameCol.Value + "', " +
                           dependeeRelationCol.Name + " = '" + dependeeRelationCol.Value + "', " +
                           addressCol.Name + " = '" + addressCol.Value + "', " +
                           dateOfBirthCol.Name + " = '" + dateOfBirthCol.Value + "', " +
                           sexCol.Name + " = '" + sexCol.Value + "', " +
                           professionCol.Name + " = '" + professionCol.Value + "', " +
                           hospitalIDCol.Name + " = '" + hospitalIDCol.Value + "', " +
                           symptomsCol.Name + " = '" + symptomsCol.Value + "', " +
                           symptomsRemarksCol.Name + " = '" + symptomsRemarksCol.Value + "', " +
                           diagnosesCol.Name + " = '" + diagnosesCol.Value + "', " +
                           diagnosisRemarksCol.Name + " = '" + diagnosisRemarksCol.Value + "', " +
                           prescriptionCol.Name + " = '" + prescriptionCol.Value + "'" +
                           " WHERE " +
                           accNumberCol.Name + " = '" + accNumberCol.Value + "' AND " +
                           dateOfExamCol.Name + " = '" + dateOfExamCol.Value + "'";
            return query;
        }

        public override void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            string query = "SELECT * FROM " + patientTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand readCmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            SQLiteDataReader reader = readCmd.ExecuteReader();
            reader.Read();

            PatientTabVM ptViewModel = (PatientTabVM)viewmodel;
            ptViewModel.AccNumber = reader.GetInt32(accNumberCol.Index).ToString(CultureInfo.InvariantCulture);
            ptViewModel.DateOfExam = Convert.ToDateTime(reader.GetString(dateOfExamCol.Index), CultureInfo.InvariantCulture);

            ptViewModel.FirstName = reader.GetString(firstNameCol.Index);
            ptViewModel.MiddleName = reader.GetString(middleNameCol.Index);
            ptViewModel.LastName = reader.GetString(lastNameCol.Index);
            ptViewModel.Title = reader.GetString(titleCol.Index);
            ptViewModel.Phone = reader.GetString(phoneCol.Index);
            ptViewModel.DependeeName = reader.GetString(dependeeNameCol.Index);
            ptViewModel.DependeeRelation = (RelationType)Enum.Parse(typeof(RelationType), reader.GetString(dependeeRelationCol.Index));
            ptViewModel.Address = reader.GetString(addressCol.Index);
            ptViewModel.DateOfBirth = Convert.ToDateTime(reader.GetString(dateOfBirthCol.Index), CultureInfo.InvariantCulture);
            ptViewModel.Sex = (SexType)Enum.Parse(typeof(SexType), reader.GetString(sexCol.Index));
            ptViewModel.Profession = reader.GetString(professionCol.Index);
            ptViewModel.HospitalID = reader.GetString(hospitalIDCol.Index);

            IList<Symptom> symList = ptViewModel.CreateUncheckedSymptomsList();
            string symStr = reader.GetString(symptomsCol.Index);
            string[] symArr = symStr.Split(',').Select(sym => sym.Trim()).ToArray();

            foreach (string sym in symArr)
            {
                Symptom found = symList.FirstOrDefault(x => x.Description.Equals(sym));

                if (found != null)
                {
                    found.IsChecked = true;
                }
            }

            ptViewModel.Symptoms = symList;
            ptViewModel.SymptomsRemarks = reader.GetString(symptomsRemarksCol.Index);

            IList<Diagnosis> diagList = ptViewModel.CreateUncheckedDiagnosisList();
            string diagStr = reader.GetString(diagnosesCol.Index);
            string[] diagArr = diagStr.Split(',').Select(diag => diag.Trim()).ToArray();

            foreach (string diag in diagArr)
            {
                Diagnosis found = diagList.FirstOrDefault(x => x.Description.Equals(diag));

                if (found != null)
                {
                    found.IsChecked = true;
                }
            }

            ptViewModel.Diagnoses = diagList;

            ptViewModel.DiagnosisRemarks = reader.GetString(diagnosisRemarksCol.Index);
            ptViewModel.Prescription = reader.GetString(prescriptionCol.Index);
        }

        public override bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            string query = "DELETE FROM " + patientTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            int rows = cmd.ExecuteNonQuery();

            return (rows == 1);
        }

        public bool DoesRecordExistInDatabase(string accNumber, string examDate)
        {
            string query = "SELECT * FROM " + patientTable + " WHERE AccNumber = '" + accNumber +
                           "' AND DateOfExam = '" + examDate + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseInfo.SqliteCon);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return (count > 0);
        }
        #endregion
    }
}
