using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzArena_API.Models;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetKategoriak()
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var kategoriak = context.kategoriak.Include(x => x.Termekek).ToList();
                    return Ok(new { message = "Sikeres lekérdezés", result = kategoriak });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }

        [HttpPost]
        public ActionResult KategoriaLetrehozas(string nev)
        {
            try
            {
                using (var context = new PizzArenadbContext())
                {
                    var kategoria = new Kategoria
                    {
                        Nev = nev
                    };

                    if (kategoria != null)
                    {
                        context.kategoriak.Add(kategoria);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres hozzáadás", result = kategoria });
                    }

                    return Ok(new { message = "Sikertelen hozzáadás", result = kategoria });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }
    }
}
