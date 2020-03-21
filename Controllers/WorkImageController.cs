﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkImageController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly PointyHandler _handler;

        public WorkImageController(ApplicationDbContext context)
        {
            this.context = context;
            _handler = new PointyHandler(this.context);
        }

        [HttpGet]
        public ICollection<WorkImage> Get()
        {
            return _handler.GetAllWorkImages();
        }

        [HttpGet("{id}")]
        public WorkImage Get(int id)
        {
            return _handler.WorkImageDetails(id);
        }
        [Authorize(Roles = "Service Provider")]
        [HttpPost]
        public void Post(WorkImage workImage)
        {
            if (ModelState.IsValid)
                _handler.AddWorkImage(workImage);
        }

        [HttpPut]
        [Authorize(Roles = "Service Provider")]
        public void Put(WorkImage workImage)
        {
            if (ModelState.IsValid)
                _handler.EditWorkImage(workImage);
        }

        [Authorize(Roles = "Service Provider")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _handler.DeleteWorkImages(id);
        }
    }
}