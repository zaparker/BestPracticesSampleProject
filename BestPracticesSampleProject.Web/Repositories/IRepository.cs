using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Repositories
{
    public interface IRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> GetQueryable();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
