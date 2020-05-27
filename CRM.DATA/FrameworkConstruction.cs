using CRM.CORE;
using CRM.HelperLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.DATA
{
    /// <summary>
    /// Extensions for <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction UseClientDataStore(this FrameworkConstruction construction)
        {
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                string connectionString = construction.Configuration.GetConnectionString("ClientDataStoreConnection");
                options.UseSqlite(connectionString);
            });

            construction.Services.AddScoped<IClientDataStore>(
                provider => new ClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            return construction;
        }
    }
}
