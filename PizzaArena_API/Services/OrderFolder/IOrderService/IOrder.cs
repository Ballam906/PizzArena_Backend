using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderFolder.Dtos;
using static PizzaArena_API.Services.ProductFolder.Dtos.ProductDto;

namespace PizzaArena_API.Services.OrderFolder.IOrderService
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrders();

        Task<IEnumerable<Order>> GetUserOrders(string userId);

        Task<IEnumerable<Order>> GetUserOrdersWithItems(string userId);

        Task<Order?> GetOrderById(int id);

        Task<Order> CreateFullOrder(OrderCreateRequest request);

        Task<Order> AddOrder(OrderDto.OrderAddDto neworder);

        Task<bool> DeleteOrder(int id);

        Task<Order?> UpdateOrder(int id, OrderDto.UpdateOrderDto uporder);

        Task<Order?> UpdateOrderStatus(int id, OrderStatus status);
    }
}
