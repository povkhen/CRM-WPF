using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM.CORE
{
    /// <summary>
    /// A view model for user after login
    /// </summary>
    public class WelcomeUserViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; set; }

        public ICommand LoadCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public WelcomeUserViewModel()
        {
            LogoutCommand = new RelayCommand(async () => await IoC.Auth.LogoutAsync());
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            ClearCommand = new RelayCommand(() => ClearUserData());
        }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

       

        /// <summary>
        /// Clears any data specific to the current user
        /// </summary>
        public void ClearUserData()
        {
            // Clear all view models containing the users info
            UserName = null;
            FullName = null;
            Email = null;
            Phone = null;
        }

        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {
            await UpdateValuesFromLocalStoreAsync();
     
        }

        private async Task UpdateValuesFromLocalStoreAsync()
        {
            var storedCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();
            UserName = storedCredentials.UserName;
            FullName = storedCredentials.FullName;
            Email = storedCredentials.Email;
            Phone = storedCredentials.Phone;


        }
    }
}
