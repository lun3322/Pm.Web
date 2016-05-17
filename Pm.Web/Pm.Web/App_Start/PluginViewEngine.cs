using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pm.Web {
    public class PluginViewEngine : RazorViewEngine {
        public PluginViewEngine()
            : this((IViewPageActivator)null) {
        }

        public PluginViewEngine(IViewPageActivator viewPageActivator)
            : base(viewPageActivator) {
            this.AreaViewLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            this.AreaMasterLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };
            this.AreaPartialViewLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };
            this.ViewLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            this.MasterLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            this.PartialViewLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            this.FileExtensions = new [] {
                "cshtml",
            };
        }
    }
}