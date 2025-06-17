using Dto;
using IBll;

namespace Bll
{
    public class CategoryBll: IBll.IBllServices<Dto.CategoryDto>
    {
        IDal.IDal<Dto.CategoryDto> dalC;
        public CategoryBll(IDal.IDal<Dto.CategoryDto> category)
        {
            this.dalC = category;
        }
        public async Task<List<Dto.CategoryDto>> SelectAllAsync()
        {
  
            return await dalC.SelectAllAsync();
        }

    }
}
