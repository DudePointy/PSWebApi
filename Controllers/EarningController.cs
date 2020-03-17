using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningController
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public EarningController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }


        [HttpGet]
        public ICollection<Earnings> Get()
        {
            return _handler.GetAllEarnings();
        }

        [HttpGet("{id}")]
        public Earnings Get(int id)
        {
            return _handler.EarningDetails(id);
        }

        [HttpPost]
        public void Post(Earnings earnings)
        {
            _handler.AddEarnings(earnings);
        }

        [HttpPut]
        public void Put(Earnings earnings)
        {
            _handler.EditEarnings(earnings);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteEarnings(id);
        }
    }
}
