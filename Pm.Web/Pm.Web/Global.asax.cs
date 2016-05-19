using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private const string HttpContextKey = "MefContainerKey";

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 插件配置
            var pluginPath = Server.MapPath("~/Plugin");
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            var pluginDirectories = Directory.GetDirectories(pluginPath, "Pm*", SearchOption.AllDirectories);
            var direCatalogs = pluginDirectories.Select(m => new DirectoryCatalog(m)).ToList();
            direCatalogs.ForEach(catalog.Catalogs.Add);

            var container = new CompositionContainer(catalog);
            HttpContext.Current.Application["Container"] = container;

            // 保存 DirectoryCatalog 为了后面刷新插件用
            HttpContext.Current.Application["DirectoryCatalogs"] = direCatalogs;
            
            // 添加路由插件注册
            var rotes = container.GetExports<IRouteConfig>();
            foreach (var item in rotes) {
                item.Value.RegisterRoutes(RouteTable.Routes);
            }

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new PluginViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
