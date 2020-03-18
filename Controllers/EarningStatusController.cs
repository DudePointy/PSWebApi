using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningStatusController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public EarningStatusController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<EarningStatus> Get()
        {
            return _handler.GetAllEarningStatus();
        }

        [HttpGet("{id}")]
        public EarningStatus Get(int id)
        {
            return _handler.EarningStatusDetails(id);
        }

        [HttpPost]
        public void Post(EarningStatus earningStatus)
        {
            if (ModelState.IsValid)
                _handler.AddEarningStatus(earningStatus);
        }

        [HttpPut]
        public void Put(EarningStatus earningStatus)
        {
            if (ModelState.IsValid)
                _handler.EditEarningStatus(earningStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteEarningStatus(id);
        }
    }
}