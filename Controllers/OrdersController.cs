using CustomerManagement.Interfaces;
using CustomerManagement.Models.DTOs.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await service.GetOrderById(id);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            var orders = await service.GetOrdersById(customerId);
            return Ok(orders);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDetailsModel order)
        {
            await service.UpdateOrder(order);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SetOrder([FromBody] OrderDetailsModel order)
        {
            await service.AddOrder(order);
            return Ok();
        }
    }
}
