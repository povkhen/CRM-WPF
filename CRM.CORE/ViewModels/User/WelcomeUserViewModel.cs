namespace CRM.CORE
{
    /// <summary>
    /// A view model for user after login
    /// </summary>
    public class WelcomeUserViewModel : BaseViewModel
    {
        /// <summary>
        /// The display username
        /// </summary>
        public string Username { get; set; }


        /// <summary>
        /// The display fullname
        /// </summary>
        public string FullName { get; set; }


        /// <summary>
        /// The display email
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// The display phone
        /// </summary>
        public string Phone { get; set; }
    }
}
