using Castle.MicroKernel.Registration;
using SC.MVC.Starterkit.Business.Attributes;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Installers
{
    [AutoInstall]
    public class StarterkitInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register
                (Component.For<ISettingsWrapper>().ImplementedBy<SettingsWrapper>().LifestyleTransient());
        }
    }
}
