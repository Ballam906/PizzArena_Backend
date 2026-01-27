using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.CategoryFolder.ICategoryService;
using System.Xml.Linq;

namespace PizzaArena_API.Services.CategoryFolder
{
    public class CategoryService : ICategory
    {
        private readonly PizzArenaDbContext _context;

        public CategoryService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<object> CategoryAdd(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new { result = "", message = "Nincs név megadva" };
            }

            var category = new Category
            {
                Name = Name,
            };

            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return new { result = category, message = "Új kategória hozzáadva." };
        }

        public async Task<object> CategoryDelete(int id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return new { result = "", message = "Nincs ilyen kategória." };
            }

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return new { result = "", message = "Sikeres törlés" };
        }

        public async Task<object> CategoryModify(int id, string Name)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return new { result = "", message = "Nincs ilyen kategória." };
            }

            if (string.IsNullOrEmpty(Name))
            {
                return new { result = "", message = "A megadott termék nem létezik." };
            }

            category.Name = Name;
            _context.categories.Update(category);
            await _context.SaveChangesAsync();

            return new { result = category, message = "Sikeres módosítás" };
        }

        public async Task<object> GetAllCategory()
        {
            var categories = await _context.categories.ToListAsync();

            return new { result = categories, message = "Sikeres lekérdezés" };
        }

        public async Task<object> GetCategoryById(int id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return new { result = "", message = "Nincs ilyen kategória" };
            }

            return new { result = category, message = "Sikeres lekérdezés" };
        }
    }
}
