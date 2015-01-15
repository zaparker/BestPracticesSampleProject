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
    public class DepartmentsControllerTest
    {
        private DepartmentsController GetController()
        {
            var items = new List<Department>();
            items.Add(new Department { Id = 0, Name = "Test Department 1" });
            items.Add(new Department { Id = 1, Name = "Test Department 2" });

            var service = new Mock<IDepartmentService>();
            service.Setup(m => m.ListAllAsync()).Returns(Task.FromResult<IEnumerable<Department>>(items));
            service.Setup(m => m.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(items[0]));
            service.Setup(m => m.CreateAsync(It.IsAny<Department>())).Returns(Task.FromResult(items[0]));

            var controller = new DepartmentsController(service.Object);
            controller.Request = new HttpRequestMessage();
            var configuration = new HttpConfiguration();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, configuration);

            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Route(It.IsAny<string>(), It.IsAny<object>())).Returns("/api/departments/5");
            controller.Url = mockUrlHelper.Object;
            return controller;
        }

        [TestMethod]
        public async Task GetAll()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Test Department 1", result.ElementAt(0).Name);
            Assert.AreEqual("Test Department 2", result.ElementAt(1).Name);
        }

        [TestMethod]
        public async Task GetById()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.GetById(5);

            // Assert
            Assert.AreEqual("Test Department 1", result.Name);
        }

        [TestMethod]
        public async Task Post()
        {
            // Arrange
            var controller = GetController();

            // Act
            var result = await controller.Post(new Department());

            // Assert
            Assert.IsInstanceOfType(result.Content, typeof(ObjectContent));
            var content = result.Content as ObjectContent;
            Assert.IsInstanceOfType(content.Value, typeof(Department));

            var department = content.Value as Department;
            Assert.AreEqual("Test Department 1", department.Name);
        }

        [TestMethod]
        public async Task Put()
        {
            // Arrange
            var controller = GetController();

            // Act
            await controller.Put(5, new Department());

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
