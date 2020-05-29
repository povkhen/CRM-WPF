using System.Threading.Tasks;

namespace CRM.CORE
{
    /// <summary>
    /// The design-time data for a <see cref="WelcomeUserViewModel"/>
    /// </summary>
    public class WelcomeDesignModel : WelcomeUserViewModel
    {
        #region Singlton

        /// <summary>
        /// A single instance of the dising model
        /// </summary>
        public static WelcomeDesignModel Instance => IoC.Mapper.Map<WelcomeDesignModel>(GetLoginCredential());

        
        private static LoginCredentialsDataModel GetLoginCredential()
        {
            return IoC.ClientDataStore.GetLoginCredentialsAsync().Result;
        }
        #endregion


    }
}
