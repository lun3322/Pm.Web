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

            // 插件配置
            var pluginPath = Server.MapPath("~/Plugin");
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var direCatalog = new DirectoryCatalog(pluginPath);
            catalog.Catalogs.Add(direCatalog);
            var soler = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(soler);

            // 保存 DirectoryCatalog 为了后面刷新插件用
            HttpContext.Current.Application["DirectoryCatalog"] = direCatalog;

            // 添加路由插件注册
            var rotes = soler.Container.GetExports<IRouteConfig>();
            foreach (var item in rotes) {
                item.Value.RegisterRoutes(RouteTable.Routes);
            }

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new PluginViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
