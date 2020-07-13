using BookMeProject;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFGenericRepo
{
    class IOC_repoDependencyInstaller : IWindsorInstaller
    {



        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

             container.Register(
                Component.For<bookMeDBContext>(),
                
                //Register Open generic Type 
                // ref the windsor documentation- https://github.com/castleproject/Windsor/blob/master/docs/registering-components-one-by-one.md
                Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(EFGeneric_QueryImplementation<>)),
                Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(EFGeneric_CommandImplementation<>))
                );





        }
    }
}
