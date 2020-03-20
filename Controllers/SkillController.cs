using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public SkillController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }


        [HttpGet]
        public ICollection<Skill> Get()
        {
            return _handler.GetAllSkills();
        }

        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            return _handler.SkillDetails(id);
        }

        [HttpPost]
        public void Post(Skill skill)
        {
            if (ModelState.IsValid)
                _handler.AddSkill(skill);
        }

        [HttpPut]
        public void Put(Skill skill)
        {
            if (ModelState.IsValid)
                _handler.EditSkill(skill);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteSkill(id);
        }
    }
}
