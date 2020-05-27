using CRM.CORE;
using System.Windows;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {

        /// <summary>
        /// The view model for this window
        /// </summary>
        private DialogWindowViewModel mViewModel;


        /// <summary>
        /// The view model for this window
        /// </summary>
        public DialogWindowViewModel ViewModel 
        {
            get => mViewModel;
            set 
            {
                mViewModel = value;
                DataContext = mViewModel;
            }

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
