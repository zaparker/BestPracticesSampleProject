﻿using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BestPracticesSampleProject.Web.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly BestPracticesSampleProjectDatabaseContext dbContext;

        public DepartmentRepository(BestPracticesSampleProjectDatabaseContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Department> GetQueryable()
        {
            return dbContext.Departments;
        }

        public Task CreateAsync(Department department)
        {
            dbContext.Departments.Add(department);
            return Task.FromResult(0);
        }

        public async Task UpdateAsync(Department department)
        {
            if (department == null)
                throw new ArgumentNullException("department");
            var original = await dbContext.Departments.FindAsync(department.Id);
            var entry = dbContext.Entry<Department>(original);
            entry.CurrentValues.SetValues(department);
        }

        public async Task DeleteAsync(int id)
        {
            var original = await dbContext.Departments.FindAsync(id);
            dbContext.Departments.Remove(original);
        }

        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}