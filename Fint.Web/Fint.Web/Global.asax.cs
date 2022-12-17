using Autofac;
using Autofac.Integration.Mvc;
using Fint.Web.App_Start;
using Fint.Web.Authentication;
using Fint.Web.Authentication.Interfaces;
using Fint.Web.Constants;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Fint.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new DependencyInjectionConfig().Configure();
        }

        protected void Application_BeginRequest()
        {
            var userHasActiveSession = !string.IsNullOrEmpty(HttpContext.Current.Session?[AuthenticationConstants.SessionUserId]?.ToString() ?? string.Empty);
            var isLoginPage = !this.Request.Url.LocalPath.StartsWith("/Account/Login", StringComparison.OrdinalIgnoreCase);
            if (!userHasActiveSession && !isLoginPage)
            {
                Response.Redirect("/Account/Login");
            }
        }
    }
}
