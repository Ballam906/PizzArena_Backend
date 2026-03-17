namespace PizzaArena_API.Services.GlobalSettingsFolder.Dtos
{
    public class GlobalSettingsDto
    {
        public record GlobalDto(
            string ContactEmail,
            string DeliveryTime,
            string FacebookUrl,
            string InstagramUrl
        );
    }
}
