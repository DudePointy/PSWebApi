using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PaymentStatusController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public PaymentStatusController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<PaymentStatus> Get()
        {
            return _handler.GetAllPaymentStatuses();
        }

        [HttpGet("{id}")]
        public PaymentStatus Get(int id)
        {
            return _handler.PaymentStatusDetails(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post(PaymentStatus payment)
        {
            if (ModelState.IsValid)
                _handler.AddPaymentStatus(payment);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(PaymentStatus payment)
        {
            if (ModelState.IsValid)
                _handler.EditPaymentStatus(payment);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeletePaymentStatus(id);
        }
    }
}