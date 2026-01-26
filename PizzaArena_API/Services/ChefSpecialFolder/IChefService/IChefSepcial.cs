using static PizzaArena_API.Services.ChefSpecialFolder.Dtos.ChefDto;

namespace PizzaArena_API.Services.ChefSpecialFolder.IChefService
{
    public interface IChefSepcial
    {
        Task<object> ChefAdd(ChefAddDto chefadd);
        Task<object> ChefModify(ChefModDto chefmod);
        Task<object> ChefDelete(int id);
        Task<object> ChefGetById(int id);
        Task<object> ChefGetAll();
    }
}
