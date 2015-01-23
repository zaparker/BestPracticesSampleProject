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
    /// API controller for interacting with projects.
    /// </summary>
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService service;

        /// <summary>
        /// Creates a new ProjectsController using the specified IProjectService.
        /// </summary>
        /// <param name="service">Used for creating, retrieving, updating, and deleting projects.</param>
        public ProjectsController(IProjectService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieves all projects in the specified department.
        /// </summary>
        /// <param name="departmentId">The primarty identifier of the department to get info for.</param>
        /// <returns>The matching projects.</returns>
        [Route("")]
        public Task<IEnumerable<Project>> GetByDepartmentId([FromUri]int departmentId)
        {
            return service.ListByDepartmentIdAsync(departmentId);
        }

        /// <summary>
        /// Retrieves a single project with the matching id.
        /// </summary>
        /// <param name="id">The primary identifier of the project to retrieve.</param>
        /// <returns>The matchinng project.</returns>
        [Route("{id}", Name = "GetProjectById")]
        public Task<Project> GetById(int id)
        {
            return service.GetByIdAsync(id);
        }

        /// <summary>
        /// Creates a new project, and returns both the new project and a header containing the url to the new project.
        /// </summary>
        /// <param name="value">The values of the new project.</param>
        /// <returns>HttpResponseMessage containing the new project in the response body, and the url to the project in the headers.</returns>
        public async Task<HttpResponseMessage> Post([FromBody]Project value)
        {
            var result = await service.CreateAsync(value);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Location = new Uri(Url.Route("GetProjectById", new { id = result.Id }), UriKind.Relative);
            return response;
        }

        /// <summary>
        /// Updates the project matching the specified id.
        /// </summary>
        /// <param name="id">The primary identifier of the project to update.</param>
        /// <param name="value">The new values to set for the project.</param>
        /// <returns></returns>
        public async Task Put(int id, [FromBody]Project value)
        {
            await service.UpdateAsync(value);
        }

        /// <summary>
        /// Deletes the specified project.
        /// </summary>
        /// <param name="id">The primary identifier of the project to delete.</param>
        /// <returns></returns>
        public Task Delete(int id)
        {
            return service.DeleteAsync(id);
        }
    }
}
