using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public void Post(Category category)
        {
            if (ModelState.IsValid)
                _handler.AddCategory(category);
        }

        [HttpPut]
        public void Put(Category category)
        {
            if (ModelState.IsValid)
                _handler.EditCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteCategory(id);
        }
    }
}
