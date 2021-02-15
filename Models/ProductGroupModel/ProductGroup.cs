using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmileShop.API.Models.ProductModel;

namespace SmileShop.API.Models.ProductGroupModel
{

    [Table("ProductGroup")]
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public Guid UpdatedById { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool isActive { get; set; }
        public List<Product> Products { get; set; }
    }
}
