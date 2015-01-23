using BestPracticesSampleProject.Web.Models;
using BestPracticesSampleProject.Web.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPracticesSampleProject.Web
{
    /// <summary>
    /// Windsor installer for registering repositories.
    /// </summary>
    public class RepositoryInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs all of the application's repositories.
        /// </summary>
        /// <param name="container">The container which will contain the registered repositories.</param>
        /// <param name="store">Not used.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<BestPracticesSampleProjectDatabaseContext>()
                .ImplementedBy<BestPracticesSampleProjectDatabaseContext>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IProjectRepository>().WithServiceBase()
                                .LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IDepartmentRepository>().WithServiceBase()
                                .LifestyleTransient());
        }
    }
}