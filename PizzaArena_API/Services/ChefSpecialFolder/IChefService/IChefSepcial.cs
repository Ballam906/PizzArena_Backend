using PizzaArena_API.Models;
using static PizzaArena_API.Services.ChefSpecialFolder.Dtos.ChefDto;

namespace PizzaArena_API.Services.ChefSpecialFolder.IChefService
{
    public interface IChefSepcial
    {
        Task<ChefSpecial> ChefAdd(ChefAddDto chefadd);
        Task<ChefSpecial?> ChefModify(ChefModDto chefmod);
        Task<bool> ChefDelete(int id);
        Task<ChefSpecial?> ChefGetById(int id);
        Task<IEnumerable<ChefSpecial>> ChefGetAll();
    }
}
