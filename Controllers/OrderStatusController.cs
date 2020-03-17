using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public OrderStatusController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<OrderStatus> Get()
        {
            return _handler.GetAllOrderStatuses();
        }

        [HttpGet("{id}")]
        public OrderStatus Get(int id)
        {
            return _handler.OrderStatusDetails(id);
        }

        [HttpPost]
        public void Post(OrderStatus orderStatus)
        {
            _handler.AddOrderStatus(orderStatus);
        }

        [HttpPut]
        public void Put(OrderStatus orderStatus)
        {
            _handler.EditOrderStatus(orderStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrderStatus(id);
        }
    }
}