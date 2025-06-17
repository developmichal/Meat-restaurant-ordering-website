using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDalProduct : IDal.IDal<Dto.ProductDto>
    {
        public Task<List<ProductDto>> SelectProductById(short id);

    }

}
