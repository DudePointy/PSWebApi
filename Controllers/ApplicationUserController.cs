using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ApplicationUserController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<ApplicationUser> Get()
        {
            return context.ApplicationUsers.ToList();
        }

        [HttpGet("{id}")]
        public ApplicationUser Get(int id)
        {
            return context.ApplicationUsers.FirstOrDefault(a => a.Id == id);
        }

        [HttpPost]
        public void Post(ApplicationUser applicationUser)
        {
            context.ApplicationUsers.Add(applicationUser);
            context.SaveChanges();
        }

        [HttpPut]
        public void Put(ApplicationUser applicationUser)
        {
            context.Entry(applicationUser).State = EntityState.Modified;
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = context.ApplicationUsers.FirstOrDefault(a => a.Id == id);
            if (user != null)
                context.ApplicationUsers.Remove(user);
        }
    }
}
