using Microsoft.Extensions.DependencyInjection;
using System;
using static CRM.HelperLogic.FrameworkDI;

namespace CRM.HelperLogic
{

    public static class Framework
    {
        #region Public Properties

        public static FrameworkConstruction Construction { get; private set; }

        /// <summary>
        /// The dependency injection service provider
        /// </summary>
        public static IServiceProvider Provider => Construction?.Provider;

        #endregion

        #region Extension Methods

        /// <summary>
        /// Should be called once a Framework Construction is finished and we want to build it and
        /// start our application
        /// </summary>
        /// <param name="construction">The construction</param>
 
        public static void Build(this FrameworkConstruction construction)
        {
            // Build the service provider
            construction.Build();

        }

    
        public static void Build(IServiceProvider provider)
        {
            // Build the service provider
            Construction.Build(provider);

        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T">The type of construction to use</typeparam>
        public static FrameworkConstruction Construct<T>()
            where T : FrameworkConstruction, new()
        {
            Construction = new T();

            // Return construction for chaining
            return Construction;
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="T">The type of construction to use</typeparam>
        /// <param name="constructionInstance">The instance of the construction to use</param>
        public static FrameworkConstruction Construct<T>(T constructionInstance)
            where T : FrameworkConstruction
        {
            // Set construction
            Construction = constructionInstance;

            // Return construction for chaining
            return Construction;
        }

        /// <summary>
        /// Shortcut to Framework.Provider.GetService to get an injected service of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of service to get</typeparam>
        /// <returns></returns>
        public static T Service<T>()
        {
            // Use provider to get the service
            return Provider.GetService<T>();
        }

        #endregion
    }
}
