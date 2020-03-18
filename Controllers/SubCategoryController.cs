using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public SubCategoryController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<SubCategory> Get()
        {
            return _handler.GetAllSubCategories();
        }

        [HttpGet("{id}")]
        public SubCategory Get(int id)
        {
            return _handler.SubCategoryDetails(id);
        }

        [HttpPost]
        public void Post(SubCategory subCategory)
        {
            if (ModelState.IsValid)
                _handler.AddSubCategory(subCategory);
        }

        [HttpPut]
        public void Put(SubCategory subCategory)
        {
            if (ModelState.IsValid)
                _handler.EditSubCategory(subCategory);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteSubCategory(id);
        }
    }
}