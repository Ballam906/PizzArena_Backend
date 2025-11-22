using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetTermek()
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var termekek = context.termekek.ToList();
                    return Ok(new { message = "Sikeres lekérdezés", result = termekek });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }

        [HttpPost]
        public ActionResult TermekLetrehozas(TermekLetrehozasDto Termek)
        {
            try
            {
                using (var context = new PizzArenadbContext())
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
                        context.termekek.Add(termek);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres felvétel", result = termek });
                    }
                    return NotFound(new { message = "Sikertlen felvétel", result = termek });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult TermekLekID(int id)
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var termek = context.termekek.FirstOrDefault(x => x.Id == id);
                    if (termek != null)
                    {
                        return Ok(new { messaege = "Sikeres lekérdezés", result = termek });
                    }
                    return NotFound(new { message = "Sikertelen lekérdezés", result = termek });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }

        [HttpPut]
        public ActionResult TermekFrissites(int id, TermekFrissitesDto termekfrissites)
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var meglevotermek = context.termekek.FirstOrDefault(x => x.Id == id);
                    if (meglevotermek != null)
                    {
                        meglevotermek.Ar = termekfrissites.Ar;
                        meglevotermek.Nev = termekfrissites.Nev;
                        meglevotermek.Leiras = termekfrissites.Leiras;
                        meglevotermek.ModIdo = termekfrissites.ModIdo;
                        meglevotermek.Kategoria_Id = termekfrissites.Kategoria_Id;
                        meglevotermek.Kep_Url = termekfrissites.Kep_Url;

                        context.termekek.Update(meglevotermek);
                        context.SaveChanges();
                        return Ok(new { message = "Sikeres frisítés." });
                    }

                    return NotFound(new { message = "Nincs mit frissíteni!" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }

        [HttpDelete]
        public ActionResult TermekTorles(int id)
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var termek = context.termekek.FirstOrDefault(x => x.Id == id);
                    if (termek != null)
                    {
                        context.termekek.Remove(termek);
                        context.SaveChanges();
                        return Ok(new { message = "Sikeres törlés." });
                    }
                    return NotFound(new { message = "Nincs mit törölni!" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { messaege = ex.Message, result = "" });
            }
        }
    }
}
