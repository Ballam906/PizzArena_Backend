using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
using PizzaArena_API.Services.GlobalSettingsFolder.Dtos;
using PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService;
using static PizzaArena_API.Services.GlobalSettingsFolder.Dtos.GlobalSettingsDto;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalSettingsController : ControllerBase
    {
        private readonly IGlobalSettings _globalsettings;

        public GlobalSettingsController(IGlobalSettings globalsettings)
        {
            _globalsettings = globalsettings;
        }

        [HttpGet]
        public async Task<ActionResult<GlobalSettings>> Get()
        {
            var settings = await _globalsettings.GetSettings();
            if (settings == null) return NotFound("A beállítások még nincsenek inicializálva.");
            return Ok(settings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<GlobalSettings>> Update([FromBody] GlobalDto dto)
        {
            var result = await _globalsettings.UpdateSettings(dto);
            return Ok(result);
        }
    }
}
