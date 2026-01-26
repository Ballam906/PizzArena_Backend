namespace PizzaArena_API.Services.GlobalSettingsFolder.Dtos
{
    public class GlobalSettingsDto
    {
        public record GlobalDto(
            string RestaurantName,
            string DeliveryTime,
            string FacebookUrl,
            string InstagramUrl
        );
    }
}
