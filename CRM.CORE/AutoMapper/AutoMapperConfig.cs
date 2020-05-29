using AutoMapper;
using CRM.CORE;
using CRM.HelperLogic;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.DATA
{
    /// <summary>
    /// Stores MapperConfiguration
    /// </summary>
    public static class AutoMapperConfig
    {
        
        public static MapperConfiguration CreateConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserForListApiModel, LoginCredentialsDataModel>();
                cfg.CreateMap<LoginCredentialsDataModel, WelcomeDesignModel>();

            });
            return configuration;
        }
    }
}
