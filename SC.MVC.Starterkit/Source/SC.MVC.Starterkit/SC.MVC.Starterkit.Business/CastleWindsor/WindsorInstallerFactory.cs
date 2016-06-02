using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorInstallerFactory<T> : InstallerFactory
        where T : Attribute
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            return base.Select(installerTypes).Where(this.HasFilterAttribute);
        }

        public bool HasFilterAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).Any();
        }
    }
}
