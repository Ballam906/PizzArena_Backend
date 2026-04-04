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

        public async Task<ChefSpecial> ChefAdd(ChefDto.ChefAddDto chefadd)
        {
            var special = new ChefSpecial
            {
                ProductId = chefadd.ProductId,
                CustomNote = chefadd.CustomNote,
            };

            _context.chefSpecials.Add(special);
            await _context.SaveChangesAsync();
            return special;

        }

        public async Task<bool> ChefDelete(int id)
        {
            var special = await _context.chefSpecials.FindAsync(id);
            if (special == null) return false;

            _context.chefSpecials.Remove(special);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ChefSpecial>> ChefGetAll()
        {
            return await _context.chefSpecials.Include(x => x.Product).ToListAsync();
        }

        public async Task<ChefSpecial?> ChefGetById(int id)
        {
            return await _context.chefSpecials.FindAsync(id);
        }

        public async Task<ChefSpecial?> ChefModify(ChefDto.ChefModDto chefmod)
        {
            var special = await _context.chefSpecials.FindAsync(chefmod.Id);
            if (special == null) return null;

            special.ProductId = chefmod.ProductId;
            special.CustomNote = chefmod.CustomNote;

            await _context.SaveChangesAsync();
            return special;
        }
    }
}
