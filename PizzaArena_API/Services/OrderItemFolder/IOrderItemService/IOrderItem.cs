using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderItemFolder.Dtos;

namespace PizzaArena_API.Services.OrderItemFolder.IOrderItemService
{
    public interface IOrderItem
    {
        Task<IEnumerable<OrderItemDto.OrderItemResponseDto>> GetItemsByOrderId(int orderId);

        Task<Order_Item> AddItem(OrderItemDto.OrderItemAddDto newItem);

        Task<Order_Item?> GetById(int id);

        Task<Order_Item?> UpdateQuantity(int id, int newQuantity);

        Task<bool> DeleteItem(int id);
    }
}
