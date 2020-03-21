using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public RoleController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }



        [HttpGet]
        public ICollection<Role> Get()
        {
            return _handler.GetAllRoles();
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return _handler.RoleDetails(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post(Role role)
        {
            _handler.AddRole(role);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(Role role)
        {
            _handler.EditRole(role);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteRole(id);
        }
    }
}