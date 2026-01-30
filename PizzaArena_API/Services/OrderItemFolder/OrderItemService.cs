using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderItemFolder.Dtos;
using PizzaArena_API.Services.OrderItemFolder.IOrderItemService;

namespace PizzaArena_API.Services.OrderItemFolder
{
    public class OrderItemService :IOrderItem
    {
        private readonly PizzArenaDbContext _context;

        public OrderItemService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<object> AddOrderItem(OrderItemDto.OrderItemAddDto newitem)
        {
            var item = new Order_Item
            {
                ItemPrice = newitem.ItemPrice,
                Piece = newitem.Piece,
                Order_Id = newitem.Order_Id,
                Item_Id = newitem.Item_Id
            };

            _context.order_items.Add(item);
            await _context.SaveChangesAsync();

            return new { result = item, message = "Tétel hozzáadva a rendeléshez." };
        }

        public async Task<object> DeleteOrderItem(int id)
        {
            var item = await _context.order_items.FirstOrDefaultAsync(x => x.Id == id);

            if (item != null)
            {
                _context.order_items.Remove(item);
                await _context.SaveChangesAsync();
                return new { message = "Rendelési tétel törölve." };
            }

            return new { message = "Nincs ilyen tétel." };
        }

        public async Task<object> GetAllOrderItems()
        {
            return await _context.order_items
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<object> GetItemsByOrderId(int orderId)
        {
            var items = await _context.order_items
                .Include(x => x.Product)
                .Where(x => x.Order_Id == orderId)
                .ToListAsync();

            if (items.Any())
            {
                return items;
            }

            return new { message = "Ehhez a rendeléshez nincsenek tételek." };
        }

        public async Task<object> UpdateOrderItem(int id, OrderItemDto.OrderItemUpdateDto upitem)
        {
            var item = await _context.order_items.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return new { message = "Módosítani kívánt tétel nem létezik!" };
            }

            item.ItemPrice = upitem.ItemPrice;
            item.Piece = upitem.Piece;

            _context.order_items.Update(item);
            await _context.SaveChangesAsync();

            return new { result = item, message = "Tétel sikeresen frissítve." };
        }
    }
}
