using System;
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

        public string Username { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

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
                await IoC.Auth.RegisterAsync
                (
                    new RegisterCredentials
                    {
                        Password = UnsecurePassword(parameter),
                        UserName = this.Username,
                        Gender = this.Gender,
                        FullName = this.FullName,
                        BirthDate = this.BirthDate,
                        City = this.City,
                        Country = this.Country,
                        Email = this.Email
                    }, 
                    registeIsRunning
                );

            });
        }

        /// <summary>
        /// Unsecure password to string
        /// </summary>
        /// <param name="pass">Secure string</param>
        /// <returns></returns>
        private string UnsecurePassword(object pass) => (pass as IHavePassword).SecurePassword.Unsecure();

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
