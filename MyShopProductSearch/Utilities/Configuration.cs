using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopProductSearch.Utilities
{
    public static class Configuration
    {
        private static IConfigurationRoot _configuration;

        static Configuration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        public static string Get(string key)
        {
           return _configuration[key];
        }

    }
}
