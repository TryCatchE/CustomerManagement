using CustomerManagement.Data;
using CustomerManagement.Interfaces;
using CustomerManagement.Models;
using CustomerManagement.Models.DTOs.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService service;
        private string UserId
        {
            get => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier && x.ValueType != "JSON_NULL")?.Value;
        }

        public CustomersController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await service.GetCustomers(UserId);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await service.GetCustomer(id, UserId);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> SetCustomer([FromBody] CustomerAddModel customer)
        {
            try
            {
               await  service.AddCustomer(customer, UserId);
                return Ok(new
                {
                    Message="Hello!!"
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    
                    Message = ex.Message
                });

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateModel customer)
        {
            await service.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await service.DeleteCustomer(id, UserId);
            return Ok();
        }
    }
}
