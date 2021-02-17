using System;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;

namespace SmileShop.API.DTOs.Product
{
    public class GetProductNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}