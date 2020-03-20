using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private PointyHandler _handler;
        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _handler = new PointyHandler(context);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Register(user);
                return Ok(user);
            }
            return BadRequest(new { message = "Invalid Register request" });
        }

        public IActionResult Activation()
        {
            var currentUserId = int.Parse(User.Identity.Name);
            var user = _handler.UserDetails(currentUserId);
            user.AccountStatusId = _handler.GetAllAccountStatuses().First(c => c.Name.ToLower() == "activated").Id;
            _handler.EditUser(user);
            return Ok();

        }

        [HttpPut]
        public IActionResult Edit([FromBody]User user)
        {
            _handler.EditUser(user);
            return Ok();
        }
        //TODO [Authorize(Roles = )]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgetPassword([FromBody]string email)
        {
            var user = _userService.GetAll().Single(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                _userService.ChangePassword(email);
                return Ok();
            }

            return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole("Admin")) //TODO replace hard coded Role
                return Forbid();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
