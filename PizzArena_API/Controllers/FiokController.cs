using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzArena_API.Models;
using PizzArena_API.Models.Dtos;
using System.Text;
using System.Security.Cryptography;


namespace PizzArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiokController : ControllerBase
    {
        private readonly PizzArenadbContext _context;
        public FiokController(PizzArenadbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetFiok()
        {
            try
            {
                var fiokok = await _context.Fiokok
                    .Include(f => f.Szerepkor)
                    .Select(f => new
                    {
                        f.Id,
                        f.Felhasznalonev,
                        f.Email,
                        f.Jelszo,
                        f.RegisztracioIdeje,
                        f.SzerepkorId,
                        Szerepkor = f.Szerepkor.Nev
                    })
                    .ToListAsync();
                return Ok(new { message = "Sikeres lekérdezés", result = fiokok });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpPost]
        public async Task<ActionResult> FiokLetrehozas(FiokLetrehozas fiokletrehozas)
        {
            try
            {
                string hashJelszo = HashPasswordSHA256(fiokletrehozas.Jelszo);

                var fiok = new Fiok
                {
                    Felhasznalonev = fiokletrehozas.Felhasznalonev,
                    Email = fiokletrehozas.Email,
                    Jelszo = hashJelszo,
                    SzerepkorId = fiokletrehozas.SzerepkorId
                };

                if (fiok != null)
                {
                    await _context.Fiokok.AddAsync(fiok);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new { message = "Sikeres felvétel", result = fiok });
                }
                return NotFound(new { message = "Sikertlen felvétel", result = fiok });

            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FiokGETID(Guid id)
        {
            try
            {
                var fiok = await _context.Fiokok.Include(f => f.Szerepkor).Select(f => new
                {
                    f.Id,
                    f.Felhasznalonev,
                    f.Email,
                    f.Jelszo,
                    f.RegisztracioIdeje,
                    f.SzerepkorId,
                    Szerepkor = f.Szerepkor.Nev
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (fiok != null)
                {
                    return Ok(new { messaege = "Sikeres lekérdezés", result = fiok });
                }
                return NotFound(new { message = "Sikertelen lekérdezés", result = fiok });
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpPut]
        public async Task<ActionResult> FiokFrissites(Guid id, FiokFrissites fiokfrissites)
        {
            try
            {
                var fiok = await _context.Fiokok.FirstOrDefaultAsync(x => x.Id == id);
                if (fiok != null)
                {
                    fiok.Email = fiokfrissites.Email;
                    fiok.Felhasznalonev = fiokfrissites.Felhasznalonev;
                    fiok.Jelszo = fiokfrissites.Jelszo;
                    fiok.SzerepkorId = fiokfrissites.SzerepkorId;

                    _context.Fiokok.Update(fiok);
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
        public async Task<ActionResult> FiokTorles(Guid id)
        {
            try
            {
                var fiok = await _context.Fiokok.FirstOrDefaultAsync(x => x.Id == id);
                if (fiok != null)
                {
                    _context.Fiokok.Remove(fiok);
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



        [HttpPost("loginadmin")]
        public async Task<ActionResult> Login(FiokLogin login)
        {
            try
            {
                string hashJelszo = HashPasswordSHA256(login.Jelszo);

                var fiok = await _context.Fiokok
                    .Include(f => f.Szerepkor)
                    .FirstOrDefaultAsync(f =>
                        f.Felhasznalonev == login.Felhasznalonev &&
                        f.Jelszo == hashJelszo);

                if (fiok == null)
                {
                    return Unauthorized(new { message = "Hibás felhasználónév vagy jelszó" });
                }

                if (fiok.Szerepkor.Nev != "Admin")
                    return Unauthorized(new { message = "Csak admin felhasználó léphet be" });

                return Ok(new
                {
                    message = "Sikeres bejelentkezés",
                    result = new
                    {
                        fiok.Id,
                        fiok.Felhasznalonev,
                        fiok.Email,
                        Szerepkor = fiok.Szerepkor.Nev
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost("regisztracioadmin")]
        public async Task<ActionResult> Regisztracio(FiokRegisztracio regisztracio)
        {
            try
            {

                string hashJelszo = HashPasswordSHA256(regisztracio.Jelszo);

                var adminSzerepkor = await _context.Szerepkorok
                    .FirstOrDefaultAsync(s => s.Nev == "Admin");

                if (adminSzerepkor == null)
                    throw new Exception("Admin szerepkör nem található.");

                var fiok = new Fiok
                {
                    Felhasznalonev = regisztracio.Felhasznalonev,
                    Email = regisztracio.Email,
                    Jelszo = hashJelszo,
                    SzerepkorId = adminSzerepkor.Id,
                    Szerepkor = adminSzerepkor
                };

                if (fiok != null)
                {
                    await _context.Fiokok.AddAsync(fiok);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, new {
                        message = "Sikeres felvétel",
                        result = new
                        {
                            fiok.Id,
                            fiok.Felhasznalonev,
                            fiok.Email,
                            Szerepkor = adminSzerepkor.Nev  // nem kell új betöltés
                        }
                    });
                }
                return NotFound(new { message = "Sikertlen felvétel", result = fiok });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }



        private string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                // Régebbi .NET kompatibilis hex string előállítás
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

    }
}
