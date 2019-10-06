using System;
using System.Collections.Generic;
using Audiometry.Model.TabModel;

namespace Audiometry.ViewModel.PatientVM
{
    public enum RelationType
    {
        Son,
        Daughter,
        Wife
    }

    public enum SexType
    {
        Male,
        Female
    }

    public class PatientTabVM : TabVM
    {
        #region private members
        private string firstName;
        private string middleName;
        private string lastName;
        private string title;
        private string accNumber;
        private string phone;
        private string dependeeName;
        private RelationType dependeeRelation;
        private string address;
        private string prescription;
        private DateTime dateOfBirth;
        private SexType sex;
        private DateTime dateOfExam;
        private IList<Test> testHistory;
        private string hospitalID;
        private IList<Symptom> symptoms;
        private string symptompsRemarks;
        private IList<Diagnosis> diagnoses;
        private string diagnosisRemarks;
        private string profession;

        private TabModel ptModel;
        #endregion

        #region properties
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == null || !firstName.Equals(value))
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (middleName == null || !middleName.Equals(value))
                {
                    middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName == null || !lastName.Equals(value))
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title == null || !title.Equals(value))
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string AccNumber
        {
            get { return accNumber; }
            set
            {
                if (accNumber == null || !accNumber.Equals(value))
                {
                    accNumber = value;
                    OnPropertyChanged("AccNumber");
                }
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone == null || !phone.Equals(value))
                {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public string DependeeName
        {
            get { return dependeeName; }
            set
            {
                if (dependeeName == null || !dependeeName.Equals(value))
                {
                    dependeeName = value;
                    OnPropertyChanged("DependeeName");
                }
            }
        }

        public RelationType DependeeRelation
        {
            get { return dependeeRelation; }
            set
            {
                if (dependeeRelation != value)
                {
                    dependeeRelation = value;
                    OnPropertyChanged("DependeeRelation");
                }
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (address == null || !address.Equals(value))
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string Prescription
        {
            get { return prescription; }
            set
            {
                if (prescription == null || !prescription.Equals(value))
                {
                    prescription = value;
                    OnPropertyChanged("Prescription");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (!dateOfBirth.Equals(value))
                {
                    dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }

        public SexType Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    sex = value;
                    OnPropertyChanged("Sex");
                }
            }
        }

        public DateTime DateOfExam
        {
            get { return dateOfExam; }
            set
                {
                if (!dateOfExam.Equals(value))
                {
                    dateOfExam = value;
                    OnPropertyChanged("DateOfExam");
                }
            }
        }

        private IList<Test> TestHistory
        {
            get { return testHistory; }
            set
            {
                testHistory = value;
                OnPropertyChanged("TestHistory");
            }
        }

        public string HospitalID
        {
            get { return hospitalID; }
            set
            {
                if (hospitalID == null || !hospitalID.Equals(value))
                {
                    hospitalID = value;
                    OnPropertyChanged("HospitalID");
                }
            }
        }

        public IList<Symptom> Symptoms
        {
            get { return symptoms; }
            set
            {
                symptoms = value;
                OnPropertyChanged("Symptoms");
            }
        }

        public string SymptomsRemarks
        {
            get { return symptompsRemarks; }
            set
            {
                if (symptompsRemarks == null || !symptompsRemarks.Equals(value))
                {
                    symptompsRemarks = value;
                    OnPropertyChanged("SymptomsRemarks");
                }
            }
        }

        public IList<Diagnosis> Diagnoses
        {
            get { return diagnoses; }
            set
            {
                diagnoses = value;
                OnPropertyChanged("Diagnoses");
            }
        }

        public string DiagnosisRemarks
        {
            get { return diagnosisRemarks; }
            set
            {
                if (diagnosisRemarks == null || !diagnosisRemarks.Equals(value))
                {
                    diagnosisRemarks = value;
                    OnPropertyChanged("DiagnosisRemarks");
                }
            }
        }

        public string Profession
        {
            get { return profession; }
            set
            {
                if (profession == null || !profession.Equals(value))
                {
                    profession = value;
                    OnPropertyChanged("Profession");
                }
            }
        }
        #endregion

        #region public members
        public PatientTabVM()
        {
            DateOfBirth = DateTime.Now;
            DateOfExam = DateTime.Now;
            TestHistory = new List<Test>();
            Symptoms = CreateUncheckedSymptomsList();
            Diagnoses = CreateUncheckedDiagnosisList();

            ptModel = new PatientModel(this);
        }

        public IList<Diagnosis> CreateUncheckedDiagnosisList()
        {
            IList<Diagnosis> diagList = new List<Diagnosis>();
            diagList.Add(new Diagnosis("Barotrauma"));
            diagList.Add(new Diagnosis("Meniere's disease"));
            diagList.Add(new Diagnosis("Otitis Externa"));
            diagList.Add(new Diagnosis("Otitis Media"));
            diagList.Add(new Diagnosis("Ruptured Eardrum"));
            diagList.Add(new Diagnosis("Tinnitus"));
            return diagList;
        }

        public IList<Symptom> CreateUncheckedSymptomsList()
        {
            IList<Symptom> symList = new List<Symptom>();
            symList.Add(new Symptom("Earache"));
            symList.Add(new Symptom("Fever"));
            symList.Add(new Symptom("Fluid draining from the ear"));
            symList.Add(new Symptom("Headache"));
            symList.Add(new Symptom("Loss of balance"));
            symList.Add(new Symptom("Loss of hearing"));
            symList.Add(new Symptom("Nausea and vomiting"));
            symList.Add(new Symptom("Pus-filled or bloody drainage from the ear"));
            symList.Add(new Symptom("Redness and swelling of the outer ear"));
            symList.Add(new Symptom("Vertigo"));
            return symList;
        }

        public override bool AddRecordToDatabase(string accountNumber, string examDate, out string msg)
        {
            return ptModel.AddRecordToDatabase(accountNumber, examDate, out msg);
        }

        public override bool UpdateRecordInDatabase(string accountNumber, string examDate, out string msg)
        {
            return ptModel.UpdateRecordInDatabase(accountNumber, examDate, out msg);
        }

        public override void OpenRecordFromDatabase(string accountNumber, string examDate)
        {
            ptModel.OpenRecordFromDatabase(accountNumber, examDate);
        }

        public bool DoesRecordExistInDatabase(string accountNumber, string examDate)
        {
            return ((PatientModel)ptModel).DoesRecordExistInDatabase(accountNumber, examDate);
        }

        public override bool DeleteRecordFromDatabase(string accountNumber, string examDate)
        {
            return ptModel.DeleteRecordFromDatabase(accountNumber, examDate);
        }

        public bool IsValidRecord()
        {
            ulong accNumRes;
            bool isValid = ulong.TryParse(accNumber, out accNumRes);

            return isValid;
        }

        public override void InitializeProperties()
        {
            AccNumber = null;
            DateOfExam = DateTime.Now;

            FirstName = null;
            MiddleName = null;
            LastName = null;
            Title = null;
            Phone = null;
            DependeeName = null;
            DependeeRelation = RelationType.Son;
            Address = null;
            DateOfBirth = DateTime.Now;
            Sex = SexType.Male;
            Profession = null;
            HospitalID = null;
            Symptoms = CreateUncheckedSymptomsList();
            SymptomsRemarks = null;
            Diagnoses = CreateUncheckedDiagnosisList();
            DiagnosisRemarks = null;
            Prescription = null;
        }
        #endregion
    }
}
