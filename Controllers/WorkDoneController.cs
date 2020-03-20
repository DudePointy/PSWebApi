using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDoneController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public WorkDoneController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }


        [HttpGet]
        public ICollection<WorkDone> Get()
        {
            return _handler.GetAllWorkDone();
        }

        [HttpGet("{id}")]
        public WorkDone Get(int id)
        {
            return _handler.WorkDoneDetails(id);
        }

        [HttpPost]
        public void Post(WorkDone workDone)
        {
            if (ModelState.IsValid)
                _handler.AddWorkDone(workDone);
        }

        [HttpPut]
        public void Put(WorkDone workDone)
        {
            if (ModelState.IsValid)
                _handler.EditWorkDone(workDone);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteWorkDone(id);
        }
    }
}
