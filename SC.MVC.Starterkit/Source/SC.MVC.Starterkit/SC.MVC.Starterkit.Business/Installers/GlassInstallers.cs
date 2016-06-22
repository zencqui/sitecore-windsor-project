using Castle.MicroKernel.Registration;
using Glass.Mapper.Sc;
using SC.MVC.Starterkit.Business.CastleWindsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Installers
{
    [AutoInstall]
    public class GlassInstallers : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<ISitecoreContext, ISitecoreService>()
                .ImplementedBy<SitecoreContext>()
                .LifestyleTransient());

            container.Register(
                Component.For<IGlassHtml>()
                .ImplementedBy<GlassHtml>()
                .LifestyleTransient());
        }
    }
}
