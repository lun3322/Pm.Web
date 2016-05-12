using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Routing;

namespace Pm.Web.Controllers {
    public class ControllersBase : Controller {
        protected CompositionContainer Container { get; set; }

        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);
            Container = HttpContext.Application["Container"] as CompositionContainer;
            Container?.ComposeParts(this);
        }
    }
}