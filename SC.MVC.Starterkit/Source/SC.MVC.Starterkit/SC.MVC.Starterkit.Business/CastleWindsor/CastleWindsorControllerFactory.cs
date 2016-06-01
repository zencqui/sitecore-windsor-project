using Castle.MicroKernel;
using Castle.Windsor;
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
            return base.CreateController(requestContext, controllerName);
        }
    }
}
