using static PizzaArena_API.Services.ChefSpecialFolder.Dtos.ChefDto;

namespace PizzaArena_API.Services.CategoryFolder.ICategoryService
{
    public interface ICategory
    {
        Task<object> CategoryAdd(string Name);
        Task<object> CategoryModify(int id, string Name);
        Task<object> CategoryDelete(int id);
        Task<object> GetCategoryById(int id);
        Task<object> GetAllCategory();
    }
}
