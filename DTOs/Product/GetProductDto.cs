using System;

namespace SmileShop.API.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public int ProductGroupId { get; set; }

    }
}