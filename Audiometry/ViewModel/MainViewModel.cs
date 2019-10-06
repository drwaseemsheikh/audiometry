using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Audiometry.Converter;
using Audiometry.Database;
using Audiometry.ViewModel.BithermalCaloricVM;
using Audiometry.ViewModel.PatientVM;
using Audiometry.ViewModel.ImpedanceVM;
using Audiometry.ViewModel.PureToneVM;
using Audiometry.ViewModel.SpeechVM;

namespace Audiometry.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Members
        public const int PatientTabIndex = 0;
        public const int PureToneTabIndex = 1;
        public const int SpeechTabIndex = 2;
        public const int ImpedanceTabIndex = 3;
        public const int BithermalCaloricTabIndex = 4;
        private SortedDictionary<int, TabVM> tabVMDict;
        #endregion

        #region Properties
        public PatientTabVM Patient { get; private set; }

        public ObservableCollection<TabVM> TabVMs { get; private set; }
        #endregion

        #region Methods
        public MainViewModel()
        {
            tabVMDict = new SortedDictionary<int, TabVM>();
            tabVMDict[PatientTabIndex] = new PatientTabVM();
            tabVMDict[PureToneTabIndex] = new PureToneTabVM();
            tabVMDict[SpeechTabIndex] = new SpeechTabVM();
            tabVMDict[ImpedanceTabIndex] = new ImpedanceTabVM();
            tabVMDict[BithermalCaloricTabIndex] = new BithermalCaloricTabVM();
            TabVMs = new ObservableCollection<TabVM>(tabVMDict.Values);

            Patient = (PatientTabVM)tabVMDict[PatientTabIndex];
        }

        public bool AddRecordToDatabase(out string msg)
        {
            string error;
            string accNumber = Patient.AccNumber;
            string examDate = SqliteDateTimeHelper.ToSqliteDateTime(Patient.DateOfExam);

            bool success = Patient.AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[PureToneTabIndex].AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[SpeechTabIndex].AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[ImpedanceTabIndex].AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[BithermalCaloricTabIndex].AddRecordToDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            msg = string.Empty;
            return true;
        }

        public bool UpdateRecordInDatabase(out string msg)
        {
            string error;
            string accNumber = Patient.AccNumber;
            string examDate = SqliteDateTimeHelper.ToSqliteDateTime(Patient.DateOfExam);

            bool success = Patient.UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[PureToneTabIndex].UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[SpeechTabIndex].UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[ImpedanceTabIndex].UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            success = tabVMDict[BithermalCaloricTabIndex].UpdateRecordInDatabase(accNumber, examDate, out error);

            if (!success)
            {
                msg = error;
                return false;
            }

            msg = string.Empty;
            return true;
        }

        public void OpenRecordFromDatabase(string accNumber, string examDate)
        {
            Patient.OpenRecordFromDatabase(accNumber, examDate);
            tabVMDict[PureToneTabIndex].OpenRecordFromDatabase(accNumber, examDate);
            tabVMDict[SpeechTabIndex].OpenRecordFromDatabase(accNumber, examDate);
            tabVMDict[ImpedanceTabIndex].OpenRecordFromDatabase(accNumber, examDate);
            tabVMDict[BithermalCaloricTabIndex].OpenRecordFromDatabase(accNumber, examDate);
        }

        public bool DeleteRecordFromDatabase(string accNumber, string examDate)
        {
            bool patientDel = Patient.DeleteRecordFromDatabase(accNumber, examDate);
            bool puretoneDel = tabVMDict[PureToneTabIndex].DeleteRecordFromDatabase(accNumber, examDate);
            bool speechDel = tabVMDict[SpeechTabIndex].DeleteRecordFromDatabase(accNumber, examDate);
            bool impedanceDel = tabVMDict[ImpedanceTabIndex].DeleteRecordFromDatabase(accNumber, examDate);
            bool caloricDel = tabVMDict[BithermalCaloricTabIndex].DeleteRecordFromDatabase(accNumber, examDate);

            return (patientDel || puretoneDel || speechDel || impedanceDel || caloricDel);
        }

        public bool DoesRecordExistInDatabase(string accountNumber, string examDate)
        {
            bool recordExists = Patient.DoesRecordExistInDatabase(accountNumber, examDate);

            return recordExists;
        }

        public void InitializeProperties()
        {
            Patient.InitializeProperties();
            tabVMDict[PureToneTabIndex].InitializeProperties();
            tabVMDict[SpeechTabIndex].InitializeProperties();
            tabVMDict[ImpedanceTabIndex].InitializeProperties();
            tabVMDict[BithermalCaloricTabIndex].InitializeProperties();
        }

        public static void OpenDbConnection(bool isEncrypted)
        {
            DatabaseInfo.OpenDbConnection(isEncrypted);
        }

        public static void CloseDbConnection()
        {
            DatabaseInfo.CloseDbConnection();
        }
        #endregion
    }
}
