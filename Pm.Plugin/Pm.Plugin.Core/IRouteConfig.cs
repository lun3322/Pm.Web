using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Pm.Plugin.Core {
    public interface IRouteConfig {
        void RegisterRoutes(RouteCollection routes);
    }
}
