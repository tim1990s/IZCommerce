using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class Supplier
    {
        [Column("SupplierId")]
        public int SupplierId { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string ContactFName { get; set; }

        [MaxLength(50)]
        public string ContactLName { get; set; }

        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [MaxLength(60)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }
        
        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(25)]
        public string State { get; set; }

        [MaxLength(15)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }

        [MaxLength(25)]
        public string Fax { get; set; }

        [MaxLength(75)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string WebSite { get; set; }

        [MaxLength(100)]
        public string PaymentMethods { get; set; }
        
        public string DiscountType { get; set; }
        
        public double DiscountRate { get; set; }

        [MaxLength(255)]
        public string TypeGoods { get; set; }
        
        public bool DiscountAvailable { get; set; }
        
        public bool CurrentOrder { get; set; }

        [MaxLength(50)]
        public string CustomerID { get; set; }

        [MaxLength(100)]
        public string SizeURL { get; set; }

        [MaxLength(100)]
        public string Logo { get; set; }

        [MaxLength(75)]
        public int Ranking { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
