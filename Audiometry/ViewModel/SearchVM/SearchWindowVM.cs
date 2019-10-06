using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Input;
using Audiometry.Converter;
using Audiometry.Database;
using Microsoft.Practices.Prism.Commands;

namespace Audiometry.ViewModel.SearchVM
{
    public class SearchWindowVM : ViewModelBase
    {
        #region Types
        public enum ActionType
        {
            CANCEL_ACTION,
            OPEN_ACTION
        }
        #endregion

        #region Members
        private string accountNumberSearch;
        private string firstNameSearch;
        private string lastNameSearch;
        private DateTime examDateStart;
        private DateTime examDateEnd;
        private ObservableCollection<Patient> patientRecords;

        private ICommand searchCommand;
        private ICommand openCommand;
        #endregion

        #region Database
        private const string patientTable = "PatientInfo";
        private const string accountNumberCol = "AccNumber";
        private const string firstNameCol = "FirstName";
        private const string lastNameCol = "LastName";
        private const string examDateCol = "DateOfExam";
        #endregion

        #region Properties
        public string AccountNumberSearch
        {
            get { return accountNumberSearch; }
            set
            {
                if (accountNumberSearch != value)
                {
                    accountNumberSearch = value;
                    OnPropertyChanged("AccountNumberSearch");
                }
            }
        }

        public string FirstNameSearch
        {
            get { return firstNameSearch; }
            set
            {
                if (firstNameSearch != value)
                {
                    firstNameSearch = value;
                    OnPropertyChanged("FirstNameSearch");
                }
            }
        }

        public string LastNameSearch
        {
            get { return lastNameSearch; }
            set
            {
                if (lastNameSearch != value)
                {
                    lastNameSearch = value;
                    OnPropertyChanged("LastNameSearch");
                }
            }
        }

        public DateTime ExamDateStart
        {
            get { return examDateStart; }
            set
            {
                if (examDateStart != value)
                {
                    examDateStart = value;
                    OnPropertyChanged("ExamDateStart");
                }
            }
        }

        public DateTime ExamDateEnd
        {
            get { return examDateEnd; }
            set
            {
                if (examDateEnd != value)
                {
                    examDateEnd = value;
                    OnPropertyChanged("ExamDateEnd");
                }
            }
        }

        public ObservableCollection<Patient> PatientRecords
        {
            get { return patientRecords; }
            set
            {
                if (patientRecords != value)
                {
                    patientRecords = value;
                    OnPropertyChanged("PatientRecords");
                }
            }
        }

        public ICommand SearchCommand
        {
            get { return searchCommand ?? (searchCommand = new DelegateCommand(SearchExamRecord, CanSearchExamRecordExecute)); }
        }

        public ICommand OpenCommand
        {
            get { return openCommand ?? (openCommand = new DelegateCommand(OpenExamRecord, CanOpenExamRecordExecute)); }
        }

        public Action CloseAction { get; set; }

        public ActionType SearchWindowAction { get; private set; }

        public bool IsRecordSelected
        {
            get
            {
                return (PatientRecords.Any(x => x.IsSelected == true));
            }
        }

        public string AccountNumberSelected
        {
            get
            {
                Patient pt = PatientRecords.FirstOrDefault(x => x.IsSelected == true);
                return pt.AccountNumber;
            }
        }

        public DateTime ExamDateSelected
        {
            get
            {
                Patient pt = PatientRecords.FirstOrDefault(x => x.IsSelected == true);
                return pt.ExamDate;
            }
        }
        #endregion

        #region Methods
        public SearchWindowVM()
        {
            ExamDateStart = DateTime.Now;
            ExamDateEnd = DateTime.Now;
            SearchWindowAction = ActionType.CANCEL_ACTION;
            PatientRecords = new ObservableCollection<Patient>();
        }

        private void SearchExamRecord()
        {
            string query = ConstructSearchQuery();
            MainViewModel.OpenDbConnection(true);

            try
            {
                SQLiteDataAdapter adapt = new SQLiteDataAdapter(query, DatabaseInfo.SqliteCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

                foreach (DataRow row in table.Rows)
                {
                    string accNumber = ((long)row[accountNumberCol]).ToString();
                    string fName = (string)row[firstNameCol];
                    string lName = (string)row[lastNameCol];
                    string examDate = (string)row[examDateCol];

                    Patient pt = new Patient(accNumber, fName, lName, examDate, false);
                    patients.Add(pt);
                }

                PatientRecords = patients;
                DatabaseInfo.CloseDbConnection();
            }
            catch (Exception)
            {
                DatabaseInfo.CloseDbConnection();
                throw;
            }
        }

        private string ConstructSearchQuery()
        {
            string query = "SELECT " + accountNumberCol + ", " + firstNameCol + ", " + lastNameCol + ", " + examDateCol + 
                " FROM " + patientTable;
            bool isAndClause = false;

            if (!(String.IsNullOrEmpty(AccountNumberSearch) || String.IsNullOrWhiteSpace(AccountNumberSearch)) ||
                !(String.IsNullOrEmpty(FirstNameSearch) || String.IsNullOrWhiteSpace(FirstNameSearch)) ||
                !(String.IsNullOrEmpty(LastNameSearch) || String.IsNullOrWhiteSpace(LastNameSearch)) ||
               (ExamDateEnd >= ExamDateStart))
            {
                query += " WHERE ";
            }

            if (!String.IsNullOrEmpty(AccountNumberSearch) && !String.IsNullOrWhiteSpace(AccountNumberSearch))
            {
                query += accountNumberCol + " = " + "'" + AccountNumberSearch + "'";
                isAndClause = true;
            }

            if (!String.IsNullOrEmpty(FirstNameSearch) && !String.IsNullOrWhiteSpace(FirstNameSearch))
            {
                if (isAndClause)
                {
                    query += " AND ";
                }

                query += firstNameCol + " = " + "'" + FirstNameSearch + "'";
                isAndClause = true;
            }

            if (!String.IsNullOrEmpty(LastNameSearch) && !String.IsNullOrWhiteSpace(LastNameSearch))
            {
                if (isAndClause)
                {
                    query += " AND ";
                }

                query += lastNameCol + " = " + "'" + LastNameSearch + "'";
                isAndClause = true;
            }

            if (ExamDateEnd >= ExamDateStart)
            {
                if (isAndClause)
                {
                    query += " AND ";
                }

                query += examDateCol + " BETWEEN " + "'" + SqliteDateTimeHelper.ToSqliteDateTime(ExamDateStart) + "' AND '" + 
                    SqliteDateTimeHelper.ToSqliteDateTime(ExamDateEnd) + "'";
            }

            query += ";";

            return query;
        }

        private bool CanSearchExamRecordExecute()
        {
            return true;
        }

        private void OpenExamRecord()
        {
            SearchWindowAction = ActionType.OPEN_ACTION;
            CloseAction();
        }

        private bool CanOpenExamRecordExecute()
        {
            return true;
        }
        #endregion
    }
}
