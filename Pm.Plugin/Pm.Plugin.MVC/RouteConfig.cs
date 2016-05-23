using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Pm.Plugin.Core;

namespace Pm.Plugin.MVC {
    [Export(typeof(IRouteConfig))]
    public class RouteConfig : IRouteConfig {
        public void RegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                name: "Pm.Plugin.MVC.RouteConfig",
                url: "Shit/Index",
                defaults: new { controller = "Shit", action = "Index" }
                );
        }
    }
}
