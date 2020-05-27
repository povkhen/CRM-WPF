using CRM.CORE;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CRM.WPF
{
    /// <summary>
    /// A base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private members

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion


        #region Public Properties

        /// <summary>
        /// Minimum widht of this dialog
        /// </summary>
        public int WindowMinimumWidht { get; set; } = 250;


        /// <summary>
        /// Minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; }

        /// <summary>
        /// The title for this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion



        #region Contsructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            mDialogWindow = new DialogWindow();
            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);
            
        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// Dispays a single messagebox to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel) where T: BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidht;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = viewModel.Title ?? Title;

                    mDialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    mDialogWindow.ShowDialog();

                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
           
        }
        #endregion

    }
}
