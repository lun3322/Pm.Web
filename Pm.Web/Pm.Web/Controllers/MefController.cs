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
            HttpRuntime.UnloadAppDomain();
            System.IO.File.SetLastWriteTimeUtc(Server.MapPath("~/web.config"), DateTime.UtcNow);
            System.IO.File.SetLastWriteTimeUtc(Server.MapPath("~/global.asax"), DateTime.UtcNow);

            return Redirect("/");
        }
    }
}