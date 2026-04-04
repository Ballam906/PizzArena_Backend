using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
using PizzaArena_API.Services.CategoryFolder;
using PizzaArena_API.Services.CategoryFolder.Dtos;
using PizzaArena_API.Services.CategoryFolder.ICategoryService;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _icategory;

        public CategoryController(ICategory icategory)
        {
            _icategory = icategory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _icategory.GetAllCategory());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var result = await _icategory.GetCategoryById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> Create(CategoryDto.CreateCategoryDto dto)
        {
            var result = await _icategory.CategoryAdd(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> Update(int id, CategoryDto.UpdateCategoryDto dto)
        {
            var result = await _icategory.CategoryModify(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _icategory.CategoryDelete(id);
            if (!success) return NotFound();
            return Ok(new { message = "Kategória törölve." });
        }
    }
}
