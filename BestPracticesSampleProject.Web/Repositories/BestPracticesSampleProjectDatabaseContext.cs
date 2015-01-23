using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BestPracticesSampleProject.Web.Repositories
{
    /// <summary>
    /// DbContext for the BestPracticesSampleProject application.
    /// </summary>
    public class BestPracticesSampleProjectDatabaseContext : DbContext
    {
        /// <summary>
        /// The DbSet of departments.
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; }

        /// <summary>
        /// The DbSet of projects.
        /// </summary>
        public virtual DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Creates a new BestPracticesSampleProjectDatabaseContext using the default connection string name.
        /// </summary>
        public BestPracticesSampleProjectDatabaseContext()
            : base() { 
        }
    }
}