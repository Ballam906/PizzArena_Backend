using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;

namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesItemController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public RendelesItemController(PizzArenadbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> RendelesItemLekerdezes()
        {
            try
            {
                var rendelesitem = await _context.Rendeles_Termek.ToListAsync();
                return Ok(new { message = "Sikeres lekérdezés", result = rendelesitem });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpPost]
        public async Task<ActionResult> RendelesItemHozzaadas(RendelesItemLetrehozas rendelesitemletrehozas)
        {
            try
            {
                var rendelesitem = new Rendeles_Termek
                {
                    DbAr = rendelesitemletrehozas.DbAr,
                    Darab = rendelesitemletrehozas.Darab,
                    Rendeles_Id = rendelesitemletrehozas.Rendeles_Id,
                    Termek_Id = rendelesitemletrehozas.Termek_Id
                };
                if (rendelesitem != null)
                {
                    await _context.Rendeles_Termek.AddAsync(rendelesitem);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres hozzáadás", result = rendelesitem });
                }
                return Ok(new { message = "Sikertelen hozzáadás", result = rendelesitem });
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

    }
}
