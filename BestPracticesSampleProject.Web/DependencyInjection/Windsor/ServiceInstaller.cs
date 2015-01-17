using BestPracticesSampleProject.Web.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPracticesSampleProject.Web.DependencyInjection.Windsor
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IDepartmentService>()
                                .LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IProjectService>()
                                .LifestyleTransient());
        }
    }
}