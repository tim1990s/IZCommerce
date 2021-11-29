using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class Product
    {
        [Column("ProductId")]
        public int ProductId { get; set; }
        
        [MaxLength(50)]
        public string SKU { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductDescription { get; set; }
        
        public int QuantityPerUnit { get; set; }

        [MaxLength(20)]
        public string UnitSize { get; set; }
        
        public double MSRP { get; set; }
        
        [MaxLength(50)]
        public string AvailableSize { get; set; }

        [MaxLength(50)]
        public string AvailableColors { get; set; }
        
        public int SizeID { get; set; }
        
        public int ColorID { get; set; }
        
        public double Discount { get; set; }
        
        public double UnitWeight { get; set; }
        
        public int UnitsInStock { get; set; }
        
        public int UnitsOnOrder { get; set; }
        
        public int ReorderLevel { get; set; }
        
        public bool ProductAvailable { get; set; }
        
        public bool DiscountAvailable { get; set; }
        
        public bool CurrentOrder { get; set; }

        [MaxLength(100)]
        public string Picture { get; set; }
        
        public string Ranking { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
