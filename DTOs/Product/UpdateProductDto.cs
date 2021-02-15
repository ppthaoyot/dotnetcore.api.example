namespace SmileShop.API.DTOs.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int ProductGroupId { get; set; }
        public bool isActive { get; set; }
    }
}