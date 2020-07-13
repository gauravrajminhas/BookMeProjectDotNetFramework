using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAPI_ReSTServices.App_Start
{
    // ref :- https://github.com/castleproject/Windsor/blob/master/docs/installers.md
    // configure the Container 

    public class IOC_BootStrapper : IContainerAccessor, IDisposable
    {
        public IWindsorContainer Container => new WindsorContainer();


        public IWindsorContainer bootstrapContainer()
        {
            return Container
                .Install(
                    //new iControllerInstallers(),
                    //new iRepoInstallers()
                    //Configuration.FromAppConfig(),
                    FromAssembly.This(),
                    FromAssembly.Named("BusinessLogicServicesLayer"),
                    FromAssembly.Named("DataAccessEFGenericRepo"),
                    FromAssembly.Named("BusinessLogicValidationLayer")
                );
        }



        public void Dispose()
        {
            Container.Dispose();
        }
    }
}