using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ContractStatusController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ContractStatusController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<ContractStatus> Get()
        {
            return _handler.GetAllContractStatuses();

        }

        [HttpGet("{id}")]
        public ContractStatus Get(int id)
        {
            return _handler.ContractStatusDetails(id);

        }

        [HttpPost]
        public void Post(ContractStatus contractStatus)
        {
            if (ModelState.IsValid)
                _handler.AddContractStatus(contractStatus);
        }

        [HttpPut]

        public void Put(ContractStatus contractStatus)
        {
            if (ModelState.IsValid)
                _handler.EditContractStatus(contractStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteContractStatus(id);
        }
    }
}