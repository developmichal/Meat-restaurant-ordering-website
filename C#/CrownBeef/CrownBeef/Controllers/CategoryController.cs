using Microsoft.AspNetCore.Mvc;

namespace CrownBeef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        IBll.IBllServices<Dto.CategoryDto> c;
        public CategoryController(IBll.IBllServices<Dto.CategoryDto> c)
        {
            this.c = c;

        }
        [HttpGet]
        public async Task<List<Dto.CategoryDto>> GetAsync()
        {
            //Bll_Services.CoursesBll c = new Bll_Services.CoursesBll();
            return await c.SelectAllAsync();
        }
    }
}
