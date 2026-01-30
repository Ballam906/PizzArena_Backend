using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuristaAPI.Dtos;
using TuristaAPI.Models;

namespace TuristaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuravezetoController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public TuravezetoController(TuristadbContext context)
        {
            _context = context;
        }

        [HttpPut("modosit")]
        public async Task<ActionResult> Modosit(int id, TuravezetoModDto mod)
        {
            var vane = await _context.Turavezetos.FirstOrDefaultAsync(x => x.Id == id);
            if (vane == null)
            {
                return NotFound("Nem azonosítható túravezető");
            }

            vane.Email = mod.Email;
            vane.Nev = mod.Nev;
            vane.Telefon = mod.Telefon;
            vane.Minosites = mod.Minosites;

            _context.Turavezetos.Update(vane);
            await _context.SaveChangesAsync();

            return Ok(vane);    
        }

        [HttpDelete("torol/{id}")]
        public async Task<IActionResult> DeleteTuravezeto(int id)
        {
            var turavezeto = await _context.Turavezetos.FindAsync(id);

            if (turavezeto == null)
            {
                return NotFound("Nincs megfelelő túravezető!");
            }

            _context.Turavezetos.Remove(turavezeto);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Túravezető sikeresen törölve." });
        }
    }
}
