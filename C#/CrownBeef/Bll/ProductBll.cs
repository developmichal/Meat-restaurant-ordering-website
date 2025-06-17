using Dto;
using IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ProductBll : IBll.IBllProduct
    {
        IDal.IDalProduct dalP;
        public ProductBll(IDal.IDalProduct product)
        {
            this.dalP = product;
        }
        public async Task<List<Dto.ProductDto>> SelectAllAsync()
        {

            return await dalP.SelectAllAsync();
        }

        public Task<List<ProductDto>> SelectProductById(short id)
        {
            return dalP.SelectProductById(id);
        }

        public async Task<List<Dto.ProductDto>> SelectProductByPriceAsync(short categoryCode, short? min, short? max)
        {
            var products = await SelectProductById(categoryCode);
            if (min != null)
                products = products.Where(p => p.Price >= min).ToList();
            if (max != null)
                products = products.Where(p => p.Price <= max).ToList();

            return products;
        }

    }
}

