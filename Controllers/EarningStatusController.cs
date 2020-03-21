using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Authorize(Roles = "Admin")]
        public void Post(EarningStatus earningStatus)
        {
            if (ModelState.IsValid)
                _handler.AddEarningStatus(earningStatus);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(EarningStatus earningStatus)
        {
            if (ModelState.IsValid)
                _handler.EditEarningStatus(earningStatus);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _handler.DeleteEarningStatus(id);
        }
    }
}