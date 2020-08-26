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

namespace DataAccessEFGenericRepo
{
    public class IOC_repoDependency_Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //open generic type
                Component.For<bookMeDBContext>().ImplementedBy(typeof(bookMeDBContext)),

                //for Mocker APIs
                //Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(mock_EFGeneric_CommandImplementation<>)),
                //Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(mock_EFGeneric_QueryImplementation<>))

                //For Actual Repository 
                Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(EFGeneric_CommandImplementation<>)),
                Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(EFGeneric_QueryImplementation<>))

                );
        }
    }
}