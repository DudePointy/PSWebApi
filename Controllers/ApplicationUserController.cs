using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ApplicationUserController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<User> Get()
        {
            return _handler.GetAllUsers();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _handler.UserDetails(id);
        }

        [HttpPost]
        public void Post(User user)
        {
            if (ModelState.IsValid)
                _handler.AddUser(user);
        }

        [HttpPut]
        public void Put(User user)
        {
            if (ModelState.IsValid)
                _handler.EditUser(user);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteUser(id);
        }
    }
}
