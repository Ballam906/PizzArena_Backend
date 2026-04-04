using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChefSpecial>>> GetAll() =>
        Ok(await _chefSepcial.ChefGetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<ChefSpecial>> GetById(int id)
        {
            var res = await _chefSepcial.ChefGetById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ChefSpecial>> Add(ChefDto.ChefAddDto dto) =>
            Ok(await _chefSepcial.ChefAdd(dto));


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<ChefSpecial>> Modify(ChefDto.ChefModDto dto)
        {
            var res = await _chefSepcial.ChefModify(dto);
            return res == null ? NotFound() : Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _chefSepcial.ChefDelete(id);
            return success ? Ok(new { message = "Séf ajánlata törölve." }) : NotFound();
        }
    }
}
