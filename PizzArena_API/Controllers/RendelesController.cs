using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public RendelesController(PizzArenadbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> RendelesLekerdezes()
        {
            try
            {
                var rendelesek = await _context.Rendelesek.ToListAsync();
                return Ok(new { message = "Sikeres lekérdezés", result = rendelesek });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> RendelesHozzaadas(RendelesLetrehozas rendelesletrehozas)
        {
            try
            {
                var rendeles = new Rendeles
                {
                    Nev = rendelesletrehozas.Nev,
                    VasarloTelszam = rendelesletrehozas.VasarloTelszam,
                    SzallitasiCim = rendelesletrehozas.SzallitasiCim,
                    Felhasznalo_Id = rendelesletrehozas.Felhasznalo_Id
                };
                if (rendeles != null)
                {
                    await _context.Rendelesek.AddAsync(rendeles);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres hozzáadás", result = rendeles });
                }
                return Ok(new { message = "Sikertelen hozzáadás", result = rendeles });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new
                {
                    message = ex.InnerException?.Message ?? ex.Message,
                    result = ""
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> RendelesLEID(int id)
        {
            try
            {
                var rendeles = await _context.Rendelesek.FirstOrDefaultAsync(x => x.Id == id);
                if (rendeles != null)
                {
                    return Ok(new { messaege = "Sikeres lekérdezés", result = rendeles });
                }
                return NotFound(new { message = "Sikertelen lekérdezés", result = rendeles });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> RendelesFrissites(int id, RendelesFrissites rendelesFrissites)
        {
            try
            {
                var rendeles = await _context.Rendelesek.FirstOrDefaultAsync(x => x.Id == id);
                if (rendeles != null)
                {
                    rendeles.Nev = rendelesFrissites.Nev;
                    rendeles.VasarloTelszam = rendelesFrissites.VasarloTelszam;
                    rendeles.SzallitasiCim = rendelesFrissites.SzallitasiCim;


                    _context.Rendelesek.Update(rendeles);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Sikeres frisítés." });
                }

                return NotFound(new { message = "Nincs mit frissíteni!" });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RendelesTorles(int id)
        {
            try
            {
                var rendeles = await _context.Rendelesek.FirstOrDefaultAsync(x => x.Id == id);
                if (rendeles != null)
                {
                    _context.Rendelesek.Remove(rendeles);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Sikeres törlés." });
                }
                return NotFound(new { message = "Nincs mit törölni!" });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }
    }
}
