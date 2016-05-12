using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Pm.Plugin.Core;

namespace Pm.Plugin.Nav {
    [Export(typeof(IRouteConfig))]
    public class RouteConfig : IRouteConfig {
        public void RegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                name: "Pm.Plugin.Nav",
                url: "nav/about",
                defaults: new {controller = "Home", action = "About"}
                );
        }
    }
}
