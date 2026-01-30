using PizzaArena_API.Services.OrderFolder.Dtos;
using static PizzaArena_API.Services.ProductFolder.Dtos.ProductDto;

namespace PizzaArena_API.Services.OrderFolder.IOrderService
{
    public interface IOrder
    {
        Task<object> GetOrders();
        Task<object> GetUserOrders(string userId);
        Task<object> GetOrderById(int id);
        Task<object> AddOrder(OrderDto.OrderAddDto neworder);
        Task<object> DeleteOrder(int id);
        Task<object> UpdateOrder(int id, OrderDto.UpdateOrderDto uporder);
    }
}
