using CRM.CORE;

namespace CRM.WPF
{
    /// <summary>
    /// Locates view model from the IoC for use binding in Xaml Files
    /// </summary>
    public  class ViewModelLocator
    {

        /// <summary>
        /// Singleton instance of the locator 
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();  

        /// <summary>
        /// The Application view model
        /// </summary>
        public ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

    }
}
