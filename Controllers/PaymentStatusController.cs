using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public void Post(PaymentStatus payment)
        {
            if (ModelState.IsValid)
                _handler.AddPaymentStatus(payment);
        }

        [HttpPut]
        public void Put(PaymentStatus payment)
        {
            if (ModelState.IsValid)
                _handler.EditPaymentStatus(payment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeletePaymentStatus(id);
        }
    }
}