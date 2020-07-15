using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DTOMappingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_ReSTServices.App_Start
{
    public class IOC_DTOMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<userDTOMapping>()
                              
                ); 
        }
    }
}