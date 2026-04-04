using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.RestaurantsFolder.Dtos;
using PizzaArena_API.Services.RestaurantsFolder.IRestaurantsService;

namespace PizzaArena_API.Services.RestaurantsFolder
{
    public class RestaurantService : IRestaurants
    {
        private readonly PizzArenaDbContext _context;

        public RestaurantService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> AddRestaurant(RestaDto.RestaurantDto dto)
        {
            var restaurant = new Restaurant
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                OpeningHours = dto.OpeningHours,
                Address = dto.Address,
                ContactPhone = dto.ContactPhone,
            };

            _context.restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;


        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaurant = await _context.restaurants.FindAsync(id);
            if (restaurant == null) return false;
            _context.restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            return await _context.restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantById(int id)
        {
            return await _context.restaurants.FindAsync(id);
        }

        public async Task<Restaurant?> UpdateRestaurant(RestaDto.RestaurantUpdateDto dto)
        {
            var restaurant = await _context.restaurants.FindAsync(dto.Id);
            if (restaurant == null) return null;

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.ContactPhone = dto.ContactPhone;
            restaurant.Address = dto.Address;
            restaurant.OpeningHours = dto.OpeningHours;
            restaurant.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return restaurant;
        }
    }
}
