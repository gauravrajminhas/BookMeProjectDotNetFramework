using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPI_ReSTServices.App_Start;

namespace WebAPI_ReSTServices
{
    public class WebApiApplication : System.Web.HttpApplication, IContainerAccessor, IDisposable
    {
        public IWindsorContainer Container => new IOC_BootStrapper().bootstrapContainer();




        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // Console.WriteLine(Container);


        }
    }
}
