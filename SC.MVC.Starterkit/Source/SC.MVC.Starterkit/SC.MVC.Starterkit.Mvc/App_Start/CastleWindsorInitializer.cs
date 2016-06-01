using Castle.Windsor;
using SC.MVC.Starterkit.Business.CastleWindsor;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SC.MVC.Starterkit.Mvc.App_Start
{
    public class CastleWindsorInitializer
    {
        private IWindsorContainer container;

        public void Process(PipelineArgs args)
        {
            this.container = new Castle.Windsor.WindsorContainer();
            
        }

        public void InitializeCastleWindsor()
        {
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(new CastleWindsorControllerFactory(this.container));
        }
    }
}