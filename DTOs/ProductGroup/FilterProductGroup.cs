namespace SmileShop.API.DTOs.ProductGroup
{
    public class FilterProductGroup : PaginationDto
    {
        public string Name { get; set; }

        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;
    }
}