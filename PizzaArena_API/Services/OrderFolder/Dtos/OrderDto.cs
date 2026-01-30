namespace PizzaArena_API.Services.OrderFolder.Dtos
{
    public class OrderDto
    {
        public record OrderAddDto(
            string customerName,
            string customerEmail,
            string customerPhone,
            string postalCode,
            string city,
            string street,
            string other,
            string userid
        );

        public record UpdateOrderDto(
            string customerName,
            string customerEmail,
            string customerPhone,
            string postalCode,
            string city,
            string street,
            string other,
            string userid
        );
    }
}
