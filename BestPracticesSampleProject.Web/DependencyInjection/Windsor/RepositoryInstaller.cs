using BestPracticesSampleProject.Web.Models;
using BestPracticesSampleProject.Web.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPracticesSampleProject.Web.DependencyInjection.Windsor
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IRepository<Department>>()
                                .LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IRepository<Project>>()
                                .LifestyleTransient());
            container.Register(Component.For<BestPracticesSampleProjectDatabaseContext>().UsingFactoryMethod(ctx => new BestPracticesSampleProjectDatabaseContext()));
        }
    }
}