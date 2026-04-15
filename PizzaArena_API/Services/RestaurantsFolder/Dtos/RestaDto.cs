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

        public record RestaurantUpdateDto
        {
            public string Name { get; init; }
            public string Description { get; init; }
            public string ImageUrl { get; init; }
            public string OpeningHours { get; init; }
            public string Address { get; init; }
            public string ContactPhone { get; init; }
        }
    }
}
