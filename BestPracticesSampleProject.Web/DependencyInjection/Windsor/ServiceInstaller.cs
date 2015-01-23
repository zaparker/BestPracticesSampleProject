using BestPracticesSampleProject.Web.Services;
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
    /// Windsor installer for registering services.
    /// </summary>
    public class ServiceInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs all of the application's services.
        /// </summary>
        /// <param name="container">The container which will contain the registered services.</param>
        /// <param name="store">Not used.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IDepartmentService>().WithServiceBase()
                                .LifestyleTransient());
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IProjectService>().WithServiceBase()
                                .LifestyleTransient());
        }
    }
}