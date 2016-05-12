using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using Pm.Plugin.Core;

namespace Pm.Web.Controllers {
    public class HomeController : ControllersBase {
        [ImportMany]
        private IEnumerable<IIndexBlock> _indexBlock = null;

        public ActionResult Index() {
            var model = new Models.Home.IndexViewModel {
                Blocks = _indexBlock.Select(m => new Models.Home.IndexBlock() {
                    Text = m.GetText(),
                    Title = m.GetTitle(),
                    Link = m.GetLink()
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