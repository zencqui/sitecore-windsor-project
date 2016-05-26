using Castle.MicroKernel;
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
        public CastleWindsorControllerFactory(IKernel kernel)
        { 
        }
    }
}
