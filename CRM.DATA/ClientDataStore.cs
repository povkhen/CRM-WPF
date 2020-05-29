using CRM.CORE;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DATA
{
    /// <summary>
    /// Stores and retrives information about the client application 
    /// such as login credentials
    /// </summary>
    public class ClientDataStore : IClientDataStore
    {
        private readonly ClientDataStoreDbContext _dbContext;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// If the current user had logged in credentials
        /// </summary>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
            
        }

       
        /// <summary>
        /// Make sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complite</returns>
        public async Task EnsureDataStoreAsync()
        {
            await _dbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored login credentials for this client 
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {

            return Task.FromResult(_dbContext.LoginCredentials.FirstOrDefault());   

        }



        /// <summary>
        /// Store the given login credentials to the backing data store
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task StoreLoginCredentialsAsync(LoginCredentialsDataModel loginCredentialsDataModel)
        {
            _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);
            _dbContext.LoginCredentials.Add(loginCredentialsDataModel);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all login credentials stored in the data store
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllLoginCredentialsAsync()
        {
            _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);
            await _dbContext.SaveChangesAsync();
        }
    }
}
