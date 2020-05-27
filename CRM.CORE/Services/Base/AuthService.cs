using CRM.HelperLogic;
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
        public async Task LoginAsync(object parameter, bool loginIsRunning)
        {
            await Task.Run( async () =>
            {
                 var result = await WebRequests.PostAsync<LoginResultApiModel>
                 (
                    "http://localhost:5000/api/auth/login",
                     new LoginCredentials 
                     { 
                         UserName = "admin",
                         Password = "password" 
                     });

                if (result == null || result.ServerResponse == null)
                {
                    var message = "Unknown error from server call"; 
                    
                    if (result?.ServerResponse != null)
                        message = result.ErrorMessage;
                    
                    else if (!string.IsNullOrWhiteSpace(result?.RawServerResponse))
                        message = $"Unexpected response from server. {result.RawServerResponse}";        

                    else if (result != null)
                        message = $"Failed to communicate with server. Status code {result.StatusCode}. {result.StatusDescription}";


                    // TODO: Show message on UI
                    return;
                }

               
            });
        }
    }
}
