using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController
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
            _handler.AddContract(contract);
        }

        [HttpPut]
        public void Put(Contract contract)
        {
            _handler.EditContract(contract);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteContract(id);
        }
    }
}