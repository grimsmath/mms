﻿using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MMS.DAO;

namespace MMS
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = true;
            
            AreaRegistration.RegisterAllAreas();
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();
		}
	}
}