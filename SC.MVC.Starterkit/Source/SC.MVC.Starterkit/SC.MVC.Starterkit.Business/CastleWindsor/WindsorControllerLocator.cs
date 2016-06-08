using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorControllerLocator : ControllerLocator
    {
        public override ControllerBuilder GetControllerBuilder(string controllerName, string actionName)
        {
            Tuple<string, string> controllerAndAction = this.GetControllerAndAction(controllerName, actionName);
            if (controllerAndAction == null)
            {
                return null;
            }

            return new WindsorControllerBuilder(controllerAndAction.Item1, controllerAndAction.Item2);
        }
    }
}
