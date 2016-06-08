using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorGetControllerRenderer : GetControllerRenderer
    {
        protected override Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            Tuple<string, string> controllerAndAction = this.GetControllerAndAction(rendering, args);

            if (controllerAndAction == null)
            {
                return null;
            }

            return new WindsorControllerRenderer() { ControllerName = controllerAndAction.Item1, ActionName = controllerAndAction.Item2 };
        }
    }
}
