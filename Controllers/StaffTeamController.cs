using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class StaffTeamController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public StaffTeamController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<StaffTeam> Get()
        {
            return _handler.GetAllStaffTeams();
        }

        [HttpGet("{id}")]
        public StaffTeam Get(int id)
        {
            return _handler.StaffTeamDetails(id);
        }

        [HttpPost]
        public void Post(StaffTeam staffTeam)
        {
            if (ModelState.IsValid)
                _handler.AddStaffTeam(staffTeam);
        }

        [HttpPut]
        public void Put(StaffTeam staffTeam)
        {
            if (ModelState.IsValid)
                _handler.EditStaffTeam(staffTeam);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteStaffTeam(id);
        }
    }
}