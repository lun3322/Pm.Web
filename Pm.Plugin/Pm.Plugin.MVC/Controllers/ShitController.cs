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
        public void Index() {
            Response.Write("<h1>测试注入!</h1>");
        }
    }
}
