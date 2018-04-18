using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MultiLangProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LangDefault",
                url: "{lang}/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { lang = "fr-fr|es-es|en-us" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", lang = "en-us" }
            );
        }
    }
}
