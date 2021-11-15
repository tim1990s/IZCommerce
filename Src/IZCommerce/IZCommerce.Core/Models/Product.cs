using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        public string SKU { get; set; }
        
        public string SupplierProductID { get; set; }
        
        public string ProductName { get; set; }
        
        public string ProductDescription { get; set; }
        
        public int SupplierID { get; set; }
        
        public int CategoryID { get; set; }
        
        public int QuantityPerUnit { get; set; }
        
        public string UnitSize { get; set; }
        
        public double MSRP { get; set; }
        
        public string AvailableSize { get; set; }
        
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
        
        public string Picture { get; set; }
        
        public string Ranking { get; set; }

        public string Note { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
