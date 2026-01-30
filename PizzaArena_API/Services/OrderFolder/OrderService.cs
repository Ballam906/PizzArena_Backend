using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderFolder.Dtos;
using PizzaArena_API.Services.OrderFolder.IOrderService;

namespace PizzaArena_API.Services.OrderFolder
{
    public class OrderService : IOrder
    {
        private readonly PizzArenaDbContext _context;

        public OrderService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<object> AddOrder(OrderDto.OrderAddDto neworder)
        {
            var order = new Order
            {
                User_Id = neworder.userid,
                OrderTime = DateTime.Now,
                CustomerName = neworder.customerName,
                CustomerEmail = neworder.customerEmail,
                CustomerPhone = neworder.customerPhone,
                PostalCode = neworder.postalCode,
                City = neworder.city,
                Street = neworder.street,
                Other = neworder.other
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return new { result = order, message = "Rendelés sikeresen létrehozva" };
        }

        public async Task<object> DeleteOrder(int id)
        {
            var order = await _context.orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null) return new { message = "Nincs ilyen rendelés" };

            var items = await _context.order_items.Where(x => x.Order_Id == id).ToListAsync();
            if (items.Any())
            {
                _context.order_items.RemoveRange(items); 
            }

            _context.orders.Remove(order);

            await _context.SaveChangesAsync();

            return new { message = "Rendelés és a hozzá tartozó tételek sikeresen törölve" };
        }

        public async Task<object> GetOrderById(int id)
        {
            var vane = await _context.orders.FirstOrDefaultAsync(x => x.Id == id);
            if (vane != null)
            {
                return vane;
            }

            return new { message = "Nincs ilyen rendelés" };
        }

        public async Task<object> GetOrders()
        {
            var orders = await _context.orders.ToListAsync();
            return orders;
        }

        public async Task<object> GetUserOrders(string userId)
        {
            var userOrders = await _context.orders
                .Where(x => x.User_Id == userId)
                .ToListAsync();

            if (userOrders.Any())
            {
                return userOrders;
            }

            return new { message = "Ennek a felhasználónak még nincs rendelése." };
        }

        public async Task<object> UpdateOrder(int id, OrderDto.UpdateOrderDto uporder)
        {
            var vane = await _context.orders.FirstOrDefaultAsync(x => x.Id == id);
            if (vane == null)
            {
                return new { message = "Nincs ilyen rendelés!" };
            }

            vane.User_Id = uporder.userid;
            vane.CustomerPhone = uporder.customerPhone;
            vane.CustomerName = uporder.customerName;
            vane.CustomerEmail = uporder.customerEmail;
            vane.Street = uporder.street;
            vane.Other = uporder.other;
            vane.PostalCode = uporder.postalCode;
            vane.City = uporder.city;

            _context.orders.Update(vane);
            await _context.SaveChangesAsync();

            return new { result = vane, message = "Rendelés sikeresen frissítve" };
        }
    }
}
