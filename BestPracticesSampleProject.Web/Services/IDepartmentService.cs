using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetByIdAsync(int id);
        Task<IEnumerable<Department>> ListAllAsync();
        Task<Department> CreateAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);
    }
}
