using Dal.models;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class ProductConverters
    {
        public static Dto.ProductDto ToProductDto(Dal.models.Product product)
        {
            Dto.ProductDto newProduct = new Dto.ProductDto();
            newProduct.ProductCode = product.ProductCode;
            newProduct.ProductName = product.ProductName;
            newProduct.ProductDescription = product.ProductDescription;
            newProduct.Price = product.Price;
            newProduct.Picture = product.Picture;
            newProduct.QuantityInStock = product.QuantityInStock;
            newProduct.LastUpdateDate = product.LastUpdateDate.ToString("yyyy-MM-dd");
            newProduct.CategoryCode = product.CategoryCode;
            return newProduct;
        }

        public static List<Dto.ProductDto> ToListProductDto(List<Dal.models.Product> listProductDto)
        {
            List<Dto.ProductDto> newlistProduct = new List<Dto.ProductDto>();
            foreach (Dal.models.Product product in listProductDto)
            {
                newlistProduct.Add(ToProductDto(product));
            }
            return newlistProduct;
            ;
        }

        public static Dal.models.Product ToProduct(Dto.ProductDto product)
        {
            Dal.models.Product newProduct = new Dal.models.Product();
            newProduct.ProductName = product.ProductName;
            newProduct.ProductDescription = product.ProductDescription;
            newProduct.Price = product.Price;
            newProduct.Picture = product.Picture;
            newProduct.QuantityInStock = product.QuantityInStock;
            newProduct.LastUpdateDate = DateOnly.ParseExact(product.LastUpdateDate, "yyyy-MM-dd"); ;
            newProduct.CategoryCode = product.CategoryCode;
            return newProduct;
        }

    }
}
