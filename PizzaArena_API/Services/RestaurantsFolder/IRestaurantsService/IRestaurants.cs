using PizzaArena_API.Models;
using static PizzaArena_API.Services.RestaurantsFolder.Dtos.RestaDto;
namespace PizzaArena_API.Services.RestaurantsFolder.IRestaurantsService
{
    public interface IRestaurants
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();

        Task<Restaurant?> GetRestaurantById(int id);

        Task<Restaurant> AddRestaurant(RestaurantDto dto);

        Task<Restaurant?> UpdateRestaurant(int id,RestaurantUpdateDto dto);

        Task<bool> DeleteRestaurant(int id);
    }
}
