using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Glass.Mapper;
using Glass.Mapper.Configuration;
using Glass.Mapper.Configuration.Attributes;
using Glass.Mapper.Sc.CastleWindsor;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Installers;
using SC.MVC.Starterkit.Business.Utilities;
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
        public void Process(PipelineArgs args)
        {
            var resolver = DependencyResolver.CreateStandardResolver();
            Resolver.Container = resolver.Container;

            InitializeCastleWindsor(resolver.Container);
            // Register Installers
            RegisterInstallers(resolver.Container);

            Sitecore.Mvc.Configuration.MvcSettings.RegisterObject<ControllerLocator>(() => new WindsorControllerLocator());

            //Load Glass
            Context context = Context.Create(resolver);
            context.Load(GlassLoader());
        }

        public static void InitializeCastleWindsor(IWindsorContainer container)
        {
            var windsorControllerFactory = new CastleWindsorControllerFactory(container.Kernel);
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
        }

        private static void RegisterInstallers(IWindsorContainer container)
        {
            var config = new Config();
            container.Install(new AutoInstaller(), new SitecoreInstaller(config));
        }

        private static IConfigurationLoader[] GlassLoader()
        {
            IConfigurationLoader attributes =
                new AttributeConfigurationLoader(AssemblyUtility.RelatedAssemblies.ToArray());

            return new IConfigurationLoader[] { attributes };
        }
    }
}