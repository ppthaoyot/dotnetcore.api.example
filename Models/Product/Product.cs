using System;
using System.ComponentModel.DataAnnotations;

namespace SmileShop.API.Models.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool isActive { get; set; }

        public int ProductGroupId { get; set; }
        public Models.ProductGroup.ProductGroup ProductGroup { get; set; }
    }
}