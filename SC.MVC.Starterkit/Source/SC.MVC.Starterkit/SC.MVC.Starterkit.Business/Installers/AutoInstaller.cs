using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Installers
{
    public class AutoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var installerFactory = new WindsorInstallerFactory<AutoInstallAttribute>();
            var filteredAssemblies = AssemblyUtility.RelatedAssemblies
                .Select(x => FromAssembly.Named(x, installerFactory)).ToArray();

            container.Install(filteredAssemblies);
        }
    }
}
