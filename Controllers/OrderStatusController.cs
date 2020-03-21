using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [Authorize(Roles = "Admin")]
        public void Post(OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
                _handler.AddOrderStatus(orderStatus);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
                _handler.EditOrderStatus(orderStatus);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrderStatus(id);
        }
    }
}