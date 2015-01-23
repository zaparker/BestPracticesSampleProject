using BestPracticesSampleProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesSampleProject.Web.Repositories
{
    /// <summary>
    /// Defines the CRUD operations for a generic repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable
    {
        /// <summary>
        /// Retrieves a queryable object for the repository.
        /// </summary>
        /// <returns>The queryable object for the repository.</returns>
        IQueryable<TEntity> GetQueryable();

        /// <summary>
        /// Adds a new entity to the repository. 
        /// </summary>
        /// <param name="entity">The entity to add to the repository.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="id">The primary identifier of the entity to delete.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes to the repository.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
