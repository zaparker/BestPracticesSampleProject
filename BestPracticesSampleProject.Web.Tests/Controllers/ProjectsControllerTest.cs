using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestPracticesSampleProject.Web;
using BestPracticesSampleProject.Web.Controllers;
using System.Threading.Tasks;
using BestPracticesSampleProject.Web.Services;
using Moq;
using BestPracticesSampleProject.Web.Models;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace BestPracticesSampleProject.Web.Tests.Controllers
{
    [TestClass]
    public class ProjectsControllerTest
    {
        private ProjectsController GetController()
        {
            var items = new List<Project>();
            items.Add(new Project { Id = 0, Name = "Test Project 1" });
            items.Add(new Project { Id = 1, Name = "Test Project 2" });

            var service = new Mock<IProjectService>();
            service.Setup(m => m.ListByDepartmentIdAsync(It.IsAny<int>())).Returns(Task.FromResult<IEnumerable<Project>>(items));
            service.Setup(m => m.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(items[0]));
            service.Setup(m => m.CreateAsync(It.IsAny<Project>())).Returns(Task.FromResult(items[0]));

            var controller = new ProjectsController(service.Object);
            controller.Request = new HttpRequestMessage();
            var configuration = new HttpConfiguration();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, configuration);

            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Route(It.IsAny<string>(), It.IsAny<object>())).Returns("/api/Projects/5");
            controller.Url = mockUrlHelper.Object;
            return controller;
        }

        [TestMethod]
        public async Task GetAll()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.GetByDepartmentId(4);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Test Project 1", result.ElementAt(0).Name);
            Assert.AreEqual("Test Project 2", result.ElementAt(1).Name);
        }

        [TestMethod]
        public async Task GetById()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.GetById(5);

            // Assert
            Assert.AreEqual("Test Project 1", result.Name);
        }

        [TestMethod]
        public async Task Post()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.Post(new Project());

            // Assert
            Assert.IsInstanceOfType(result.Content, typeof(ObjectContent));
            var content = result.Content as ObjectContent;
            Assert.IsInstanceOfType(content.Value, typeof(Project));

            var Project = content.Value as Project;
            Assert.AreEqual("Test Project 1", Project.Name);
        }

        [TestMethod]
        public async Task Put()
        {
            // Arrange
            var controller = GetController();

            // Act
            await controller.Put(5, new Project());

            // Assert
        }

        [TestMethod]
        public async Task Delete()
        {
            // Arrange
            var controller = GetController();

            // Act
            await controller.Delete(5);

            // Assert
        }
    }
}
