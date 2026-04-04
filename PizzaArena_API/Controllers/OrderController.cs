using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
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

        [Authorize]
        [HttpPost("FullOrder")]
        public async Task<ActionResult<Order>> AddFullOrder([FromBody] OrderCreateRequest request)
        {
            if (request == null || request.Items == null || !request.Items.Any())
            {
                return BadRequest("A rendelés nem tartalmaz tételeket vagy hibás az adat.");
            }

            try
            {
                var result = await _order.CreateFullOrder(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt a rendelés mentésekor: {ex.Message}");
            }
        }



        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateStatus(int id, OrderDto.UpdateOrderStatusDto updorder)
        {
            if (updorder == null) return BadRequest("Nem érkezett adat.");

            var result = await _order.UpdateOrderStatus(id, updorder.Status);
            if (result == null) return NotFound("A rendelés nem található.");

            return Ok(result);
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

            return Ok(await _order.GetUserOrders(userId));
        }

        [HttpGet("MyOrdersWithItems")]
         [Authorize]
        public async Task<ActionResult> GetMyOrdersItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            return Ok(await _order.GetUserOrdersWithItems(userId));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _order.GetOrderById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await _order.DeleteOrder(id);
            if (!result) return NotFound();
            return Ok(new { message = "Törlés sikeres" });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrder(OrderDto.OrderAddDto order)
        {
            var result = await _order.AddOrder(order);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateOrder(int id, OrderDto.UpdateOrderDto updorder)
        {
            var result = await _order.UpdateOrder(id, updorder);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
