using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _irestaurant.GetAllRestaurants();
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var res = await _irestaurant.GetRestaurantById(id);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Add(RestaDto.RestaurantDto dto)
        {
            var res = await _irestaurant.AddRestaurant(dto);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> Update(int id, RestaDto.RestaurantDto dto)
        {
            var res = await _irestaurant.UpdateRestaurant(id, dto);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _irestaurant.DeleteRestaurant(id);
            return Ok(res);
        }
    }
}
