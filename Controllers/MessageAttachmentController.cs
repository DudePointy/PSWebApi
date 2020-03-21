using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class MessageAttachmentController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public MessageAttachmentController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<MessageAttachment> Get(MessageAttachment message)
        {
            return _handler.GetAllMessageAttachments();
        }

        [HttpGet("{id}")]
        public MessageAttachment Get(int id)
        {
            return _handler.MessageAttachmentDetails(id);
        }

        [HttpPost]
        public void Post(MessageAttachment message)
        {
            if (ModelState.IsValid)
                _handler.AddMessageAttachment(message);
        }

        [HttpPut]
        public void Put(MessageAttachment message)
        {
            if (ModelState.IsValid)
                _handler.EditMessageAttachment(message);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteMessageAttachment(id);
        }
    }
}