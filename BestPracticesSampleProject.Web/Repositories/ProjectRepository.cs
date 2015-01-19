using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BestPracticesSampleProject.Web.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BestPracticesSampleProjectDatabaseContext dbContext;

        public ProjectRepository(BestPracticesSampleProjectDatabaseContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Project> GetQueryable()
        {
            return dbContext.Projects;
        }

        public Task CreateAsync(Project project)
        {
            dbContext.Projects.Add(project);
            return Task.FromResult(0);
        }

        public async Task UpdateAsync(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            var original = await dbContext.Projects.FindAsync(project.Id);
            var entry = dbContext.Entry<Project>(original);
            entry.CurrentValues.SetValues(project);
        }

        public async Task DeleteAsync(int id)
        {
            var original = await dbContext.Projects.FindAsync(id);
            dbContext.Projects.Remove(original);
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