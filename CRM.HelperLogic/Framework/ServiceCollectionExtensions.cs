using Microsoft.Extensions.DependencyInjection;

namespace CRM.HelperLogic
{
    /// <summary>
    /// Extension methods for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        
        public static FrameworkConstruction AddFramework(this IServiceCollection services)
        {
            // Add the services 
            Framework.Construction.UseHostedServices(services);

            // Return construction for chaining
            return Framework.Construction;
        }
    }
}
