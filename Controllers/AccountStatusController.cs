using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountStatusController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public AccountStatusController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }


        [HttpGet]
        public ICollection<AccountStatus> Get()
        {
            return _handler.GetAllAccountStatuses();
        }

        [HttpGet("{id}")]
        public AccountStatus Get(int id)
        {
            return _handler.AccountStatusDetails(id);
        }

        [HttpPost]
        public void Post(AccountStatus accountStatus)
        {
            if (ModelState.IsValid)
                _handler.AddAccountStatus(accountStatus);
        }

        [HttpPut]
        public void Put(AccountStatus accountStatus)
        {
            if (ModelState.IsValid)
                _handler.EditAccountStatus(accountStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteAccountStatus(id);
        }
    }
}