using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderItemFolder;
using PizzaArena_API.Services.OrderItemFolder.Dtos;
using PizzaArena_API.Services.OrderItemFolder.IOrderItemService;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItem _orderItem;

        public OrderItemController(IOrderItem orderItem)
        {
            _orderItem = orderItem;
        }

        [Authorize]
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItemDto.OrderItemResponseDto>>> GetByOrder(int orderId)
        {
            var items = await _orderItem.GetItemsByOrderId(orderId);
            return Ok(items);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Item>> GetById(int id)
        {
            var item = await _orderItem.GetById(id);
            if (item == null) return NotFound($"Az {id} azonosítójú tétel nem található.");
            return Ok(item);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Order_Item>> AddItem([FromBody] OrderItemDto.OrderItemAddDto newItem)
        {
            if (newItem == null) return BadRequest("Hibás adatok.");

            var result = await _orderItem.AddItem(newItem);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/quantity")]
        public async Task<ActionResult> UpdateQuantity(int id, [FromBody] int newQuantity)
        {
            if (newQuantity <= 0) return BadRequest("A mennyiségnek pozitív egész számnak kell lennie.");

            var result = await _orderItem.UpdateQuantity(id, newQuantity);
            if (result == null) return NotFound("A módosítani kívánt tétel nem található.");

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var success = await _orderItem.DeleteItem(id);
            if (!success) return NotFound("A törölni kívánt tétel nem található.");

            return Ok(new { message = "Tétel sikeresen törölve." });
        }

    }
}
