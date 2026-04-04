using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ProductFolder.Dtos;
using PizzaArena_API.Services.RestaurantsFolder;
using PizzaArena_API.Services.RestaurantsFolder.Dtos;
using PizzaArena_API.Services.RestaurantsFolder.IRestaurantsService;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurants _irestaurant;

        public RestaurantController(IRestaurants irestaurant)
        {
            _irestaurant = irestaurant;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurant()
        {
            return Ok(await _irestaurant.GetAllRestaurants());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetById(int id)
        {
            var res = await _irestaurant.GetRestaurantById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<Restaurant>> Add(RestaDto.RestaurantDto dto)
        {
            return Ok(await _irestaurant.AddRestaurant(dto));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<Restaurant>> Modify(RestaDto.RestaurantUpdateDto dto)
        {
            var res = await _irestaurant.UpdateRestaurant(dto);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _irestaurant.DeleteRestaurant(id);
            return success ? Ok(new { message = "Étterem sikeresen törölve." }) : NotFound();
        }
    }
}
