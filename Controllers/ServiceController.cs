using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ServiceController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return _handler.GetAllServices();
        }

        [HttpGet("{id}")]
        public Service Get(int id)
        {
            return _handler.ServiceDetails(id);
        }

        [HttpPost]
        public void Post(Service service)
        {
            _handler.AddService(service);
        }

        [HttpPut]
        public void Put(Service service)
        {
            _handler.EditService(service);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteService(id);
        }
    }
}
