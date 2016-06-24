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

            Type modelType = this.GetModelVromViewPath(args.Rendering, args);

            if (modelType == null || !typeof(IGlassBase).IsAssignableFrom(modelType))
            {
                return;
            }


            var sitecoreContext = this.SitecoreContext();
            IGlassBase createdInstance = GetInstanceFromContext(args.Rendering, sitecoreContext);

            if (modelType.IsInstanceOfType(createdInstance))
            {
                args.Result = createdInstance;
            }
 
            // else if model type is not type of created instance.

            args.AbortPipeline();
        }

        private IGlassBase GetInstanceFromContext(Rendering rendering, ISitecoreContext sitecoreContext)
        {
            string datasource = rendering.DataSource;
            Type glassBaseType = typeof(GlassBase);

            if (!datasource.IsNotNullOrEmpty())
            {
                return (IGlassBase)sitecoreContext.GetCurrentItem(glassBaseType, inferType: true);
            }

            Item item = sitecoreContext.Database.GetItem(datasource);

            return (IGlassBase)sitecoreContext.CreateType(glassBaseType, item, true, true, null, null);
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
