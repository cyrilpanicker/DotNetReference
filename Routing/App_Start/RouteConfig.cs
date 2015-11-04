using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Routing.App_Start {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Index.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Index.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Index.aspx");
        }
    }
}