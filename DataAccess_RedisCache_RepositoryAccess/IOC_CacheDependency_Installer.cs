using BookMeProject;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessEFGenericRepo;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_RedisCache_RepositoryAccess
{
    public class IOC_CacheDependency_Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            Console.WriteLine("Redis Dependency Installer called ");

            container.Register(

                //Component.For<bookMeDBContext>().ImplementedBy(typeof(bookMeDBContext)),

                //for Mocker APIs
                //Component.For(typeof(iRepoCommand<>)).ImplementedBy(typeof(mock_EFGeneric_CommandImplementation<>)),
                //Component.For(typeof(iRepoQuery<>)).ImplementedBy(typeof(mock_EFGeneric_QueryImplementation<>))

                //For Actual Repository 
                Component.For(typeof(iCachedCommandRepo<>)).ImplementedBy(typeof(cached_CommandImplementation<>)),
                Component.For(typeof(iCachedQueryRepo<>)).ImplementedBy(typeof(cached_QueryImplementation<>))
                );
        }
    }
}
