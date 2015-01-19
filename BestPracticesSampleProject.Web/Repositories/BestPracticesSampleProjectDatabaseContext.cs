using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BestPracticesSampleProject.Web.Repositories
{
    public class BestPracticesSampleProjectDatabaseContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public BestPracticesSampleProjectDatabaseContext()
            : base() { 
        }
    }
}