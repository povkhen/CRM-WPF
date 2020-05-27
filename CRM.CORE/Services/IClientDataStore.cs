using System.Threading.Tasks;

namespace CRM.CORE
{
    /// <summary>
    /// Store and retrieves information about the client application
    /// as login credentials
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// If the current user had logged in credentials
        /// </summary>
        Task<bool> HasCredentialsAsync();

        /// <summary>
        /// Make sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complite</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets the stored login credentials for this client 
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        Task<LoginCredentialsDataModel> GetLoginCredentialsAsync();


        /// <summary>
        /// Store the given login credentials to the backing data store
        /// </summary>
        /// <param name="loginCredentialsDataModel">The login credentials to save</param>
        /// <returns>The task that will finish once the save is complete</returns>
        Task StoreLoginCredentialsAsync(LoginCredentialsDataModel loginCredentialsDataModel);
    }
}
