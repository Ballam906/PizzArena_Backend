using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Services.ChefSpecialFolder.Dtos;
using PizzaArena_API.Services.ChefSpecialFolder.IChefService;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefSpecialController : ControllerBase
    {
        private readonly IChefSepcial _chefSepcial;

        public ChefSpecialController(IChefSepcial chefSepcial)
        {
            _chefSepcial = chefSepcial;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _chefSepcial.ChefGetAll();
            return Ok(res);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var res = await _chefSepcial.ChefGetById(id);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Add(ChefDto.ChefAddDto chefAddDto)
        {
            var res = await _chefSepcial.ChefAdd(chefAddDto);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> Modify(ChefDto.ChefModDto chefModDto)
        {
            var res = await _chefSepcial.ChefModify(chefModDto);
            return Ok(res);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _chefSepcial.ChefDelete(id);
            return Ok(res);
        }
    }
}
