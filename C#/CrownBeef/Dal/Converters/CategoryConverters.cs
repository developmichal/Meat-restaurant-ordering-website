using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class CategoryConverters
    {
        public static Dto.CategoryDto ToCategoryDto(Dal.models.Category category)
        {
            Dto.CategoryDto newCategory = new Dto.CategoryDto();
            newCategory.CategoryCode = category.CategoryCode;
            newCategory.CategoryName = category.CategoryName;
            return newCategory;
        }

        public static List<Dto.CategoryDto> ToListCategoryDto(List<Dal.models.Category> listCategoryDto)
        {
            List<Dto.CategoryDto> newlistCategory = new List<Dto.CategoryDto>();
            foreach (Dal.models.Category category in listCategoryDto)
            {
                newlistCategory.Add(ToCategoryDto(category));
            }
            return newlistCategory;
            ;
        }

        public static Dal.models.Category ToCategory(Dto.CategoryDto category)
        {
            Dal.models.Category newCategory = new Dal.models.Category();
            newCategory.CategoryName = category.CategoryName;
            return newCategory;
        }

        internal static List<CategoryDto> ToListCategoryDto()
        {
            throw new NotImplementedException();
        }
    }
}
