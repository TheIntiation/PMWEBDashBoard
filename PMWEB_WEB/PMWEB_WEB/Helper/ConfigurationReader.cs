using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PMWEB_WEB.Helper
{
    public static class ConfigurationReader
    {

        public static string GetServiceLayerBaseAddress()
        {
            return ReadItemFromAppSettings("ServiceLayerBaseAddress");
        }
        private static string ReadItemFromAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}