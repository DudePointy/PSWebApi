using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMessageController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public OrderMessageController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<OrderMessage> Get()
        {
            return _handler.GetAllOrderMessages();
        }

        [HttpGet("{id}")]
        public OrderMessage Get(int id)
        {
            return _handler.OrderMessageDetails(id);
        }

        [HttpPost]
        public void Post(OrderMessage orderMessage)
        {
            if (ModelState.IsValid)
                _handler.AddOrderMessage(orderMessage);
        }

        [HttpPut]
        public void Put(OrderMessage orderMessage)
        {
            if (ModelState.IsValid)
                _handler.EditOrderMessage(orderMessage);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrderMessage(id);
        }
    }
}