using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using SC.MVC.Starterkit.Business.Models;
using SC.MVC.Starterkit.Business.Services;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SC.MVC.Starterkit.Mvc.Areas.SCMVC.Controllers
{
    public class SampleController : GlassController
    {
        private readonly ISettingsWrapper settings;

        public SampleController(
            ISettingsWrapper settings,
            ISitecoreContext sitecoreContext,
            IGlassHtml glassHtml)
            : base(sitecoreContext, glassHtml)
        {
            this.settings = settings;
        }

        public ActionResult SampleAction()
        {
            var item = this.SitecoreContext.GetCurrentItem<IGlassBase>();

            var value = this.settings.GetSetting("settingName");

            return View("~/Areas/SCMVC/Views/sampleview.cshtml");
        }

    }
}
