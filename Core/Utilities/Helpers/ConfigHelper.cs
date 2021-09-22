using Core.Utilities.Helpers.Abstracts;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Utilities.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        private IConfiguration _configuration;
        private static IConfiguration _staticConfiguration;
        public ConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _staticConfiguration = configuration;
        }
        public T GetSettingsData<T>(string key, string parentProvider)
        {
            return (T)Convert.ChangeType(_configuration.GetSection(parentProvider)[key], typeof(T));
        }

        public static T GetSettingsDataStatic<T>(string key, string parentProvider)
        {
            return (T)Convert.ChangeType(_staticConfiguration.GetSection(parentProvider)[key], typeof(T));
        }
    }
}
