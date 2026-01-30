using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuristaAPI.Models;

namespace TuristaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuraController : ControllerBase
    {
        private readonly TuristadbContext _context;

        public TuraController(TuristadbContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            var turak = await _context.Turas.ToListAsync();
            return Ok(turak);
        }

        [HttpGet("ById")]
        public async Task<ActionResult> GetById(int id)
        {
            var vane = await _context.Turas.Include(x => x.Turavezeto).Select(x => new {x.Id,x.Idopont,vezeto = x.Turavezeto.Nev, x.Koltseg }).FirstOrDefaultAsync(x => x.Id == id);
            if (vane == null)
            {
                return NotFound("Hiányzó túra!");
            }

            return Ok(vane);
        }
    }
}
