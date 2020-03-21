using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _handler.GetAllCategories();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _handler.CategoryDetails(id);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public void Post(Category category)
        {
            if (ModelState.IsValid)
                _handler.AddCategory(category);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(Category category)
        {
            if (ModelState.IsValid)
                _handler.EditCategory(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteCategory(id);
        }
    }
}
