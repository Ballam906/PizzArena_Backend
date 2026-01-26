using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ChefSpecialFolder.Dtos;
using PizzaArena_API.Services.ChefSpecialFolder.IChefService;

namespace PizzaArena_API.Services.ChefSpecialFolder
{
    public class ChefSpecialService : IChefSepcial
    {
        private readonly PizzArenaDbContext _context;

        public ChefSpecialService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<object> ChefAdd(ChefDto.ChefAddDto chefadd)
        {
            var product = await _context.products.FindAsync(chefadd.ProductId);
            if (product == null)
            {
                return new { result = "", Message = "A megadott termék nem létezik." };
            }

            var newchefspecial = new ChefSpecial
            {
                ProductId = chefadd.ProductId,
                CustomNote = chefadd.CustomNote
            };

            _context.chefSpecials.Add(newchefspecial);

            await _context.SaveChangesAsync();

            return new {result =  newchefspecial, message = "Sikeres hozzáadás"};
        }

        public async Task<object> ChefDelete(int id)
        {
            var chefspecial = await _context.chefSpecials.FindAsync(id);
            if (chefspecial == null)
            {
                return new { result = "", message = "Nincs ilyen Chef Special" };
            }

            _context.chefSpecials.Remove(chefspecial);
            await _context.SaveChangesAsync();

            return new { result = "", message = "Sikeres törlés" };
        }

        public async Task<object> ChefGetAll()
        {
            var chefspecials = await _context.chefSpecials
                .Include(x => x.Product)
                .ToListAsync();

            return new { result = chefspecials, message = "Sikeres lekérdezés" };
        }

        public async Task<object> ChefGetById(int id)
        {
            var chefspecial = await _context.chefSpecials
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (chefspecial == null)
            {
                return new { result = "", message = "Nincs ilyen Chef Special" };
            }

            return new { result = chefspecial, message = "Sikeres lekérdezés" };
        }

        public async Task<object> ChefModify(ChefDto.ChefModDto chefmod)
        {
            var chefspecial = await _context.chefSpecials.FindAsync(chefmod.Id);
            if (chefspecial == null)
            {
                return new { result = "", message = "Nincs ilyen Chef Special" };
            }

            chefspecial.ProductId = chefmod.ProductId;
            chefspecial.CustomNote = chefmod.CustomNote;

            await _context.SaveChangesAsync();

            return new { result = chefspecial, message = "Sikeres módosítás" };
        }
    }
}
