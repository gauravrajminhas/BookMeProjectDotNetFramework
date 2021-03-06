﻿using Castle.Windsor;
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

        //how to get the assembly name ? 
        // http://inoteitdown.blogspot.com/2011/07/get-assembly-fully-qualified-name.html

        public IWindsorContainer bootstrapContainer()
        {
            return Container
                .Install(
                    //new iControllerInstallers(),
                    //new iRepoInstallers(),
                    //Configuration.FromAppConfig(),
                    FromAssembly.This(),
                    FromAssembly.Named("DataAccess_RedisCache_RepositoryAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"),
                    FromAssembly.Named("DataAccessEFGenericRepo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"),
                    FromAssembly.Named("DTOMappingLayer, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null")
                    //FromAssembly.Named("BusinessLogicValidationLayer"),
                    //FromAssembly.Named("BusinessLogicServicesLayer"),
                    //FromAssembly.Named("DataAccessEFGenericRepo")

                );
        }



        public void Dispose()
        {
            //Container.Dispose();
        }
    }
}