using System;
using System.Collections.Generic;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Models;

namespace SmileShop.API.DTOs.ProductGroup
{
    public class GetProductGroupFilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto UpdatedBy { get; set; }
    }
}