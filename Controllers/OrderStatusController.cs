using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class OrderStatusController : ControllerBase
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
            if (ModelState.IsValid)
                _handler.AddOrderStatus(orderStatus);
        }

        [HttpPut]
        public void Put(OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
                _handler.EditOrderStatus(orderStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrderStatus(id);
        }
    }
}