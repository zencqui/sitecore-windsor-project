using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Installers;
using Sitecore.Mvc.Controllers;
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

            // Register Installers
            RegisterInstallers();

            Sitecore.Mvc.Configuration.MvcSettings.RegisterObject<ControllerLocator>(() => new WindsorControllerLocator());
        }

        public void InitializeCastleWindsor()
        {
            var windsorControllerFactory = new CastleWindsorControllerFactory(this.container);
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
        }

        private void RegisterInstallers()
        {
            container.Install(new AutoInstaller());
        }
    }
}