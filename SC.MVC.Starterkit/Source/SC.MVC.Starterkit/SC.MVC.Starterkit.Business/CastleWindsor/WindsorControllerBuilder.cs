using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sitecore.StringExtensions;

namespace SC.MVC.Starterkit.Business.CastleWindsor
{
    public class WindsorControllerBuilder : Sitecore.Mvc.Controllers.ControllerBuilder
    {

        public WindsorControllerBuilder(string controllerSpecification, string actionName)
            : base(controllerSpecification, actionName)
        {
 
        }

        protected override IController CreateControllerUsingFactory()
        {
            IControllerFactory windsorControllerFactory = System.Web.Mvc.ControllerBuilder.Current.GetControllerFactory();
            if (windsorControllerFactory == null)
            {
                return null;
            }

            PageContext context = PageContext.Current;
            if(!string.IsNullOrEmpty(this.ActionName))
            {
                context.RequestContext.RouteData.Values["action"] = this.ActionName;
            }

            return windsorControllerFactory.CreateController(context.RequestContext, this.ControllerName);
        }

        protected override IController CreateControllerUsingReflection()
        {
            string controllerSpecification = this.ControllerSpecification;
            object @object = TypeHelper.CreateObject(controllerSpecification, new object[0]);

            if(@object == null)
            {
                throw new InvalidOperationException("Could not create a controller instance from type name: '{0}'".FormatWith(new object[]
				{
					controllerSpecification
				}));
            }

            var controller = @object as IController;
            if(controller == null)
            {
                throw new InvalidOperationException("The controller instance does not implement '{0}'. Controller type: '{1}'".FormatWith(new object[]
				{
					typeof(IController),
					@object.GetType()
				}));
            }

            return controller;
        }
    }
}
