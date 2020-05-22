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
        public static WelcomeDesignModel Instance => new WelcomeDesignModel();

        #endregion

        /// <summary>
        /// Default contructor
        /// </summary>
        public WelcomeDesignModel()
        {
           
            Username = "Misha";
            FullName = "Misha Povkh";
            Email = "a@a.a";
            Phone = "911";
        }

    }
}
