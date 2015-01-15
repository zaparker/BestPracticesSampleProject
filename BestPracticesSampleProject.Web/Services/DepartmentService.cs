using BestPracticesSampleProject.Web.Models;
using BestPracticesSampleProject.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BestPracticesSampleProject.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> repository;

        public DepartmentService(IRepository<Department> repository)
        {
            this.repository = repository;
        }

        public Task<Department> GetByIdAsync(int id)
        {
            return Task.FromResult(repository.GetQueryable().FirstOrDefault(d => d.Id == id));
        }

        public Task<IEnumerable<Department>> ListAllAsync()
        {
            return Task.FromResult<IEnumerable<Department>>(repository.GetQueryable());
        }

        public async Task<Department> CreateAsync(Department department)
        {
            await repository.CreateAsync(department);
            await repository.SaveChangesAsync();
            return department;
        }

        public async Task UpdateAsync(Department department)
        {
            await repository.UpdateAsync(department);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveChangesAsync();
        }
    }
}