using CRM.CORE;
using Microsoft.EntityFrameworkCore;


namespace CRM.DATA
{
    /// <summary>
    /// The database context for the client data store
    /// using Entity Framework
    /// </summary>
    public class ClientDataStoreDbContext : DbContext
    {

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; } 

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fluent api

            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(a => a.Id);

        }


    }
}
