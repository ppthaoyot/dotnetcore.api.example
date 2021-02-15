namespace SmileShop.API.DTOs.Product
{
    public class FilterProduct : PaginationDto
    {

        public string Name { get; set; }

        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;
    }
}