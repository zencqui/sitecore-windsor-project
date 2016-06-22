using SC.MVC.Starterkit.Business.Services;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SC.MVC.Starterkit.Mvc.Areas.SCMVC.Controllers
{
    public class SampleController : SitecoreController
    {
        private readonly ISettingsWrapper settings;

        public SampleController(ISettingsWrapper settings)
        {
            this.settings = settings;
        }

        public ActionResult SampleAction()
        {
            var value = this.settings.GetSetting("settingName");

            return View("~/Areas/SCMVC/Views/sampleview.cshtml");
        }

    }
}
