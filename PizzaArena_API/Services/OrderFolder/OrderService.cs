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

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.orders.Include(o => o.Restaurant).OrderByDescending(o => o.OrderTime).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string userId)
        {
            return await _context.orders.Where(o => o.User_Id == userId).OrderByDescending(o => o.OrderTime).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetUserOrdersWithItems(string userId)
        {
            return await _context.orders.Include(o => o.OrderItems).Where(o => o.User_Id == userId).OrderByDescending(o => o.OrderTime).ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.orders .Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> AddOrder(OrderDto.OrderAddDto neworder)
        {
            var order = new Order
            {
                User_Id = neworder.UserId,
                OrderTime = DateTime.Now,
                Status = OrderStatus.New,
                CustomerName = neworder.CustomerName,
                CustomerEmail = neworder.CustomerEmail,
                CustomerPhone = neworder.CustomerPhone,
                PostalCode = neworder.PostalCode,
                City = neworder.City,
                Street = neworder.Street,
                Other = neworder.Other,
                RestaurantId = neworder.RestaurantId,
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order == null) return false;

            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order?> UpdateOrder(int id, OrderDto.UpdateOrderDto uporder)
        {
            var order = await _context.orders.FindAsync(id);
            if (order == null) return null;

            order.CustomerName = uporder.CustomerName;
            order.CustomerEmail = uporder.CustomerEmail;
            order.CustomerPhone = uporder.CustomerPhone;
            order.PostalCode = uporder.PostalCode;
            order.City = uporder.City;
            order.Street = uporder.Street;
            order.Other = uporder.Other;
            order.Status = uporder.Status;
            order.RestaurantId = uporder.RestaurantId;

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = await _context.orders.FindAsync(id);
            if (order == null) return null;

            order.Status = status;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> CreateFullOrder(OrderCreateRequest request)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                PostalCode = request.PostalCode,
                City = request.City,
                Street = request.Street,
                Other = request.Other,
                User_Id = request.UserId,
                RestaurantId = request.RestaurantId,
                OrderTime = DateTime.Now,
                Status = OrderStatus.New,
                OrderItems = request.Items.Select(i => new Order_Item
                {
                    Item_Id = i.ProductId,
                    Piece = i.Piece,
                    ItemPrice = i.ItemPrice
                }).ToList()
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
