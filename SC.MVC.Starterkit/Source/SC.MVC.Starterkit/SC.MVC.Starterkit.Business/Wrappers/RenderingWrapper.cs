using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.MVC.Starterkit.Business.Wrappers
{
    public class RenderingWrapper : RenderingWrapperBase
    {
        private readonly Rendering rendering;

        public RenderingWrapper(Rendering rendering)
        {
            this.rendering = rendering;
        }

        public override string Datasource
        {
            get
            {
                return this.rendering != null ? this.rendering.DataSource : string.Empty;
            }
        }
    }
}
