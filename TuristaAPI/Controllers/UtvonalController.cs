using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuristaAPI.Models;
using TuristaAPI.Dtos;

namespace TuristaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtvonalController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public UtvonalController(TuristadbContext context)
        {
            _context = context;
        }

        [HttpPost("uj")]
        public async Task<ActionResult> AddNew(UtvonalUjDto uj)
        {
            var utvonal = new Utvonal
            {
                Allomasok = uj.Allomasok,
                Tav = uj.Tav,
                Szint = uj.Szint,
                NehezsegId = uj.NehezsegId
            };
            try
            {
                _context.Utvonals.Add(utvonal);
                await _context.SaveChangesAsync();
                return Ok("Sikeres mentés");
            }
            catch (Exception)
            {

                return StatusCode(400, "Hiba a mentés során.");
            }
            
        }
    }
}
