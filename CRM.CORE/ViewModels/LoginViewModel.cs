﻿using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.CORE
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
            LoginCommand = new RelayParamatrizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }
        #endregion

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <param name="parameter"> The <see cref="SecureString" passed in from the view for the users password/></param>
        /// <returns></returns>
        private async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await IoC.Auth.LoginAsync(
                    new LoginCredentials
                    {
                        UserName = this.Username,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    },
                    LoginIsRunning);
                
                if (await IoC.ClientDataStore.HasCredentialsAsync())
                    IoC.Application.GoToPage(ApplicationPage.Home);


            });
        }


        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <param name="parameter"> The <see cref="SecureString" passed in from the view for the users password/></param>
        /// <returns></returns>
        private async Task RegisterAsync()
        {

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register); 
            await Task.Delay(1);
        }
    }
}
