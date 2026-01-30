using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Services.CategoryFolder;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _icategory.GetAllCategory();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _icategory.GetCategoryById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            var result = await _icategory.CategoryAdd(name);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] string name)
        {
            var result = await _icategory.CategoryModify(id, name);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _icategory.CategoryDelete(id);
            return Ok(result);
        }
    }
}
