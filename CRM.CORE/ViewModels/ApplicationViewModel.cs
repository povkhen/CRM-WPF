using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.CORE
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class  ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The currant page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// Navigate to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
        }
    }
}
