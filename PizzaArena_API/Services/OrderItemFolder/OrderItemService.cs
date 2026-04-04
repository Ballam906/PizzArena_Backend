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

        public async Task<Order_Item?> GetById(int id)
        {
            return await _context.order_items
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<IEnumerable<Order_Item>> GetItemsByOrderId(int orderId)
        {
            return await _context.order_items
                .Include(oi => oi.Product)
                .Where(oi => oi.Order_Id == orderId)
                .ToListAsync();
        }

        public async Task<Order_Item> AddItem(OrderItemDto.OrderItemAddDto newItem)
        {
            var item = new Order_Item
            {
                Order_Id = newItem.Order_Id,
                Item_Id = newItem.Item_Id,
                Piece = newItem.Piece,
                ItemPrice = newItem.ItemPrice
            };

            _context.order_items.Add(item);
            await _context.SaveChangesAsync();

            await _context.Entry(item).Reference(i => i.Product).LoadAsync();
            return item;
        }

        public async Task<Order_Item?> UpdateQuantity(int id, int newQuantity)
        {
            var item = await _context.order_items.FindAsync(id);
            if (item == null) return null;

            item.Piece = newQuantity;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var item = await _context.order_items.FindAsync(id);
            if (item == null) return false;

            _context.order_items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
