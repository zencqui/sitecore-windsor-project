using Sitecore.Data.Items;
using Sitecore.Mvc.Pipelines.Response.GetModel;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Mvc.Extensions;
using System.Web.Compilation;
using SC.MVC.Starterkit.Business.Models;
using Glass.Mapper.Sc;
using Glass.Mapper;

namespace SC.MVC.Starterkit.Business.Pipelines
{
    public class GetMvcViewModel : GetModelProcessor
    {
        public override void Process(GetModelArgs args)
        {
            if (args.Result != null)
            {
                return;
            }

            Type type = this.GetModelVromViewPath(args.Rendering, args);

            if (type == null || !typeof(IGlassBase).IsAssignableFrom(type))
            {
                return;
            }

            // should be in separate method
            string datasource = args.Rendering.DataSource;
            Type glassType = typeof(GlassBase);

            IGlassBase result;
            var sitecoreContext = this.SitecoreContext();

            if (!string.IsNullOrEmpty(datasource))
            {
                args.Result = (IGlassBase)sitecoreContext.GetCurrentItem(glassType, inferType: true);
            }

            Item itemDatasource = sitecoreContext.Database.GetItem(datasource);

            result = (IGlassBase)sitecoreContext.CreateType(glassType, itemDatasource, true, true, null, null);

            args.Result = result;

            args.AbortPipeline();
        }

        private ISitecoreContext SitecoreContext()
        {
            Context context = Context.Contexts.ContainsKey("Default") ? Context.Contexts["Default"] : null;
            
            if (context == null)
            {
                throw new MapperException("Unable to find context: Default");
            }

            return new SitecoreContext(context);
        }

        protected virtual Type GetModelVromViewPath(Rendering rendering, GetModelArgs args)
        {
            string path = rendering.Renderer is ViewRenderer
                ? ((ViewRenderer)rendering.Renderer).ViewPath
                : rendering.ToString().Replace("View: ", string.Empty);

            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            Type compiledType = BuildManager.GetCompiledType(path);
            Type baseType = compiledType.BaseType;

            // check if base type is null or generic
            if (baseType == null || !baseType.IsGenericType)
            {
                return null;
            }

            Type modelType = baseType.GetGenericArguments()[0];

            // check if no model has been set
            if (modelType == typeof(object))
            {
                return null;
            }

            return modelType;
        }
    }
}
