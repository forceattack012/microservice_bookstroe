using Bookstore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Bookstore.Domain.Entities.Order order)
        {
            await _orderRepository.CreateOrder(order);
            return StatusCode((int)HttpStatusCode.Created, "successful");
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> CreateOrder(long customerId)
        {
            var order = await _orderRepository.GetOrderByCustomerId(customerId);
            if(order == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "order not found");
            }

            return StatusCode((int)HttpStatusCode.OK, order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if(order == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "order not found");
            }

            return StatusCode((int)HttpStatusCode.OK, "delete sucessful");
        }
    }
}
