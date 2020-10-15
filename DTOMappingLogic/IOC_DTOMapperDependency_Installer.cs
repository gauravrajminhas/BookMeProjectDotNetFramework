using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DTOMappingLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOMappingLayer
{
    public class IOC_DTOMapperDependency_Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<userDTOMapping>()
                              
                ); 
        }
    }
}