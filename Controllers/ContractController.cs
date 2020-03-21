using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ContractController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public ContractController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<Contract> Get()
        {
            return _handler.GetAllContracts();
        }

        [HttpGet("{id}")]
        public Contract Get(int id)
        {
            return _handler.ContractDetails(id);
        }

        [HttpPost]
        public void Post(Contract contract)
        {
            if (ModelState.IsValid)
                _handler.AddContract(contract);
        }

        [HttpPut]
        public void Put(Contract contract)
        {
            if (ModelState.IsValid)
                _handler.EditContract(contract);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteContract(id);
        }
    }
}