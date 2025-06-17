using Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrownBeef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IBll.IBllProduct Product;
        public ProductController(IBll.IBllProduct product)
        {
            this.Product = product;

        }
        [HttpGet]
        public async Task<List<Dto.ProductDto>> GetAsync()
        {
            return await Product.SelectAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<List<ProductDto>> GetAsync(short id)
        {
            return await Product.SelectProductById(id);
        }
        [HttpGet("price")]
        public async Task<List<ProductDto>> GetAsync([FromQuery] short categoryCode, [FromQuery] short? min = null, [FromQuery] short? max = null)
        {
            return await Product.SelectProductByPriceAsync(categoryCode, min, max);
        }

    }
}
