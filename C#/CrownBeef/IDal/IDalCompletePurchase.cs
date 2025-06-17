using Dto;

namespace IDal
{
    public interface IDalCompletePurchase
    {
        Task<int> AddCompletePurchaseAsync(CompletePurchaseDto completePurchaseDto);
    }
}
