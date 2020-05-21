using CRM.Core;
using CRM.CORE;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.WPF
{

    /// <summary>
    /// The View Model for the login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The username of user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Indicating flag if the logging is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {

            // Create commands
            LoginCommand = new RelayParamatrizedCommand(async (parameter) => await Login(parameter));


        }
        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter"> The <see cref="SecureString" passed in from the view for the users password/></param>
        /// <returns></returns>
        private async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            { 
                await Task.Delay(500);
                var username = this.Username;    
            });
            
        }
    }
}
