using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.CORE
{

    /// <summary>
    /// The View Model for the register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService = new AuthService();

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }


        /// <summary>
        /// The command to register for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The username of user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Indicating flag if the register is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public RegisterViewModel()
        {


            // Create commands
            RegisterCommand = new RelayParamatrizedCommand(async (parameter) => await RegisterAsync(parameter, RegisterIsRunning));
       
            
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }
        #endregion


        /// <summary>
        /// Attemps to register a new user
        /// </summary>
        /// <param name="parameter"> The <see cref="SecureString" passed in from the view for the users password/></param>
        /// <param name="registeIsRunning"></param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter, bool registeIsRunning)
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Send Message",
                    Message = "Thanks",
                    OkText = "Ok"
                });

            });
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        private async Task LoginAsync()
        {

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            await Task.Delay(1);

        }
    }
}
