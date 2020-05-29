using System;

namespace CRM.CORE
{
    /// <summary>
    /// The credentials for an API client to register into the server
    /// </summary>
    public class RegisterCredentials
    {

        #region Public Properties
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastActive { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        
        #endregion

    }
}
