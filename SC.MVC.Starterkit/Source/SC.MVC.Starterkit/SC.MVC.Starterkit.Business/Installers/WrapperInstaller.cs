using Castle.MicroKernel.Registration;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Wrappers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Installers
{
    [AutoInstall]
    public class WrapperInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<RenderingContextWrapperBase>()
                .UsingFactoryMethod(() => new RenderingContextWrapper(RenderingContext.Current))
                .LifestyleTransient());

            container.Register(
                Component.For<RenderingWrapperBase>()
                .ImplementedBy<RenderingWrapper>()
                .LifestyleTransient());
        }
    }
}
