using CRM.CORE;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CRM.WPF
{

    /// <summary>
    /// The View Model for the dialog window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// Tht title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to host insede the dialog
        /// </summary>
        public Control Content { get; set; } 

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window)
        {
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            TitleHeight = 30;
        }

        #endregion
    }
}
