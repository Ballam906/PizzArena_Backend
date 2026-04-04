using PizzaArena_API.Models;
using PizzaArena_API.Services.CategoryFolder.Dtos;
using static PizzaArena_API.Services.ChefSpecialFolder.Dtos.ChefDto;

namespace PizzaArena_API.Services.CategoryFolder.ICategoryService
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category?> GetCategoryById(int id);
        Task<Category> CategoryAdd(CategoryDto.CreateCategoryDto dto);
        Task<Category?> CategoryModify(int id, CategoryDto.UpdateCategoryDto dto);
        Task<bool> CategoryDelete(int id);
    }
}
