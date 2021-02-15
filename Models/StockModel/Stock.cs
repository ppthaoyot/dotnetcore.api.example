using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmileShop.API.Models.ProductGroupModel;
using SmileShop.API.Models.ProductModel;

namespace SmileShop.API.Models.StockModel
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int AmountBefore { get; set; }

        [Required]
        public int AmountEdit { get; set; }

        [Required]
        public int AmountAfter { get; set; }
        public string Remark { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

    }
}