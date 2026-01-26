using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Services.GlobalSettingsFolder.Dtos;
using PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService;

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
        public async Task<ActionResult> Get()
        {
            var res = await _globalsettings.GetSettings();
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Update(GlobalSettingsDto.GlobalDto dto)
        {
            var res = await _globalsettings.UpdateSettings(dto);
            return Ok(res);
        }
    }
}
