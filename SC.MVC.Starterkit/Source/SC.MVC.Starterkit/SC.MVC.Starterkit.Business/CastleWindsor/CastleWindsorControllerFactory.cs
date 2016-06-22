using Castle.MicroKernel;
using Castle.Windsor;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public CastleWindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (!TypeHelper.LooksLikeTypeName(controllerName))
            {
                return base.CreateController(requestContext, controllerName);
            }

            var controllerType = Type.GetType(controllerName);

            if (controllerType == null)
            {
                Log.Error(string.Format(CultureInfo.InvariantCulture,
                    "Controller '{0}' not foud. - Reqiest URL: {1}",
                    controllerName, requestContext.HttpContext.Request.Url), this);

                return null;
            }

            return this.GetControllerInstance(requestContext, controllerType);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (Type.ReferenceEquals(controllerType, null))
            {
                return null;
            }

            if (this.kernel.HasComponent(controllerType))
            {
                return this.kernel.Resolve(controllerType) as IController;
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            this.kernel.ReleaseComponent(controller);
        }
    }
}
