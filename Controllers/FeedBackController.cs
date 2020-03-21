using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class FeedBackController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public FeedBackController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }


        [HttpGet]
        public ICollection<Feedback> Get()
        {
            return _handler.GetAllFeedback();
        }

        [HttpGet("{id}")]
        public Feedback Get(int id)
        {
            return _handler.FeedbackDetails(id);
        }

        [HttpPost]
        public void Post(Feedback feedback)
        {
            if (ModelState.IsValid)
                _handler.AddFeedback(feedback);
        }

        [HttpPut]
        public void Put(Feedback feedback)
        {
            if (ModelState.IsValid)
                _handler.EditFeedback(feedback);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteFeedback(id);
        }
    }
}
