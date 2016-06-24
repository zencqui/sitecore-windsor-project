using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Wrappers
{
    public class RenderingContextWrapper : RenderingContextWrapperBase
    {
        public readonly RenderingContext renderingContext;

        public RenderingContextWrapper(RenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public override RenderingWrapperBase Rendering
        {
            get 
            {
                return new RenderingWrapper(this.renderingContext.Rendering);
            }
        }
    }
}
