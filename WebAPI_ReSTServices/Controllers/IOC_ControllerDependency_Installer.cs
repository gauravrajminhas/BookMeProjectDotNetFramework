using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ReSTServices.Controllers
{
    public class IOC_ControllerDependency_Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Console.WriteLine("IOC Installer Called");
        }
    }
}