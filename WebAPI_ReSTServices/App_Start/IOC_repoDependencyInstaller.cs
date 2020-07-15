using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessEFGenericRepo;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_MockerLibraries;

namespace WebAPI_ReSTServices.App_Start
{
    public class IOC_repoDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //open generic type
                Component.For<bookMeDBContext>(),

                Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(mock_EFGeneric_CommandImplementation<>)),
                Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(mock_EFGeneric_QueryImplementation<>))

                //Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(EFGeneric_CommandImplementation<>)),
                //Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(EFGeneric_QueryImplementation<>))



                );
        }
    }
}