using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Services
{
    public interface IProjectService
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> ListByDepartmentIdAsync(int departmentId);
        Task<Project> CreateAsync(Project Project);
        Task UpdateAsync(Project Project);
        Task DeleteAsync(int id);
    }
}
