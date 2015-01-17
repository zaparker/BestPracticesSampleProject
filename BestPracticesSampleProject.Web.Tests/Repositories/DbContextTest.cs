using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Tests.Repositories
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void TestInitialize() 
        {
            var context = new BestPracticesSampleProject.Web.Repositories.BestPracticesSampleProjectDatabaseContext();        
        }
    }
}
