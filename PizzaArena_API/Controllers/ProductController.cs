using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ChefSpecialFolder.Dtos;
using PizzaArena_API.Services.ChefSpecialFolder.IChefService;
using PizzaArena_API.Services.ProductFolder.Dtos;
using PizzaArena_API.Services.ProductFolder.IProductService;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            return Ok(await _product.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var res = await _product.GetProductById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> Add(ProductDto.ProductAddDto dto)
        {
            return Ok(await _product.AddProduct(dto));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<Product>> Modify(ProductDto.ProductUpdateDto dto)
        {
            var res = await _product.UpdateProduct(dto);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _product.DeleteProduct(id);
            return success ? Ok(new { message = "Termék sikeresen törölve." }) : NotFound();
        }

    }
}
