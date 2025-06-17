using Dal.models;
using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductDal : IDal.IDalProduct
    {
        CrownBeefContext db;
        public ProductDal(CrownBeefContext db)
        {
            this.db = db;
        }
        public async Task<List<Dto.ProductDto>> SelectAllAsync()
        {
            var product = await db.Products.ToListAsync();
            return Converters.ProductConverters.ToListProductDto(product);
        }
        public async Task<List<ProductDto>> SelectProductById(short id)
        {
            var products = await db.Products.Where(prod => prod.CategoryCode == id).Take(10).ToListAsync();
            if (products.Count == 0)
                return null;

            var productDtos = Dal.Converters.ProductConverters.ToListProductDto(products);
            return productDtos;
        }

    }
}
