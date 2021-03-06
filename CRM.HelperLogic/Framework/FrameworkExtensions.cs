﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace CRM.HelperLogic
{
    /// <summary>
    /// Extension methods 
    /// </summary>
    public static class FrameworkExtensions
    {
        #region Configuration

        /// <summary>
        /// Configures a framework construction in the default way
        /// </summary>
        /// <param name="construction">The construction to configure</param>
        /// <param name="configure">The custom configuration action</param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultConfiguration(this FrameworkConstruction construction, Action<IConfigurationBuilder> configure = null)
        {
            // Create our configuration sources
            var configurationBuilder = new ConfigurationBuilder()
                // Add environment variables
                .AddEnvironmentVariables();

            // If we are not on a mobile platform...
            if (!construction.Environment.IsMobile)
            {
                // Add file based configuration

                // Set base path for Json files as the startup location of the application
                configurationBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                // Add application settings json files
                configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddJsonFile($"appsettings.{construction.Environment.Configuration}.json", optional: true, reloadOnChange: true);
            }

            // Let custom configuration happen
            configure?.Invoke(configurationBuilder);

            // Inject configuration into services
            var configuration = configurationBuilder.Build();
            construction.Services.AddSingleton<IConfiguration>(configuration);

            // Set the construction Configuration
            construction.UseConfiguration(configuration);

            // Chain the construction
            return construction;
        }

        /// <summary>
        /// Configures a framework construction using the provided configuration
        /// </summary>
        /// <param name="construction">The construction to configure</param>
        /// <param name="configure">The configuration</param>
        /// <returns></returns>
        public static FrameworkConstruction AddConfiguration(this FrameworkConstruction construction, IConfiguration configuration)
        {
            // Add specific configuration
            construction.UseConfiguration(configuration);

            // Add configuration to services
            construction.Services.AddSingleton(configuration);

            // Chain the construction
            return construction;
        }

        #endregion

        /// <summary>
        /// Injects all of the default services 
        /// </summary>
        /// <param name="construction">The construction</param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultServices(this FrameworkConstruction construction)
        {

            

            // Chain the construction
            return construction;
        }

    }
}
