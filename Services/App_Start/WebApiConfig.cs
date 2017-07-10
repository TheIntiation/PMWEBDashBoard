using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Services
{

    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Enable Cros
            config.EnableCors();
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //xml.UseXmlSerializer = true;

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "DefaultApi",routeTemplate: "api/{controller}/{id}",defaults: new { id = RouteParameter.Optional });
        
        }

    }

}
