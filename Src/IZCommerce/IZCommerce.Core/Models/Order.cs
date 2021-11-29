using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZCommerce.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime dateTime { get; set; }


        public DateTime RequiredDate { get; set; }

        public string Freight { get; set; }

        public double SalesTax { get; set; }

        public DateTime Timestamp { get; set; }

        public int TransacStatus { get; set; }

        public string Errlog { get; set; }

        public string ErrMsg { get; set; }

        public string FullFilled { get; set; }

        public bool Deleted { get; set; }

        public double Paid { get; set; }

        public DateTime PaymentDate { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Payment))]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey(nameof(Shipper))]
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}
