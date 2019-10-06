using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Threading;
using Audiometry.Converter;
using Audiometry.Print;
using Audiometry.ViewModel;
using Audiometry.ViewModel.BithermalCaloricVM;
using Audiometry.ViewModel.ImpedanceVM;
using Audiometry.ViewModel.PureToneVM;
using Audiometry.ViewModel.PureToneVM.Audiogram;
using Audiometry.ViewModel.PureToneVM.SpecialTestsVM;
using Audiometry.ViewModel.SearchVM;
using Audiometry.ViewModel.SpeechVM;
using OxyPlot;
using Application = System.Windows.Application;
using Control = System.Windows.Controls.Control;
using MessageBox = System.Windows.MessageBox;
using Size = System.Windows.Size;
using TextBox = System.Windows.Controls.TextBox;

namespace Audiometry.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Types
        public enum SaveDatabaseType
        {
            ADDED_NEW,
            MODIFIED_EXISTING,
            NO_ACTION
        }
        #endregion

        #region Members
        private MainViewModel mainVM;
        #endregion

        #region Methods
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                mainVM = new MainViewModel();
                DataContext = mainVM;

                TabItem patientTab = (TabItem)mainTabCtrl.Items[MainViewModel.PatientTabIndex];
                patientTab.DataContext = mainVM.TabVMs[MainViewModel.PatientTabIndex];

                TabItem pureToneTab = (TabItem)mainTabCtrl.Items[MainViewModel.PureToneTabIndex];
                pureToneTab.DataContext = mainVM.TabVMs[MainViewModel.PureToneTabIndex];

                TabItem ablbTab = (TabItem)specialTestsTabCtrl.Items[AblbTabVM.AblbTabIndex];
                ablbTab.DataContext = ((PureToneTabVM)mainVM.TabVMs[MainViewModel.PureToneTabIndex]).AblbTabVM;
                TabItem sisiTab = (TabItem)specialTestsTabCtrl.Items[SisiTabVM.SisiTabIndex];
                sisiTab.DataContext = ((PureToneTabVM)mainVM.TabVMs[MainViewModel.PureToneTabIndex]).SisiTabVM;
                TabItem toneDecayTab = (TabItem)specialTestsTabCtrl.Items[ToneDecayTabVM.ToneDecayTabIndex];
                toneDecayTab.DataContext = ((PureToneTabVM)mainVM.TabVMs[MainViewModel.PureToneTabIndex]).ToneDecayTabVM;
                TabItem stengerTab = (TabItem)specialTestsTabCtrl.Items[StengerTabVM.StengerTabIndex];
                stengerTab.DataContext = ((PureToneTabVM)mainVM.TabVMs[MainViewModel.PureToneTabIndex]).StengerTabVM;

                TabItem speechTab = (TabItem)mainTabCtrl.Items[MainViewModel.SpeechTabIndex];
                speechTab.DataContext = mainVM.TabVMs[MainViewModel.SpeechTabIndex];
                TabItem impedanceTab = (TabItem)mainTabCtrl.Items[MainViewModel.ImpedanceTabIndex];
                impedanceTab.DataContext = mainVM.TabVMs[MainViewModel.ImpedanceTabIndex];
                TabItem caloricTab = (TabItem)mainTabCtrl.Items[MainViewModel.BithermalCaloricTabIndex];
                caloricTab.DataContext = mainVM.TabVMs[MainViewModel.BithermalCaloricTabIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                CloseApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private static void CloseApplication()
        {
            MainViewModel.CloseDbConnection();
            Application.Current.Shutdown();
        }

        private void HLTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                ((Control)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                {
                    ((TextBox)sender).SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SaveDbBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveRecordToDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private SaveDatabaseType SaveRecordToDatabase()
        {
            SaveDatabaseType saveType = SaveDatabaseType.NO_ACTION;

            if (mainVM.Patient.IsValidRecord())
            {
                MainViewModel.OpenDbConnection(true);

                try
                {
                    string accountNumber = mainVM.Patient.AccNumber;
                    string examDate = mainVM.Patient.DateOfExam.ToString(CultureInfo.CurrentCulture);
                    string sqliteExamDate = SqliteDateTimeHelper.ToSqliteDateTime(mainVM.Patient.DateOfExam);
                    bool recordExists = mainVM.DoesRecordExistInDatabase(accountNumber, sqliteExamDate);

                    if (!recordExists)
                    {
                        string error;
                        string msg = string.Empty;
                        bool success = mainVM.AddRecordToDatabase(out error);
                        MainViewModel.CloseDbConnection();

                        if (success)
                        {
                            saveType = SaveDatabaseType.ADDED_NEW;
                            msg = "Patient record with account number " + accountNumber + " and date of exam " +
                                      examDate + " written to the database.";
                        }
                        else
                        {
                            msg = "Error: Failed to write patient record with account number " + accountNumber + " and date of exam " +
                                      examDate + " to the database. " + error;
                        }

                        MessageBox.Show(msg);
                    }
                    else
                    {
                        string msg = "A patient record with account number " + accountNumber + " and date of exam " +
                                     examDate + " already exists in the database. Would you like to overwrite the existing " +
                                     "record with the new data or create a new record?" + Environment.NewLine +
                                     Environment.NewLine + "Click YES to overwrite the existing data and NO to create a new record." +
                                     " In order to create a new record you will have to change the exam date or account number.";
                        MessageBoxResult result = MessageBox.Show(msg, "Confirm Overwrite", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.Yes)
                        {
                            string error;
                            msg = string.Empty;
                            bool success = mainVM.UpdateRecordInDatabase(out error);
                            MainViewModel.CloseDbConnection();

                            if (success)
                            {
                                saveType = SaveDatabaseType.MODIFIED_EXISTING;
                                msg = "Patient record with account number " + accountNumber + " and date of exam " +
                                      examDate + " updated in the database.";
                            }
                            else
                            {
                                msg = "Error: Failed to update patient record with account number " + accountNumber + " and date of exam " +
                                      examDate + " to the database. " + error;
                            }

                            MessageBox.Show(msg);
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            saveType = SaveDatabaseType.NO_ACTION;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainViewModel.CloseDbConnection();
                    MessageBox.Show("Exception thrown while writing patient record to the database." +
                                    Environment.NewLine + Environment.NewLine + "Exception Message: " + ex.Message +
                                    Environment.NewLine + Environment.NewLine + "Exception Stack Trace: " + ex.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Invalid patient record with account number " + mainVM.Patient.AccNumber +
                                " . Cannot save to the database.");
            }

            return saveType;
        }

        private void OpenDbBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchWindow searchWin = new SearchWindow();
                searchWin.ShowDialog();

                if (searchWin.SearchVM.SearchWindowAction == SearchWindowVM.ActionType.OPEN_ACTION &&
                    searchWin.SearchVM.IsRecordSelected)
                {
                    MainViewModel.OpenDbConnection(true);

                    try
                    {
                        mainVM.OpenRecordFromDatabase(searchWin.SearchVM.AccountNumberSelected,
                            SqliteDateTimeHelper.ToSqliteDateTime(searchWin.SearchVM.ExamDateSelected));

                        MainViewModel.CloseDbConnection();
                    }
                    catch (Exception ex)
                    {
                        MainViewModel.CloseDbConnection();
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DeleteDbBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainViewModel.OpenDbConnection(true);

                string accountNumber = mainVM.Patient.AccNumber;
                string dateTime = mainVM.Patient.DateOfExam.ToString(CultureInfo.CurrentCulture);
                string sqlDateTime = SqliteDateTimeHelper.ToSqliteDateTime(mainVM.Patient.DateOfExam);
                bool recordExists = mainVM.DoesRecordExistInDatabase(accountNumber, sqlDateTime);
                string msg = string.Empty;

                if (!recordExists)
                {
                    msg = "Patient with account number " + accountNumber + " and date of exam " +
                          dateTime + " does not exist in the database. Nothing to delete.";
                }
                else
                {
                    msg = "Patient with account number " + accountNumber + " and date of exam " + 
                        dateTime + " will be deleted from the database. Are you sure you want to delete?" + 
                        Environment.NewLine + Environment.NewLine + "Click YES to delete the record and NO to cancel.";
                    
                    MessageBoxResult result = MessageBox.Show(msg, "Confirm Delete", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        bool success = mainVM.DeleteRecordFromDatabase(accountNumber, sqlDateTime);

                        if (success)
                        {
                            msg = "Patient with account number " + accountNumber + " and date of exam " +
                              dateTime + " deleted from the database.";
                        }
                        else
                        {
                            msg = "Error: Failed to delete patient with account number " + accountNumber +
                                " and date of exam " + dateTime + " from the database.";
                        }

                        MessageBox.Show(msg);
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        //do nothing
                    }
                }

                MainViewModel.CloseDbConnection();
            }
            catch (Exception ex)
            {
                MainViewModel.CloseDbConnection();
                MessageBox.Show("Exception thrown while deleting patient record from the database." +
                                Environment.NewLine + Environment.NewLine + "Exception Message: " + ex.Message +
                                Environment.NewLine + Environment.NewLine + "Exception Stack Trace: " + ex.StackTrace);
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mainVM.Patient.IsValidRecord())
                {
                    string msg = "The application contains patient data. Would you like to save the existing " +
                                 "data before clearing it?" + Environment.NewLine + Environment.NewLine +
                                 "Click YES to save the existing data and NO to clear it without saving.";
                    MessageBoxResult result = MessageBox.Show(msg, "Confirm Saving Before Clearing", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        SaveDatabaseType saveType = SaveRecordToDatabase();

                        if (saveType == SaveDatabaseType.ADDED_NEW || saveType == SaveDatabaseType.MODIFIED_EXISTING)
                        {
                            mainVM.InitializeProperties();
                        }
                        else
                        {
                            //could not save the existing valid patient data, so dont' clear it.
                        }
                    }
                    else
                    {
                        //clear existing data without saving
                        mainVM.InitializeProperties();
                    }
                }
                else
                {
                    //invalid account number that can't be saved, so clear it
                    mainVM.InitializeProperties();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void PrintGuiBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog printDlg = new PrintDialog();
                bool? print = printDlg.ShowDialog();

                if (print.HasValue && print.Value)
                {
                    int mainTabIndex = mainTabCtrl.SelectedIndex;

                    var pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);

                    var document = new FixedDocument();
                    document.DocumentPaginator.PageSize = pageSize;

                    SwitchTab(mainTabCtrl, MainViewModel.PatientTabIndex);
                    var firstPageContent = PrintUtility.CreatePrintPageContent(pageSize, PatientInfoCanvas, "Patient Information");
                    document.Pages.Add(firstPageContent);

                    var secondPageContent = PrintUtility.CreatePrintPageContent(pageSize, ExamInfoCanvas, "Exam Information");
                    document.Pages.Add(secondPageContent);

                    int ptamTabIndex = ptamTabCtrl.SelectedIndex;
                    SwitchTab(mainTabCtrl, MainViewModel.PureToneTabIndex);
                    var thirdPageContent = PrintUtility.CreatePrintPageContent(pageSize, PureToneAMCanvas, ptamTabCtrl, 0, 3, "Pure Tone Audiometry");
                    document.Pages.Add(thirdPageContent);

                    var fourthPageContent = PrintUtility.CreatePrintPageContent(pageSize, PureToneAMCanvas, ptamTabCtrl, 4, 6, "Pure Tone Audiometry");
                    document.Pages.Add(fourthPageContent);

                    AudiogramPlot audiogramPlot =
                        ((PureToneTabVM)mainVM.TabVMs[MainViewModel.PureToneTabIndex]).ACMskTabVM.PureToneData.AudiogramPlot;
                    var fifthPageContent = PrintUtility.CreatePrintPageContentOxyPlot(pageSize,
                       audiogramPlot, (int)AudiogramPlot.Width, (int)AudiogramPlot.Height, "Audiogram");
                    document.Pages.Add(fifthPageContent);

                    var sixthPageContent = PrintUtility.CreatePrintPageContent(pageSize, HearingDisabilityCanvas, "Hearing Disability");
                    document.Pages.Add(sixthPageContent);

                    int specTabIndex = specialTestsTabCtrl.SelectedIndex;
                    var seventhPageContent = PrintUtility.CreatePrintPageContent(pageSize, SpecialTestsCanvas, specialTestsTabCtrl, 0, 2, "Special Tests");
                    document.Pages.Add(seventhPageContent);

                    var eighthPageContent = PrintUtility.CreatePrintPageContent(pageSize, SpecialTestsCanvas, specialTestsTabCtrl, 3, 3, "Special Tests");
                    document.Pages.Add(eighthPageContent);

                    var ninthPageContent = PrintUtility.CreatePrintPageContent(pageSize, TuningForkTestsCanvas, "Tuning Fork Tests");
                    document.Pages.Add(ninthPageContent);

                    SwitchTab(mainTabCtrl, MainViewModel.SpeechTabIndex);
                    var tenthPageContent = PrintUtility.CreatePrintPageContent(pageSize, SpeechAudiometryCanvas, "Speech Audiometry");
                    document.Pages.Add(tenthPageContent);

                    PlotModel speechPlot = ((SpeechTabVM)mainVM.TabVMs[MainViewModel.SpeechTabIndex]).SpeechPlotModel;
                    var eleventhPageContent = PrintUtility.CreatePrintPageContentOxyPlot(pageSize, speechPlot,
                        (int)SpeechAudiometryPlot.Width, (int)SpeechAudiometryPlot.Height, "Speech Audiometry");
                    document.Pages.Add(eleventhPageContent);

                    SwitchTab(mainTabCtrl, MainViewModel.ImpedanceTabIndex);
                    var twelvethPageContent = PrintUtility.CreatePrintPageContent(pageSize, ImpedanceCanvas, "Impedance Audiometry");
                    document.Pages.Add(twelvethPageContent);

                    PlotModel impedancePlot =
                        ((ImpedanceTabVM) mainVM.TabVMs[MainViewModel.ImpedanceTabIndex]).Tympanogram;
                    var thirteenthPageContent = PrintUtility.CreatePrintPageContentOxyPlot(pageSize, impedancePlot,
                        (int)ImpedancePlot.Width, (int)ImpedancePlot.Height, "Tympanogram");
                    document.Pages.Add(thirteenthPageContent);

                    SwitchTab(mainTabCtrl, MainViewModel.BithermalCaloricTabIndex);
                    var fourteenthPageContent = PrintUtility.CreatePrintPageContent(pageSize, BithermalCaloricCanvas, "Bithermal Caloric Test");
                    document.Pages.Add(fourteenthPageContent);

                    var fifteenthPageContent = PrintUtility.CreatePrintPageContentOxyPlot(pageSize,
                        ((BithermalCaloricTabVM)mainVM.TabVMs[MainViewModel.BithermalCaloricTabIndex]),
                        (int)BithermalCaloricPlot.Width, (int)BithermalCaloricPlot.Height, "Calorigram");
                    document.Pages.Add(fifteenthPageContent);


                    //SwitchTab(mainTabCtrl, mainTabIndex);
                    mainTabCtrl.SelectedIndex = mainTabIndex;
                    ptamTabCtrl.SelectedIndex = ptamTabIndex;
                    specialTestsTabCtrl.SelectedIndex = specTabIndex;
                    ChangeWidthAndRefresh();
                    // Send to the printer.
                    printDlg.PrintDocument(document.DocumentPaginator, "AudiologicProfile.pdf");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SwitchTab(TabControl tabCtrl, int tabIndex)
        {
            tabCtrl.SelectedIndex = tabIndex;
            tabCtrl.SelectedItem = tabCtrl.Items[tabIndex];
            tabCtrl.Measure(mainTabCtrl.RenderSize);
            tabCtrl.Arrange(new Rect(mainTabCtrl.RenderSize));
            tabCtrl.UpdateLayout();
        }

        private void ChangeWidthAndRefresh()
        {
            var old_Width = this.Width;
            this.Width = old_Width - 1;
            this.Refresh();
            this.Width = old_Width;
            this.Refresh();
        }

        private void ExitApplication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CloseApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion
    }
}
