using BestPracticesSampleProject.Web.Models;
using BestPracticesSampleProject.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BestPracticesSampleProject.Web.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> repository;

        public ProjectService(IRepository<Project> repository)
        {
            this.repository = repository;
        }

        public Task<Project> GetByIdAsync(int id)
        {
            return Task.FromResult(repository.GetQueryable().FirstOrDefault(d => d.Id == id));
        }

        public Task<IEnumerable<Project>> ListByDepartmentIdAsync(int departmentId)
        {
            return Task.FromResult<IEnumerable<Project>>(repository.GetQueryable().Where(p => p.DepartmentId == departmentId));
        }

        public async Task<Project> CreateAsync(Project Project)
        {
            await repository.CreateAsync(Project);
            await repository.SaveChangesAsync();
            return Project;
        }

        public async Task UpdateAsync(Project Project)
        {
            await repository.UpdateAsync(Project);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveChangesAsync();
        }
    }
}