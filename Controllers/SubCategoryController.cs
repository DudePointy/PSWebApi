using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post(SubCategory subCategory)
        {
            if (ModelState.IsValid)
                _handler.AddSubCategory(subCategory);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(SubCategory subCategory)
        {
            if (ModelState.IsValid)
                _handler.EditSubCategory(subCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteSubCategory(id);
        }
    }
}