using System;
using System.Collections.Generic;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Models;

namespace SmileShop.API.DTOs.ProductGroup
{
    public class GetProductGroupNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}