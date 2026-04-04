using PizzaArena_API.Models;

namespace PizzaArena_API.Services.OrderFolder.Dtos
{
    public class OrderDto
    {
        public record OrderAddDto(
            string CustomerName,
            string CustomerEmail,
            string CustomerPhone,
            string PostalCode,
            string City,
            string Street,
            string Other,
            string UserId,
            int RestaurantId
        );

        
        public record UpdateOrderDto(
            string CustomerName,
            string CustomerEmail,
            string CustomerPhone,
            string PostalCode,
            string City,
            string Street,
            string Other,
            OrderStatus Status,
            int RestaurantId 
        );

        public record UpdateOrderStatusDto(
            OrderStatus Status
        );
    }
}
