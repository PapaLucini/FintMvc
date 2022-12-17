using Autofac;
using Autofac.Integration.Mvc;
using Fint.Web.Authentication.Interfaces;
using Fint.Web.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpClientWrapper.Interfaces;
using HttpClientWrapper;
using Fint.Web.Services.Nordigen.Interfaces;
using Fint.Web.Services.Nordigen;
using Fint.Web.Services.Authentication.Interfaces;
using Fint.Web.Services.Authentication;

namespace Fint.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CustomFirebaseAuthenticationProvider>().As<ICustomAuthenticationProvider>();
            builder.RegisterType<HttpClientService>().As<IHttpClientService>();
            builder.RegisterType<NordigenService>().As<INordigenService>();
            builder.RegisterType<FirebaseAuthenticationService>().As<IAuthenticationSerivce>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            return container;
        }
    }
}