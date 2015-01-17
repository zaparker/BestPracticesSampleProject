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
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService service;

        public DepartmentsController(IDepartmentService service)
        {
            this.service = service;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return service.ListAllAsync();
        }

        [Route(Name = "GetDepartmentById")]
        public Task<Department> GetById(int id)
        {
            return service.GetByIdAsync(id);
        }

        public async Task<HttpResponseMessage> Post([FromBody]Department value)
        {
            var result = await service.CreateAsync(value);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            response.Headers.Location = new Uri(Url.Route("GetDepartmentById", new { id = result.Id }), UriKind.Relative);
            return response;
        }

        public async Task Put(int id, [FromBody]Department value)
        {
            await service.UpdateAsync(value);
        }

        public Task Delete(int id)
        {
            return service.DeleteAsync(id);
        }
    }
}
