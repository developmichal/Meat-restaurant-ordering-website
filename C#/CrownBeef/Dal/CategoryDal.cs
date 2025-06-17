
using Dal.models;
using Dto;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class CategoryDal : IDal.IDal<Dto.CategoryDto>
    {
        CrownBeefContext db;
        public CategoryDal(CrownBeefContext db)
        {
            this.db = db;
        }
        public async Task<List<Dto.CategoryDto>> SelectAllAsync()
        {
            var category = await db.Categories.ToListAsync();
            return Converters.CategoryConverters.ToListCategoryDto(category);
        }
    }
}