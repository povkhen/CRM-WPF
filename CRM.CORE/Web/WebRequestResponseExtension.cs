using CRM.HelperLogic;
using System.Threading.Tasks;

namespace CRM.CORE
{
    /// <summary>
    /// Extension methods for <see cref="WebRequestResult{T}"/> class
    /// </summary>
    public static class WebRequestResponseExtension
    {
        /// <summary>
        /// Cheks the web requsts for any errors, displaying them if there are any
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns>Return true if there was an error</returns>
        public static async Task<bool> DisplayErrorIfFailedAsync<T>(this WebRequestResult<T> result, string title)
        {
            if (result == null || result.ServerResponse == null || !result.Successfull)
            {
                var message = "Unknown error from server call";

                if (result.ServerResponse != null)
                    message = result.ErrorMessage;

                else if (!string.IsNullOrWhiteSpace(result?.RawServerResponse))
                    message = $"Unexpected response from server. {result.RawServerResponse}";

                else if (result != null)
                    message = $"Failed to communicate with server. Status code {result.StatusCode}. {result.StatusDescription}";


                await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = title,
                    Message = message
                });
                return true;
            }
            return false; 
        }
    }
}
