namespace PizzaArena_API.Services.RestaurantsFolder.Dtos
{
    public class RestaDto
    {
        public record RestaurantDto(
            string Name,
            string Description,
            string ImageUrl,
            string OpeningHours,
            string Address,
            string ContactPhone
        );

        public record RestaurantUpdateDto(
            int Id,
            string Name,
            string Description,
            string ImageUrl,
            string OpeningHours,
            string Address,
            string ContactPhone
        );
    }
}
