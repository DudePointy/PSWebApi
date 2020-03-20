using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public PaymentController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<Payment> Get()
        {
            return _handler.GetAllPayments();
        }

        [HttpGet("{id}")]
        public Payment Get(int id)
        {
            return _handler.PaymentDetails(id);
        }

        [HttpPost]
        public void Post(Payment payment)
        {
            if (ModelState.IsValid)
                _handler.AddPayment(payment);
        }

        [HttpPut]
        public void Put(Payment payment)
        {
            if (ModelState.IsValid)
                _handler.EditPayment(payment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeletePayment(id);
        }
    }
}