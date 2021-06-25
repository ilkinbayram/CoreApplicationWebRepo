using Core.Utilities.Helpers.Abstracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        private IConfiguration _configuration;
        public ConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public T GetSettingsData<T>(string key, string parentProvider)
        {
            return (T)Convert.ChangeType(_configuration.GetSection(parentProvider)[key], typeof(T));
        }
    }
}
