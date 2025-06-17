namespace Dto
{
    public class CompletePurchaseDto
    {
        public CustomerDto CurrentUser { get; set; }
        public short PurchaseCode { get; set; }
        public int PurchaseAmount { get; set; }
        public string Note { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
