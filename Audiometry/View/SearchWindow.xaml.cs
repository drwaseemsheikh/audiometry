using System;
using System.Windows;
using Audiometry.ViewModel.SearchVM;

namespace Audiometry.View
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindowVM SearchVM { get; private set; }

        public SearchWindow()
        {
            try
            {
                InitializeComponent();

                SearchVM = new SearchWindowVM();
                DataContext = SearchVM;

                if (SearchVM.CloseAction == null)
                {
                    SearchVM.CloseAction = new Action(this.Close);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                throw ex;
            }
        }
    }
}
