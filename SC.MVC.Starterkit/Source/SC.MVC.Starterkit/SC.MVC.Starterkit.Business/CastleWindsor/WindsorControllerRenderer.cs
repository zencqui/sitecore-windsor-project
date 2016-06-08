using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Mvc.Extensions;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorControllerRenderer : ControllerRenderer
    {
        public override void Render(System.IO.TextWriter writer)
        {
            string controllerName = this.ControllerName;
            string actionName = this.ActionName;

            if (controllerName.IsWhiteSpaceOrNull() || actionName.IsWhiteSpaceOrNull())
            {
                return;
            }

            var windsorControllerRunner = new WindsorControllerRunner(controllerName, actionName);
            var value = windsorControllerRunner.Execute();

            if (value.IsEmptyOrNull())
            {
                return;
            }

            writer.Write(value);
        }
    }
}
