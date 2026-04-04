using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.CategoryFolder.Dtos;
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

        public async Task<Category> CategoryAdd(CategoryDto.CreateCategoryDto dto)
        {
            var category = new Category { Name = dto.Name };
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> CategoryDelete(int id)
        {
            var category = await _context.categories.FindAsync(id);
            if (category == null) return false;

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> CategoryModify(int id, CategoryDto.UpdateCategoryDto dto)
        {
            var category = await _context.categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            category.Name = dto.Name;
            await _context.SaveChangesAsync();
            return category;

        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.categories.FindAsync(id);
        }
    }
}
