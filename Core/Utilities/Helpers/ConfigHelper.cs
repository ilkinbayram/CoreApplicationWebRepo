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
        public T GetSettingsData<T>(string parentKey, string childKey)
        {
            return (T)Convert.ChangeType(_configuration.GetSection(parentKey)[childKey], typeof(T));
        }

        public static T GetSettingsDataStatic<T>(string parentKey, string childKey)
        {
            return (T)Convert.ChangeType(_staticConfiguration.GetSection(parentKey)[childKey], typeof(T));
        }
    }
}
