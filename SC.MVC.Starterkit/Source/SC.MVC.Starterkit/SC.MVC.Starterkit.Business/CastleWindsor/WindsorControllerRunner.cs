using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorControllerRunner : ControllerRunner
    {
        public WindsorControllerRunner(string controllerName, string actionName)
            : base(controllerName, actionName)
        {
            this.NeedRelease = true; 
        }

        protected override System.Web.Mvc.IController CreateController()
        {
            if (!TypeHelper.LooksLikeTypeName(this.ControllerName))
            {
                return base.CreateController();
            }

            return System.Web.Mvc.ControllerBuilder.Current.GetControllerFactory()
                .CreateController(PageContext.Current.RequestContext, this.ControllerName);
        }
    }
}
