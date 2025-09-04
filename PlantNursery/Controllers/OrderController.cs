using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DTO.OrderDto;

namespace PlantNursery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        //GET api/orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<OrderResponseDto>>> GetOrdersByUserId(int userId)
        {
            if (userId < 0)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {
                var orders = await _orderService.GetOrdersByUserId(userId);
                if (orders == null || orders.Count == 0)
                {
                    return NotFound("No orders found for the specified user.");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        //POST api/orders
        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is required.");
            }
            try
            {
                var createdOrder = await _orderService.CreateOrder(orderDto);
                return CreatedAtAction(nameof(CreateOrder), new { id = createdOrder.Id }, createdOrder);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE api/orders/{orderId}
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            if (orderId <= 0)
            {
                return BadRequest("Invalid order ID.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var deletedOrder = await _orderService.DeleteOrder(orderId);
                if (deletedOrder == null)
                {
                    return NotFound("Order not found.");
                }
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
