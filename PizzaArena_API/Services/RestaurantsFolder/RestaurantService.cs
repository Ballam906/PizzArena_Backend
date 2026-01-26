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

        public async Task<object> AddRestaurant(RestaDto.RestaurantDto dto)
        {
            var newRestaurant = new Restaurant
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                OpeningHours = dto.OpeningHours,
                Address = dto.Address
            };

            _context.restaurants.Add(newRestaurant);
            await _context.SaveChangesAsync();

            return new { result = newRestaurant, message = "Étterem sikeresen hozzáadva." };
        }

        public async Task<object> DeleteRestaurant(int id)
        {
            var restaurant = await _context.restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return new { result = "", message = "Étterem nem található a törléshez." };
            }

            _context.restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return new { result = "", message = "Étterem sikeresen törölve." };
        }

        public async Task<object> GetAllRestaurants()
        {
            var restaurants = await _context.restaurants.ToListAsync();
            return new { result = restaurants, message = "Éttermek sikeresen lekérve." };
        }

        public async Task<object> GetRestaurantById(int id)
        {
            var restaurant = await _context.restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return new { result = "", message = "Étterem nem található." };
            }
            return new { result = restaurant, message = "Étterem megtalálva." };
        }

        public async Task<object> UpdateRestaurant(int id, RestaDto.RestaurantDto dto)
        {
            var restaurant = await _context.restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return new { result = "", message = "Nem található az étterem a módosításhoz." };
            }

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.ImageUrl = dto.ImageUrl;
            restaurant.OpeningHours = dto.OpeningHours;
            restaurant.Address = dto.Address;

            _context.restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return new { result = restaurant, message = "Étterem sikeresen frissítve." };
        }
    }
}
