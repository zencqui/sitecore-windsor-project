using Castle.MicroKernel;
using Castle.Windsor;
using Sitecore.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public CastleWindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (!TypeHelper.LooksLikeTypeName(controllerName))
            {
                return null;
            }

            var controllerType = Type.GetType(controllerName);
            if (!Type.ReferenceEquals(controllerType, null))
            {
                return this.GetControllerInstance(requestContext, controllerType);
            }

            return base.CreateController(requestContext, controllerName);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (Type.ReferenceEquals(controllerType, null))
            {
                return null;
            }

            return this.container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            this.container.Release(controller);
        }
    }
}
