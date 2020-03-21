using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public UserSkillController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<UserSkill> Get()
        {
            return _handler.GetAllUserSkills();
        }

        [HttpGet("{id}")]
        public UserSkill Get(int id)
        {
            return _handler.UserSkillDetails(id);
        }

        [HttpPost]
        public void Post(UserSkill skill)
        {
            if (ModelState.IsValid)
                _handler.AddUserSkill(skill);
        }

        [HttpPut]
        public void Put(UserSkill skill)
        {
            if (ModelState.IsValid)
                _handler.EditUserSkill(skill);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteUserSkill(id);
        }
    }
}