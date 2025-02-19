using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Automation.Utilities
{
    public class ConfigReader
    {
        private readonly IConfiguration _configuration;

        public ConfigReader()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public string GetSetting(string key)
        {
            key = key.Replace(" ", "").Trim();
            var value = _configuration[key];

            if (value == null)
            {
                throw new ArgumentException($"Configuration key '{key}' not found.");
            }

            return value;
        }
        public int GetTimeoutSetting(string key)
        {
            key = key.Replace(" ", "");
            int.TryParse(_configuration[key], out int timeout);
            return timeout;
        }

        public string GetEnvironmentSetting(string settingName)
        {
            var environment = GetSetting("ApplicationSettings:Environment");
            var key = $"ApplicationSettings:{environment}:{settingName}";
            return GetSetting(key);
        }
    }
}