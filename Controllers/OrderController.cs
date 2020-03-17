using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet("{id}")]
        public ICollection<Order> Get()
        {
            return _handler.GetAllOrders();
        }

        [HttpGet]
        public Order Get(int id)
        {
            return _handler.OrderDetails(id);
        }

        [HttpPost]
        public void Post(Order order)
        {
            _handler.AddOrder(order);
        }

        [HttpPut]
        public void Put(Order order)
        {
            _handler.EditOrder(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrder(id);
        }
    }
}
