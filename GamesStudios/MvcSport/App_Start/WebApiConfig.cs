﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace GamesStudios
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
          
            // TODO: Add any additional configuration code.

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}