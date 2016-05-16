using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Pm.Plugin.Core;

namespace Pm.Web.Controllers {
    public class HomeController : ControllersBase {
        public ActionResult Index() {
            var exports = Container.GetExports<IIndexBlock>();

            var model = new Models.Home.IndexViewModel {
                Blocks = exports.Select(m => new Models.Home.IndexBlock() {
                    Text = m.Value.GetText(),
                    Title = m.Value.GetTitle(),
                    Link = m.Value.GetLink()
                })
            };
            
            return View(model);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}