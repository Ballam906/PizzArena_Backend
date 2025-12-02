using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public KategoriaController(PizzArenadbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult> GetKategoriak()
        {
            try
            {
                var kategoriak = await _context.kategoriak.Include(x => x.Termekek).ToListAsync();
                return Ok(new { message = "Sikeres lekérdezés", result = kategoriak });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpPost]

        public async Task<ActionResult> KategoriaLetrehozas(string nev)
        {
            try
            {
                var kategoria = new Kategoria
                {
                    Nev = nev
                };

                if (kategoria != null)
                {
                    _context.kategoriak.Add(kategoria);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres hozzáadás", result = kategoria });
                }

                return Ok(new { message = "Sikertelen hozzáadás", result = kategoria });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> KategoriaLEKID(int id)
        {
            try
            {
                var kategoria = await _context.kategoriak.FirstOrDefaultAsync(x => x.Id == id);
                if (kategoria != null)
                {
                    return Ok(new { messaege = "Sikeres lekérdezés", result = kategoria });
                }
                return NotFound(new { message = "Sikertelen lekérdezés", result = kategoria });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpGet("KategoriaTermekekkel")]
        public async Task<ActionResult> KategoriaTermekekkel(int id)
        {
            try
            {
                var kategoria = await _context.kategoriak
                    .Include(u => u.Termekek)
                    .FirstOrDefaultAsync(x => x.Id == id);


                if (kategoria != null)
                {
                    return Ok(new { messaege = "Sikeres lekérdezés", result = kategoria });
                }
                return NotFound(new { message = "Sikertelen lekérdezés", result = kategoria });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> KategoriaFrissites(int id, KategoriaFrissites kategoriaFrissites)
        {
            try
            {
                var meglevokategoria = await _context.kategoriak.FirstOrDefaultAsync(x => x.Id == id);
                if (meglevokategoria != null)
                {
                    meglevokategoria.Nev = kategoriaFrissites.Nev;

                    _context.kategoriak.Update(meglevokategoria);
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
        public async Task<ActionResult> KategoriaTorles(int id)
        {
            try
            {
                var kategoria = await _context.kategoriak.FirstOrDefaultAsync(x => x.Id == id);
                if (kategoria != null)
                {
                    _context.kategoriak.Remove(kategoria);
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
