using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestPracticesSampleProject.Web.Services;
using System.Threading.Tasks;
using BestPracticesSampleProject.Web.Models;
using System.Collections.Generic;
using Moq;
using BestPracticesSampleProject.Web.Repositories;

namespace BestPracticesSampleProject.Web.Tests.Services
{
    [TestClass]
    public class ProjectServiceTest
    {
        private ProjectService GetService()
        {
            var items = new List<Project>();
            items.Add(new Project { Id = 0, Name = "Test Project 1", DepartmentId = 1 });
            items.Add(new Project { Id = 1, Name = "Test Project 2", DepartmentId = 1 });
            items.Add(new Project { Id = 2, Name = "Test Project 3", DepartmentId = 0 });

            var queryable = items.AsQueryable();

            var set = new Mock<IQueryable<Project>>();
            set.Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            set.Setup(m => m.Expression).Returns(queryable.Expression);
            set.Setup(m => m.Provider).Returns(queryable.Provider);

            var repository = new Mock<IProjectRepository>();
            repository.Setup(m => m.GetQueryable()).Returns(set.Object);

            return new ProjectService(repository.Object);
        }

        [TestMethod]
        public async Task ListAll()
        {
            // Arrange
            var svc = GetService();

            // Act
            var results = await svc.ListByDepartmentIdAsync(1);

            // Assert
            Assert.AreEqual(2, results.Count());
        }
    }
}
