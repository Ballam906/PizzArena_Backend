using static PizzaArena_API.Services.RestaurantsFolder.Dtos.RestaDto;
namespace PizzaArena_API.Services.RestaurantsFolder.IRestaurantsService
{
    public interface IRestaurants
    {
        Task<object> GetAllRestaurants();

        Task<object> GetRestaurantById(int id);

        Task<object> AddRestaurant(RestaurantDto dto);

        Task<object> UpdateRestaurant(int id, RestaurantDto dto);

        Task<object> DeleteRestaurant(int id);
    }
}
