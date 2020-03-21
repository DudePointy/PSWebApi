using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceImageController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ServiceImageController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<ServiceImage> Get()
        {
            return _handler.GetAllServicesImages();
        }

        [HttpGet("{id}")]
        public ServiceImage Get(int id)
        {
            return _handler.ServiceImageDetails(id);
        }

        [HttpPost]
        [Authorize(Roles = "Service Provider")]
        public void Post(ServiceImage serviceImage)
        {
            if (ModelState.IsValid)
                _handler.AddServiceImage(serviceImage);
        }

        [HttpPut]
        [Authorize(Roles = "Service Provider")]
        public void Put(ServiceImage serviceImage)
        {
            if (ModelState.IsValid)
                _handler.EditServiceImage(serviceImage);
        }

        [Authorize(Roles = "Service Provider")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteServiceImage(id);
        }
    }
}