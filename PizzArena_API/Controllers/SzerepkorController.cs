using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;
using System.Security.Policy;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzerepkorController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public SzerepkorController(PizzArenadbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> SzerepkorLetrehozas(SzerepkorLetrehozas szerepkorletrehozas)
        {
            try
            {
                var szerepkor = new Szerepkor
                {
                    Nev = szerepkorletrehozas.Nev,
                };

                if (szerepkor != null)
                {
                    await _context.Szerepkorok.AddAsync(szerepkor);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres felvétel", result = szerepkor });
                }

                return NotFound(new { message = "Sikertlen felvétel", result = szerepkor });

            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> SzerepkorLekerdezes()
        {
            try
            {
                var szerepkorok = await _context.Szerepkorok.ToListAsync();
                return Ok(new { message = "Sikeres lekérdezés", result = szerepkorok });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

    }
}
