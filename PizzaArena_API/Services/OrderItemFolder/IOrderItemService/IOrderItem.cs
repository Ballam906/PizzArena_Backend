using PizzaArena_API.Services.OrderItemFolder.Dtos;

namespace PizzaArena_API.Services.OrderItemFolder.IOrderItemService
{
    public interface IOrderItem
    {
        Task<object> GetAllOrderItems(); 
        Task<object> GetItemsByOrderId(int orderId); 
        Task<object> AddOrderItem(OrderItemDto.OrderItemAddDto newitem);
        Task<object> DeleteOrderItem(int id);
        Task<object> UpdateOrderItem(int id, OrderItemDto.OrderItemUpdateDto upitem);
    }
}
