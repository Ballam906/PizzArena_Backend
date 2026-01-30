using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Services.OrderFolder.Dtos;
using PizzaArena_API.Services.OrderFolder.IOrderService;
using System.Security.Claims;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _order.GetOrders();
            return Ok(result);
        }

        [HttpGet("MyOrders")]
        [Authorize]
        public async Task<ActionResult> GetMyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var result = await _order.GetUserOrders(userId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _order.GetOrderById(id);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await _order.DeleteOrder(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrder(OrderDto.OrderAddDto order)
        {

            var result = await _order.AddOrder(order);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOrder(int id, OrderDto.UpdateOrderDto updorder)
        {
            var result = await _order.UpdateOrder(id, updorder);
            return Ok(result);
        }

    }
}
