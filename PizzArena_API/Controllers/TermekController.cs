using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public TermekController(PizzArenadbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetTermek()
        {
            try
            {
                return Ok(new { message = "Sikeres lekérdezés", result = await _context.termekek.ToListAsync() });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> TermekLetrehozas(TermekLetrehozasDto Termek)
        {
            try
            {
                var termek = new Termek
                {
                    Nev = Termek.Nev,
                    Leiras = Termek.Leiras,
                    Ar = Termek.Ar,
                    Kategoria_Id = Termek.Kategoria_Id,
                    Kep_Url = Termek.Kep_Url
                };

                if (termek != null)
                {
                    await _context.termekek.AddAsync(termek);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres felvétel", result = termek });
                }
                return NotFound(new { message = "Sikertlen felvétel", result = termek });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpGet("{id}")]

        public async Task<ActionResult> TermekLekID(int id)
        {
            try
            {
                
                var termek = await _context.termekek.FirstOrDefaultAsync(x => x.Id == id);
                if (termek != null)
                {
                    return Ok(new { messaege = "Sikeres lekérdezés", result = termek });
                }
                return NotFound(new { message = "Sikertelen lekérdezés", result = termek });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpPut]

        public async Task<ActionResult> TermekFrissites(int id, TermekFrissitesDto termekfrissites)
        {
            try
            {
                var meglevotermek = await _context.termekek.FirstOrDefaultAsync(x => x.Id == id);
                if (meglevotermek != null)
                {
                    meglevotermek.Ar = termekfrissites.Ar;
                    meglevotermek.Nev = termekfrissites.Nev;
                    meglevotermek.Leiras = termekfrissites.Leiras;
                    meglevotermek.ModIdo = termekfrissites.ModIdo;
                    meglevotermek.Kategoria_Id = termekfrissites.Kategoria_Id;
                    meglevotermek.Kep_Url = termekfrissites.Kep_Url;

                    _context.termekek.Update(meglevotermek);
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

        public async Task<ActionResult> TermekTorles(int id)
        {
            try
            {
                var termek = await _context.termekek.FirstOrDefaultAsync(x => x.Id == id);
                if (termek != null)
                {
                    _context.termekek.Remove(termek);
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
