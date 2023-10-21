using CustomerManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesControler : ControllerBase
    {
        //put x --> 1 address
        //delete customer --> id.address
        //get customerid --> all addresses
        private readonly IAddressService service;

        public AddressesControler(IAddressService service)
        {
            this.service = service;
        }
        private string UserId
        {
            get => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier && x.ValueType != "JSON_NULL")?.Value;
        }




    }
}
