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
    public class DepartmentServiceTest
    {
        private DepartmentService GetService()
        {
            var items = new List<Department>();
            items.Add(new Department { Id = 0, Name = "Test Department 1" });
            items.Add(new Department { Id = 1, Name = "Test Department 2" });

            var queryable = items.AsQueryable();

            var set = new Mock<IQueryable<Department>>();
            set.Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            set.Setup(m => m.Expression).Returns(queryable.Expression);
            set.Setup(m => m.Provider).Returns(queryable.Provider);

            var repository = new Mock<IRepository<Department>>();
            repository.Setup(m => m.GetQueryable()).Returns(set.Object);

            return new DepartmentService(repository.Object);
        }

        [TestMethod]
        public async Task ListAll()
        {
            // Arrange
            var svc = GetService();

            // Act
            var results = await svc.ListAllAsync();

            // Assert
            Assert.AreEqual(2, results.Count());
        }
    }
}
