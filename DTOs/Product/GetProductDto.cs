using System;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;

namespace SmileShop.API.DTOs.Product
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto UpdatedBy { get; set; }
        public GetProductGroupNameDto ProductGroup { get; set; }

    }
}