using Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrownBeef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletePurchaseController : Controller
    {
        private readonly IBll.IBllCompletePurchase bll;

        public CompletePurchaseController(IBll.IBllCompletePurchase bll)
        {
            this.bll = bll;
        }

        [HttpPost]
        public async Task<int> PostAsync([FromBody] CompletePurchaseDto completePurchaseDto)
        {
            return await bll.AddCompletePurchaseAsync(completePurchaseDto);
        }
    }
}

