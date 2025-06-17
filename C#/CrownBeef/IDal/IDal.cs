using Dto;

namespace IDal
{

    public interface IDal<T>
    {
        public Task<List<T>> SelectAllAsync();
    }

}
