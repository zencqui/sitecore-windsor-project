using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using SC.MVC.Starterkit.Business.Models;
using SC.MVC.Starterkit.Business.Services;
using SC.MVC.Starterkit.Business.Wrappers;
using SC.MVC.Starterkit.Mvc.Areas.SCMVC.ViewModels;
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

        private readonly RenderingContextWrapperBase renderingContext;

        public SampleController(
            ISettingsWrapper settings,
            RenderingContextWrapperBase renderingContext,
            ISitecoreContext sitecoreContext,
            IGlassHtml glassHtml)
            : base(sitecoreContext, glassHtml)
        {
            this.settings = settings;
            this.renderingContext = renderingContext;
        }

        public ActionResult SampleAction()
        {
            var item = this.SitecoreContext.GetCurrentItem<IGlassBase>();

            ICoinCopyright copyright = this.SitecoreContext.GetItem<ICoinCopyright>(this.renderingContext.Rendering.Datasource, true, true);
            CopyrightViewModel model = new CopyrightViewModel();
            model.CopyrightText = copyright.CopyrightText;

            var value = this.settings.GetSetting("settingName");

            return View("~/Areas/SCMVC/Views/sampleview.cshtml", model);
        }

    }
}
