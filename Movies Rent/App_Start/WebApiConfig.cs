using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Movies_Rent
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
         var settring= config.Formatters.JsonFormatter.SerializerSettings;
            settring.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settring.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
