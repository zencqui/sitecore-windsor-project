using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SC.MVC.Starterkit.Business.CastleWindsor;
using SC.MVC.Starterkit.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Installers
{
    [AutoInstall]
    public class ControllerInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(new IRegistration[] { AssemblyUtility.GetControllerDescriptor() });
        }
    }
}
