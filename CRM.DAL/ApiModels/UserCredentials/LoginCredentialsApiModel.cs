﻿namespace CRM.DAL
{
    /// <summary>
    /// The credentials for an API client to log into the server and receive a token back
    /// </summary>
    class LoginCredentialsApiModel
    {

        #region Public Properties
        /// <summary>
        /// The users username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

    }
}
