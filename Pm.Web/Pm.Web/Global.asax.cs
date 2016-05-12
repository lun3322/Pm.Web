using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Pm.Plugin.Core;

namespace Pm.Web {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var pluginPath = Server.MapPath("~/Plugin");
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(pluginPath));
            var soler = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(soler);

            var rotes = soler.Container.GetExports<IRouteConfig>();
            foreach (var item in rotes) {
                item.Value.RegisterRoutes(RouteTable.Routes);
            }

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
