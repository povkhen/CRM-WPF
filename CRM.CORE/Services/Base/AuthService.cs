using CRM.HelperLogic;
using System;
using System.Threading.Tasks;

namespace CRM.CORE
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(LoginCredentials loginFields, bool loginIsRunning)
        {
            await Task.Run(async () =>
            {
                var result = await WebRequests.PostAsync<LoginResultApiModel>
                 (
                    "http://localhost:5000/api/auth/login",
                     loginFields
                 );

                if (await result.DisplayErrorIfFailedAsync("Login Failed"))
                    return;
             
                var userData = result.ServerResponse.User;
                var token = result.ServerResponse.Token;

                var loginCredentials = IoC.Mapper.Map<LoginCredentialsDataModel>(userData);
                loginCredentials.Token = token;


                await IoC.ClientDataStore.StoreLoginCredentialsAsync(loginCredentials);

            });
        }



        /// <summary>
        /// Attempts to register the user in
        /// </summary>
      
        public async Task RegisterAsync(RegisterCredentials registerCredentials, bool registerIsRunning)
        {
            await Task.Run(async () =>
           {
               var result = await WebRequests.PostAsync<UserDetailedApiModel>
                (
                   "http://localhost:5000/api/auth/register",
                    registerCredentials
                );

                
               if (await result.DisplayErrorIfFailedAsync("Register Failed"))
                   return;
                               

           });
        }

        /// <summary>
        /// Logs the user out
        /// </summary>
        public async Task LogoutAsync()
        {
            // TODO: Confirm the user wants to logout

            await IoC.ClientDataStore.ClearAllLoginCredentialsAsync();

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            // Go to login page
            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        private void ClearUserData()
        {
            
        }
    } 
}