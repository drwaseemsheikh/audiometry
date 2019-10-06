using System;
using System.ComponentModel;
using System.Globalization;

namespace Audiometry.ViewModel.SearchVM
{
    public class Patient : INotifyPropertyChanged
    {
        #region Members
        private string accountNumber;
        private string firstName;
        private string lastName;
        private DateTime examDate;
        private bool isSelected;
        #endregion

        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (accountNumber != value)
                {
                    accountNumber = value;
                    OnPropertyChanged("AccountNumber");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public DateTime ExamDate
        {
            get { return examDate; }
            set
            {
                if (examDate != value)
                {
                    examDate = value;
                    OnPropertyChanged("ExamDate");
                }
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        #region Methods
        public Patient(string accNumber, string fName, string lName, string date, bool isSel)
        {
            AccountNumber = accNumber;
            FirstName = fName;
            LastName = lName;
            ExamDate = Convert.ToDateTime(date, CultureInfo.InvariantCulture);
            IsSelected = isSel;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
