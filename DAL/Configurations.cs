using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Configurations
    {
        public static string ConnectionString
        {
            get
            {
                return GetConnectionString();
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PMWEB_ConnectionString"].ConnectionString;
        }

        private static string GetAppConfigItem(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
