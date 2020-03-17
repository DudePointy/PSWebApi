using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public MessageController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<Message> Get()
        {
            return _handler.GetAllMessages();
        }

        [HttpGet("{id}")]
        public Message Get(int id)
        {
            return _handler.MessageDetails(id);
        }

        [HttpPost]
        public void Post(Message message)
        {
            _handler.AddMessage(message);
        }

        [HttpPut]
        public void Put(Message message)
        {
            _handler.EditMessage(message);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteMessage(id);
        }
    }
}