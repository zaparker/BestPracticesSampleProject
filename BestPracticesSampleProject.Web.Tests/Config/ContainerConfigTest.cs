using BestPracticesSampleProject.Web.Controllers;
using BestPracticesSampleProject.Web.Repositories;
using BestPracticesSampleProject.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BestPracticesSampleProject.Web.Tests.Config
{
    [TestClass]
    public class ContainerConfigTest
    {
        [TestInitialize]
        public void Init()
        {
            // Arrange
            var httpConfig = new Mock<HttpConfiguration>();
            ContainerConfig.Config(httpConfig.Object);
        }

        [TestMethod]
        public void ResolveHomeController() 
        {
            // Act
            var controller = ContainerConfig.Container.Resolve<HomeController>();

            // Assert
            Assert.IsInstanceOfType(controller, typeof(HomeController));
        }

        [TestMethod]
        public void ResolveDepartmentController()
        {
            // Act
            var controller = ContainerConfig.Container.Resolve<DepartmentsController>();

            // Assert
            Assert.IsInstanceOfType(controller, typeof(DepartmentsController));
        }

        [TestMethod]
        public void ResolveProjectController()
        {
            // Act
            var controller = ContainerConfig.Container.Resolve<ProjectsController>();

            // Assert
            Assert.IsInstanceOfType(controller, typeof(ProjectsController));
        }

        [TestMethod]
        public void ResolveDepartmentService()
        {
            // Act
            var service = ContainerConfig.Container.Resolve<IDepartmentService>();

            // Assert
            Assert.IsInstanceOfType(service, typeof(DepartmentService));
        }

        [TestMethod]
        public void ResolveProjectService()
        {
            // Act
            var service = ContainerConfig.Container.Resolve<IProjectService>();

            // Assert
            Assert.IsInstanceOfType(service, typeof(ProjectService));
        }

        [TestMethod]
        public void ResolveDepartmentRepository()
        {
            // Act
            var Repository = ContainerConfig.Container.Resolve<IDepartmentRepository>();

            // Assert
            Assert.IsInstanceOfType(Repository, typeof(DepartmentRepository));
        }

        [TestMethod]
        public void ResolveProjectRepository()
        {
            // Act
            var Repository = ContainerConfig.Container.Resolve<IProjectRepository>();

            // Assert
            Assert.IsInstanceOfType(Repository, typeof(ProjectRepository));
        }
    }
}
