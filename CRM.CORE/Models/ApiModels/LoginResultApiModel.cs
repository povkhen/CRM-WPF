namespace CRM.CORE
{
    /// <summary>
    /// The result of a successfull login request via API
    /// </summary>
    public class LoginResultApiModel
    {
        /// <summary>
        /// The authentication token used to stay authenticated throught future requests
        /// </summary>
        public string Token { get; set; }

        public UserForListApiModel User { get; set; }
    }
}
