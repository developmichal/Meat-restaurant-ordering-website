using Dto;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CrownBeef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        IBll.IBllCustomer c;
        public CustomerController(IBll.IBllCustomer c)
        {
            this.c = c;

        }
        [HttpGet]
        public async Task<List<Dto.CustomerDto>> GetAsync()
        {
            return await c.SelectAllAsync();
        }

        [HttpPost]
        public async Task<Dto.CustomerDto> PostAsync([FromBody] CustomerDto customerDto)
        {
            return await c.AddCustomerAsync(customerDto);
        }
        [HttpGet("{email}")]
        public async Task<Dto.CustomerDto> GetAsync(string email)
        {
            return await c.SelectById(email);
        }
    }
}
