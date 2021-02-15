using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmileShop.API.Models.ProductGroupModel;

namespace SmileShop.API.Models.ProductModel
{
    [Table("Product")]
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
        public Guid CreatedById { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]

        public Guid UpdatedById { get; set; }
        [Required]

        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool isActive { get; set; }
        [Required]
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}