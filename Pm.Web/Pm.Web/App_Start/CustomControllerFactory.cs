using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pm.Web {
    public class CustomControllerFactory : DefaultControllerFactory {
        public override IController CreateController(RequestContext requestContext, string controllerName) {
            // 这里似乎是不对的.
            // 因为controller是可以重名的.
            var controllers = DependencyResolver.Current.GetServices<Controller>();
            foreach (var contr in controllers) {
                if (contr.GetType().Name.Contains(controllerName, StringComparison.OrdinalIgnoreCase)) {
                    return contr;
                }
            }

            return base.CreateController(requestContext, controllerName);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            var controller = DependencyResolver.Current.GetService(controllerType) as IController;
            if (controller != null) {
                return controller;
            }
            return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}