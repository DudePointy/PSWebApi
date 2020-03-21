using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<Order> Get()
        {
            return _handler.GetAllOrders();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _handler.OrderDetails(id);
        }

        [HttpPost]
        public void Post(Order order)
        {
            if (ModelState.IsValid)
                _handler.AddOrder(order);
        }

        [HttpPut]
        public void Put(Order order)
        {
            if (ModelState.IsValid)
                _handler.EditOrder(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrder(id);
        }
    }
}
