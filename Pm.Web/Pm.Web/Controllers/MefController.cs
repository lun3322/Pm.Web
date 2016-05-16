using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pm.Web.Controllers
{
    public class MefController : ControllersBase
    {
        public RedirectResult RefreshMef() {
            Catalog.Refresh();

            return Redirect("/");
        }
    }
}