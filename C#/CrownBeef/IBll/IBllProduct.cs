using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface IBllProduct : IBllServices<Dto.ProductDto>
    {
        Task<List<ProductDto>> SelectProductById(short id);
        Task<List<Dto.ProductDto>> SelectProductByPriceAsync(short categoryCode, short? min, short? max);
    }
}
