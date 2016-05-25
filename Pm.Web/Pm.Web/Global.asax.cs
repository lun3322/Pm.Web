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
using NLog;
using NLog.Config;
using Pm.Plugin.Core;

namespace Pm.Web {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LogManager.Configuration = new XmlLoggingConfiguration(Server.MapPath("~/NLog.config"));
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("程序启动.");
            
            // 插件配置
            var pluginPath = Server.MapPath("~/Plugin");
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            var pluginDirectories = Directory.GetDirectories(pluginPath, "Pm*", SearchOption.AllDirectories);
            var direCatalogs = pluginDirectories.Select(m => new DirectoryCatalog(m)).ToList();
            direCatalogs.ForEach(catalog.Catalogs.Add);

            var soler = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(soler);

            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            
            // 保存 DirectoryCatalog 为了后面刷新插件用
            HttpContext.Current.Application["DirectoryCatalogs"] = direCatalogs;
            
            // 添加路由插件注册
            var rotes = DependencyResolver.Current.GetServices<IRouteConfig>();
            foreach (var item in rotes) {
                item.RegisterRoutes(RouteTable.Routes);
            }

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new PluginViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
