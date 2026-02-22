using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _product.GetProducts();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _product.GetProductById(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _product.DeleteProduct(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDto.ProductAddDto product)
        {
            var result = await _product.AddProduct(product);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id,ProductDto.ProductUpdateDto updproduct)
        {
            var result = await _product.UpdateProduct(id, updproduct);
            return Ok(result);
        }

    }
}
