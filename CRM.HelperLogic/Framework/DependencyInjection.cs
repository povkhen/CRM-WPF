using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.HelperLogic
{

    public static class FrameworkDI
    {
        /// <summary>
        /// Gets the configuration
        /// </summary>
        public static IConfiguration Configuration => Framework.Provider?.GetService<IConfiguration>();


        /// <summary>
        /// Gets the framework environment
        /// </summary>
        public static IFrameworkEnvironment FrameworkEnvironment => Framework.Provider?.GetService<IFrameworkEnvironment>();

    }
}
