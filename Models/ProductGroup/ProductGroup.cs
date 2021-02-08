using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileShop.API.Models.ProductGroup
{
    [Table("ProductGroup")]
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool isActive { get; set; }

        public List<Models.Product.Product> Products { get; set; }
    }
}