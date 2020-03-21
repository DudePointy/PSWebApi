﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Moderator, Service Provider")]

    public class OrderAttachmentController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public OrderAttachmentController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }
        [HttpGet]
        public ICollection<OrderAttachment> Get()
        {
            return _handler.GetAllOrderAttachment();
        }

        [HttpGet("{id}")]
        public OrderAttachment Get(int id)
        {
            return _handler.OrderAttachmentDetails(id);
        }

        [HttpPost]
        public void Post(OrderAttachment orderAttachment)
        {
            if (ModelState.IsValid)
                _handler.AddOrderAttachment(orderAttachment);
        }

        [HttpPut]
        public void Put(OrderAttachment orderAttachment)
        {
            if (ModelState.IsValid)
                _handler.EditOrderAttachment(orderAttachment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteOrderAttachment(id);
        }
    }
}