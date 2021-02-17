using System;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;

namespace SmileShop.API.DTOs.ProductGroup
{
    public class RemoveProductGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}