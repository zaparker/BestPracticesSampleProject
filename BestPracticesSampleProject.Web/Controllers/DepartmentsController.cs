using BestPracticesSampleProject.Web.Models;
using BestPracticesSampleProject.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BestPracticesSampleProject.Web.Controllers
{
    /// <summary>
    /// API controller for interacting with departments.
    /// </summary>
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService service;

        /// <summary>
        /// Creates a new DepartmentsController using the specified IDepartmentService.
        /// </summary>
        /// <param name="service">Used for creating, retrieving, updating, and deleting departments.</param>
        public DepartmentsController(IDepartmentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieves all departments.
        /// </summary>
        /// <returns>All departments available returned by the service.</returns>
        [Route("")]
        public Task<IEnumerable<Department>> GetAll()
        {
            return service.ListAllAsync();
        }

        /// <summary>
        /// Retrieves a single department with the matching id.
        /// </summary>
        /// <param name="id">The primary identifier of the department to retrieve.</param>
        /// <returns>The matchinng department.</returns>
        [Route("{id}", Name = "GetDepartmentById")]
        public Task<Department> GetById(int id)
        {
            return service.GetByIdAsync(id);
        }

        /// <summary>
        /// Creates a new department, and returns both the new department and a header containing the url to the new department.
        /// </summary>
        /// <param name="value">The values of the new department.</param>
        /// <returns>HttpResponseMessage containing the new department in the response body, and the url to the department in the headers.</returns>
        public async Task<HttpResponseMessage> Post([FromBody]Department value)
        {
            var result = await service.CreateAsync(value);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Location = new Uri(Url.Route("GetDepartmentById", new { id = result.Id }), UriKind.Relative);
            return response;
        }

        /// <summary>
        /// Updates the department matching the specified id.
        /// </summary>
        /// <param name="id">The primary identifier of the department to update.</param>
        /// <param name="value">The new values to set for the deparment.</param>
        /// <returns></returns>
        public async Task Put(int id, [FromBody]Department value)
        {
            await service.UpdateAsync(value);
        }

        /// <summary>
        /// Deletes the specified department.
        /// </summary>
        /// <param name="id">The primary identifier of the department to delete.</param>
        /// <returns></returns>
        public Task Delete(int id)
        {
            return service.DeleteAsync(id);
        }
    }
}
