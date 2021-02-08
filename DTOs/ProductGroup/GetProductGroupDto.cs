using System;
using System.Collections.Generic;
using SmileShop.API.DTOs.Product;

namespace SmileShop.API.DTOs.ProductGroup
{
    public class GetProductGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool isActive { get; set; }
        public List<GetProductDto> Products { get; set; }
    }
}