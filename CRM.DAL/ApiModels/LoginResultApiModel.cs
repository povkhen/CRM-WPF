namespace CRM.DAL
{
    /// <summary>
    /// The result of a successfull login request via API
    /// </summary>
    class LoginResultApiModel
    {
        #region Public Properties

        /// <summary>
        /// The authentication token used to stay authenticated throught future requests
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The user for list info
        /// </summary>
        public string UserForListCred { get; set; }

        #endregion

    }
}
