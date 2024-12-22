using AutoMapper;
using BlogApp.API.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        BlogAppDbContext _db;
        private readonly IMapper _mapper;

        public CategoriesController(BlogAppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetAction(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryDto category)
        {
            var newCategory = _mapper.Map<Category>(category);

            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newCategory);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound("Category movcud deyil");
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCategoryDto dto)
        {
            var category = _db.Categories.AsNoTracking().FirstOrDefault(c=>c.Id == dto.Id);
            if (category == null)
            {
                return NotFound("Category Movcud deyil");
            }
            category = _mapper.Map<Category>(dto);
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
