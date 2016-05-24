using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.Composition;

namespace Pm.Plugin.MVC.Controllers {
    [Export(typeof(Controller))]
    public class ShitController : Controller {
        public ViewResult Index() {
            // Response.Write("<h1>测试注入!</h1>");
            return View("~/Plugin/Pm.Plugin.MVC/Views/Shit/Index.cshtml");
        }

        public ViewResult Fuck() {

            return View("~/Plugin/Pm.Plugin.MVC/Views/Shit/Fuck.cshtml");
        }
    }
}
